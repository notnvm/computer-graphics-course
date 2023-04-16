using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computer_graphics
{
    internal class shift : filters
    {
        protected override Color calculate_pxl_color(Bitmap src_img, int x, int y)
        {
            x = x + 50;
            if (x >= src_img.Width || x < 0)
                return Color.FromArgb(0, 0, 0);
            return Color.FromArgb(
                clamp((int)(src_img.GetPixel(x, y).R), 0, 255),
                clamp((int)(src_img.GetPixel(x, y).G), 0, 255),
                clamp((int)(src_img.GetPixel(x, y).B), 0, 255));
        }
    }
}
