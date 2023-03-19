using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computer_graphics
{
    internal class blur_filter : matirx_filter
    {
        public blur_filter()
        {
            int sz_x = 3;
            int sz_y = 3;
            kernel = new float[sz_x, sz_y];
            for (int i = 0; i < sz_x; ++i)
                for (int j = 0; j < sz_y; ++j)
                    kernel[i, j] = 1.0f / (float)(sz_x * sz_y);
        }
    }
}
