using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
namespace Golovanov_CG_lab2_24_02_25
{
    public abstract class Filter
    {
        public virtual Bitmap ProcessImage(Bitmap image, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(image.Width, image.Height);
            for (int i = 0; i < image.Width; i++)
            {
                worker.ReportProgress((int)((float)i / image.Width * 100));
                if (worker.CancellationPending) return null;
                for (int j = 0; j < image.Height; j++)
                {
                    resultImage.SetPixel(i, j, CalculateNewPixelColor(image, i, j));
                }
            }
            return resultImage;
        }

        protected abstract Color CalculateNewPixelColor(Bitmap image, int x, int y);
        public int Clamp(int value, int min = 0, int max = 255)
        {
            if (value < min) { return min; }
            if (value > max) { return max; }
            return value;
        }
    }
}
