using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computer_graphics
{
    internal class gaussian_filter : matirx_filter
    {

        public gaussian_filter()
        {
            create_gaussian_kernel(3, 2);
        }
        public void create_gaussian_kernel(int rad, float sigma)
        {
            int sz = 2 * rad + 1;
            kernel = new float[sz, sz];
            float norm = 0;
            for (int i = -rad; i <= rad; ++i)
                for(int j = -rad; j <= rad; ++j)
                {
                    kernel[i + rad, j + rad] = (float)(Math.Exp(-(i * i + j * j) / (2 * sigma * sigma)));
                    norm += kernel[i + rad, j + rad];
                }

            for (int i = 0; i < sz; ++i)
                for (int j = 0; j < sz; ++j)
                    kernel[i, j] /= norm;
        } 
    }
}
