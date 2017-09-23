using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.FreeGlut;

namespace Tetris.Keyboard.KeyboardActions
{
    class General
    {
        public void OnEscClick()
        {
            Glut.glutLeaveMainLoop();
        }
    }
}
