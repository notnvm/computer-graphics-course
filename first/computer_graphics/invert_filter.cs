using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computer_graphics
{
    internal class invert_filter : filters
    {
        protected override Color calculate_pxl_color(Bitmap src_img, int x, int y)
        {
                Color src_col = src_img.GetPixel(x, y);
                Color res_color = Color.FromArgb(
                    clamp((255 - src_col.R),0,255), 
                    clamp((255 - src_col.G),0,255), 
                    clamp((255 - src_col.B),0,255)
                    );
                return res_color;
        }
    }
}
