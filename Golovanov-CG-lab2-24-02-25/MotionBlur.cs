using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golovanov_CG_lab2_24_02_25
{
    internal class MotionBlur : MatrixFilter
    {
        public MotionBlur(int n = 3)
        {
            if (n % 2 == 0) n--;
            n = Math.Max(n, 3);
            kernel = new float[n, n];
            for (int i = 0; i < n; i++)
            {
                kernel[i, i] = 1.0f / n;
            }
        }
    }
}
