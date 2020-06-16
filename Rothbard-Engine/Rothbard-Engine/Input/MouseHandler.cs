using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    /// <summary>
    /// Stores mouse event data
    /// </summary>
    class MouseHandler : EventArgs, IMouseInput
    {
        // DECLARE an int[] to store the mouse position, call it '_mouseVal'
        private int[] _mouseVal;

        /// <summary>
        /// Returns the mouse location
        /// </summary>
        /// <returns></returns>
        public int[] GetMouseVal()
        {
            // DECLARE an INSTANTIATE a new MouseState, call it 'mouseState'
            MouseState mouseState = Mouse.GetState();

            // IF the left mouse button has been pressed
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                // SET _mouseVal to the current position of the mouse
                _mouseVal = new int[] { mouseState.X, mouseState.Y };
            }

            return _mouseVal;
        }
    }
}
