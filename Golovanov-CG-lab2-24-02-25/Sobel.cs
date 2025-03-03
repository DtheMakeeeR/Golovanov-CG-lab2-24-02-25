using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golovanov_CG_lab2_24_02_25
{
    
    internal class Sobel:MatrixFilter
    {
        public Sobel(AxisMode mode)
        {
            kernel = new float[3, 3];
            float[] stroke = new float[3] { 1, 2, 1 };
            switch (mode)
            {
                case AxisMode.AxisX:
                    for (int i = 0; i < 3; i++)
                    {
                        kernel[i, 0] = -stroke[i];
                        kernel[i, 2] = stroke[i];
                    }                   
                    break;

                case AxisMode.AxisY:
                    for (int i = 0; i < 3; i++)
                    {
                        kernel[0, i] = -stroke[i];
                        kernel[2, i] = stroke[i];
                    }
                    break;
            }
        }
    }
}
