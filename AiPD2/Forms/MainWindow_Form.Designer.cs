namespace AiPD2.Forms
{
    partial class MainWindow_Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MainMenu_MenuStrip = new MenuStrip();
            file_ToolStripMenuItem = new ToolStripMenuItem();
            LoadAudioFile_ToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            Exit_ToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            resetPlotsToolStripMenuItem = new ToolStripMenuItem();
            MainSplitContainer = new SplitContainer();
            Spectrogram_Plot = new ScottPlot.WinForms.FormsPlot();
            FrameCepstrum_Plot = new ScottPlot.WinForms.FormsPlot();
            FrameSpectrum_Plot = new ScottPlot.WinForms.FormsPlot();
            WindowedFrame_Plot = new ScottPlot.WinForms.FormsPlot();
            FundamentalFrequency_Plot = new ScottPlot.WinForms.FormsPlot();
            SpectralCrestFactor_Plot = new ScottPlot.WinForms.FormsPlot();
            SpectralFlatnessMeasure_Plot = new ScottPlot.WinForms.FormsPlot();
            BandEnergyRatio_Plot = new ScottPlot.WinForms.FormsPlot();
            BandEnergy_Plot = new ScottPlot.WinForms.FormsPlot();
            EffectiveBandwidth_Plot = new ScottPlot.WinForms.FormsPlot();
            FrequencyCentroid_Plot = new ScottPlot.WinForms.FormsPlot();
            Volume_Plot = new ScottPlot.WinForms.FormsPlot();
            WindowedWaveform_Plot = new ScottPlot.WinForms.FormsPlot();
            FFTMagnitude_Plot = new ScottPlot.WinForms.FormsPlot();
            Waveform_Plot = new ScottPlot.WinForms.FormsPlot();
            groupBox4 = new GroupBox();
            label3 = new Label();
            SelectedFrame_NumericUpDown = new NumericUpDown();
            groupBox3 = new GroupBox();
            label1 = new Label();
            WindowType_ComboBox = new ComboBox();
            groupBox2 = new GroupBox();
            FrameSize_Label = new Label();
            FrameSize_ComboBox = new ComboBox();
            HopSize_Label = new Label();
            HopSize_NumericUpDown = new NumericUpDown();
            groupBox1 = new GroupBox();
            RemoveDCOffset_Checkbox = new CheckBox();
            Normalize_CheckBox = new CheckBox();
            MainMenu_MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MainSplitContainer).BeginInit();
            MainSplitContainer.Panel1.SuspendLayout();
            MainSplitContainer.Panel2.SuspendLayout();
            MainSplitContainer.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SelectedFrame_NumericUpDown).BeginInit();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)HopSize_NumericUpDown).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // MainMenu_MenuStrip
            // 
            MainMenu_MenuStrip.Items.AddRange(new ToolStripItem[] { file_ToolStripMenuItem, viewToolStripMenuItem });
            MainMenu_MenuStrip.Location = new Point(0, 0);
            MainMenu_MenuStrip.Name = "MainMenu_MenuStrip";
            MainMenu_MenuStrip.Size = new Size(884, 24);
            MainMenu_MenuStrip.TabIndex = 0;
            // 
            // file_ToolStripMenuItem
            // 
            file_ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { LoadAudioFile_ToolStripMenuItem, toolStripMenuItem1, Exit_ToolStripMenuItem });
            file_ToolStripMenuItem.Name = "file_ToolStripMenuItem";
            file_ToolStripMenuItem.Size = new Size(37, 20);
            file_ToolStripMenuItem.Text = "File";
            // 
            // LoadAudioFile_ToolStripMenuItem
            // 
            LoadAudioFile_ToolStripMenuItem.Name = "LoadAudioFile_ToolStripMenuItem";
            LoadAudioFile_ToolStripMenuItem.Size = new Size(149, 22);
            LoadAudioFile_ToolStripMenuItem.Text = "Load WAV File";
            LoadAudioFile_ToolStripMenuItem.Click += LoadAudioFile_ToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(146, 6);
            // 
            // Exit_ToolStripMenuItem
            // 
            Exit_ToolStripMenuItem.Name = "Exit_ToolStripMenuItem";
            Exit_ToolStripMenuItem.Size = new Size(149, 22);
            Exit_ToolStripMenuItem.Text = "Exit";
            Exit_ToolStripMenuItem.Click += Exit_ToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { resetPlotsToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(53, 20);
            viewToolStripMenuItem.Text = "Widok";
            // 
            // resetPlotsToolStripMenuItem
            // 
            resetPlotsToolStripMenuItem.Name = "resetPlotsToolStripMenuItem";
            resetPlotsToolStripMenuItem.Size = new Size(131, 22);
            resetPlotsToolStripMenuItem.Text = "Reset Plots";
            resetPlotsToolStripMenuItem.Click += ResetPlots_ToolStripMenuItem_Click;
            // 
            // MainSplitContainer
            // 
            MainSplitContainer.Dock = DockStyle.Fill;
            MainSplitContainer.Location = new Point(0, 24);
            MainSplitContainer.Margin = new Padding(0);
            MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            MainSplitContainer.Panel1.AutoScroll = true;
            MainSplitContainer.Panel1.AutoScrollMinSize = new Size(20, 0);
            MainSplitContainer.Panel1.BackColor = Color.White;
            MainSplitContainer.Panel1.Controls.Add(Spectrogram_Plot);
            MainSplitContainer.Panel1.Controls.Add(FrameCepstrum_Plot);
            MainSplitContainer.Panel1.Controls.Add(FrameSpectrum_Plot);
            MainSplitContainer.Panel1.Controls.Add(WindowedFrame_Plot);
            MainSplitContainer.Panel1.Controls.Add(FundamentalFrequency_Plot);
            MainSplitContainer.Panel1.Controls.Add(SpectralCrestFactor_Plot);
            MainSplitContainer.Panel1.Controls.Add(SpectralFlatnessMeasure_Plot);
            MainSplitContainer.Panel1.Controls.Add(BandEnergyRatio_Plot);
            MainSplitContainer.Panel1.Controls.Add(BandEnergy_Plot);
            MainSplitContainer.Panel1.Controls.Add(EffectiveBandwidth_Plot);
            MainSplitContainer.Panel1.Controls.Add(FrequencyCentroid_Plot);
            MainSplitContainer.Panel1.Controls.Add(Volume_Plot);
            MainSplitContainer.Panel1.Controls.Add(WindowedWaveform_Plot);
            MainSplitContainer.Panel1.Controls.Add(FFTMagnitude_Plot);
            MainSplitContainer.Panel1.Controls.Add(Waveform_Plot);
            // 
            // MainSplitContainer.Panel2
            // 
            MainSplitContainer.Panel2.BackColor = SystemColors.Control;
            MainSplitContainer.Panel2.Controls.Add(groupBox4);
            MainSplitContainer.Panel2.Controls.Add(groupBox3);
            MainSplitContainer.Panel2.Controls.Add(groupBox2);
            MainSplitContainer.Panel2.Controls.Add(groupBox1);
            MainSplitContainer.Panel2.RightToLeft = RightToLeft.No;
            MainSplitContainer.RightToLeft = RightToLeft.No;
            MainSplitContainer.Size = new Size(884, 588);
            MainSplitContainer.SplitterDistance = 650;
            MainSplitContainer.TabIndex = 1;
            // 
            // Spectrogram_Plot
            // 
            Spectrogram_Plot.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Spectrogram_Plot.BackColor = Color.White;
            Spectrogram_Plot.Location = new Point(3, 2803);
            Spectrogram_Plot.Margin = new Padding(3, 0, 3, 0);
            Spectrogram_Plot.Name = "Spectrogram_Plot";
            Spectrogram_Plot.Size = new Size(128, 200);
            Spectrogram_Plot.TabIndex = 14;
            // 
            // FrameCepstrum_Plot
            // 
            FrameCepstrum_Plot.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            FrameCepstrum_Plot.BackColor = Color.White;
            FrameCepstrum_Plot.Location = new Point(3, 2603);
            FrameCepstrum_Plot.Margin = new Padding(3, 0, 3, 0);
            FrameCepstrum_Plot.Name = "FrameCepstrum_Plot";
            FrameCepstrum_Plot.Size = new Size(128, 200);
            FrameCepstrum_Plot.TabIndex = 13;
            // 
            // FrameSpectrum_Plot
            // 
            FrameSpectrum_Plot.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            FrameSpectrum_Plot.BackColor = Color.White;
            FrameSpectrum_Plot.Location = new Point(3, 2403);
            FrameSpectrum_Plot.Margin = new Padding(3, 0, 3, 0);
            FrameSpectrum_Plot.Name = "FrameSpectrum_Plot";
            FrameSpectrum_Plot.Size = new Size(128, 200);
            FrameSpectrum_Plot.TabIndex = 12;
            // 
            // WindowedFrame_Plot
            // 
            WindowedFrame_Plot.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            WindowedFrame_Plot.BackColor = Color.White;
            WindowedFrame_Plot.Location = new Point(3, 2203);
            WindowedFrame_Plot.Margin = new Padding(3, 0, 3, 0);
            WindowedFrame_Plot.Name = "WindowedFrame_Plot";
            WindowedFrame_Plot.Size = new Size(128, 200);
            WindowedFrame_Plot.TabIndex = 11;
            // 
            // FundamentalFrequency_Plot
            // 
            FundamentalFrequency_Plot.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            FundamentalFrequency_Plot.BackColor = Color.White;
            FundamentalFrequency_Plot.Location = new Point(3, 2003);
            FundamentalFrequency_Plot.Margin = new Padding(3, 0, 3, 0);
            FundamentalFrequency_Plot.Name = "FundamentalFrequency_Plot";
            FundamentalFrequency_Plot.Size = new Size(128, 200);
            FundamentalFrequency_Plot.TabIndex = 10;
            // 
            // SpectralCrestFactor_Plot
            // 
            SpectralCrestFactor_Plot.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SpectralCrestFactor_Plot.BackColor = Color.White;
            SpectralCrestFactor_Plot.Location = new Point(3, 1803);
            SpectralCrestFactor_Plot.Margin = new Padding(3, 0, 3, 0);
            SpectralCrestFactor_Plot.Name = "SpectralCrestFactor_Plot";
            SpectralCrestFactor_Plot.Size = new Size(128, 200);
            SpectralCrestFactor_Plot.TabIndex = 9;
            // 
            // SpectralFlatnessMeasure_Plot
            // 
            SpectralFlatnessMeasure_Plot.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SpectralFlatnessMeasure_Plot.BackColor = Color.White;
            SpectralFlatnessMeasure_Plot.Location = new Point(3, 1603);
            SpectralFlatnessMeasure_Plot.Margin = new Padding(3, 0, 3, 0);
            SpectralFlatnessMeasure_Plot.Name = "SpectralFlatnessMeasure_Plot";
            SpectralFlatnessMeasure_Plot.Size = new Size(128, 200);
            SpectralFlatnessMeasure_Plot.TabIndex = 8;
            // 
            // BandEnergyRatio_Plot
            // 
            BandEnergyRatio_Plot.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BandEnergyRatio_Plot.BackColor = Color.White;
            BandEnergyRatio_Plot.Location = new Point(3, 1403);
            BandEnergyRatio_Plot.Margin = new Padding(3, 0, 3, 0);
            BandEnergyRatio_Plot.Name = "BandEnergyRatio_Plot";
            BandEnergyRatio_Plot.Size = new Size(128, 200);
            BandEnergyRatio_Plot.TabIndex = 7;
            // 
            // BandEnergy_Plot
            // 
            BandEnergy_Plot.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BandEnergy_Plot.BackColor = Color.White;
            BandEnergy_Plot.Location = new Point(3, 1203);
            BandEnergy_Plot.Margin = new Padding(3, 0, 3, 0);
            BandEnergy_Plot.Name = "BandEnergy_Plot";
            BandEnergy_Plot.Size = new Size(128, 200);
            BandEnergy_Plot.TabIndex = 6;
            // 
            // EffectiveBandwidth_Plot
            // 
            EffectiveBandwidth_Plot.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            EffectiveBandwidth_Plot.BackColor = Color.White;
            EffectiveBandwidth_Plot.Location = new Point(3, 1003);
            EffectiveBandwidth_Plot.Margin = new Padding(3, 0, 3, 0);
            EffectiveBandwidth_Plot.Name = "EffectiveBandwidth_Plot";
            EffectiveBandwidth_Plot.Size = new Size(128, 200);
            EffectiveBandwidth_Plot.TabIndex = 5;
            // 
            // FrequencyCentroid_Plot
            // 
            FrequencyCentroid_Plot.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            FrequencyCentroid_Plot.BackColor = Color.White;
            FrequencyCentroid_Plot.Location = new Point(3, 803);
            FrequencyCentroid_Plot.Margin = new Padding(3, 0, 3, 0);
            FrequencyCentroid_Plot.Name = "FrequencyCentroid_Plot";
            FrequencyCentroid_Plot.Size = new Size(128, 200);
            FrequencyCentroid_Plot.TabIndex = 4;
            // 
            // Volume_Plot
            // 
            Volume_Plot.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Volume_Plot.BackColor = Color.White;
            Volume_Plot.Location = new Point(3, 603);
            Volume_Plot.Margin = new Padding(3, 0, 3, 0);
            Volume_Plot.Name = "Volume_Plot";
            Volume_Plot.Size = new Size(128, 200);
            Volume_Plot.TabIndex = 3;
            // 
            // WindowedWaveform_Plot
            // 
            WindowedWaveform_Plot.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            WindowedWaveform_Plot.BackColor = Color.White;
            WindowedWaveform_Plot.Location = new Point(3, 203);
            WindowedWaveform_Plot.Margin = new Padding(3, 3, 3, 0);
            WindowedWaveform_Plot.Name = "WindowedWaveform_Plot";
            WindowedWaveform_Plot.Size = new Size(128, 200);
            WindowedWaveform_Plot.TabIndex = 2;
            WindowedWaveform_Plot.Tag = "";
            // 
            // FFTMagnitude_Plot
            // 
            FFTMagnitude_Plot.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            FFTMagnitude_Plot.BackColor = Color.White;
            FFTMagnitude_Plot.Location = new Point(3, 403);
            FFTMagnitude_Plot.Margin = new Padding(3, 0, 3, 0);
            FFTMagnitude_Plot.Name = "FFTMagnitude_Plot";
            FFTMagnitude_Plot.Size = new Size(128, 200);
            FFTMagnitude_Plot.TabIndex = 1;
            // 
            // Waveform_Plot
            // 
            Waveform_Plot.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Waveform_Plot.BackColor = Color.White;
            Waveform_Plot.Location = new Point(3, 3);
            Waveform_Plot.Margin = new Padding(3, 3, 3, 0);
            Waveform_Plot.Name = "Waveform_Plot";
            Waveform_Plot.Size = new Size(128, 200);
            Waveform_Plot.TabIndex = 0;
            Waveform_Plot.Tag = "";
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox4.Controls.Add(label3);
            groupBox4.Controls.Add(SelectedFrame_NumericUpDown);
            groupBox4.Location = new Point(3, 243);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(224, 83);
            groupBox4.TabIndex = 13;
            groupBox4.TabStop = false;
            groupBox4.Text = "Visualization";
            // 
            // label3
            // 
            label3.Location = new Point(3, 22);
            label3.Margin = new Padding(3, 2, 3, 2);
            label3.Name = "label3";
            label3.Size = new Size(92, 23);
            label3.TabIndex = 3;
            label3.Text = "Selected Frame";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // SelectedFrame_NumericUpDown
            // 
            SelectedFrame_NumericUpDown.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SelectedFrame_NumericUpDown.Location = new Point(139, 22);
            SelectedFrame_NumericUpDown.Maximum = new decimal(new int[] { 256, 0, 0, 0 });
            SelectedFrame_NumericUpDown.Name = "SelectedFrame_NumericUpDown";
            SelectedFrame_NumericUpDown.Size = new Size(82, 23);
            SelectedFrame_NumericUpDown.TabIndex = 5;
            SelectedFrame_NumericUpDown.Value = new decimal(new int[] { 128, 0, 0, 0 });
            SelectedFrame_NumericUpDown.ValueChanged += SelectedFrame_NumericUpDown_ValueChanged;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(WindowType_ComboBox);
            groupBox3.Location = new Point(3, 177);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(224, 60);
            groupBox3.TabIndex = 12;
            groupBox3.TabStop = false;
            groupBox3.Text = "Windowing settings";
            // 
            // label1
            // 
            label1.Location = new Point(3, 21);
            label1.Margin = new Padding(3, 2, 3, 2);
            label1.Name = "label1";
            label1.Size = new Size(83, 23);
            label1.TabIndex = 7;
            label1.Text = "Window Type";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // WindowType_ComboBox
            // 
            WindowType_ComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            WindowType_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            WindowType_ComboBox.FormattingEnabled = true;
            WindowType_ComboBox.Location = new Point(120, 21);
            WindowType_ComboBox.Name = "WindowType_ComboBox";
            WindowType_ComboBox.Size = new Size(101, 23);
            WindowType_ComboBox.TabIndex = 6;
            WindowType_ComboBox.SelectedIndexChanged += WindowType_ComboBox_SelectedIndexChanged;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(FrameSize_Label);
            groupBox2.Controls.Add(FrameSize_ComboBox);
            groupBox2.Controls.Add(HopSize_Label);
            groupBox2.Controls.Add(HopSize_NumericUpDown);
            groupBox2.Location = new Point(3, 88);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(224, 83);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Frame settings";
            // 
            // FrameSize_Label
            // 
            FrameSize_Label.Location = new Point(3, 24);
            FrameSize_Label.Margin = new Padding(3, 2, 3, 2);
            FrameSize_Label.Name = "FrameSize_Label";
            FrameSize_Label.Size = new Size(66, 23);
            FrameSize_Label.TabIndex = 2;
            FrameSize_Label.Text = "Frame Size";
            FrameSize_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FrameSize_ComboBox
            // 
            FrameSize_ComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            FrameSize_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            FrameSize_ComboBox.FormattingEnabled = true;
            FrameSize_ComboBox.Location = new Point(139, 24);
            FrameSize_ComboBox.Margin = new Padding(0);
            FrameSize_ComboBox.Name = "FrameSize_ComboBox";
            FrameSize_ComboBox.Size = new Size(82, 23);
            FrameSize_ComboBox.TabIndex = 1;
            FrameSize_ComboBox.SelectedIndexChanged += FrameSize_ComboBox_SelectedIndexChanged;
            // 
            // HopSize_Label
            // 
            HopSize_Label.Location = new Point(3, 51);
            HopSize_Label.Margin = new Padding(3, 2, 3, 2);
            HopSize_Label.Name = "HopSize_Label";
            HopSize_Label.Size = new Size(66, 23);
            HopSize_Label.TabIndex = 3;
            HopSize_Label.Text = "Hop Size";
            HopSize_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // HopSize_NumericUpDown
            // 
            HopSize_NumericUpDown.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            HopSize_NumericUpDown.Location = new Point(139, 51);
            HopSize_NumericUpDown.Maximum = new decimal(new int[] { 256, 0, 0, 0 });
            HopSize_NumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            HopSize_NumericUpDown.Name = "HopSize_NumericUpDown";
            HopSize_NumericUpDown.Size = new Size(82, 23);
            HopSize_NumericUpDown.TabIndex = 5;
            HopSize_NumericUpDown.Value = new decimal(new int[] { 128, 0, 0, 0 });
            HopSize_NumericUpDown.ValueChanged += HopSize_NumericUpDown_ValueChanged;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(RemoveDCOffset_Checkbox);
            groupBox1.Controls.Add(Normalize_CheckBox);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(224, 79);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Preprocessing";
            // 
            // RemoveDCOffset_Checkbox
            // 
            RemoveDCOffset_Checkbox.AutoSize = true;
            RemoveDCOffset_Checkbox.Location = new Point(6, 22);
            RemoveDCOffset_Checkbox.Name = "RemoveDCOffset_Checkbox";
            RemoveDCOffset_Checkbox.Size = new Size(123, 19);
            RemoveDCOffset_Checkbox.TabIndex = 8;
            RemoveDCOffset_Checkbox.Text = "Remove DC Offset";
            RemoveDCOffset_Checkbox.UseVisualStyleBackColor = true;
            RemoveDCOffset_Checkbox.CheckedChanged += RemoveDCOffset_Checkbox_CheckedChanged;
            // 
            // Normalize_CheckBox
            // 
            Normalize_CheckBox.AutoSize = true;
            Normalize_CheckBox.Location = new Point(6, 47);
            Normalize_CheckBox.Name = "Normalize_CheckBox";
            Normalize_CheckBox.Size = new Size(80, 19);
            Normalize_CheckBox.TabIndex = 9;
            Normalize_CheckBox.Text = "Normalize";
            Normalize_CheckBox.UseVisualStyleBackColor = true;
            Normalize_CheckBox.CheckedChanged += Normalize_CheckBox_CheckedChanged;
            // 
            // MainWindow_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(884, 612);
            Controls.Add(MainSplitContainer);
            Controls.Add(MainMenu_MenuStrip);
            DoubleBuffered = true;
            MainMenuStrip = MainMenu_MenuStrip;
            MinimumSize = new Size(400, 200);
            Name = "MainWindow_Form";
            Text = "AiPD Projekt 1";
            MainMenu_MenuStrip.ResumeLayout(false);
            MainMenu_MenuStrip.PerformLayout();
            MainSplitContainer.Panel1.ResumeLayout(false);
            MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MainSplitContainer).EndInit();
            MainSplitContainer.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SelectedFrame_NumericUpDown).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)HopSize_NumericUpDown).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip MainMenu_MenuStrip;
        private ToolStripMenuItem file_ToolStripMenuItem;
        private ToolStripMenuItem Exit_ToolStripMenuItem;
        private ToolStripMenuItem LoadAudioFile_ToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private SplitContainer MainSplitContainer;
        private ScottPlot.WinForms.FormsPlot Waveform_Plot;
        private ScottPlot.WinForms.FormsPlot FFTMagnitude_Plot;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem resetPlotsToolStripMenuItem;
        private Label FrameSize_Label;
        private ComboBox FrameSize_ComboBox;
        private NumericUpDown HopSize_NumericUpDown;
        private Label HopSize_Label;
        private Label label1;
        private ComboBox WindowType_ComboBox;
        private ScottPlot.WinForms.FormsPlot FrequencyCentroid_Plot;
        private ScottPlot.WinForms.FormsPlot Volume_Plot;
        private ScottPlot.WinForms.FormsPlot WindowedWaveform_Plot;
        private ScottPlot.WinForms.FormsPlot EffectiveBandwidth_Plot;
        private ScottPlot.WinForms.FormsPlot BandEnergy_Plot;
        private ScottPlot.WinForms.FormsPlot BandEnergyRatio_Plot;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private CheckBox RemoveDCOffset_Checkbox;
        private CheckBox Normalize_CheckBox;
        private GroupBox groupBox3;
        private ScottPlot.WinForms.FormsPlot SpectralCrestFactor_Plot;
        private ScottPlot.WinForms.FormsPlot SpectralFlatnessMeasure_Plot;
        private ScottPlot.WinForms.FormsPlot FundamentalFrequency_Plot;
        private GroupBox groupBox4;
        private Label label3;
        private NumericUpDown SelectedFrame_NumericUpDown;
        private ScottPlot.WinForms.FormsPlot FrameCepstrum_Plot;
        private ScottPlot.WinForms.FormsPlot FrameSpectrum_Plot;
        private ScottPlot.WinForms.FormsPlot WindowedFrame_Plot;
        private ScottPlot.WinForms.FormsPlot Spectrogram_Plot;
    }
}
