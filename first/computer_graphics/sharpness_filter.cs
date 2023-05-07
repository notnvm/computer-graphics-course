using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computer_graphics
{
    internal class sharpness_filter : matirx_filter
    {
        public sharpness_filter()
        {
            kernel = new float[,]{
                { -1,  -1,  -1, },
                { -1,  9,  -1, },
                { -1,  -1,  -1, },
            };
        }
    }
}
