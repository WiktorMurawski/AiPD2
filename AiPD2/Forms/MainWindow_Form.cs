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
            this.Text = WINDOW_NAME;

            SetupComboBoxes();
            SetupPlots();
        }

        #region SETUP
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
            Plots.Add((WavePlot, "Waveform"));
            Plots.Add((WindowedSignalPlot, "Windowed signal"));
            Plots.Add((FFTMagnitudePlot, "Spectrum"));
            Plots.Add((formsPlot4, "Volume"));
            Plots.Add((formsPlot5, "formsPlot5"));
            Plots.Add((formsPlot6, "formsPlot6"));

            //LinkAllPlotsBidirectionally();

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

        private void LinkAllPlotsBidirectionally()
        {
            for (int i = 0; i < Plots.Count; i++)
            {
                for (int j = 0; j < Plots.Count; j++)
                {
                    if (i == j) continue;
                    Plots[i].Item1.Plot.Axes.Link(Plots[j].Item1.Plot, x: true, y: false);
                }
            }
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
                DisplayCalculatedParams();
            }
        }
        #endregion

        private void FrameSize_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (cb.SelectedItem is null) return;
            int selectedValue = (int)cb.SelectedItem;

            CurrentAudioProcessingSettings.FrameSize = selectedValue;
            Cursor = Cursors.WaitCursor;
            //CurrentWaveform.FrameSizeChanged();
            Cursor = Cursors.Default;

            DisplayCalculatedParams();
        }
        private void WindowType_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (cb.SelectedItem is null) return;
            WindowType selectedValue = (WindowType)cb.SelectedItem;

            CurrentAudioProcessingSettings.WindowType = selectedValue;
            Cursor = Cursors.WaitCursor;
            AnalyzeAudio();
            Cursor = Cursors.Default;

            DisplayCalculatedParams();
        }

        private void AnalyzeAudio()
        {
            if (CurrentWaveform == null) return;

            CurrentAnalysisResult = AudioAnalyzer.Analyze(CurrentWaveform, CurrentAudioProcessingSettings);
        }

        private void DisplayCalculatedParams()
        {
            if (CurrentWaveform == null) return;

            PlotSignals();
        }

        private void DisplayOnPlot(FormsPlot plot, double[] data, ScottPlot.Color color, double step = 1.0)
        {
            if (plot == null || data == null) throw new ArgumentNullException();
            if (CurrentAnalysisResult == null) return;

            plot.Plot.Clear();

            var signal = plot.Plot.Add.Signal(data, step);

            plot.Plot.Axes.AutoScale();
            plot.Refresh();
        }

        private void PlotSignals()
        {
            if (CurrentWaveform == null) return;
            if (CurrentAnalysisResult == null) return;

            DisplayAudioWaveOnPlot();

            DisplayOnPlot(WindowedSignalPlot, CurrentAnalysisResult.WindowedSignal, ScottPlot.Colors.Red, step: 1.0 / CurrentWaveform.SampleRate);
            DisplayOnPlot(FFTMagnitudePlot, CurrentAnalysisResult.FullSignalSpectrum, ScottPlot.Colors.Red);

            //DisplayTimeParamsSignalOnPlot(VolumePlot, CurrentAudioModel.TimeParams.Volume, Colors.Red);
            //DisplayTimeParamsSignalOnPlot(STEPlot, CurrentAudioModel.TimeParams.ShortTimeEnergy, Colors.DarkRed);
            //DisplayTimeParamsSignalOnPlot(ZCRPlot, CurrentAudioModel.TimeParams.ZeroCrossingRate, Colors.Blue);
            //DisplayTimeParamsSignalOnPlot(SRPlot, CurrentAudioModel.TimeParams.SilentRatio, Colors.DarkCyan);
            //DisplayTimeParamsSignalOnPlot(VoicedRatioPlot, CurrentAudioModel.TimeParams.VoicedRatio, Colors.Purple);
            //DisplayTimeParamsSignalOnPlot(FFAutocorrelationPlot, CurrentAudioModel.TimeParams.FundamentalFrequencyAutocorrelation, Colors.Green);
            //DisplayTimeParamsSignalOnPlot(FFAMDFPlot, CurrentAudioModel.TimeParams.FundamentalFrequencyAMDF, Colors.Green);
        }

        private void DisplayAudioWaveOnPlot()
        {
            if (CurrentWaveform == null)
                return;

            WavePlot.Plot.Clear();

            double step = 1.0 / CurrentWaveform.SampleRate;

            var signal = WavePlot.Plot.Add.Signal(
                CurrentWaveform.Samples,
                step);

            signal.Color = ScottPlot.Colors.Blue;
            signal.LineWidth = 1.0f;

            //WavePlot.Plot.Title($"{CurrentAudioModel.FileName}");
            //WavePlot.Plot.XLabel("Czas (sekundy)");
            //WavePlot.Plot.YLabel("Amplituda");

            WavePlot.Plot.Axes.SetLimitsY(-1.00, 1.00);
            WavePlot.Plot.Axes.SetLimitsX(0, CurrentWaveform.Duration.TotalSeconds);

            WavePlot.Refresh();
        }

        private void DisplayTimeParamsSignalOnPlot(FormsPlot plot, double[] paramSignal, ScottPlot.Color color)
        {
            ////if (CurrentAudioModel?.TimeParams == null || paramSignal.Length == 0)
            ////    return;

            //plot.Plot.Clear();

            //double step = (double)AudioModel.FrameSize / CurrentAudioModel.SampleRate;
            ////var timeParams = CurrentAudioModel.TimeParams;
            //var signal = plot.Plot.Add.Signal(
            //    paramSignal,
            //    step);

            //signal.Data.XOffset = step / 2;

            //signal.Color = color;
            //signal.LineWidth = 1.0f;

            //plot.Plot.Axes.AutoScaleY();
            //plot.Plot.Axes.SetLimitsX(0, CurrentAudioModel.Duration.TotalSeconds);
            plot.Refresh();
        }
    }
}
