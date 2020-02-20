using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace booq
{
    #region Structures_Handle    
    [StructLayout(LayoutKind.Sequential)]
    public struct MidiOutCaps
    {
        public UInt16 wMid;
        public UInt16 wPid;
        public UInt32 vDriverVersion;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public String szPname;
        public UInt16 wTechnology;
        public UInt16 wVoices;
        public UInt16 wNotes;
        public UInt16 wChannelMask;
        public UInt32 dwSupport;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MIDIINCAPS
    {
        public UInt16 wMid;
        public UInt16 wPid;
        public UInt32 vDriverVersion;     // MMVERSION
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public String szPname;
        public UInt32 dwSupport;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HMIDIIN
    {
        public IntPtr handle;
    }
    #endregion

    public class M_MidModel
    {    
        #region Methods
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern uint midiInGetNumDevs();

        [DllImport("winmm.dll", SetLastError = true)]
        public static extern MMRESULT midiInGetDevCaps(UIntPtr uDeviceID, out MIDIINCAPS caps,
        UInt32 cbMidiInCaps);

        [DllImport("winmm.dll", SetLastError = true)]
        public static extern MMRESULT midiInStart(HMIDIIN hMidiIn);

        [DllImport("winmm.dll", SetLastError = true)]
        public static extern MMRESULT midiInStop(HMIDIIN hMidiIn);

        [DllImport("winmm.dll", SetLastError = true)]
        public static extern MMRESULT midiInClose(HMIDIIN hMidiIn);

        [DllImport("winmm.dll", SetLastError = true)]
        public static extern MMRESULT midiInOpen(out HMIDIIN lphMidiIn, UIntPtr uDeviceID, MidiInProc dwCallback, UIntPtr dwCallbackInstance, MidiOpenFlags dwFlags);

        public delegate void MidiInProc(HMIDIIN hMidiIn, MidiInMessage wMsg, UIntPtr dwInstance, UIntPtr dwParam1, UIntPtr dwParam2);

        public delegate void MidiCallBack(int handle, int msg, int instance, int param1, int param2);

        public static MMRESULT midiInOpen(out HMIDIIN lphMidiIn, UIntPtr uDeviceID, MidiInProc dwCallback, UIntPtr dwCallbackInstance)
        {
            return midiInOpen(out lphMidiIn, uDeviceID, dwCallback, dwCallbackInstance,
                dwCallback == null ? MidiOpenFlags.CALLBACK_NULL : MidiOpenFlags.CALLBACK_FUNCTION);
        }

        [DllImport("winmm.dll")]
        public static extern int midiOutGetNumDevs();

        [DllImport("winmm.dll")]
        public static extern int midiOutGetDevCaps(Int32 uDeviceID,
           ref MidiOutCaps lpMidiOutCaps, UInt32 cbMidiOutCaps);

        [DllImport("winmm.dll")]
        public static extern int midiOutOpen(ref int handle,
           int deviceID, MidiCallBack proc, int instance, int flags);

        [DllImport("winmm.dll")]
        public static extern int midiOutShortMsg(int handle,
           int message);

        [DllImport("winmm.dll")]
        public static extern int midiInStop(IntPtr hMidiIn);

        [DllImport("winmm.dll")]
        public static extern int midiOutClose(int handle);

        public const UInt32 MAXPNAMELEN = 32;

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

        #region PitchHeightName Constants

        public readonly String[] PitchHeightName = { "B9", "A#9", "A9", "G#9", "G9", "F#9", "F9", "E9", "D#9", "D9", "C#9", "C9",
            "B8", "A#8", "A8", "G#8", "G8", "F#8", "F8", "E8", "D#8", "D8", "C#8", "C8", "B7", "A#7", "A7", "G#7", "G7",
            "F#7", "F7", "E7", "D#7", "D7", "C#7", "C7", "B6", "A#6", "A6", "G#6", "G6", "F#6", "F6", "E6", "D#6", "D6",
            "C#6", "C6", "B5", "A#5", "A5", "G#5", "G5", "F#5", "F5", "E5", "D#5", "D5", "C#5", "C5", "B4", "A#4", "A4",
            "G#4", "G4", "F#4", "F4", "E4", "D#4", "D4", "C#4", "C4", "B3", "A#3", "A3", "G#3", "G3", "F#3", "F3", "E3",
            "D#3", "D3", "C#3", "C3", "B2", "A#2", "A2", "G#2", "G2", "F#2", "F2", "E2", "D#2", "D2", "C#2", "C2", "B1",
            "A#1", "A1", "G#1", "G1", "F#1", "F1", "E1", "D#1", "D1", "C#1", "C1", "B0", "A#0", "A0", "G#0", "G0",
            "F#0", "F0", "E0", "D#0", "D0", "C#0", "C0" };
        #endregion

        #region GeneralMIDI_Instruments Constants

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

        // Drum Constatnts Add
    }
}
