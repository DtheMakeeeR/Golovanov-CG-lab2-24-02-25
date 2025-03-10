using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golovanov_CG_lab2_24_02_25
{
    internal class GrayScaleFilter : Filter
    {
        public override Color CalculateNewPixelColor(Bitmap image, int x, int y)
        {
            Color pixel = image.GetPixel(x, y);
            int intensity =(int)(0.36*pixel.R + 0.53*pixel.G + 0.11*pixel.B);
            return Color.FromArgb(intensity, intensity, intensity);
        }
    }
}
