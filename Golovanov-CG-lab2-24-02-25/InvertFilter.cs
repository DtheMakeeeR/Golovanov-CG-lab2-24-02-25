using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Golovanov_CG_lab2_24_02_25
{
    internal class InvertFilter : Filter
    {
        protected override Color CalculateNewPixelColor(Bitmap image, int x, int y)
        {
            Color sourceColor = image.GetPixel(x, y);
            Color resultColor = Color.FromArgb(255-sourceColor.R, 
                                               255-sourceColor.G, 
                                               255-sourceColor.B);
            return resultColor;
        }
    }
}
