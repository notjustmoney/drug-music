/*
             int eCount = 0;

            C_MidControl.res = M_MidModel.midiOutGetDevCaps(0, ref formCap, (UInt32)Marshal.SizeOf(formCap));
            C_MidControl.res = M_MidModel.midiOutOpen(ref C_MidControl.ohandle, 0, null, 0, 0);

            //axisThread = new Thread(new ThreadStart(moveAxis));
            //playThread = new Thread(new ThreadStart(Run));
            /* 
            for (int i=0; i<noteDict.Count; i++)
            {
                if (!noteDict[i].IsDisposed) eCount++;
                toolStripStatusLabel4.Text = eCount.ToString();
            }

//axisThread.Start();
//playThread.Start();

var prevTimestamp = -250;

            for (int i=0; i<noteDict.Count; i++)
            {
                if (!noteDict[i].IsDisposed)
                {
                    byte[] data = new byte[4];
data[0] = 0x90;
                    data[1] = noteDict[i].noteLevel;
                    data[2] = 127;

                    uint msg = BitConverter.ToUInt32(data, 0);
C_MidControl.res = M_MidModel.midiOutShortMsg(C_MidControl.ohandle, (int) msg);
                    var sleepTimestamp = noteDict[i].noteTimeStamp - prevTimestamp;
Thread.Sleep(sleepTimestamp);
                    prevTimestamp = noteDict[i].noteTimeStamp;
                }
            }
            //pBar.Location = new Point(0, 0);
            C_MidControl.res = M_MidModel.midiOutClose(C_MidControl.ohandle);
 * 
 * * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */
