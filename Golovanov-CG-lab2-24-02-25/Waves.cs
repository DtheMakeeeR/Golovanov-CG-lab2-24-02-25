using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golovanov_CG_lab2_24_02_25
{
    internal class Waves : Filter
    {
        public override Color CalculateNewPixelColor(Bitmap image, int x, int y)
        {
            int posX = Clamp((int)(x + 20*Math.Sin(Math.PI*2*y/60)), 1, image.Width-1);
            return image.GetPixel(posX, y);
        }
    }
}
