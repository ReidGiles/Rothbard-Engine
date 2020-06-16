using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    /// <summary>
    /// Collision event publisher
    /// </summary>
    interface ICollisionPublisher
    {
        /// <summary>
        /// Subscription method, used to store reference to listeners
        /// </summary>
        /// <param name="handler"></param>
        void AddListener(EventHandler<ICollisionInput> handler);
    }
}