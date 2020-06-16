using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    /// <summary>
    /// Manages input management events
    /// </summary>
    interface IInputManager
    {
        /// <summary>
        /// Subscribe handler as a listener for keyboard events
        /// </summary>
        /// <param name="handler"></param>
        void AddListener(EventHandler<IKeyboardInput> handler);

        /// <summary>
        /// Subscribe handler as a listener for mouse events
        /// </summary>
        /// <param name="handler"></param>
        void AddListener(EventHandler<IMouseInput> handler);
    }
}
