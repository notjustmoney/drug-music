using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace booq
{
    public class MidPattern
    {
        private byte[][] mData;

        public MidPattern()
        {
            byte[][] mData = new byte[128][];
            for (int i = 0; i < 128; i++)
            {
                mData[i] = new byte[4];
            }
        }

    }
}
