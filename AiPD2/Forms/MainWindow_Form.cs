using AiPD2.Audio;
using AiPD2.Models;
using ScottPlot.WinForms;

namespace AiPD2.Forms
{
    public partial class MainWindow_Form : Form
    {
        private const string WINDOW_NAME = "AiPD Projekt 2";
        private List<(FormsPlot, string)> Plots { get; set; } = new List<(FormsPlot, string)>();

        private Waveform? CurrentWaveform { get; set; }
        private AnalysisResult? CurrentAnalysisResult { get; set; }
        private AudioProcessingSettings CurrentAudioProcessingSettings { get; set; } = new AudioProcessingSettings();
        private VisualizationSettings CurrentVisualizationSettings { get; set; } = new VisualizationSettings();

        public MainWindow_Form()
        {
            InitializeComponent();

            Setup();
        }

        private void AnalyzeAudio()
        {
            if (CurrentWaveform == null) return;
            Cursor = Cursors.WaitCursor;
            CurrentAnalysisResult = AudioAnalyzer.Analyze(CurrentWaveform, CurrentAudioProcessingSettings);
            Cursor = Cursors.Default;

            SelectedFrame_NumericUpDown.Maximum = CurrentAnalysisResult.WindowedFrames.Length - 1;
        }

        #region SETUP
        private void Setup()
        {
            this.Text = WINDOW_NAME;
            SetupComboBoxes();
            SetupPlots();
            SetDefaults();
        }

        private void SetDefaults()
        {
            RemoveDCOffset_Checkbox.Checked = CurrentAudioProcessingSettings.RemoveDCOffset;
            Normalize_CheckBox.Checked = CurrentAudioProcessingSettings.Normalize;
            SelectedFrame_NumericUpDown.Value = CurrentVisualizationSettings.SelectedFrameIndex;
            HopSize_NumericUpDown.Value = CurrentAudioProcessingSettings.HopSize;
        }

        private void SetupComboBoxes()
        {
            FrameSize_ComboBox.Items.Clear();
            FrameSize_ComboBox.Items.AddRange(new object[] { 128, 256, 512, 1024, 2048 });
            FrameSize_ComboBox.SelectedIndex = 3;
            CurrentAudioProcessingSettings.FrameSize = (int)FrameSize_ComboBox.SelectedItem!;

            WindowType_ComboBox.Items.Clear();
            WindowType_ComboBox.Items.AddRange(Enum.GetValues(typeof(Windowing.WindowType)).Cast<object>().ToArray());
            WindowType_ComboBox.SelectedIndex = 0;
            CurrentAudioProcessingSettings.WindowType = (Windowing.WindowType)WindowType_ComboBox.SelectedItem!;
        }

        private void CreatePlotsList()
        {
            Plots.Add((WindowedWaveform_Plot, "Windowed waveform"));
            Plots.Add((FFTMagnitude_Plot, "Spectrum"));
            Plots.Add((Volume_Plot, "Volume"));
            Plots.Add((FrequencyCentroid_Plot, "Frequency Centroid"));
            Plots.Add((EffectiveBandwidth_Plot, "Effective Bandwidth"));
            Plots.Add((BandEnergy_Plot, "Band Energy"));
            Plots.Add((BandEnergyRatio_Plot, "Band Energy Ratio"));
            Plots.Add((SpectralFlatnessMeasure_Plot, "Spectral Flatness Measure"));
            Plots.Add((SpectralCrestFactor_Plot, "Spectral Crest Factor"));
            Plots.Add((FundamentalFrequency_Plot, "Fundamental Frequency"));
            Plots.Add((WindowedFrame_Plot, "Windowed Frame"));
            Plots.Add((FrameSpectrum_Plot, "Frame Spectrum"));
            Plots.Add((FrameCepstrum_Plot, "Frame Cepstrum"));
            Plots.Add((Spectrogram_Plot, "Spectrogram"));
            Plots.Add((Waveform_Plot, "Waveform"));
        }

        private void SetupPlots()
        {
            CreatePlotsList();

            //LinkAllPlotsBidirectionally();
            LinkTwoPlotsBidirectionally(Waveform_Plot, WindowedWaveform_Plot);

            foreach (var (plot, title) in Plots)
            {
                plot.Width = MainSplitContainer.Panel1.Width - 20;
                plot.Plot.Title(title);
                plot.Plot.Axes.SetLimitsX(0.00, 1.00);
                plot.Plot.Axes.SetLimitsY(-1.00, 1.00);
                plot.Plot.Layout.Fixed(new ScottPlot.PixelPadding(
                    left: 40,
                    right: 5,
                    bottom: 40,
                    top: 40
                ));
                plot.Refresh();
            }

            foreach (var (plot, _) in Plots)
            {
                plot.MouseWheel += (sender, e) =>
                {
                    ((HandledMouseEventArgs)e).Handled = true;
                };
            }

            Spectrogram_Plot.Plot.Layout.Default();

            UpdateScrollSize();
        }

        private void LinkTwoPlotsBidirectionally(FormsPlot plot1, FormsPlot plot2)
        {
            plot1.Plot.Axes.Link(plot2.Plot, x: true, y: false);
            plot2.Plot.Axes.Link(plot1.Plot, x: true, y: false);
        }
        #endregion

