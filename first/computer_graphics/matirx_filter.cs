using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computer_graphics
{
    internal class matirx_filter : filters
    {
        protected float[,] kernel = null;
        protected matirx_filter() { }
        public matirx_filter(float[,] kernel)
        {
            this.kernel = kernel;
        }

        protected override Color calculate_pxl_color(Bitmap src_img, int x, int y)
        {
            int rad_x = kernel.GetLength(0) / 2;
            int rad_y = kernel.GetLength(1) / 2;
            
            float res_R = 0, res_G = 0, res_B = 0;
            for(int l = -rad_y; l <=rad_y; ++l)
                for(int k = -rad_x; k <= rad_x; ++k)
                {
                    int idx = clamp(x + k, 0, src_img.Width - 1);
                    int idy = clamp(y + l, 0, src_img.Height - 1);
                    Color neighbor_color = src_img.GetPixel(idx, idy);
                    res_R += neighbor_color.R * kernel[k + rad_x, l + rad_y];
                    res_G += neighbor_color.G * kernel[k + rad_x, l + rad_y];
                    res_B += neighbor_color.B * kernel[k + rad_x, l + rad_y];
                }

            return Color.FromArgb(
                clamp((int)res_R,0,255),
                clamp((int)res_G,0,255),
                clamp((int)res_B, 0, 255)
                );
        }
    }
}
