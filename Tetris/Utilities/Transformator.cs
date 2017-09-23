using OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Utilities
{
    public static class Transformator
    {
        public static Vector3 ToVector3(this RGB rgb)
        {
            return new Vector3(rgb.Red, rgb.Blue, rgb.Green);
        }
    }
}
