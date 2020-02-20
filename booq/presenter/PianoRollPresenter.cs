using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace booq.presenter
{
    public class PianoRollPresenter
    {
        private MainForm view;

        public enum MouseMode
        {
            NONE = 0,
            PENCIL_MODE = 1,
            SELECT_REGION_MODE = 2,
            SERIAL_PAINT_MODE = 3
        }

        public PianoRollPresenter(MainForm view)
        {
            this.view = view;
        }

    }
}
