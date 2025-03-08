using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golovanov_CG_lab2_24_02_25
{
    internal class GaryWorld : Filter
    {
        int allR = 0, allG = 0, allB = 0;
        float avg;
        protected override Color CalculateNewPixelColor(Bitmap image, int x, int y)
        {
            Color pixel = image.GetPixel(x, y);
            int pixelR = (int)((pixel.R * avg) / allR);
            int pixelG = (int)((pixel.G * avg) / allG);
            int pixelB = (int)((pixel.B * avg) / allB);
            if (pixelR > 255) pixelR = 255;
            if (pixelG > 255) pixelG = 255;
            if (pixelB > 255) pixelB = 255;
            Color nPixel = Color.FromArgb(pixelR, pixelG, pixelB);
            return nPixel;
        }
        public override Bitmap ProcessImage(Bitmap image, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(image.Width, image.Height);
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color pixel = image.GetPixel(i, j);
                    allR += pixel.R;
                    allG += pixel.G;
                    allB += pixel.B;
                }
            }
            if (worker.CancellationPending) return null;
            avg = (allR + allB + allG) / 3;
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
    }
}
