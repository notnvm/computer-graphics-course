using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computer_graphics
{
    internal class perfect_reflector : filters
    {
        protected override Color calculate_pxl_color(Bitmap src_img, int x, int y)
        {
            Color src_col = src_img.GetPixel(x, y);
            Color max_c = max_col(src_img);
            return Color.FromArgb(
                 clamp((src_col.R * (255 / max_c.R)), 0, 255),
                 clamp((src_col.G * (255 / max_c.G)), 0, 255),
                 clamp((src_col.B * (255 / max_c.B)), 0, 255)
                );
        }
    }
}
