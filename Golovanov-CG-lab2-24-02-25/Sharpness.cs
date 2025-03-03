using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golovanov_CG_lab2_24_02_25
{
    internal class Sharpness:MatrixFilter
    {
        public Sharpness()
        {
            kernel = new float[3, 3];
            kernel[0, 1] = kernel[1, 0] = kernel[1, 2] = kernel[2, 1] =  -1;
            kernel[1, 1] = 5;
        }
    }
}
