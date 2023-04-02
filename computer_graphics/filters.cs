using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace computer_graphics
{
    abstract class filters
    {
        public Color max_col(Bitmap src_img)
        {
            int max_r = 0;
            int max_g = 0;
            int max_b = 0;
            for (int i = 0; i < src_img.Width; ++i)
                for (int j = 0; j < src_img.Height; ++j) {
                    Color pixel_color = src_img.GetPixel(i, j);
                    if (pixel_color.R > max_r)
                        max_r = pixel_color.R;
                    if (pixel_color.G > max_g)
                        max_g = pixel_color.G;
                    if (pixel_color.B > max_b)
                        max_b = pixel_color.B;
                }
            return Color.FromArgb(max_r, max_g, max_b);
        }

        public Color min_col(Bitmap src_img)
        {
            int min_r = 0;
            int min_g = 0;
            int min_b = 0;
            for (int i = 0; i < src_img.Width; ++i)
                for (int j = 0; j < src_img.Height; ++j)
                {
                    Color pixel_color = src_img.GetPixel(i, j);
                    if (pixel_color.R < min_r)
                        min_r = pixel_color.R;
                    if (pixel_color.G < min_g)
                        min_g = pixel_color.G;
                    if (pixel_color.B < min_b)
                        min_b = pixel_color.B;
                }
            return Color.FromArgb(min_r, min_g, min_b);
        }

        public int clamp(int val, int min, int max)
        {
            if (val < min)
                val = min;
            if (val > max)
                val = max;
            return val;
        }
        protected abstract Color calculate_pxl_color(Bitmap src_img, int x, int y);

        public Bitmap process_image(Bitmap src, BackgroundWorker worker)
        {

            Bitmap res = new Bitmap(src.Width, src.Height);
            for (int i = 0; i < src.Width; ++i)
            {
                worker.ReportProgress((int)((float)i / res.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < src.Height; ++j)
                    res.SetPixel(i, j, calculate_pxl_color(src, i, j));
            }


            return res;
        }
    }

    //class invert_filter : filters
    //{
    //    protected override Color calculate_pxl_color(Bitmap src_img, int x, int y)
    //    {
    //        Color src_col = src_img.GetPixel(x, y);
    //        Color res_color = Color.FromArgb(255 - src_col.R, 255 - src_col.G, 255 - src_col.B);
    //        return res_color;
    //    }
    //}
}
