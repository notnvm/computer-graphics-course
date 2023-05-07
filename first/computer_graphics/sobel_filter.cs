using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computer_graphics
{
    internal class sobel_filter : matirx_filter
    {
        public sobel_filter()
        {
            kernel = new float[,]{
                { -1,  0,  1, },
                { -2,  0,  2, },
                { -1,  0,  1, },
            };
        }
    }
}
