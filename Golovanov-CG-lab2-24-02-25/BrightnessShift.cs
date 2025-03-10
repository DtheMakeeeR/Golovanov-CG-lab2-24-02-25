using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golovanov_CG_lab2_24_02_25
{
    internal class BrightnessShift : Filter
    {
        int coeff;
        public BrightnessShift(int c)
        {
            coeff = c;
        }
        public override Color CalculateNewPixelColor(Bitmap image, int x, int y)
        {
            Color pixel = image.GetPixel(x, y);
            int r = Clamp(pixel.R + coeff);
            int g = Clamp(pixel.G + coeff);
            int b = Clamp(pixel.B + coeff);
            return Color.FromArgb(r, g, b);
        }
    }
}
