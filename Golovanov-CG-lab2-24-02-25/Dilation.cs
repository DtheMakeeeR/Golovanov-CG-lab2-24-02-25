using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Golovanov_CG_lab2_24_02_25
{
    internal class Dilation : Morphling
    {
        public Dilation(Segment mode = Segment.Cube, int sz = 3) : base(mode, sz)
        {

        }
        public override Color CalculateNewPixelColor(Bitmap image, int x, int y)
        {
            int posX, posY;
            List<int> redChanel = new List<int>();
            List<int> greenChanel = new List<int>();
            List<int> blueChanel = new List<int>();
            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    posX = Clamp(x + i, 0, image.Width - 1);
                    posY = Clamp(y + j, 0, image.Height - 1);
                    if (kernel[i + radius, j + radius])
                    {
                        redChanel.Add(image.GetPixel(posX, posY).R);
                        greenChanel.Add(image.GetPixel(posX, posY).G);
                        blueChanel.Add(image.GetPixel(posX, posY).B);
                    }
                }
            }
            return Color.FromArgb(redChanel.Max(), greenChanel.Max(), blueChanel.Max());
        }
    }
}
