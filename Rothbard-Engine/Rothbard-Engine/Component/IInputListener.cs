using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    /// <summary>
    /// Stores input listening data
    /// </summary>
    public interface IInputListener
    {
        /// <summary>
        /// bool named 'KeboardListener' for defining if an entity should respond to keyboard inputs
        /// </summary>
        bool KeyboardListener { get; set; }

        /// <summary>
        /// bool named 'MouseListener' for defining if an entity should respond to mouse inputs
        /// </summary>
        bool MouseListener { get; set; }
    }
}
