using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Utilities
{
    public class RGB
    {
        public int Red { get; set; }
        public int Blue { get; set; }
        public int Green { get; set; }

        public RGB() { }

        public RGB(int red, int blue, int green)
        {
            Red = red;
            Blue = blue;
            Green = green;
        }
    }
}
