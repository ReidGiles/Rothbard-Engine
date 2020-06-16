using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine.Input
{
    /// <summary>
    /// Allows a class to receive mouse event data
    /// </summary>
    interface IMouseListener
    {
        /// <summary>
        /// Receives mouse event data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnNewMouseInput(object sender, IMouseInput args);
    }
}
