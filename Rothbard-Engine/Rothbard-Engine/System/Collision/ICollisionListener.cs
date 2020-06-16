using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    /// <summary>
    /// Collision event listener
    /// </summary>
    public interface ICollisionListener
    {
        /// <summary>
        /// Receives collision event data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnNewCollision(object sender, ICollisionInput args);
    }
}