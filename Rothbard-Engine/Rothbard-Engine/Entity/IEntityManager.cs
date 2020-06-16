using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    /// <summary>
    /// Manages the lifecycle of entity
    /// </summary>
    interface IEntityManager
    {
        /// <summary>
        /// Creates a new entity
        /// </summary>
        /// <returns></returns>
        Guid Request();

        /// <summary>
        /// Terminates an entity
        /// </summary>
        /// <param name="pGuid"></param>
        void Terminate(Guid pGuid);
    }
}