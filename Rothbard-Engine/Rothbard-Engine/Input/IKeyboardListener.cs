using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    /// <summary>
    /// Allows a class to receive keyboard event data
    /// </summary>
    public interface IKeyboardListener
    {
        /// <summary>
        /// Receives keyboard event data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnNewKeyboardInput(object sender, IKeyboardInput args);
    }
}