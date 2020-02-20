using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace booq.Model
{
    public class MIDI_WIN32_MSDN
    {
        /// Win32 docs : https://docs.microsoft.com/ko-kr/windows/desktop/Multimedia/musical-instrument-digital-interface--midi
        /// Reference :  https://docs.microsoft.com/ko-kr/windows/desktop/Multimedia/midi-reference
        /// All structures and methods about MSDN Windows Multimedia System API
        
        #region Structures   

        /// <summary>
        /// The MIDIOUTCAPS structure describes the capabilities of a MIDI output device.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MidiOutCaps
        {
            public UInt16 wMid;             // Manufacturer identifier of the device driver for the MIDI output device. 
            public UInt16 wPid;             // Product identifier of the MIDI output device.
            public UInt32 vDriverVersion;   // Version number of the device driver for the MIDI output device.
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public String szPname;          // Product name in a null-terminated string.
            public UInt16 wTechnology;      // Type of the MIDI output device.
            public UInt16 wVoices;          // Number of voices supported by an internal synthesizer device.
            public UInt16 wNotes;           // Maximum number of simultaneous notes that can be played by an internal synthesizer device.
            public UInt16 wChannelMask;     // Channels that an internal synthesizer device responds to, 
                                            // where the least significant bit refers to channel 0 
                                            // and the most significant bit to channel 15.
            public UInt32 dwSupport;        // Optional functionality supported by the device.
        }

        /// <summary>
        /// The MIDIINCAPS structure describes the capabilities of a MIDI input device.
        /// </summary>

        [StructLayout(LayoutKind.Sequential)]
        public struct MIDIINCAPS
        {
            public UInt16 wMid;             // Manufacturer identifier of the device driver for the MIDI input device.
            public UInt16 wPid;             // Product identifier of the MIDI input device.
            public UInt32 vDriverVersion;   // Version number of the device driver for the MIDI input device.
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] 
            public String szPname;          // Product name in a null-terminated string.
            public UInt32 dwSupport;        // Reserved; must be zero.
        }

        /// <summary>
        /// The MIDIHDR structure defines the header used to identify a MIDI system-exclusive or stream buffer.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MIDIHDR
        {
            public IntPtr lpData;       // Pointer to MIDI data.
            public int dwBufferLength;  // Size of the buffer.
            public int dwBytesRecorded; // Actual amount of data in the buffer. 
                                        // This value should be less than or equal to the value given in the dwBufferLength member.
            public IntPtr dwUser;       // Custom user data.
            public int dwFlags;         // Flags giving information about the buffer.
            public IntPtr lpNext;       // Reserved; do not use.
            public IntPtr reserved;     // Reserved; do not use.
            public int dwOffset;        // Offset into the buffer when a callback is performed. 
                                        // (This callback is generated because the MEVT_F_CALLBACK flag is set in the dwEvent member of the MIDIEVENT structure.) 
                                        // This offset enables an application to determine which event caused the callback.

            //public IntPtr dwReserved;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public int[] reservedArray; // 
        }
        #endregion

        #region MIDI_Constants

        public const UInt32 MAXPNAMELEN = 32;

        /// <summary>
        /// Handling Constants about MIDI Error Messages
        /// </summary> 
        public enum MMRESULT : uint
        {
            // General return codes.
            MMSYSERR_BASE = 0,
            MMSYSERR_NOERROR = MMSYSERR_BASE + 0,
            MMSYSERR_ERROR = MMSYSERR_BASE + 1,
            MMSYSERR_BADDEVICEID = MMSYSERR_BASE + 2,
            MMSYSERR_NOTENABLED = MMSYSERR_BASE + 3,
            MMSYSERR_ALLOCATED = MMSYSERR_BASE + 4,
            MMSYSERR_INVALHANDLE = MMSYSERR_BASE + 5,
            MMSYSERR_NODRIVER = MMSYSERR_BASE + 6,
            MMSYSERR_NOMEM = MMSYSERR_BASE + 7,
            MMSYSERR_NOTSUPPORTED = MMSYSERR_BASE + 8,
            MMSYSERR_BADERRNUM = MMSYSERR_BASE + 9,
            MMSYSERR_INVALFLAG = MMSYSERR_BASE + 10,
            MMSYSERR_INVALPARAM = MMSYSERR_BASE + 11,
            MMSYSERR_HANDLEBUSY = MMSYSERR_BASE + 12,
            MMSYSERR_INVALIDALIAS = MMSYSERR_BASE + 13,
            MMSYSERR_BADDB = MMSYSERR_BASE + 14,
            MMSYSERR_KEYNOTFOUND = MMSYSERR_BASE + 15,
            MMSYSERR_READERROR = MMSYSERR_BASE + 16,
            MMSYSERR_WRITEERROR = MMSYSERR_BASE + 17,
            MMSYSERR_DELETEERROR = MMSYSERR_BASE + 18,
            MMSYSERR_VALNOTFOUND = MMSYSERR_BASE + 19,
            MMSYSERR_NODRIVERCB = MMSYSERR_BASE + 20,
            MMSYSERR_MOREDATA = MMSYSERR_BASE + 21,
            MMSYSERR_LASTERROR = MMSYSERR_BASE + 21,

            // MIDI-specific return codes.
            MIDIERR_BASE = 64,
            MIDIERR_UNPREPARED = MIDIERR_BASE + 0,
            MIDIERR_STILLPLAYING = MIDIERR_BASE + 1,
            MIDIERR_NOMAP = MIDIERR_BASE + 2,
            MIDIERR_NOTREADY = MIDIERR_BASE + 3,
            MIDIERR_NODEVICE = MIDIERR_BASE + 4,
            MIDIERR_INVALIDSETUP = MIDIERR_BASE + 5,
            MIDIERR_BADOPENMODE = MIDIERR_BASE + 6,
            MIDIERR_DONT_CONTINUE = MIDIERR_BASE + 7,
            MIDIERR_LASTERROR = MIDIERR_BASE + 7
        }

        /// <summary>
        /// Flags passed to midiInOpen() and midiOutOpen().
        /// </summary>
        public enum MidiOpenFlags : uint
        {
            CALLBACK_TYPEMASK = 0x70000,
            CALLBACK_NULL = 0x00000,
            CALLBACK_WINDOW = 0x10000,
            CALLBACK_TASK = 0x20000,
            CALLBACK_FUNCTION = 0x30000,
            CALLBACK_THREAD = CALLBACK_TASK,
            CALLBACK_EVENT = 0x50000,
            MIDI_IO_STATUS = 0x00020
        }

        /// <summary>
        /// "Midi Out Messages", passed to wMsg param of MidiOutProc.
        /// </summary>
        public enum MidiOutMessage : uint
        {
            MOM_OPEN = 0x3C7,
            MOM_CLOSE = 0x3C8,
            MOM_DONE = 0x3C9
        }

        /// <summary>
        /// "Midi In Messages", passed to wMsg param of MidiInProc.
        /// </summary>
        public enum MidiInMessage : uint
        {
            MIM_OPEN = 0x3C1,
            MIM_CLOSE = 0x3C2,
            MIM_DATA = 0x3C3,
            MIM_LONGDATA = 0x3C4,
            MIM_ERROR = 0x3C5,
            MIM_LONGERROR = 0x3C6,
            MIM_MOREDATA = 0x3CC
        }

        #endregion

        #region MIDI_HANDLE

        /// <summary>
        /// Win32 handle for a MIDI output device.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct HMIDIOUT
        {
            public IntPtr handle;
        }

        /// <summary>
        /// Win32 handle for a MIDI input device.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct HMIDIIN
        {
            public IntPtr handle;
        }
        #endregion

        #region MIDI_IN_METHODS

        /// <summary>
        /// Returns the number of MIDI input devices on this system.
        /// </summary>
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern uint midiInGetNumDevs();

        /// <summary>
        /// Fills in the capabilities struct for a specific input device.
        /// </summary>
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern MMRESULT midiInGetDevCaps(UIntPtr uDeviceID, out MIDIINCAPS caps,
        UInt32 cbMidiInCaps);

        /// <summary>
        /// Opens a MIDI input device.
        /// </summary>
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern MMRESULT midiInOpen(out HMIDIIN lphMidiIn, UIntPtr uDeviceID, MidiInProc dwCallback, UIntPtr dwCallbackInstance, MidiOpenFlags dwFlags);

        public static MMRESULT midiInOpen(out HMIDIIN lphMidiIn, UIntPtr uDeviceID, MidiInProc dwCallback, UIntPtr dwCallbackInstance)
        {
            return midiInOpen(out lphMidiIn, uDeviceID, dwCallback, dwCallbackInstance,
                dwCallback == null ? MidiOpenFlags.CALLBACK_NULL : MidiOpenFlags.CALLBACK_FUNCTION);
        }

        /// <summary>
        /// Starts input on a MIDI input device.
        /// </summary>
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern MMRESULT midiInStart(HMIDIIN hMidiIn);

        /// <summary>
        /// Stops input on a MIDI input device.
        /// </summary>
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern MMRESULT midiInStop(HMIDIIN hMidiIn);


        /// <summary>
        /// Resets input on a MIDI input device.
        /// </summary>
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern MMRESULT midiInReset(HMIDIIN hMidiIn);

        /// <summary>
        /// Closes a MIDI input device.
        /// </summary>
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern MMRESULT midiInClose(HMIDIIN hMidiIn);

        /// <summary>
        /// Send a buffer to and input device in order to receive SysEx messages.
        /// </summary>
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern MMRESULT midiInAddBuffer(HMIDIIN hMidiIn, IntPtr lpMidiInHdr, UInt32 cbMidiInHdr);

        /// <summary>
        /// Prepare an input buffer before passing to midiInAddBuffer.
        /// </summary>
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern MMRESULT midiInPrepareHeader(HMIDIIN hMidiIn, IntPtr headerPtr, UInt32 cbMidiInHdr);

        /// <summary>
        /// Clean up preparation performed by midiInPrepareHeader.
        /// </summary>
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern MMRESULT midiInUnprepareHeader(HMIDIIN hMidiIn, IntPtr headerPtr, UInt32 cbMidiInHdr);

        /// <summary>
        /// Callback invoked when a MIDI event is received from an input device.
        /// </summary>
        public delegate void MidiInProc(HMIDIIN hMidiIn, MidiInMessage wMsg, UIntPtr dwInstance, UIntPtr dwParam1, UIntPtr dwParam2);

        public delegate void MidiCallBack(int handle, int msg, int instance, int param1, int param2);

        #endregion

        #region MIDI_OUT_METHODS

        /// <summary>
        /// Callback invoked when a MIDI output device is opened, closed, or finished with a buffer.
        /// </summary>
        public delegate void MidiOutProc(HMIDIOUT hmo, MidiOutMessage wMsg, UIntPtr dwInstance,
            UIntPtr dwParam1, UIntPtr dwParam2);


        /// <summary>
        /// Returns the number of MIDI output devices on this system.
        /// </summary>
        [DllImport("winmm.dll")]
        public static extern int midiOutGetNumDevs();

        /// <summary>
        /// Fills in the capabilities struct for a specific output device.
        /// </summary>
        [DllImport("winmm.dll")]
        public static extern int midiOutGetDevCaps(Int32 uDeviceID,
           ref MidiOutCaps lpMidiOutCaps, UInt32 cbMidiOutCaps);

        /// <summary>
        /// Opens a MIDI output device.
        /// </summary>
        ///         
        [DllImport("winmm.dll", SetLastError = true)]
        private static extern MMRESULT midiOutOpen(out HMIDIOUT lphmo, UIntPtr uDeviceID,
            MidiOutProc dwCallback, UIntPtr dwCallbackInstance, MidiOpenFlags dwFlags);

        public static MMRESULT midiOutOpen(out HMIDIOUT lphmo, UIntPtr uDeviceID, MidiOutProc dwCallback, UIntPtr dwCallbackInstance)
        {
            return midiOutOpen(out lphmo, uDeviceID, dwCallback, dwCallbackInstance,
                dwCallback == null ? MidiOpenFlags.CALLBACK_NULL : MidiOpenFlags.CALLBACK_FUNCTION & MidiOpenFlags.MIDI_IO_STATUS);
        }

        /// <summary>
        /// Sends a short MIDI message (anything but sysex or stream).
        /// </summary>
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern MMRESULT midiOutShortMsg(HMIDIOUT hmo, UInt32 dwMsg);

        /// <summary>
        /// Sends a long MIDI message (sysex).
        /// </summary>
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern MMRESULT midiOutLongMsg(HMIDIOUT hmo, IntPtr lpMidiOutHdr, UInt32 cbMidiOutHdr);

        /// <summary>
        /// Closes a MIDI output device.
        /// </summary>
        [DllImport("winmm.dll")]
        public static extern int midiOutClose(int handle);

        /// <summary>
        /// Turns off all notes and sustains on a MIDI output device.
        /// </summary>
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern MMRESULT midiOutReset(HMIDIOUT hmo);

        /// <summary>
        /// Prepares a long message for sending
        /// </summary>
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern MMRESULT midiOutPrepareHeader(HMIDIOUT hmo, IntPtr lpMidiOutHdr, UInt32 cbMidiOutHdr);

        /// <summary>
        /// Frees header space after sending long message
        /// </summary>
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern MMRESULT midiOutUnprepareHeader(HMIDIOUT hmo, IntPtr lpMidiOutHdr, UInt32 cbMidiOutHdr);

        #endregion

        #region MIDI_STREAM_METHODS

        /// <summary>
        /// The midiStreamOut function plays or queues a stream (buffer) of MIDI data to a MIDI output device.
        /// </summary>
        /// 
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern MMRESULT midiStreamOut(HMIDISTRM hMidiStream, LPMIDIHDR lpMidiHdr, UINT cbMidiHdr);
        
        #endregion

        #region PitchHeightName Constants

        public static readonly String[] PitchHeightName = { "B9", "A#9", "A9", "G#9", "G9", "F#9", "F9", "E9", "D#9", "D9", "C#9", "C9",
            "B8", "A#8", "A8", "G#8", "G8", "F#8", "F8", "E8", "D#8", "D8", "C#8", "C8", "B7", "A#7", "A7", "G#7", "G7",
            "F#7", "F7", "E7", "D#7", "D7", "C#7", "C7", "B6", "A#6", "A6", "G#6", "G6", "F#6", "F6", "E6", "D#6", "D6",
            "C#6", "C6", "B5", "A#5", "A5", "G#5", "G5", "F#5", "F5", "E5", "D#5", "D5", "C#5", "C5", "B4", "A#4", "A4",
            "G#4", "G4", "F#4", "F4", "E4", "D#4", "D4", "C#4", "C4", "B3", "A#3", "A3", "G#3", "G3", "F#3", "F3", "E3",
            "D#3", "D3", "C#3", "C3", "B2", "A#2", "A2", "G#2", "G2", "F#2", "F2", "E2", "D#2", "D2", "C#2", "C2", "B1",
            "A#1", "A1", "G#1", "G1", "F#1", "F1", "E1", "D#1", "D1", "C#1", "C1", "B0", "A#0", "A0", "G#0", "G0",
            "F#0", "F0", "E0", "D#0", "D0", "C#0", "C0" };
        #endregion

        #region GeneralMIDI_Instruments Constants

        /// <summary>
        /// MIDI instrument list provided by 'General MIDI'
        /// </summary>
        public readonly String[] instrumentNameLists = {
            "0 	 Piano 1	", "1   Piano 2     ", "2   Piano 3     ", "3   Honky-tonk  ", "4   E.Piano 1   ",
            "5   E.Piano 2   ", "6   Harpsichord ", "7   Clav.       ", "8   Celesta     ", "9   Glockenspiel",
            "10   Music Box   ", "11   Vibraphone  ", "12   Marimba    ", "13   Xylophone   ", "14   Tubular-bell",
            "15   Santur      ", "16   Organ 1     ", "17   Organ 2     ", "18   Organ 3     ", "19   Church Org.1",
            "20   Reed Organ  ", "21   Accordion Fr", "22   Harmonica   ", "23   Bandoneon   ", "24   Nylon-str.Gt",
            "25   Steel-str.Gt", "26   Jazz Gt.    ", "27   Clean Gt.   ", "28   Muted Gt.   ", "29   Overdrive Gt",
            "30   DistortionGt", "31   Gt.Harmonics", "32   Acoustic Bs.", "33   Fingered Bs.", "34   Picked Bs.  ",
            "35   Fretless Bs.", "36   Slap Bass 1 ", "37   Slap Bass 2 ", "38   Synth Bass 1", "39   Synth Bass 2",
            "40   Violin      ", "41   Viola       ", "42   Cello       ", "43   Contrabass  ", "44   Tremolo Str ",
            "45   PizzicatoStr", "46   Harp        ", "47   Timpani     ", "48   Strings     ", "49   Slow Strings",
            "50   Syn.Strings1", "51   Syn.Strings2", "52   Choir Aahs  ", "53   Voice Oohs  ", "54   SynVox      ",
            "55   OrchestraHit", "56   Trumpet     ", "57   Trombone    ", "58   Tuba        ", "59   MutedTrumpet",
            "60   French Horns", "61   Brass 1     ", "62   Synth Brass1", "63   Synth Brass2", "64   Soprano Sax ",
            "65   Alto Sax    ", "66   Tenor Sax   ", "67   Baritone Sax", "68   Oboe        ", "69   English Horn",
            "70   Bassoon     ", "71   Clarinet    ", "72   Piccolo     ", "73   Flute       ", "74   Recorder    ",
            "75   Pan Flute   ", "76   Bottle Blow ", "77   Shakuhachi  ", "78   Whistle     ", "79   Ocarina     ",
            "80   Square Wave ", "81   Saw Wave    ", "82   Syn.Calliope", "83   Chiffer Lead", "84   Charang     ",
            "85   Solo Vox    ", "86   5th Saw Wave", "87   Bass & Lead ", "88   Fantasia    ", "89   Warm Pad    ",
            "90   Polysynth   ", "91   Space Voice ", "92   Bowed Glass ", "93   Metal Pad   ", "94   Halo Pad    ",
            "95   Sweep Pad   ", "96   Ice Rain    ", "97   Soundtrack  ", "98   Crystal     ", "99   Atmosphere  ",
            "100   Brightness  ", "101   Goblin      ", "102   Echo Drops  ", "103   Star Theme  ",
            "104   Sitar       ", "105   Banjo       ", "106   Shamisen    ", "107   Koto        ",
            "108   Kalimba     ", "109   Bagpipe     ", "110   Fiddle      ", "111   Shanai      ",
            "112   Tinkle Bell ", "113   Agogo       ", "114   Steel Drums ", "115   Woodblock   ",
            "116   Taiko       ", "117   Melo. Tom 1 ", "118   Synth Drum  ", "119   Reverse Cym.",
            "120   Gt.FretNoise", "121   Breath Noise", "122   Seashore    ", "123   Bird        ",
            "124   Telephone 1 ", "125   Helicopter  ", "126   Applause    ", "127   Gun Shot    " };

        #endregion

        #region GeneralMIDI_DrumPercussion Constants / Not Implemented
        #endregion

        // Drum Constatnts Add
    }
}
