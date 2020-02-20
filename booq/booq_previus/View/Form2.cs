using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace booq
{
    public enum MouseMode
    {
        NONE = 0,
        PENCIL_MODE = 1,
        SELECT_REGION_MODE = 2,
        SERIAL_PAINT_MODE = 3
    }

    public partial class PianoRoll : Form
    {
        #region MouseEvents
        private const uint LBDOWN = 0x00000002; // 왼쪽 마우스 버튼 눌림
        private const uint LBUP = 0x00000004; // 왼쪽 마우스 버튼 떼어짐
        private const uint RBDOWN = 0x00000008; // 오른쪽 마우스 버튼 눌림
        private const uint RBUP = 0x000000010; // 오른쪽 마우스 버튼 떼어짐
        private const uint WHEEL = 0x00000800; //휠 스크롤

        [DllImport("user32.dll")] // 입력 제어
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, int dwData, int dwExtraInfo);

        [DllImport("user32.dll")] // 커서 위치 제어
        static extern int SetCursorPos(int x, int y);
        #endregion

        private enum PanelGridSizeConst
        {
            DEFAULT = 0,
            HORIZONTAL_SINGLE = 1,
            HORIZONTAL_DOUBLE = 2,
            HORIZONTAL_TRIPLE = 3
        }

        private const byte NOTEPITCHMAX = 119;

        private bool isMouseClicked = false;
        private Dictionary<int, Note> noteDict = new Dictionary<int, Note>();
        private List<int> activatedNoteIdxList = new List<int>();
        private MouseMode mMode = MouseMode.SELECT_REGION_MODE;
        private Point panelPointer;  // panelPointer = PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y));
        private Point startPosition;
        private Point endPosition;
        private Pen greenPen = new Pen(Color.Green, 2);
        private Rectangle rect;
        private Graphics g;
        private Graphics h;
        private Graphics f;
        private Graphics rectG;
        private PositionBar pBar;
        private int pKeyIdx = 0;

        private PanelGridSizeConst pp = PanelGridSizeConst.HORIZONTAL_SINGLE;

        MidiOutCaps formCap;

        public PianoRoll()
        {
            InitializeComponent();
            formCap = new MidiOutCaps();
            pBar = new PositionBar();
            InnerPanel.Controls.Add(pBar);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void InnerPanel_Paint(object sender, PaintEventArgs e)
        {
            g = this.InnerPanel.CreateGraphics();
            h = this.panel2.CreateGraphics();
            f = this.panel4.CreateGraphics();

            Pen whitePen = new Pen(Color.White, 1);
            Pen redPen = new Pen(Color.Red, 1);
            Pen greenPen = new Pen(Color.Green, 1);
            Pen bluePen = new Pen(Color.Blue, 1);

            g = InnerPanel.CreateGraphics();

            for (int i = 0, j = 0; j <= 130; i++, j++)
            {
                if (i <= 130)
                {
                    g.DrawLine(whitePen, i * 25 * (int)pp, 0, i * 25 * (int)pp, 25 * (int)pp * 128);
                    f.DrawLine(whitePen, i * 25 * (int)pp, 0, i * 25 * (int)pp, 30);
                    if (i % 4 == 0)
                    {
                        g.DrawLine(redPen, i * 25 * (int)pp, 0, i * 25 * (int)pp, 25 * (int)pp * 128);
                        if(i % 16 == 0)
                            g.DrawLine(bluePen, i * 25 * (int)pp, 0, i * 25 * (int)pp, 25 * (int)pp * 128);
                    }
                }
                g.DrawLine(whitePen, 0, j * 20, 25 * (int)pp * 128, j * 20);
                h.DrawLine(whitePen, 0, j * 20, 45, j * 20);
                if(j % 12 == 0)
                    g.DrawLine(greenPen, 0, j * 20, 25 * (int)pp * 128, j * 20);
            }

            h.Dispose();
            f.Dispose();
            g.Dispose();
        }

        private void mouseMoved(object sender, MouseEventArgs e)
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
                    rect = new Rectangle(
                        startPosition.X,
                        startPosition.Y,
                        endPosition.X - startPosition.X,
                        endPosition.Y - startPosition.Y);
                    InnerPanel.Refresh();
                    g = InnerPanel.CreateGraphics();
                    g.DrawRectangle(greenPen, rect);
                    g.Dispose();
                }
            }
            else if (mMode == MouseMode.SERIAL_PAINT_MODE)
            {

            }
        }

        private void leftMouseDown(object sender, MouseEventArgs e)
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

        private void leftMouseUp(object sender, MouseEventArgs e)
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
                InnerPanel.Controls.Add(n);

                toolStripStatusLabel1.Text = n.noteLevel.ToString();
                toolStripStatusLabel2.Text = n.noteTimeStamp.ToString();
                toolStripStatusLabel3.Text = n.pKey.ToString();
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
                InnerPanel.Refresh();
            }
            else if (mMode == MouseMode.SERIAL_PAINT_MODE)
            {

            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (pp == PanelGridSizeConst.HORIZONTAL_SINGLE)
                pp = PanelGridSizeConst.HORIZONTAL_DOUBLE;
            else if (pp == PanelGridSizeConst.HORIZONTAL_DOUBLE)
                pp = PanelGridSizeConst.HORIZONTAL_TRIPLE;
            else if (pp == PanelGridSizeConst.HORIZONTAL_TRIPLE)            
                pp = PanelGridSizeConst.HORIZONTAL_SINGLE;
            
            for (int i = 0; i < noteDict.Count; i++)
            {
                noteDict[i].Width = 25 * (int)pp;
                noteDict[i].Location = new Point(noteDict[i].p.X * (int)pp, noteDict[i].p.Y);
            }
            InnerPanel.Refresh();
            panel4.Refresh();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            mMode = MouseMode.SELECT_REGION_MODE;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            mMode = MouseMode.PENCIL_MODE;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            mMode = MouseMode.SERIAL_PAINT_MODE;

            //axisThread = new Thread(new ThreadStart(moveAxis));
            //axisThread.Start();
        }

        private void panel1_Enter(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            // play music
            //backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;

            // move trackbar
            //backgroundWorker2.DoWork += backgroundWorker2_DoWork;
            backgroundWorker2.RunWorkerAsync();
            backgroundWorker2.RunWorkerCompleted += backgroundWorker2_RunWorkerCompleted;

            // event delete
            //backgroundWorker1.DoWork -= backgroundWorker1_DoWork;
            //backgroundWorker2.DoWork -= backgroundWorker2_DoWork;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            C_MidControl.res = M_MidModel.midiOutGetDevCaps(0, ref formCap, (UInt32)Marshal.SizeOf(formCap));
            C_MidControl.res = M_MidModel.midiOutOpen(ref C_MidControl.ohandle, 0, null, 0, 0);

            var prevTimestamp = -250;

            for (int i = 0; i < noteDict.Count; i++)
            {
                if (!noteDict[i].IsDisposed)
                {
                    byte[] data = new byte[4];
                    data[0] = 0x90;
                    data[1] = noteDict[i].noteLevel;
                    data[2] = 127;

                    uint msg = BitConverter.ToUInt32(data, 0);
                    C_MidControl.res = M_MidModel.midiOutShortMsg(C_MidControl.ohandle, (int)msg);
                    var sleepTimestamp = noteDict[i].noteTimeStamp - prevTimestamp;
                    Thread.Sleep(sleepTimestamp);
                    prevTimestamp = noteDict[i].noteTimeStamp;
                }
            }
            C_MidControl.res = M_MidModel.midiOutClose(C_MidControl.ohandle);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled) toolStripStatusLabel4.Text = "Cancelled";
            else if (e.Error != null) toolStripStatusLabel4.Text = "Exception Thrown";
            else toolStripStatusLabel4.Text = "Completed";
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            int xPos = 0;
            while (backgroundWorker1.IsBusy)
            {
                pBar.Location = new Point(xPos, 0);
                Thread.Sleep(250);
                xPos += 25 * (int)pp;
            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled) toolStripStatusLabel4.Text = "Cancelled";
            else if (e.Error != null) toolStripStatusLabel4.Text = "Exception Thrown";
            else toolStripStatusLabel4.Text = "Completed";
        }
    }
}


