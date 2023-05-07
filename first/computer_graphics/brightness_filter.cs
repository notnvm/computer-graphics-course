using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computer_graphics
{
    internal class brightness_filter : filters
    {
        protected override Color calculate_pxl_color(Bitmap src_img, int x, int y)
        {
            int k = 49;
            Color src_col = src_img.GetPixel(x, y);
            return Color.FromArgb(
                clamp((int)(src_col.R + k), 0, 255),
                clamp((int)(src_col.G + k), 0, 255),
                clamp((int)(src_col.B + k), 0, 255)
                );
        }
    }
}
