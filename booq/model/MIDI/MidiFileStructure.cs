using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace booq.Model
{
    public struct MidiFileStructure
    {
        public MidiHeader mHeader;  // MidiHeader DataStructure
        public MidiTrack[] mTracks; // MidiTrack ArrayBase DataStructure
    }

    public struct MidiHeader
    {
        /// <summary>
        /// MIDI_File Header region
        /// It must be always "Mthd", If not, it is not MIDI File.
        /// </summary>
        public byte[] mFileType; // Mthd 이 타입이 Mthd가 아니면 MIDI형식이 아님 (무조건 4바이트로 생성할 것)
        public uint mHeadChunk; // always 6

        /// <summary>
        /// 0 = single track file format 
        /// 1 = multiple track file format 
        /// 2 = multiple song file format(i.e., a series of type 0 files)
        /// </summary>
        public ushort mFormat; 
        public ushort mTrackCount; // 트랙의 총 개수 ( number of track chunks that follow the header chunk)

        /// <summary>
        /// unit of time for delta timing. 
        /// If the value is positive, then it represents the units per beat. 
        /// For example, +96 would mean 96 ticks per beat. 
        /// If the value is negative, delta times are in SMPTE compatible units.
        /// </summary>
        public ushort mDivision; // delta Time 결정
    }

    public struct MidiTrack
    {
        public byte[] mTrackHeader; // 트랙 맨 앞 헤더(값은 항상 Mtrk여야 함, 항상 4바이트, 트랙의 시작 부분)
        public uint mLength; //  
        public List<MIDI_event> mMidiEventLists; // 미디이벤트(명령어, 데이터)
    }
}