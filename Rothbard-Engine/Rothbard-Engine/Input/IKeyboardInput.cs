using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    interface IKeyboardInput
    {
        /// <summary>
        /// Returns keys pressed on keyboard
        /// </summary>
        Keys[] GetInputKey();
    }
}