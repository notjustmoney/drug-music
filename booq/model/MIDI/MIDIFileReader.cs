using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace booq.Model
{
    public class MIDIFileReader
    {
        private MidiFileStructure midiFileStructure;
        private FileInfo midiFileInfo;
        private FileStream midiFileStm;
        private BinaryReader midBinaryReader;
        private string str;
        private string readPath;
        private string writePath;

        // 일단은 코딩 단순화시키기위해서 1개의 샘플 파일만 읽어오게끔 함 (추후 수정 예정)

        #region Constructor

        public MIDIFileReader()
        {

        }

        public MIDIFileReader(string filepath)
        {
            this.readPath = filepath;
            midiFileStructure = new MidiFileStructure();
        }

        #endregion

        #region Properties

        public MidiFileStructure MidiFileStructure
        {
            get { return midiFileStructure; }
            set { midiFileStructure = value; }
        }

        #endregion

        private bool MidiFileRead()
        {
            // loading file
            midiFileInfo = new FileInfo(readPath);
            midiFileStm = midiFileInfo.OpenRead();
            midBinaryReader = new BinaryReader(midiFileStm);

            midiFileStructure.mHeader.mFileType = new byte[4];
            midiFileStructure.mHeader.mFileType = midBinaryReader.ReadBytes(4);

            str = Encoding.ASCII.GetString(midiFileStructure.mHeader.mFileType, 0, 4);

            // if File is not Midi File, return false
            // Tthese four characters("Mthd") at the start of the MIDI file indicate that this is a MIDI file.
            if (str != "Mthd")
            {
                return false;
            }


            // 여기서부터 구현 더 해야함

            return true;
        }

        public void MidiFileWrite()
        {

        }
    }
}
