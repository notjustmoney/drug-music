using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using booq.Model;
using booq;
using System.Threading;
using System.Runtime.InteropServices;

namespace booq.presenter
{
    public class MIDIPresenter
    {
        public static int ohandle = 0;
        public static int res = 0;

        MIDI_WIN32_MSDN mModel;
        MIDI_WIN32_MSDN.HMIDIIN h;
        MainForm view;
        MIDI_WIN32_MSDN.MidiOutCaps formCap;
        MIDI_WIN32_MSDN.MIDIINCAPS[] formDevices;
        uint num_midi_devices;

        public MIDIPresenter()
        {
            // 추후 수정
            ohandle = 0;
            res = 0;
            h = new MIDI_WIN32_MSDN.HMIDIIN();

            formCap = new MIDI_WIN32_MSDN.MidiOutCaps();
            num_midi_devices = MIDI_WIN32_MSDN.midiInGetNumDevs();
        }

        public MIDIPresenter(MainForm view)
        {
            ohandle = 0;
            res = 0;
            h = new MIDI_WIN32_MSDN.HMIDIIN();

            this.view = view;
        }

        private static void MidiProc(IntPtr hMidiIn, int wMsg, IntPtr dwInstance, int dwParam1, int dwParam2)
        {
            // Receive messages here
        }

        public static void callback(MIDI_WIN32_MSDN.HMIDIIN hMidiIn, MIDI_WIN32_MSDN wMsg, UIntPtr dwInstance, UIntPtr dwParam1, UIntPtr dwParam2)
        {
            if (wMsg.ToString() == "MIM_OPEN")
            {
                // Console.WriteLine("MIDI connection opened successfully");
            }
            else if (wMsg.ToString() == "MIM_DATA")
            {
                byte[] data = new byte[4];
                int highword = unchecked((short)(long)dwParam1);
                int lowword = unchecked((short)((long)dwParam1 >> 16));
                // unchecked : 오버플로 검사 안함

                data[0] = 0x90;
                data[1] = (byte)(highword >> 8);
                data[2] = (byte)(lowword & 0xff);
                uint msg = BitConverter.ToUInt32(data, 0);

                res = MIDI_WIN32_MSDN.midiOutShortMsg(ohandle, (int)msg);

                UIntPtr timestamp = dwParam2;
                //Console.WriteLine(String.Format("{0} :\n\tNote Index: {1}\n\tNote Velocity: {2}\n\tTimestamp: {3}", wMsg, data[1], data[2], timestamp));
            }
            return;
        }

        public void MIDI_Play()
        {
            res = MIDI_WIN32_MSDN.midiOutGetDevCaps(0, ref formCap, (UInt32)Marshal.SizeOf(formCap));
            res = MIDI_WIN32_MSDN.midiOutOpen(ref ohandle, 0, null, 0, 0);

            var prevTimestamp = -250;

            for (int i = 0; i < view.noteDict.Count; i++)
            {
                if (!view.noteDict[i].IsDisposed)
                {
                    byte[] data = new byte[4];
                    data[0] = 0x90;
                    data[1] = view.noteDict[i].noteLevel;
                    data[2] = 127;  // Note Volume

                    uint msg = BitConverter.ToUInt32(data, 0);
                    res = MIDI_WIN32_MSDN.midiOutShortMsg(ohandle, (int)msg);
                    var sleepTimestamp = view.noteDict[i].noteTimeStamp - prevTimestamp;
                    Thread.Sleep(sleepTimestamp);
                    prevTimestamp = view.noteDict[i].noteTimeStamp;
                }
            }
            res = MIDI_WIN32_MSDN.midiOutClose(ohandle);
        }

        public void MIDI_Play_newCode()
        {
            res = MIDI_WIN32_MSDN.midiOutGetDevCaps(0, ref formCap, (UInt32)Marshal.SizeOf(formCap));
            res = MIDI_WIN32_MSDN.midiOutOpen(ref ohandle, 0, null, 0, 0);

            //MIDI_Model.HMIDIOUT hOut = new MIDI_Model.HMIDIOUT();
            //MIDI_Model.MidiOutProc mOutProc = new MIDI_Model.MidiOutProc(hOut);

            for (int i = 0; i <view.noteDict.Count; i++)
            {
                byte[] data = new byte[4];
                data[0] = 0x90;
                data[1] = view.noteDict[i].noteLevel;
                data[2] = 127;  // Note Volume

                uint msg = BitConverter.ToUInt32(data, 0);
                res = MIDI_WIN32_MSDN.midiOutShortMsg(ohandle, (int)msg);
            }
            res = MIDI_WIN32_MSDN.midiOutClose(ohandle);
        }

        public void MIDI_Stop()
        {

        }

        public void MIDI_ChangeChannel()
        {

        }
    }
}
