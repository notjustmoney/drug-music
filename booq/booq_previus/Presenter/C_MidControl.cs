using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace booq
{
    public class C_MidControl
    {
        public static int ohandle = 0;
        public static int res = 0;

        public C_MidControl()
        {
            ohandle = 0;
            res = 0;
        }

        private static void MidiProc(IntPtr hMidiIn, int wMsg, IntPtr dwInstance, int dwParam1, int dwParam2)
        {
            // Receive messages here
        }

        public static void callback(HMIDIIN hMidiIn, M_MidModel.MidiInMessage wMsg, UIntPtr dwInstance, UIntPtr dwParam1, UIntPtr dwParam2)
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

               res = M_MidModel.midiOutShortMsg(ohandle, (int)msg);

                UIntPtr timestamp = dwParam2;
                //Console.WriteLine(String.Format("{0} :\n\tNote Index: {1}\n\tNote Velocity: {2}\n\tTimestamp: {3}", wMsg, data[1], data[2], timestamp));

            }
            return;
        }
    }
}
