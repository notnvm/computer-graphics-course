using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computer_graphics
{
    internal class sepia_filter : filters
    {
        protected override Color calculate_pxl_color(Bitmap src_img, int x, int y)
        {
            Color src_col = src_img.GetPixel(x, y);
            Color intensity = Color.FromArgb((int)(0.299 * src_col.R), (int)(0.587 * src_col.G), (int)(0.114 * src_col.B));
            int k = 35;
            return Color.FromArgb(
                clamp((int)(intensity.R + 2*k),0,255), 
                clamp((int)(intensity.G + 0.5 * k),0,255), 
                clamp((int)(intensity.B - 1 * k),0,255)
                );
        }
    }
}
