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
        }

        #region SETUP
        private void Setup()
        {
            this.Text = WINDOW_NAME;
            SetupComboBoxes();
            SetupPlots();
            SetDefaultAudioProcessingSettings();
        }

        private void SetDefaultAudioProcessingSettings()
        {
            RemoveDCOffset_Checkbox.Checked = CurrentAudioProcessingSettings.RemoveDCOffset;
            Normalize_CheckBox.Checked = CurrentAudioProcessingSettings.Normalize;
        }

        private void SetupComboBoxes()
        {
            FrameSize_ComboBox.Items.Clear();
            FrameSize_ComboBox.Items.AddRange(new object[] { 128, 256, 512, 1024 });
            FrameSize_ComboBox.SelectedIndex = 1;
            CurrentAudioProcessingSettings.FrameSize = (int)FrameSize_ComboBox.SelectedItem!;

            WindowType_ComboBox.Items.Clear();
            WindowType_ComboBox.Items.AddRange(Enum.GetValues(typeof(WindowType)).Cast<object>().ToArray());
            WindowType_ComboBox.SelectedIndex = 0;
            CurrentAudioProcessingSettings.WindowType = (WindowType)WindowType_ComboBox.SelectedItem!;
        }

        private void SetupPlots()
        {
            Plots.Add((Waveform_Plot, "Waveform"));
            Plots.Add((WindowedWaveform_Plot, "Windowed waveform"));
            Plots.Add((FFTMagnitude_Plot, "Spectrum"));
            Plots.Add((Volume_Plot, "Volume"));
            Plots.Add((FrequencyCentroid_Plot, "Frequency Centroid"));
            Plots.Add((EffectiveBandwidth_Plot, "Effective Bandwidth"));
            Plots.Add((BandEnergy_Plot, "Band Energy"));
            Plots.Add((BandEnergyRatio_Plot, "Band Energy Ratio"));
            Plots.Add((SpectralFlatnessMeasure_Plot, "Spectral Flatness Measure"));
            Plots.Add((SpectralCrestFactor_Plot, "Spectral Crest Factor"));

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

            PlotSignalOnPlot(FFTMagnitude_Plot, CurrentAnalysisResult.FullSignalSpectrum, ScottPlot.Colors.Red);
            PlotSignalOnPlot(Volume_Plot, CurrentAnalysisResult.Volume, ScottPlot.Colors.Red);
            PlotSignalOnPlot(FrequencyCentroid_Plot, CurrentAnalysisResult.FrequencyCentroid, ScottPlot.Colors.Red);
            PlotSignalOnPlot(EffectiveBandwidth_Plot, CurrentAnalysisResult.EffectiveBandwidth, ScottPlot.Colors.Red);
            string[] labels = FrequencyBands.Bands.Select(b => b.Label).ToArray();
            PlotSignalsOnPlot(BandEnergy_Plot, CurrentAnalysisResult.BandEnergy, labels, ScottPlot.Colors.Red);
            PlotSignalsOnPlot(BandEnergyRatio_Plot, CurrentAnalysisResult.BandEnergyRatio, labels, ScottPlot.Colors.Red);
            PlotSignalsOnPlot(SpectralFlatnessMeasure_Plot, CurrentAnalysisResult.SpectralFlatnessMeasure, labels, ScottPlot.Colors.Red);
            PlotSignalsOnPlot(SpectralCrestFactor_Plot, CurrentAnalysisResult.SpectralCrestFactor, labels, ScottPlot.Colors.Red);

            //Waveform_Plot.Plot.Axes.AutoScale();
            //Waveform_Plot.Refresh();
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

        private void PlotSignalsOnPlot(FormsPlot plot, double[][] data, string[] labels, ScottPlot.Color color, double step = 1.0)
        {
            plot.Plot.Clear();

            for (int i = 0; i < data.Length; i++)
            {
                var signal = plot.Plot.Add.Signal(data[i]);
                signal.LegendText = labels[i];
            }

            plot.Plot.ShowLegend();
            //plot.Plot.Axes.Bottom.Label.Text = "Frame";
            //plot.Plot.Axes.Left.Label.Text = "Energy Ratio";
            plot.Plot.Axes.AutoScale();
            plot.Refresh();
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
            WindowType selectedValue = (WindowType)cb.SelectedItem;

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
