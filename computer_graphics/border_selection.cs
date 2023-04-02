using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computer_graphics
{
    internal class border_selection : matirx_filter
    {
        public border_selection()
        {
            kernel = new float[,]{
                { 3,  10,  3, },
                { 0,  0,  0, },
                { -3,  -10,  -3, },
            };
        }
    }
}
