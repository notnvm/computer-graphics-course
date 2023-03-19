using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computer_graphics
{
    internal class gray_scale_filter : filters
    {
        protected override Color calculate_pxl_color(Bitmap src_img, int x, int y)
        {
            Color src_col = src_img.GetPixel(x, y);
            Color intensity = Color.FromArgb((int)(0.299 * src_col.R), (int)(0.587 * src_col.G), (int)(0.114 * src_col.B));
            return intensity;
        }
    }
}
