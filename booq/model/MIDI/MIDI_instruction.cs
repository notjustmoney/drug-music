using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace booq.Model
{
    public class MIDI_instruction
    {
        public readonly int noteOff_4bit = 8; // noteOff 명령어의 앞의 4비트 (1000nnnn)
        public readonly int noteOn_4bit = 9;  // noteOn 명령어의 앞의 4비트 (1001nnnn)

        public byte noteOffMessage;
        public byte noteOnMessage;

        public byte noteOff(int channelNo)  // channel의 음을 끄는 이벤트
        {
            noteOffMessage = 0x80;

            if (channelNo < 1 || channelNo > 16)    // 에러시 1채널에 할당
            {
                return noteOffMessage;
            }
            else
            {
                noteOffMessage += (byte)(channelNo - 1);

                return noteOffMessage;
            }
        }

        public byte noteOn(int channelNo) // channel의 음을 켜는 이벤트
        {
            noteOffMessage = 0x90;

            if (channelNo < 1 || channelNo > 16)    // 에러시 1채널에 할당
            {
                return noteOnMessage;
            }
            else
            {
                noteOnMessage += (byte)(channelNo - 1);

                return noteOnMessage;
            }
        }
    }
}
