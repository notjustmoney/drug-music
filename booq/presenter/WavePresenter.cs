using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Media;
using booq.Model;
using booq;

namespace booq.presenter
{
    public class WavePresenter
    {
        private MainForm view;
        public WaveFileReader wavFileReader;

        public WavePresenter()
        {
            // just Construct and do nothing
            //wavFS = new WaveFileStructure();            
        }

        public WavePresenter(MainForm view)
        {
            this.view = view;
            //wavFS = new WaveFileStructure();
        }

        public void SoundPlay()
        {
            SoundPlayer sound = new SoundPlayer(Application.StartupPath + @"\Files\Yamaha-V50-Rock-Beat-120bpm.wav");
            sound.Load();
            sound.Play();
        }

        public float[] SetViewSampleGraph(int rate)    // Sample 그래프 그리기 위해서 평균값 내기 written by 이윤구
        {
            int i;  // 반복자
            int cnt = 0;    // sample값 평균 배열에 값을 할당하기 위함
            uint localSampleSum = 0;    // 샘플의 지역적 합
            float[] avgSampleSum; // 샘플의 rate 당 평균
            bool breakFlag = false;

            avgSampleSum = new float[(wavFileReader.nOfSamples / rate) + 1];

            if(wavFileReader.BitsPerSample == 8)
            {

            }
            else if (wavFileReader.BitsPerSample == 16)
            {
                if (wavFileReader.numChannels == 1)
                {

                }
                else if (wavFileReader.numChannels == 2)
                {
                    for (i = 0; i < wavFileReader.nOfSamples; i += rate)
                    {
                        for (int j = i; j < i + rate; j++)
                        {
                            if (j == wavFileReader.nOfSamples)
                            {
                                breakFlag = true;
                                break;
                            }
                            localSampleSum += wavFileReader.data16L[j];
                            localSampleSum += wavFileReader.data16R[j];
                        }
                        avgSampleSum[cnt++] = localSampleSum / (rate * 2);
                        localSampleSum = 0;

                        if (breakFlag) break;
                    }
                }
            }
            return avgSampleSum;
        }
        
        public void SetViewBPS()
        {
            view.bitsPerSample = wavFileReader.BitsPerSample;
        }

        public void SetViewSR()
        {
            view.wSampleRate = wavFileReader.sampleRate;
        }
        
    }
}