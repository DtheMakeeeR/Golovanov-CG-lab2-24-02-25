using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Golovanov_CG_lab2_24_02_25
{
    internal class Glass : Filter
    {
        Random random = new Random();
        public override Color CalculateNewPixelColor(Bitmap image, int x, int y)
        {
            int rX = Clamp(((random.Next(-1, 2)) * 3 + x), 0, image.Width-1);
            int rY = Clamp(((random.Next(-1, 2)) * 3 + y), 0, image.Height-1);
            return image.GetPixel(rX, rY);
        }
    }
}
