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
            VolumePlot = new ScottPlot.WinForms.FormsPlot();
            WavePlot = new ScottPlot.WinForms.FormsPlot();
            FrameSize_Label = new Label();
            FrameSize_ComboBox = new ComboBox();
            HopSize_Label = new Label();
            numericUpDown1 = new NumericUpDown();
            MainMenu_MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MainSplitContainer).BeginInit();
            MainSplitContainer.Panel1.SuspendLayout();
            MainSplitContainer.Panel2.SuspendLayout();
            MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
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
            LoadAudioFile_ToolStripMenuItem.Size = new Size(180, 22);
            LoadAudioFile_ToolStripMenuItem.Text = "Load WAV File";
            LoadAudioFile_ToolStripMenuItem.Click += LoadAudioFile_ToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(177, 6);
            // 
            // Exit_ToolStripMenuItem
            // 
            Exit_ToolStripMenuItem.Name = "Exit_ToolStripMenuItem";
            Exit_ToolStripMenuItem.Size = new Size(180, 22);
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
            resetPlotsToolStripMenuItem.Size = new Size(180, 22);
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
            MainSplitContainer.Panel1.Controls.Add(VolumePlot);
            MainSplitContainer.Panel1.Controls.Add(WavePlot);
            // 
            // MainSplitContainer.Panel2
            // 
            MainSplitContainer.Panel2.BackColor = SystemColors.Control;
            MainSplitContainer.Panel2.Controls.Add(numericUpDown1);
            MainSplitContainer.Panel2.Controls.Add(HopSize_Label);
            MainSplitContainer.Panel2.Controls.Add(FrameSize_Label);
            MainSplitContainer.Panel2.Controls.Add(FrameSize_ComboBox);
            MainSplitContainer.Panel2.RightToLeft = RightToLeft.No;
            MainSplitContainer.RightToLeft = RightToLeft.No;
            MainSplitContainer.Size = new Size(884, 588);
            MainSplitContainer.SplitterDistance = 650;
            MainSplitContainer.TabIndex = 1;
            // 
            // VolumePlot
            // 
            VolumePlot.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            VolumePlot.BackColor = Color.White;
            VolumePlot.Location = new Point(3, 203);
            VolumePlot.Margin = new Padding(3, 0, 3, 0);
            VolumePlot.Name = "VolumePlot";
            VolumePlot.Size = new Size(502, 200);
            VolumePlot.TabIndex = 1;
            // 
            // WavePlot
            // 
            WavePlot.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            WavePlot.BackColor = Color.White;
            WavePlot.Location = new Point(3, 3);
            WavePlot.Margin = new Padding(3, 3, 3, 0);
            WavePlot.Name = "WavePlot";
            WavePlot.Size = new Size(502, 200);
            WavePlot.TabIndex = 0;
            WavePlot.Tag = "";
            // 
            // FrameSize_Label
            // 
            FrameSize_Label.Location = new Point(3, 4);
            FrameSize_Label.Name = "FrameSize_Label";
            FrameSize_Label.Size = new Size(87, 23);
            FrameSize_Label.TabIndex = 2;
            FrameSize_Label.Text = "Frame Size";
            FrameSize_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FrameSize_ComboBox
            // 
            FrameSize_ComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            FrameSize_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            FrameSize_ComboBox.FormattingEnabled = true;
            FrameSize_ComboBox.Location = new Point(145, 4);
            FrameSize_ComboBox.Name = "FrameSize_ComboBox";
            FrameSize_ComboBox.Size = new Size(82, 23);
            FrameSize_ComboBox.TabIndex = 1;
            FrameSize_ComboBox.SelectedIndexChanged += FrameSize_ComboBox_SelectedIndexChanged;
            // 
            // HopSize_Label
            // 
            HopSize_Label.Location = new Point(3, 33);
            HopSize_Label.Name = "HopSize_Label";
            HopSize_Label.Size = new Size(87, 23);
            HopSize_Label.TabIndex = 3;
            HopSize_Label.Text = "Hop Size";
            HopSize_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(145, 33);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(82, 23);
            numericUpDown1.TabIndex = 5;
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
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
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
        private ScottPlot.WinForms.FormsPlot WavePlot;
        private ScottPlot.WinForms.FormsPlot VolumePlot;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem resetPlotsToolStripMenuItem;
        private Label FrameSize_Label;
        private ComboBox FrameSize_ComboBox;
        private NumericUpDown numericUpDown1;
        private Label HopSize_Label;
    }
}
