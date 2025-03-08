using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golovanov_CG_lab2_24_02_25
{
    enum Segment
    {
        Cross,
        Cube
    }
    internal abstract class Morphling : Filter
    {
        protected bool[,] kernel;
        protected int size, radius;
        public Morphling(Segment mode = Segment.Cube, int sz = 3)
        {
            size = (sz % 2 == 0) ? sz + 1 : sz;
            radius = size / 2;
            kernel = new bool[size, size];
            switch (mode)
            {
                case Segment.Cross:
                    for (int i = 0; i < size; i++)
                    {
                        kernel[i, size/2 + 1] = true;
                    }
                    for (int j = 0; j < sz; j++)
                    {
                        kernel[size / 2 + 1, j] = true;
                    }
                    break;
                case Segment.Cube:
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < sz; j++)
                        {
                            kernel[i, j] = true;
                        }
                    }
                    break;
            }
        }
        /*public abstract Color CalculateNewPixelColor(Bitmap image, int x, int y)
        {
            int posX, posY;
            List<int> redChanel = new List<int>();
            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    posX = Clamp(x + i, 0, image.Width - 1);
                    posY = Clamp(y + j, 0, image.Height - 1);
                    redChanel.Add(image.GetPixel(posX, posY).R);
                }
            }
            throw new NotImplementedException();
        }*/
    }
}
