﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golovanov_CG_lab2_24_02_25
{
    internal class RotateFilter:Filter
    {
        int angle;
        public RotateFilter(int angle = 0)
        {
            this.angle = angle;
        }

        public override Color CalculateNewPixelColor(Bitmap image, int x, int y)
        {
            int x0 = image.Width / 2;
            int y0 = image.Height / 2;
            int posX = (int)((x - x0) * Math.Cos(angle) - (y - y0) * Math.Sin(angle) + x0);
            int posY = (int)((x - x0) * Math.Sin(angle) + (y - y0) * Math.Cos(angle) + y0);
            if (posX < 0 || posX >= image.Width || posY < 0 || posY >= image.Height)
                return Color.Black;
            return image.GetPixel(posX, posY);
        }
    }
}
