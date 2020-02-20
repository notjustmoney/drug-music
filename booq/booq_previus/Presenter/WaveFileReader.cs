using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0503_TeamProjectMidiWav
{
    public class WaveHeader
    {
        public string sGroupID; // RIFF
        public uint dwFileLength; // total file length minus 8, which is taken up by RIFF
        public string sRiffType; // always WAVE

        /// <summary>
        /// Initializes a WaveHeader object with the default values.
        /// </summary>
        public WaveHeader()
        {
            dwFileLength = 0;
            sGroupID = "RIFF";
            sRiffType = "WAVE";
        }
    }

    public class WaveFormatChunk
    {
        public string sChunkID;         // Four bytes: "fmt "
        public uint dwChunkSize;        // Length of header in bytes
        public ushort wFormatTag;       // 1 (MS PCM)
        public ushort wChannels;        // Number of channels
        public uint dwSamplesPerSec;    // Frequency of the audio in Hz... 44100
        public uint dwAvgBytesPerSec;   // for estimating RAM allocation
        public ushort wBlockAlign;      // sample frame size, in bytes
        public ushort wBitsPerSample;    // bits per sample

        /// <summary>
        /// Initializes a format chunk with the following properties:
        /// Sample rate: 44100 Hz
        /// Channels: Stereo
        /// Bit depth: 16-bit
        /// </summary>
        public WaveFormatChunk()
        {
            sChunkID = "fmt ";
            dwChunkSize = 16;
            wFormatTag = 1;
            wChannels = 2;
            dwSamplesPerSec = 44100;
            wBitsPerSample = 16;
            wBlockAlign = (ushort)(wChannels * (wBitsPerSample / 8));
            dwAvgBytesPerSec = dwSamplesPerSec * wBlockAlign;
        }
    }

    public class WaveDataChunk
    {
        public string sChunkID;       // "data"
        public uint dwChunkSize;    // data 크기
        public short[] shortArray;    // data

        public WaveDataChunk()
        {
            shortArray = new short[0];
            dwChunkSize = 0;
            sChunkID = "data";
        }
    }

    public struct WavFileStructure
    {
        // RIFF region
        public byte[] rChunkID;
        public uint chunkSize;
        public byte[] rFormat;

        // fmt region
        public byte[] fmtChunkID;
        public uint fmtChunkSize;
        public ushort audioFormat;
        public ushort numChannels;
        public uint sampleRate;
        public uint byteRate;
        public ushort blockAssign;
        public ushort BitsPerSample;

        // data region
        public string dChunkID;
        public uint dwChunkSIze;
        public byte[] data8L;
        public byte[] data8R;
        public ushort[] data16L;
        public ushort[] data16R;
        public int nOfSamples;
    }

    public class WaveRead
    {
        private WavFileStructure wavFile;

        public WaveRead()
        {
            // just Construct and do nothing
        }


    }

    public class WaveWrite
    {
        public WaveWrite()
        {

        }
    }
}
