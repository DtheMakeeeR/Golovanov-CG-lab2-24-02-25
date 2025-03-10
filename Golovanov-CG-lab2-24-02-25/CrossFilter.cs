using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golovanov_CG_lab2_24_02_25
{
    internal class CrossFilter : Filter
    {
        Glass glassFilter;
        Sepia sepiaFilter;
        GrayScaleFilter grayScaleFilter;
        InvertFilter invertFilter;
        public CrossFilter()
        {
            glassFilter = new Glass();
            sepiaFilter = new Sepia(30);
            grayScaleFilter = new GrayScaleFilter();
            invertFilter = new InvertFilter();
        }
        public override Color CalculateNewPixelColor(Bitmap image, int x, int y)
        {
            float otnoshenie = (float)image.Width / (float)image.Height;
            if ((x / otnoshenie > y) && (x / (otnoshenie) > image.Width / otnoshenie - y))
                return glassFilter.CalculateNewPixelColor(image, x, y);
            if ((x / otnoshenie < y) && (x / (otnoshenie) > image.Width / otnoshenie - y))
                return sepiaFilter.CalculateNewPixelColor(image, x, y);
            if ((x / otnoshenie < y) && (x / (otnoshenie) < image.Width / otnoshenie - y))
                return grayScaleFilter.CalculateNewPixelColor(image, x, y);
            if ((x / otnoshenie > y) && (x / (otnoshenie) < image.Width / otnoshenie - y))
                return invertFilter.CalculateNewPixelColor(image, x, y);
            else return image.GetPixel(x, y);
        }
    }
}
