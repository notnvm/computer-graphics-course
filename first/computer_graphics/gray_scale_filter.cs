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
            int intensity = Convert.ToInt32(0.36 * src_img.GetPixel(x, y).R + 0.53 * src_img.GetPixel(x, y).G + 0.11 * src_img.GetPixel(x, y).B);
            Color color = Color.FromArgb(
                clamp(intensity,0,255),
                clamp(intensity, 0, 255),
                clamp(intensity, 0, 255)
                );
            return color;
        }
    }
}
