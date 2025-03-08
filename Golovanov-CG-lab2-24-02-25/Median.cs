using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golovanov_CG_lab2_24_02_25
{
    internal class Median : Filter
    {
        int radius;
        public Median(int r = 1)
        {
            radius = r;
        }
        protected override Color CalculateNewPixelColor(Bitmap image, int x, int y)
        {
            List<int> allR = new List<int>();
            List<int> allG = new List<int>();
            List<int> allB = new List<int>();
            int median = x * y / 2;
            for (int i = -radius; i < radius; i++)
            {
                for (int j = -radius; j < radius; j++)
                {
                    int posX = Clamp(x + i, 0, image.Width - 1);
                    int posY = Clamp(y + j, 0, image.Height - 1);
                    Color pixel = image.GetPixel(posX, posY);
                    allR.Add(pixel.R);
                    allG.Add(pixel.G);
                    allB.Add(pixel.B);
                }
            }
            allR.Sort();
            allG.Sort();
            allB.Sort();
            return Color.FromArgb(allR[median], allG[median], allB[median]);
        }
    }
}
