using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace booq.Model
{
    public class MIDI_Play
    {
        public MIDI_WIN32_MSDN MIDIWin32API;
        public MIDI_WIN32_MSDN.HMIDIOUT hMIDIOUT;
        public MIDI_WIN32_MSDN.MMRESULT MMRESULT;
        public MIDI_WIN32_MSDN.MidiOutCaps MidiOutCap;
        public MIDI_WIN32_MSDN.MIDIHDR MIDIHeader;

        public MidiFileStructure MIDIFile;

        public MIDI_Play()
        {
            MIDIWin32API = new MIDI_WIN32_MSDN(); // 추후 파라미터 받는걸로 수정
        }

        public void MIDIOpenOutDevice()
        {
            hMIDIOUT = new MIDI_WIN32_MSDN.HMIDIOUT();

            /// Open the MIDI output device

            MMRESULT = MIDI_WIN32_MSDN.midiOutOpen(out hMIDIOUT, UIntPtr.Zero, null, UIntPtr.Zero);

            if (MMRESULT == MIDI_WIN32_MSDN.MMRESULT.MMSYSERR_ERROR)
            {
                Console.WriteLine("MIDI OUT OPEN ERR");
                return;
            }

            /// Before playing a MIDI file, you should use the midiOutGetDevCaps function 
            /// to determine the capabilities of the MIDI output device that is present in the system. 
            /// This function takes an address of a MIDIOUTCAPS structure, 
            /// which it fills with information about the capabilities of the given device.

            MIDI_WIN32_MSDN.midiOutGetDevCaps(0, ref MidiOutCap, (uint)Marshal.SizeOf(typeof(MIDI_WIN32_MSDN.MidiOutCaps)));
        }

        public void SetMIDIHeader()
        {
            MIDIHeader = new MIDI_WIN32_MSDN.MIDIHDR();
            MIDIHeader.dwBufferLength = Marshal.SizeOf(MIDIFile); // size는 나중에 미디파일 읽어왓을 때 실행할 사이즈만큼으로
            
        }

        public void MIDICloseOutDevice()
        {

        }

        private static void MidiProc(IntPtr hMidiIn, int wMsg, IntPtr dwInstance, int dwParam1, int dwParam2)
        {
            // Receive messages here
        }
        
        //Use one of the following techniques to pass instance data from an application to a callback function:
        //Use the dwCallbackInstance parameter of the function that opens the device driver.
        //Use the dwUser member of the MIDIHDR structure that identifies a data block being sent to a MIDI device driver.

        public static void callback(MIDI_WIN32_MSDN.HMIDIIN hMidiIn, MIDI_WIN32_MSDN wMsg, UIntPtr dwInstance, UIntPtr dwParam1, UIntPtr dwParam2)
        {
            if (wMsg.ToString() == "MIM_OPEN")
            {

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

        public void MidiOutCallback(MIDI_WIN32_MSDN.HMIDIOUT hMidiOut, MIDI_WIN32_MSDN wMsg, UIntPtr dwInstance, UIntPtr dwParam1, UIntPtr dwParam2)
        {
            if (wMsg.ToString() == "MOM_OPEN")
            {
                MIDI_WIN32_MSDN.midiOutPrepareHeader(hMidiOut, IntPtr.Zero, 65536);
            }
            else if (wMsg.ToString() == "MOM_DONE")
            {
                // do buffering (void code)
            }
            else if (wMsg.ToString() == "MOM_CLOSE")
            {
                MIDI_WIN32_MSDN.midiOutUnprepareHeader(hMidiOut, IntPtr.Zero, 65536);
            }
        }

        public void MIDI_Play_newCode()
        {
            res = MIDI_WIN32_MSDN.midiOutGetDevCaps(0, ref formCap, (UInt32)Marshal.SizeOf(formCap));
            res = MIDI_WIN32_MSDN.midiOutOpen(ref ohandle, 0, null, 0, 0);

            //MIDI_Model.HMIDIOUT hOut = new MIDI_Model.HMIDIOUT();
            //MIDI_Model.MidiOutProc mOutProc = new MIDI_Model.MidiOutProc(hOut);

            for (int i = 0; i < view.noteDict.Count; i++)
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
    }
}
