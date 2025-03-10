using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golovanov_CG_lab2_24_02_25
{
    internal class Sharr : EdgeFilter
    {
        public Sharr()
        {
            kernelX = new float[3, 3];
            kernelY = new float[3, 3];
            float[] stroke = new float[3] { -3, -10, -3 };
            for (int i = 0; i < 3; i++)
            {
                kernelX[i, 0] = -stroke[i];
                kernelX[i, 2] = stroke[i];
            }
            for (int i = 0; i < 3; i++)
            {
                kernelY[0, i] = -stroke[i];
                kernelY[2, i] = stroke[i];
            }
        }
    }
}
