using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computer_graphics
{
    class morphology : filters
    {
        public morphology() { }

        public morphology(int[,] mask, int MH, int MW)
        {
            this.mask = mask;
            this.MH = MH;
            this.MW = MW;
        }

        protected override Color calculate_pxl_color(Bitmap src_img, int x, int y)
        {
            throw new NotImplementedException();
        }

        protected int[,] mask = null;
        protected int MH;
        protected int MW;
    }
    class dilation : morphology
    {
        public dilation()
        {
            MH = 3;
            MW = 3;
            mask = new int[3, 3] { { 0, 1, 0 },
                             { 1, 1, 1 },
                             { 0, 1, 0 } };
        }
        public dilation(int[,] mask, int MH, int MW)
        {
            this.mask = mask;
            this.MH = MH;
            this.MW = MW;
        }
        protected override Color calculate_pxl_color(Bitmap src_img, int x, int y)
        {
            Color max = Color.FromArgb(0, 0, 0);
            for (int j = -MH / 2; j <= MH / 2; ++j)
            {
                for (int i = -MW / 2; i <= MW / 2; ++i)
                {
                    Color source_color = src_img.GetPixel(clamp(x + i, 0, src_img.Width - 1), clamp(y + j, 0, src_img.Height - 1));
                    if (mask[i + MW / 2, j + MH / 2] == 1 && source_color.R > max.R)
                    {
                        max = source_color;
                    }
                }
            }
            return max;
        }
    }
    class erosion : morphology
    {
        public erosion(int[,] mask, int MH, int MW)
        {
            this.mask = mask;
            this.MH = MH;
            this.MW = MW;
        }
        public erosion()
        {
            MH = 3;
            MW = 3;
            mask = new int[3, 3] { { 0, 1, 0 },
                             { 1, 1, 1 },
                             { 0, 1, 0 } };
        }
        protected override Color calculate_pxl_color(Bitmap src_img, int x, int y)
        {
            Color min = Color.FromArgb(255, 255, 255);
            for (int j = -MH / 2; j <= MH / 2; ++j)
            {
                for (int i = -MW / 2; i <= MW / 2; ++i)
                {
                    Color source_color = src_img.GetPixel(clamp(x + i, 0, src_img.Width - 1), clamp(y + j, 0, src_img.Height - 1));
                    if (mask[i + MW / 2, j + MH / 2] == 1 && source_color.R < min.R)
                    {
                        min = source_color;
                    }
                }
            }
            return min;
        }
    }

    class gradient : morphology
    {
        public gradient(int[,] mask, int MH, int MW)
        {
            this.mask = mask;
            this.MH = MH;
            this.MW = MW;
        }
        public gradient()
        {
            MH = 3;
            MW = 3;
            mask = new int[3, 3] { { 0, 1, 0 },
                             { 1, 1, 1 },
                             { 0, 1, 0 } };
        }
        protected override Color calculate_pxl_color(Bitmap src_img, int x, int y)
        {
            Color min = Color.FromArgb(255, 255, 255);
            Color max = Color.FromArgb(0, 0, 0);
            for (int j = -MH / 2; j <= MH / 2; ++j)
            {
                for (int i = -MW / 2; i <= MW / 2; ++i)
                {
                    Color source_color = src_img.GetPixel(clamp(x + i, 0, src_img.Width - 1), clamp(y + j, 0, src_img.Height - 1));
                    if (mask[i + MW / 2, j + MH / 2] == 1 && source_color.R < min.R)
                    {
                        min = source_color;
                    }
                    if (mask[i + MW / 2, j + MH / 2] == 1 && source_color.R > max.R)
                    {
                        max = source_color;
                    }
                }
            }
            return Color.FromArgb(clamp(max.R - min.R, 0, 255), clamp(max.G - min.G, 0, 255), clamp(max.B - min.B, 0, 255));
        }
    }

    class median : morphology
    {
        public median() { }
        protected override Color calculate_pxl_color(Bitmap src_img, int x, int y)
        {
            int size = 3;
            int radius = 1;
            int[] cR = new int[size * size];
            int[] cG = new int[size * size];
            int[] cB = new int[size * size];
            int k = 0;

            for (int i = -radius; i <= radius; i++)
                for (int j = -radius; j <= radius; j++)
                {
                    Color sourceColor = src_img.GetPixel(clamp(x + i, 0, src_img.Width - 1), clamp(y + j, 0, src_img.Height - 1));
                    cR[k] = sourceColor.R;
                    cG[k] = sourceColor.G;
                    cB[k] = sourceColor.B;
                    k++;
                }

            Array.Sort(cR);
            Array.Sort(cG);
            Array.Sort(cB);

            int n_ = (int)(size * size / 2);

            int cR_ = cR[n_];
            int cG_ = cG[n_];
            int cB_ = cB[n_];

            Color resultColor = Color.FromArgb(cR_, cG_, cB_);
            return resultColor;
        }
    }
}
