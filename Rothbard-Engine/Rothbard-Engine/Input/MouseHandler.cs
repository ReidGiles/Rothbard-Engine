using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    class MouseHandler : EventArgs, IMouseInput
    {
        // list to store the mouse posiition
        private int[] mouseVal;

        /// <summary>
        /// Method to return the mouse location
        /// </summary>
        /// <returns></returns>
        public int[] GetMouseVal()
        {
            // get the mouse state
            MouseState mouseState = Mouse.GetState();
            // check if the mouse button is press
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                // set the mouse val to the position of the mouse
                mouseVal = new int[] { mouseState.X, mouseState.Y };
            }
            //return the mouseVal
            return mouseVal;
        }
    }
}
