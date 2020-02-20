using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using _0503_TeamProjectMidiWav.View;

namespace booq
{
    public sealed partial class Form1 : Form
    {
        public PianoRoll gridForm;
        public WaveGraph wGraph;
        public M_MidModel mMid;
        public C_MidControl cMid;

        static int tCount = 1;

        uint num_midi_devices;
        HMIDIIN handle;
        UIntPtr device_ID;
        MIDIINCAPS[] formDevices;
        MidiOutCaps formCap;

        public Form1()
        {
            InitializeComponent();
            IsMdiContainer = true;

            mMid = new M_MidModel();
            cMid = new C_MidControl();
            formCap = new MidiOutCaps();

            gridForm = new PianoRoll();
            gridForm.MdiParent = this;
            //FormBorderStyle = FormBorderStyle.None;
            //WindowState = FormWindowState.Maximized;

            wGraph = new WaveGraph();
            wGraph.MdiParent = this;

            num_midi_devices = M_MidModel.midiInGetNumDevs();
            if (num_midi_devices == 0)
            {
                //Console.Write("Please connect MIDI device and try again.\nPress any key...");
                //Console.ReadLine();
                //Environment.Exit(1);
            }
            else
            {
                handle = new HMIDIIN();
                formDevices = new MIDIINCAPS[num_midi_devices];
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 실행취소ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (gridForm.Visible == false)
            {
                gridForm.Visible = true;
                TrackPanel.Visible = false;
            }
            else
            {
                gridForm.Visible = false;
            }
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {

        }

        private void 창모드XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void 끝내기XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(exitCode: 0); 
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            num_midi_devices = M_MidModel.midiInGetNumDevs();

            if (num_midi_devices == 0)
            {
                //Console.Write("Please connect MIDI device and try again.\nPress any key...");
                //Console.ReadLine();
                //Environment.Exit(1);
            }
            else
            {
                handle = new HMIDIIN();
                formDevices = new MIDIINCAPS[num_midi_devices];
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            C_MidControl.res = M_MidModel.midiOutGetDevCaps(0, ref formCap, (UInt32)Marshal.SizeOf(formCap));
            M_MidModel.midiInGetDevCaps(UIntPtr.Zero, out formDevices[0], (UInt32)Marshal.SizeOf(typeof(MIDIINCAPS)));
            device_ID = UIntPtr.Zero;
            M_MidModel.midiInOpen(out handle, device_ID, C_MidControl.callback, (UIntPtr)0);
            M_MidModel.midiInStart(handle);
            C_MidControl.res = M_MidModel.midiOutOpen(ref C_MidControl.ohandle, 0, null, 0, 0);
        }

        private void toolStripButton7_Click_1(object sender, EventArgs e)
        {
            M_MidModel.midiInStop(handle);
            M_MidModel.midiInClose(handle);
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {

        }

        private void 창ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            if (TrackPanel.Visible == false)
            {
                gridForm.Visible = false;
                TrackPanel.Visible = true;
            }
            else
            {
                TrackPanel.Visible = false;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void TrackPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Panel newTrackHead = new Panel();
            tCount++;
            
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            
        }

        private void patternList_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton9_Click_1(object sender, EventArgs e)
        {
            if (TrackPanel.Visible == false)
            {
                gridForm.Visible = false;
                TrackPanel.Visible = true;
            }
            else
            {
                TrackPanel.Visible = false;
            }
        }
    }
}
