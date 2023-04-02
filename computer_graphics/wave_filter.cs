using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computer_graphics
{
    internal class wave_filter : filters
    {
        //волна 𝑘, 𝑙 − индексы результирующего изображения, для которых вычисляется цвет 𝑥, 𝑦 − индексы по которым берется цвет из исходного изображения

        protected override Color calculate_pxl_color(Bitmap src_img, int x, int y)
        {
            Color plx_col = src_img.GetPixel(x, y);
            return plx_col;
        }
    }
}
