using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Keyboard.KeyboardActions;

namespace Tetris.Keyboard
{
    class KeyboardManager
    {
        public static General GeneralKeys => new General();
        public static ArrowKeyDownActions ArrowKeyDownActions => new ArrowKeyDownActions();
        public static ArrowKeyUpActions ArrowKeyUpActions => new ArrowKeyUpActions();


        public static void OnKeyboardDown(byte key, int x, int y)
        {
            switch (key)
            {
                case Keys.ESC:
                    GeneralKeys.OnEscClick();
                    break;

                default:
                    break;
            }
        }

        public static void OnSpecialKeyboardDown(int key, int x, int y)
        {
            switch (key)
            {
                #region Arrows
                case Keys.ARROW_UP:
                    break;
                case Keys.ARROW_DOWN:
                    break;
                case Keys.ARROW_LEFT:
                    break;
                case Keys.ARROW_RIGHT:
                    break;
                    #endregion
            }
        }

        public static void OnSpecialKeyboardUp(int key, int x, int y)
        {
            switch (key)
            {
                #region Arrows
                case Keys.ARROW_UP:
                    break;
                case Keys.ARROW_DOWN:
                    break;
                case Keys.ARROW_LEFT:
                    break;
                case Keys.ARROW_RIGHT:
                    break;
                    #endregion
            }
        }
    }
}
