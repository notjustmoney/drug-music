﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace booq
{
    public partial class Note : UserControl
    {
        public Point p = new Point();
        public int pKey = 0;

        public byte noteLevel;
        public int noteDuration;
        public int noteTimeStamp;

        public int x;
        public int y;

        public bool isEnabled;
        public byte[] mData;

        public Note()
        {
            InitializeComponent();
            p.X = 0;
            p.Y = 0;
            isEnabled = true;
            mData = new byte[4];
        }
        
        private void Note_Load(object sender, EventArgs e)
        {

        }

        private void Note_MouseUp(object sender, MouseEventArgs e)
        {
            isEnabled = false;
            this.Dispose(true);
        }

        public void setShortMsg()
        {
            mData[0] = 0x90;
            mData[1] = noteLevel;
            mData[2] = 111;
        }
    }
}