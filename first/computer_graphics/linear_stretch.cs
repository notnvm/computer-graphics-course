using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computer_graphics
{
    internal class linear_stretch : filters
    {
        protected override Color calculate_pxl_color(Bitmap src_img, int x, int y)
        {

            Color pxl_col = src_img.GetPixel(x, y);
            Color min_c = min_col(src_img);
            Color max_c = max_col(src_img);

            int stretched_val_r = clamp((int)((pxl_col.R - min_c.R) * 255.0 / (max_c.R - min_c.R)), 0, 255);
            int stretched_val_g = clamp((int)((pxl_col.G - min_c.G) * 255.0 / (max_c.G - min_c.G)), 0, 255);
            int stretched_val_b = clamp((int)((pxl_col.B - min_c.B) * 255.0 / (max_c.B - min_c.B)), 0, 255);

            return Color.FromArgb(stretched_val_r, stretched_val_g, stretched_val_b);
        }
    }
}