        #region MENU
        private void Exit_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ResetPlots_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoScalePlots();
        }

        private void AutoScalePlots()
        {
            foreach ((var plot, _) in Plots)
            {
                plot.Plot.Axes.SetLimitsX(0.00, 1.00);
                plot.Plot.Axes.SetLimitsY(-1.00, 1.00);
                plot.Plot.Axes.AutoScale();
                plot.Refresh();
            }
        }

        private void LoadAudioFile_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Pliki audio (*.wav)|*.wav|Wszystkie pliki (*.*)|*.*",
                Title = "Wybierz plik audio",
                InitialDirectory = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\..\..\..\")),
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                Cursor = Cursors.WaitCursor;
                CurrentWaveform = new Waveform(filePath);
                Cursor = Cursors.Default;

                this.Text = WINDOW_NAME + " - " + CurrentWaveform?.FileName;

                AnalyzeAudio();
                DisplayPlots();
            }
        }
        #endregion

        #region PLOTS
        private void DisplayPlots()
        {
            if (CurrentWaveform == null) return;

            PlotSignals();
        }

        private void PlotSignals()
        {
            if (CurrentWaveform == null) return;
            if (CurrentAnalysisResult == null) return;

            PlotSignalOnPlot(Waveform_Plot, CurrentWaveform.Samples, ScottPlot.Colors.Blue, step: 1.0 / CurrentWaveform.SampleRate);

            PlotSignalOnPlot(WindowedWaveform_Plot, CurrentAnalysisResult.WindowedWaveform, ScottPlot.Colors.Blue, step: 1.0 / CurrentWaveform.SampleRate);

            PlotSignalOnPlot(FFTMagnitude_Plot, CurrentAnalysisResult.FullSignalSpectrum, ScottPlot.Colors.Red, step: (double)CurrentWaveform.SampleRate / CurrentAnalysisResult.PaddedLength);
            PlotSignalOnPlot(Volume_Plot, CurrentAnalysisResult.Volume, ScottPlot.Colors.Red);
            PlotSignalOnPlot(FrequencyCentroid_Plot, CurrentAnalysisResult.FrequencyCentroid, ScottPlot.Colors.Red);
            PlotSignalOnPlot(EffectiveBandwidth_Plot, CurrentAnalysisResult.EffectiveBandwidth, ScottPlot.Colors.Red);

            string[] labels = FrequencyBands.Bands.Select(b => b.Label).ToArray();
            PlotSignalsOnPlot(BandEnergy_Plot, CurrentAnalysisResult.BandEnergy, labels, ScottPlot.Colors.Red);
            PlotSignalsOnPlot(BandEnergyRatio_Plot, CurrentAnalysisResult.BandEnergyRatio, labels, ScottPlot.Colors.Red);
            PlotSignalsOnPlot(SpectralFlatnessMeasure_Plot, CurrentAnalysisResult.SpectralFlatnessMeasure, labels, ScottPlot.Colors.Red);
            PlotSignalsOnPlot(SpectralCrestFactor_Plot, CurrentAnalysisResult.SpectralCrestFactor, labels, ScottPlot.Colors.Red);

            PlotSignalOnPlot(FundamentalFrequency_Plot, CurrentAnalysisResult.FundamentalFrequency, ScottPlot.Colors.Green);

            UpdateFramePlots();

            PlotSpectrogram();
        }

        private void PlotSignalOnPlot(FormsPlot plot, double[] data, ScottPlot.Color color, double step = 1.0)
        {
            if (plot == null || data == null) throw new ArgumentNullException();
            if (CurrentAnalysisResult == null) return;

            plot.Plot.Clear();

            var signal = plot.Plot.Add.Signal(data, step);
            signal.Color = color;

            plot.Plot.Axes.AutoScale();
            plot.Refresh();
        }

        private void PlotScatterOnPlot(FormsPlot plot, double[] x_data, double[] y_data, ScottPlot.Color color, double step = 1.0)
        {
            if (plot == null || x_data == null || y_data == null) throw new ArgumentNullException();
            if (CurrentAnalysisResult == null) return;

            plot.Plot.Clear();

            var scatter = plot.Plot.Add.Scatter(x_data, y_data);
            scatter.Color = color;
            scatter.MarkerSize = 0;

            plot.Plot.Axes.AutoScale();
            plot.Refresh();
        }

        private void PlotSignalsOnPlot(FormsPlot plot, double[][] data, string[] labels, ScottPlot.Color color, double step = 1.0)
        {
            plot.Plot.Clear();

            for (int i = 0; i < data.Length; i++)
            {
                var signal = plot.Plot.Add.Signal(data[i]);
                signal.LegendText = labels[i];
            }

            plot.Plot.ShowLegend();
            plot.Plot.Axes.AutoScale();
            plot.Refresh();
        }

        private void UpdateFramePlots()
        {
            if (CurrentAnalysisResult == null || CurrentWaveform == null) return;
            int frameIndex = CurrentVisualizationSettings.SelectedFrameIndex;
            if (frameIndex < 0 || frameIndex >= CurrentAnalysisResult.WindowedFrames.Length) return;

            PlotSignalOnPlot(WindowedFrame_Plot, CurrentAnalysisResult.WindowedFrames[frameIndex], ScottPlot.Colors.Orange);
            PlotSignalOnPlot(FrameSpectrum_Plot, CurrentAnalysisResult.FrameLevelSpectra[frameIndex], ScottPlot.Colors.Orange, step: (double)CurrentWaveform.SampleRate / CurrentAudioProcessingSettings.FrameSize);

            int maxHz = 400;
            int minHz = 50;
            int tauMin = (int)Math.Floor((double)CurrentWaveform.SampleRate / maxHz);
            int tauMax = (int)Math.Floor((double)CurrentWaveform.SampleRate / minHz);
            tauMax = Math.Min(tauMax, CurrentAnalysisResult.Cepstrum[frameIndex].Length - 1);
            double[] cepstrum = CurrentAnalysisResult.Cepstrum[frameIndex][tauMin..(tauMax + 1)];
            double[] quefrencies = Enumerable.Range(tauMin, cepstrum.Length)
                .Select(i => (double)i / CurrentWaveform.SampleRate)
                .ToArray();
            PlotScatterOnPlot(FrameCepstrum_Plot, quefrencies, cepstrum, ScottPlot.Colors.Orange);
        }

        private ScottPlot.Panels.ColorBar? _spectrogramColorBar;

        private void PlotSpectrogram()
        {
            if (CurrentAnalysisResult == null || CurrentWaveform == null) return;

            double[,] matrix = BuildSpectrogramMatrix(CurrentAnalysisResult.FrameLevelSpectra);

            Spectrogram_Plot.Plot.Clear();

            var heatmap = Spectrogram_Plot.Plot.Add.Heatmap(matrix);
            heatmap.Colormap = new ScottPlot.Colormaps.Magma();

            double secondsPerFrame = (double)CurrentAudioProcessingSettings.HopSize / CurrentWaveform.SampleRate;
            double maxFrequency = CurrentWaveform.SampleRate / 2.0;
            double totalSeconds = CurrentAnalysisResult.FrameLevelSpectra.Length * secondsPerFrame;

            heatmap.Position = new ScottPlot.CoordinateRect(
                left: 0,
                right: totalSeconds,
                bottom: 0,
                top: maxFrequency
            );

            if (_spectrogramColorBar == null)
                _spectrogramColorBar = Spectrogram_Plot.Plot.Add.ColorBar(heatmap);
            else
                _spectrogramColorBar.Source = heatmap;

            Spectrogram_Plot.Plot.Axes.AutoScale();
            Spectrogram_Plot.Refresh();
        }
        #endregion

        #region HELPERS
        private double[,] BuildSpectrogramMatrix(double[][] spectra)
        {
            int frames = spectra.Length;
            int bins = spectra[0].Length;
            double[,] matrix = new double[bins, frames];
            double db_silence_floor = -120;

            for (int n = 0; n < frames; n++)
                for (int k = 0; k < bins; k++)
                {
                    double magnitude = spectra[n][k];
                    matrix[k, n] = magnitude > 0 ? 20 * Math.Log10(magnitude) : db_silence_floor;
                }

            return matrix;
        }
        #endregion

        #region WinForms
        private void UpdateScrollSize()
        {
            if (Plots.Count == 0) return;

            int totalHeight = Plots
                .Select(p => p.Item1.Bottom)
                .Max() + 10;

            MainSplitContainer.Panel1.AutoScrollMinSize = new Size(0, totalHeight);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateScrollSize();
        }
        #endregion

        #region EVENTS
        private void FrameSize_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (cb.SelectedItem is null) return;
            int selectedValue = (int)cb.SelectedItem;

            CurrentAudioProcessingSettings.FrameSize = selectedValue;
            HopSize_NumericUpDown.Maximum = selectedValue;

            AnalyzeAudio();
            DisplayPlots();
        }
        private void WindowType_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (cb.SelectedItem is null) return;
            Windowing.WindowType selectedValue = (Windowing.WindowType)cb.SelectedItem;

            CurrentAudioProcessingSettings.WindowType = selectedValue;

            AnalyzeAudio();
            DisplayPlots();
        }

        private void HopSize_NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            int selectedValue = (int)nud.Value;

            CurrentAudioProcessingSettings.HopSize = selectedValue;

            AnalyzeAudio();
            DisplayPlots();
        }

        private void SelectedFrame_NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            int selectedValue = (int)nud.Value;

            CurrentVisualizationSettings.SelectedFrameIndex = selectedValue;

            UpdateFramePlots();
        }

        private void RemoveDCOffset_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            CurrentAudioProcessingSettings.RemoveDCOffset = RemoveDCOffset_Checkbox.Checked;
            AnalyzeAudio();
            DisplayPlots();
        }

        private void Normalize_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CurrentAudioProcessingSettings.Normalize = Normalize_CheckBox.Checked;
            AnalyzeAudio();
            DisplayPlots();
        }
        #endregion

    }
}
