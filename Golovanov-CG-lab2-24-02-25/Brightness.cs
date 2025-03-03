using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golovanov_CG_lab2_24_02_25
{
    internal class Brightness : Filter
    {
        int coef;
        public Brightness(int coef = 0)
        {
            this.coef = coef;
        }
        public override Color CalculateNewPixelColor(Bitmap image, int x, int y)
        {
            Color pixel = image.GetPixel(x, y);
            return Color.FromArgb(Clamp(pixel.R + coef), Clamp(pixel.G + coef), Clamp(pixel.B + coef));
        }
    }
}
