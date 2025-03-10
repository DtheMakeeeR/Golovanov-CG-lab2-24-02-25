using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Golovanov_CG_lab2_24_02_25
{
    internal class Closing : Filter
    {
        Dilation dil;
        Erosion er;
        public Closing(Segment mode = Segment.Cube, int sz = 3)
        {
            dil = new Dilation(mode, sz);
            er = new Erosion(mode, sz);
        }
        public override Bitmap ProcessImage(Bitmap image, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(image.Width, image.Height);
            resultImage = dil.ProcessImage(image, worker);
            if (resultImage == null) return null;
            resultImage = er.ProcessImage(resultImage, worker);
            return resultImage;
        }
        public override Color CalculateNewPixelColor(Bitmap image, int x, int y)
        {
            return Color.Black;
        }
    }
}
