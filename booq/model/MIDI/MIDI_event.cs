using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace booq.Model
{
    public abstract class MIDI_event
    {
        public int Delta { get; set; }  // MIDI Time and Duration Event
        public byte EventType { get; set; } // Meta / System / Midi
        public byte[] Buffer { get; set; }  
    }

    public class MidiMetaData : MIDI_event
    {

    }

    public class MidiSystemData : MIDI_event
    {

    }

    public class MidiMidiData : MIDI_event
    {

    }
}
