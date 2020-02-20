namespace booq
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.FileLoadButton = new System.Windows.Forms.ToolStripButton();
            this.TrackButton = new System.Windows.Forms.ToolStripButton();
            this.PianoRollButton = new System.Windows.Forms.ToolStripButton();
            this.WaveButton = new System.Windows.Forms.ToolStripButton();
            this.TrackPanel = new System.Windows.Forms.Panel();
            this.OuterPanel = new System.Windows.Forms.Panel();
            this.PianoRoll = new System.Windows.Forms.Panel();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.HScrollBar = new System.Windows.Forms.HScrollBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PianoRollPitchInnerPanel = new System.Windows.Forms.Panel();
            this.PianoRollPositionOuterPanel = new System.Windows.Forms.Panel();
            this.PianoRollPositionInnerPanel = new System.Windows.Forms.Panel();
            this.PianoRollMainOuterPanel = new System.Windows.Forms.Panel();
            this.PianoRollMainInnerPanel = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.PencilMode = new System.Windows.Forms.ToolStripButton();
            this.SelectRegionMode = new System.Windows.Forms.ToolStripButton();
            this.PlayMode = new System.Windows.Forms.ToolStripButton();
            this.StopMode = new System.Windows.Forms.ToolStripButton();
            this.WaveLoadFile = new System.Windows.Forms.Button();
            this.SoundPlay = new System.Windows.Forms.Button();
            this.WavOuterPanel = new System.Windows.Forms.Panel();
            this.GraphViewPanel = new System.Windows.Forms.Panel();
            this.WavePanel = new System.Windows.Forms.Panel();
            this.PlottingRateValue = new System.Windows.Forms.TextBox();
            this.WavePlot = new System.Windows.Forms.Button();
            this.SaveFileButton = new System.Windows.Forms.Button();
            this.SampleRateLabel = new System.Windows.Forms.Label();
            this.WaveBPSLabel = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolStrip.SuspendLayout();
            this.TrackPanel.SuspendLayout();
            this.PianoRoll.SuspendLayout();
            this.panel2.SuspendLayout();
            this.PianoRollPositionOuterPanel.SuspendLayout();
            this.PianoRollMainOuterPanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.WavOuterPanel.SuspendLayout();
            this.WavePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileLoadButton,
            this.TrackButton,
            this.PianoRollButton,
            this.WaveButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1578, 32);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // FileLoadButton
            // 
            this.FileLoadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FileLoadButton.Image = ((System.Drawing.Image)(resources.GetObject("FileLoadButton.Image")));
            this.FileLoadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FileLoadButton.Name = "FileLoadButton";
            this.FileLoadButton.Size = new System.Drawing.Size(83, 29);
            this.FileLoadButton.Text = "LoadFile";
            // 
            // TrackButton
            // 
            this.TrackButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TrackButton.Image = ((System.Drawing.Image)(resources.GetObject("TrackButton.Image")));
            this.TrackButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TrackButton.Name = "TrackButton";
            this.TrackButton.Size = new System.Drawing.Size(59, 29);
            this.TrackButton.Text = "Track";
            this.TrackButton.Click += new System.EventHandler(this.PianoRollPanel_ButtonClick);
            // 
            // PianoRollButton
            // 
            this.PianoRollButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PianoRollButton.Image = ((System.Drawing.Image)(resources.GetObject("PianoRollButton.Image")));
            this.PianoRollButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PianoRollButton.Name = "PianoRollButton";
            this.PianoRollButton.Size = new System.Drawing.Size(90, 29);
            this.PianoRollButton.Text = "PianoRoll";
            this.PianoRollButton.Click += new System.EventHandler(this.TrackButton_Click);
            // 
            // WaveButton
            // 
            this.WaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.WaveButton.Image = ((System.Drawing.Image)(resources.GetObject("WaveButton.Image")));
            this.WaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.WaveButton.Name = "WaveButton";
            this.WaveButton.Size = new System.Drawing.Size(61, 29);
            this.WaveButton.Text = "Wave";
            this.WaveButton.Click += new System.EventHandler(this.WaveButton_Click);
            // 
            // TrackPanel
            // 
            this.TrackPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TrackPanel.Controls.Add(this.OuterPanel);
            this.TrackPanel.Location = new System.Drawing.Point(200, 100);
            this.TrackPanel.Name = "TrackPanel";
            this.TrackPanel.Size = new System.Drawing.Size(1200, 800);
            this.TrackPanel.TabIndex = 1;
            this.TrackPanel.Visible = false;
            // 
            // OuterPanel
            // 
            this.OuterPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.OuterPanel.Location = new System.Drawing.Point(100, 100);
            this.OuterPanel.Name = "OuterPanel";
            this.OuterPanel.Size = new System.Drawing.Size(1000, 600);
            this.OuterPanel.TabIndex = 0;
            // 
            // PianoRoll
            // 
            this.PianoRoll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.PianoRoll.Controls.Add(this.vScrollBar1);
            this.PianoRoll.Controls.Add(this.HScrollBar);
            this.PianoRoll.Controls.Add(this.panel2);
            this.PianoRoll.Controls.Add(this.PianoRollPositionOuterPanel);
            this.PianoRoll.Controls.Add(this.PianoRollMainOuterPanel);
            this.PianoRoll.Controls.Add(this.toolStrip1);
            this.PianoRoll.ForeColor = System.Drawing.Color.White;
            this.PianoRoll.Location = new System.Drawing.Point(200, 100);
            this.PianoRoll.Name = "PianoRoll";
            this.PianoRoll.Size = new System.Drawing.Size(1200, 800);
            this.PianoRoll.TabIndex = 2;
            this.PianoRoll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.TrackPanel_Scroll);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(1120, 200);
            this.vScrollBar1.Maximum = 2200;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(25, 500);
            this.vScrollBar1.TabIndex = 5;
            this.vScrollBar1.Value = 1200;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            this.vScrollBar1.ValueChanged += new System.EventHandler(this.vScrollBar1_ValueChanged);
            // 
            // HScrollBar
            // 
            this.HScrollBar.Location = new System.Drawing.Point(200, 720);
            this.HScrollBar.Maximum = 3100;
            this.HScrollBar.Name = "HScrollBar";
            this.HScrollBar.Size = new System.Drawing.Size(900, 25);
            this.HScrollBar.TabIndex = 4;
            this.HScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HScrollBar_Scroll);
            this.HScrollBar.ValueChanged += new System.EventHandler(this.HScrollBar_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.PianoRollPitchInnerPanel);
            this.panel2.Location = new System.Drawing.Point(100, 200);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(70, 500);
            this.panel2.TabIndex = 3;
            // 
            // PianoRollPitchInnerPanel
            // 
            this.PianoRollPitchInnerPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.PianoRollPitchInnerPanel.Location = new System.Drawing.Point(0, 0);
            this.PianoRollPitchInnerPanel.Name = "PianoRollPitchInnerPanel";
            this.PianoRollPitchInnerPanel.Size = new System.Drawing.Size(71, 3900);
            this.PianoRollPitchInnerPanel.TabIndex = 5;
            this.PianoRollPitchInnerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.InnerPanel_Paint);
            // 
            // PianoRollPositionOuterPanel
            // 
            this.PianoRollPositionOuterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.PianoRollPositionOuterPanel.Controls.Add(this.PianoRollPositionInnerPanel);
            this.PianoRollPositionOuterPanel.Location = new System.Drawing.Point(200, 100);
            this.PianoRollPositionOuterPanel.Name = "PianoRollPositionOuterPanel";
            this.PianoRollPositionOuterPanel.Size = new System.Drawing.Size(900, 70);
            this.PianoRollPositionOuterPanel.TabIndex = 2;
            // 
            // PianoRollPositionInnerPanel
            // 
            this.PianoRollPositionInnerPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.PianoRollPositionInnerPanel.Location = new System.Drawing.Point(0, 0);
            this.PianoRollPositionInnerPanel.Name = "PianoRollPositionInnerPanel";
            this.PianoRollPositionInnerPanel.Size = new System.Drawing.Size(3429, 75);
            this.PianoRollPositionInnerPanel.TabIndex = 4;
            this.PianoRollPositionInnerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.InnerPanel_Paint);
            // 
            // PianoRollMainOuterPanel
            // 
            this.PianoRollMainOuterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.PianoRollMainOuterPanel.Controls.Add(this.PianoRollMainInnerPanel);
            this.PianoRollMainOuterPanel.ForeColor = System.Drawing.Color.White;
            this.PianoRollMainOuterPanel.Location = new System.Drawing.Point(200, 200);
            this.PianoRollMainOuterPanel.Name = "PianoRollMainOuterPanel";
            this.PianoRollMainOuterPanel.Size = new System.Drawing.Size(900, 500);
            this.PianoRollMainOuterPanel.TabIndex = 1;
            // 
            // PianoRollMainInnerPanel
            // 
            this.PianoRollMainInnerPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.PianoRollMainInnerPanel.Location = new System.Drawing.Point(0, 0);
            this.PianoRollMainInnerPanel.Name = "PianoRollMainInnerPanel";
            this.PianoRollMainInnerPanel.Size = new System.Drawing.Size(4800, 3600);
            this.PianoRollMainInnerPanel.TabIndex = 5;
            this.PianoRollMainInnerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.InnerPanel_Paint);
            this.PianoRollMainInnerPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PianoRollMainInnerPanel_MouseDown);
            this.PianoRollMainInnerPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PianoRollMainInnerPanel_MouseMove);
            this.PianoRollMainInnerPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PianoRollMainInnerPanel_MouseUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PencilMode,
            this.SelectRegionMode,
            this.PlayMode,
            this.StopMode});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1200, 32);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // PencilMode
            // 
            this.PencilMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PencilMode.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PencilMode.Image = ((System.Drawing.Image)(resources.GetObject("PencilMode.Image")));
            this.PencilMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PencilMode.Name = "PencilMode";
            this.PencilMode.Size = new System.Drawing.Size(63, 29);
            this.PencilMode.Text = "Pencil";
            this.PencilMode.Click += new System.EventHandler(this.PencilMode_Click);
            // 
            // SelectRegionMode
            // 
            this.SelectRegionMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SelectRegionMode.ForeColor = System.Drawing.Color.Black;
            this.SelectRegionMode.Image = ((System.Drawing.Image)(resources.GetObject("SelectRegionMode.Image")));
            this.SelectRegionMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SelectRegionMode.Name = "SelectRegionMode";
            this.SelectRegionMode.Size = new System.Drawing.Size(122, 29);
            this.SelectRegionMode.Text = "SelectRegion";
            this.SelectRegionMode.Click += new System.EventHandler(this.SelectRegionMode_Click);
            // 
            // PlayMode
            // 
            this.PlayMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PlayMode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.PlayMode.Image = ((System.Drawing.Image)(resources.GetObject("PlayMode.Image")));
            this.PlayMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PlayMode.Name = "PlayMode";
            this.PlayMode.Size = new System.Drawing.Size(48, 29);
            this.PlayMode.Text = "Play";
            this.PlayMode.Click += new System.EventHandler(this.PlayMode_Click);
            // 
            // StopMode
            // 
            this.StopMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StopMode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.StopMode.Image = ((System.Drawing.Image)(resources.GetObject("StopMode.Image")));
            this.StopMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StopMode.Name = "StopMode";
            this.StopMode.Size = new System.Drawing.Size(54, 29);
            this.StopMode.Text = "Stop";
            this.StopMode.Click += new System.EventHandler(this.StopMode_Click);
            // 
            // WaveLoadFile
            // 
            this.WaveLoadFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.WaveLoadFile.Location = new System.Drawing.Point(250, 50);
            this.WaveLoadFile.Name = "WaveLoadFile";
            this.WaveLoadFile.Size = new System.Drawing.Size(150, 60);
            this.WaveLoadFile.TabIndex = 0;
            this.WaveLoadFile.Text = "WaveLoadFile";
            this.WaveLoadFile.UseVisualStyleBackColor = false;
            this.WaveLoadFile.Click += new System.EventHandler(this.WaveLoadFile_Click);
            // 
            // SoundPlay
            // 
            this.SoundPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.SoundPlay.Location = new System.Drawing.Point(51, 50);
            this.SoundPlay.Name = "SoundPlay";
            this.SoundPlay.Size = new System.Drawing.Size(150, 60);
            this.SoundPlay.TabIndex = 1;
            this.SoundPlay.Text = "SoundPlay";
            this.SoundPlay.UseVisualStyleBackColor = false;
            this.SoundPlay.Click += new System.EventHandler(this.SoundPlay_Click);
            // 
            // WavOuterPanel
            // 
            this.WavOuterPanel.AutoScroll = true;
            this.WavOuterPanel.Controls.Add(this.GraphViewPanel);
            this.WavOuterPanel.Location = new System.Drawing.Point(50, 142);
            this.WavOuterPanel.Name = "WavOuterPanel";
            this.WavOuterPanel.Size = new System.Drawing.Size(944, 530);
            this.WavOuterPanel.TabIndex = 3;
            // 
            // GraphViewPanel
            // 
            this.GraphViewPanel.BackColor = System.Drawing.Color.MidnightBlue;
            this.GraphViewPanel.Location = new System.Drawing.Point(0, 0);
            this.GraphViewPanel.Name = "GraphViewPanel";
            this.GraphViewPanel.Size = new System.Drawing.Size(2000, 500);
            this.GraphViewPanel.TabIndex = 2;
            this.GraphViewPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.GraphViewPanel_Scroll);
            this.GraphViewPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GraphViewPanel_Paint);
            this.GraphViewPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GraphViewPanel_MouseDown);
            this.GraphViewPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GraphViewPanel_MouseUp);
            // 
            // WavePanel
            // 
            this.WavePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.WavePanel.Controls.Add(this.PlottingRateValue);
            this.WavePanel.Controls.Add(this.WavePlot);
            this.WavePanel.Controls.Add(this.SaveFileButton);
            this.WavePanel.Controls.Add(this.SampleRateLabel);
            this.WavePanel.Controls.Add(this.WaveBPSLabel);
            this.WavePanel.Controls.Add(this.WavOuterPanel);
            this.WavePanel.Controls.Add(this.SoundPlay);
            this.WavePanel.Controls.Add(this.WaveLoadFile);
            this.WavePanel.Location = new System.Drawing.Point(200, 100);
            this.WavePanel.Name = "WavePanel";
            this.WavePanel.Size = new System.Drawing.Size(1200, 800);
            this.WavePanel.TabIndex = 3;
            this.WavePanel.Visible = false;
            this.WavePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.WavePanel_Paint);
            // 
            // PlottingRateValue
            // 
            this.PlottingRateValue.Location = new System.Drawing.Point(864, 66);
            this.PlottingRateValue.Name = "PlottingRateValue";
            this.PlottingRateValue.Size = new System.Drawing.Size(100, 28);
            this.PlottingRateValue.TabIndex = 8;
            this.PlottingRateValue.Text = "110";
            // 
            // WavePlot
            // 
            this.WavePlot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.WavePlot.Location = new System.Drawing.Point(677, 50);
            this.WavePlot.Name = "WavePlot";
            this.WavePlot.Size = new System.Drawing.Size(150, 60);
            this.WavePlot.TabIndex = 7;
            this.WavePlot.Text = "WavePlot";
            this.WavePlot.UseVisualStyleBackColor = false;
            this.WavePlot.Click += new System.EventHandler(this.WavePlot_Click);
            // 
            // SaveFileButton
            // 
            this.SaveFileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.SaveFileButton.Location = new System.Drawing.Point(494, 50);
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.Size = new System.Drawing.Size(150, 60);
            this.SaveFileButton.TabIndex = 6;
            this.SaveFileButton.Text = "SaveFile";
            this.SaveFileButton.UseVisualStyleBackColor = false;
            this.SaveFileButton.Click += new System.EventHandler(this.SaveFileButton_Click);
            // 
            // SampleRateLabel
            // 
            this.SampleRateLabel.AutoSize = true;
            this.SampleRateLabel.Location = new System.Drawing.Point(444, 80);
            this.SampleRateLabel.Name = "SampleRateLabel";
            this.SampleRateLabel.Size = new System.Drawing.Size(18, 18);
            this.SampleRateLabel.TabIndex = 5;
            this.SampleRateLabel.Text = "0";
            // 
            // WaveBPSLabel
            // 
            this.WaveBPSLabel.AutoSize = true;
            this.WaveBPSLabel.Location = new System.Drawing.Point(444, 50);
            this.WaveBPSLabel.Name = "WaveBPSLabel";
            this.WaveBPSLabel.Size = new System.Drawing.Size(18, 18);
            this.WaveBPSLabel.TabIndex = 4;
            this.WaveBPSLabel.Text = "0";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1578, 1050);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.PianoRoll);
            this.Controls.Add(this.TrackPanel);
            this.Controls.Add(this.WavePanel);
            this.Name = "MainForm";
            this.Text = "f";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.TrackPanel.ResumeLayout(false);
            this.PianoRoll.ResumeLayout(false);
            this.PianoRoll.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.PianoRollPositionOuterPanel.ResumeLayout(false);
            this.PianoRollMainOuterPanel.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.WavOuterPanel.ResumeLayout(false);
            this.WavePanel.ResumeLayout(false);
            this.WavePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton FileLoadButton;
        private System.Windows.Forms.ToolStripButton TrackButton;
        private System.Windows.Forms.ToolStripButton PianoRollButton;
        private System.Windows.Forms.ToolStripButton WaveButton;
        private System.Windows.Forms.Panel TrackPanel;
        private System.Windows.Forms.Panel OuterPanel;
        private System.Windows.Forms.Panel PianoRoll;
        private System.Windows.Forms.Button WaveLoadFile;
        private System.Windows.Forms.Button SoundPlay;
        private System.Windows.Forms.Panel WavOuterPanel;
        private System.Windows.Forms.Panel GraphViewPanel;
        private System.Windows.Forms.Panel WavePanel;
        private System.Windows.Forms.Label WaveBPSLabel;
        private System.Windows.Forms.Label SampleRateLabel;
        private System.Windows.Forms.Button SaveFileButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton PencilMode;
        private System.Windows.Forms.ToolStripButton SelectRegionMode;
        private System.Windows.Forms.ToolStripButton PlayMode;
        private System.Windows.Forms.Panel PianoRollMainOuterPanel;
        private System.Windows.Forms.ToolStripButton StopMode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel PianoRollPositionOuterPanel;
        private System.Windows.Forms.Panel PianoRollPitchInnerPanel;
        private System.Windows.Forms.Panel PianoRollMainInnerPanel;
        private System.Windows.Forms.Panel PianoRollPositionInnerPanel;
        private System.Windows.Forms.HScrollBar HScrollBar;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Button WavePlot;
        private System.Windows.Forms.TextBox PlottingRateValue;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

