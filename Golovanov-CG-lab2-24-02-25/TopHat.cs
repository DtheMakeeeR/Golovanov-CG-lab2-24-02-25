using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golovanov_CG_lab2_24_02_25
{
    internal class TopHat : Filter
    {
        Opening op;
        Bitmap tmp;
        public TopHat(Segment mode = Segment.Cube, int sz = 3)
        {
            op = new Opening(mode, sz);           
        }
        public override Bitmap ProcessImage(Bitmap image, BackgroundWorker worker)
        {
            Bitmap res = new Bitmap(image.Width, image.Height);
            tmp = op.ProcessImage(image, worker);
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color sourceCol = image.GetPixel(i, j);
                    Color openCol = tmp.GetPixel(i, j);
                    int red = Clamp(sourceCol.R - openCol.R);
                    int green = Clamp(sourceCol.G - openCol.G);
                    int blue = Clamp(sourceCol.B - openCol.B);
                    Color resCol = Color.FromArgb(red, green, blue);
                    res.SetPixel(i, j, resCol);
                }
            }
            return res;
        }
        public override Color CalculateNewPixelColor(Bitmap image, int x, int y)
        {
            return Color.Black;
        }
    }
}
