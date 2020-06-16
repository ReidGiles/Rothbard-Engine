using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    /// <summary>
    /// Manages the lifecycle of systems
    /// </summary>
    interface ISystemManager
    {
        /// <summary>
        /// Adds a system to the system list
        /// </summary>
        /// <param name="pSystem"></param>
        void AddSystem(ISystem pSystem);

        /// <summary>
        /// Removes a system from the system list
        /// </summary>
        /// <param name="pSystem"></param>
        void RemoveSystem(ISystem pSystem);
    }
}