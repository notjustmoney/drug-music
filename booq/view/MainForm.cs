using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using booq.presenter;

namespace booq
{
    public partial class MainForm : Form
    {
        private enum PanelGridSizeConst
        {
            DEFAULT = 0,
            HORIZONTAL_SINGLE = 1,
            HORIZONTAL_DOUBLE = 2,
            HORIZONTAL_TRIPLE = 3
        }

        private enum MouseMode
        {
            NONE = 0,
            PENCIL_MODE = 1,
            SELECT_REGION_MODE = 2,
            SERIAL_PAINT_MODE = 3
        }

        WaveRead wPresenter;
        MIDIPresenter mPresenter;
        PianoRollPresenter pianoRollPresenter;
        private Graphics f, g, h; // for Piano Roll
        private Graphics wG; // for wave Graphics Ploting
        private float[] SampAvgDatas;
        private bool CanPaintWaveGraph;

        Pen whitePen = new Pen(Color.White, 1);
        Pen redPen = new Pen(Color.Red, 1);
        Pen greenPen = new Pen(Color.Green, 1);
        Pen bluePen = new Pen(Color.Blue, 1);

        private Point startPosition;
        private Point endPosition;
        private MouseMode mMode = MouseMode.PENCIL_MODE;
        private PanelGridSizeConst pp = PanelGridSizeConst.HORIZONTAL_SINGLE;
        private bool isMouseClicked = false;
        private int pKeyIdx = 0;
        public Dictionary<int, Note> noteDict = new Dictionary<int, Note>();
        private const byte NOTEPITCHMAX = 119;


        #region Form_Constructor

        public MainForm()
        {
            InitializeComponent();

            wPresenter = new WaveRead(this);
            pianoRollPresenter = new PianoRollPresenter(this);
            mPresenter = new MIDIPresenter(this);

            CanPaintWaveGraph = false;
        }
        #endregion

        #region WavePanel Properties

        public ushort bitsPerSample
        {
            get { return Convert.ToUInt16(WaveBPSLabel.Text); }
            set { WaveBPSLabel.Text = value.ToString(); }
        }

        public uint wSampleRate
        {
            get { return Convert.ToUInt16(SampleRateLabel.Text); }
            set { SampleRateLabel.Text = value.ToString(); }
        }

        #endregion

        #region MainFormEvents

        private void PianoRollPanel_ButtonClick(object sender, EventArgs e)
        {
            if (!TrackPanel.Visible)
            {
                WavePanel.Visible = false;
                PianoRoll.Visible = false;
                TrackPanel.Visible = true;
            }
            else
            {
                WavePanel.Visible = false;
                PianoRoll.Visible = false;
                TrackPanel.Visible = false;
            }
        }

        private void TrackButton_Click(object sender, EventArgs e)
        {
            if (!PianoRoll.Visible)
            {
                WavePanel.Visible = false;
                TrackPanel.Visible = false;
                PianoRoll.Visible = true;
            }
            else
            {
                WavePanel.Visible = false;
                PianoRoll.Visible = false;
                TrackPanel.Visible = false;
            }
        }

        #endregion

        #region WavePanelEvents

        private void WaveButton_Click(object sender, EventArgs e)
        {
            if (!WavePanel.Visible)
            {
                TrackPanel.Visible = false;
                PianoRoll.Visible = false;
                WavePanel.Visible = true;
            }
            else
            {
                TrackPanel.Visible = false;
                PianoRoll.Visible = false;
                WavePanel.Visible = false;
            }
        }

