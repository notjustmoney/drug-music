using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Runtime.InteropServices;

namespace _0503_TeamProjectMidiWav
{
    public class WaveLoadPlay
    {
        [DllImport("winmm.dll")]
        public static extern long mciSendString(
            string command,
            StringBuilder returnValue,
            int returnLength,
            IntPtr winHandle); // for play sounds

    }

    public partial class Form1 : Form
    {
        SoundPlayer player = new SoundPlayer();
        
    }

}
