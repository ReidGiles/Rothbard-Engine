using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    /// <summary>
    /// Stores all input listening data for an entity
    /// </summary>
    public class InputListener : IComponent, IInputListener
    {
        /// <summary>
        /// bool named 'KeboardListener' for defining if an entity should respond to keyboard inputs
        /// </summary>
        public bool KeyboardListener { get; set; }

        /// <summary>
        /// bool named 'MouseListener' for defining if an entity should respond to mouse inputs
        /// </summary>
        public bool MouseListener { get; set; }
    }
}