        private void WavePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SoundPlay_Click(object sender, EventArgs e)
        {
            wPresenter.SoundPlay();
        }

        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "WAV File|*.wav";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                string path = saveFileDialog1.FileName;
                MessageBox.Show(path);
            }
        }

        private void WaveLoadFile_Click(object sender, EventArgs e)
        {
            bool isSuccess = false;
            isSuccess = wPresenter.ReadFile(Application.StartupPath + @"\Files\Yamaha-V50-Rock-Beat-120bpm.wav");

            if (isSuccess)
            {
                wPresenter.SetViewBPS();
                wPresenter.SetViewSR();
            }
        }

        private void WavePlot_Click(object sender, EventArgs e)
        {
            CanPaintWaveGraph = true;
            GraphViewPanel.Invalidate();
        }

        private void GraphViewPanel_MouseDown(object sender, MouseEventArgs e)
        {
            startPosition = new Point(e.X, e.Y);
        }

        private void GraphViewPanel_MouseUp(object sender, MouseEventArgs e)
        {
            endPosition = new Point(e.X, e.Y);
        }

        private void GraphViewPanel_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void GraphViewPanel_Paint(object sender, PaintEventArgs e)
        {
            if (CanPaintWaveGraph)
            {
                int rate = Convert.ToInt32(PlottingRateValue.Text); // 441 = averaging rate(픽셀당 441 샘플 평균)
                int samplePlot = (wPresenter.WavFS.nOfSamples / rate) + 1;
                SampAvgDatas = new float[samplePlot];
                SampAvgDatas = wPresenter.SetViewSampleGraph(rate);

                wG = GraphViewPanel.CreateGraphics();
                Pen greenPen = new Pen(Color.Green, (float)0.5);

                int h = GraphViewPanel.Height;

                for (int i = 0; i < samplePlot; i++)
                {
                    int d = (h - (int)(SampAvgDatas[i] / 300)) / 2; // 중앙값을 평균값으로 만들어줌
                    wG.DrawLine(greenPen, (float)i / 2, d, (float)i / 2, d + (int)(SampAvgDatas[i] / 300));
                }
                wG.Dispose();
            }
        }
        #endregion

        #region PianoRollEvents

        #region PianoRollInnerPanelInitialPaints

        private void InnerPanel_Paint(object sender, PaintEventArgs e)
        {
            g = PianoRollMainInnerPanel.CreateGraphics();
            f = PianoRollPositionInnerPanel.CreateGraphics();
            h = PianoRollPitchInnerPanel.CreateGraphics();

            for (int i = 0, j = 0; i <= 130; i++, j++)
            {
                g.DrawLine(whitePen, i * 25, 0, i * 25, 25 * 128);

                if (i % 4 == 0)
                {
                    g.DrawLine(redPen, i * 25, 0, i * 25, 25 * 128);
                    f.DrawLine(whitePen, i * 25, 0, i * 25, 70);
                    if (i % 16 == 0)
                        g.DrawLine(bluePen, i * 25, 0, i * 25, 25 * 128);
                }
                if (j <= 120)
                {
                    g.DrawLine(whitePen, 0, j * 20, 25 * 128, j * 20);
                    h.DrawLine(whitePen, 0, j * 20, 70, j * 20);
                    if (j % 12 == 0)
                    {
                        g.DrawLine(greenPen, 0, j * 20, 25 * 128, j * 20);
                        h.DrawLine(greenPen, 0, j * 20, 70, j * 20);
                    }
                }
            }
            h.Dispose();
            f.Dispose();
            g.Dispose();
        }
        #endregion

        #region PianoRollPanelButtonClick

        private void PencilMode_Click(object sender, EventArgs e)
        {

        }

        private void SelectRegionMode_Click(object sender, EventArgs e)
        {

        }

        private void PlayMode_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void StopMode_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region PianoRollScrollBarEvents

        private void TrackPanel_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void HScrollBar_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        #endregion

        #region PianoRollMouseEvents

        private void PianoRollMainInnerPanel_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseClicked = true;

            if (mMode == MouseMode.PENCIL_MODE)
            {
                startPosition = new Point(e.X - e.X % 25, e.Y - e.Y % 20);
            }
            else if (mMode == MouseMode.SELECT_REGION_MODE)
            {
                // not implemented yet
                // select inner rectangle region
                Cursor = Cursors.Cross;
                startPosition = new Point(e.X, e.Y);
            }
            else if (mMode == MouseMode.SERIAL_PAINT_MODE)
            {

            }
        }

        private void PianoRollMainInnerPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mMode == MouseMode.PENCIL_MODE)
            {
                // do nothing
            }
            else if (mMode == MouseMode.SELECT_REGION_MODE)
            {
                if (isMouseClicked)
                {
                    endPosition = new Point(e.X, e.Y);
                    Rectangle rect = new Rectangle(
                        startPosition.X,
                        startPosition.Y,
                        endPosition.X - startPosition.X,
                        endPosition.Y - startPosition.Y);
                    PianoRollMainInnerPanel.Refresh();
                    g = PianoRollMainInnerPanel.CreateGraphics();
                    g.DrawRectangle(greenPen, rect);
                    g.Dispose();
                }
            }
            else if (mMode == MouseMode.SERIAL_PAINT_MODE)
            {

            }
        }

        private void PianoRollMainInnerPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseClicked = false;

            if (mMode == MouseMode.PENCIL_MODE)
            {
                Point sP = new Point(startPosition.X, startPosition.Y);
                Note n = new Note();

                n.Size = new Size(25 * (int)pp, 20);
                n.BackColor = Color.Aquamarine;
                n.Location = sP;
                n.p = sP;
                n.x = n.p.X / 25;
                n.y = n.p.Y / 20;
                n.pKey = pKeyIdx++;

                n.noteLevel = NOTEPITCHMAX;
                n.noteLevel -= (byte)n.y;
                n.noteTimeStamp = n.x * 250;
                n.noteDuration = 250;

                noteDict.Add(n.pKey, n);
                PianoRollMainInnerPanel.Controls.Add(n);

                //toolStripStatusLabel1.Text = n.noteLevel.ToString();
                //toolStripStatusLabel2.Text = n.noteTimeStamp.ToString();
                //toolStripStatusLabel3.Text = n.pKey.ToString();
            }
            else if (mMode == MouseMode.SELECT_REGION_MODE)
            {
                // not implemented yet
                // select inner rectangle region
                for (int i = 0; i < noteDict.Count; i++)
                {
                    if (noteDict[i].p.X >= startPosition.X &&
                        noteDict[i].p.X <= endPosition.X &&
                        noteDict[i].p.Y >= startPosition.Y &&
                        noteDict[i].p.Y <= endPosition.Y)
                    {
                        noteDict[i].BackColor = Color.Violet;
                    }
                }
                Cursor = Cursors.Default;
                PianoRollMainInnerPanel.Refresh();
            }
            else if (mMode == MouseMode.SERIAL_PAINT_MODE)
            {

            }
        }

        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            mPresenter.MIDI_Play();
        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            int scrollPos = vScrollBar1.Value * (-1);
            Console.WriteLine(scrollPos);
            PianoRollMainInnerPanel.Location = new Point(PianoRollMainInnerPanel.Location.X, scrollPos);
            PianoRollPitchInnerPanel.Location = new Point(PianoRollPitchInnerPanel.Location.X, scrollPos);
        }

        private void HScrollBar_ValueChanged(object sender, EventArgs e)
        {
            int scrollPos = HScrollBar.Value * (-1);
            Console.WriteLine(scrollPos);
            PianoRollMainInnerPanel.Location = new Point(scrollPos, PianoRollMainInnerPanel.Location.Y);
            PianoRollPositionInnerPanel.Location = new Point(scrollPos, PianoRollPositionInnerPanel.Location.Y);
        }

        #endregion

        #region 나중에수정



        #endregion
    }
}
