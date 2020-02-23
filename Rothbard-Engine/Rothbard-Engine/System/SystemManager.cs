using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    class SystemManager : ISystemManager, IUpdatable
    {
        // DECLARE an IList of type ISystem, call it '_systems'
        private IList<ISystem> _systems;

        /// <summary>
        /// Constructor for SystemManager
        /// </summary>
        public SystemManager()
        {
            // INSTANTIATE _systems
            _systems = new List<ISystem>();
        }

        /// <summary>
        /// Adds a system to the system list
        /// </summary>
        /// <param name="pSystem"></param>
        public void AddSystem(ISystem pSystem)
        {
            _systems.Add(pSystem);
        }

        /// <summary>
        /// Removes a system from the system list
        /// </summary>
        /// <param name="pSystem"></param>
        public void RemoveSystem(ISystem pSystem)
        {
            _systems.Remove(pSystem);
        }

        /// <summary>
        /// Removes a system from the system list
        /// </summary>
        public void RemoveSystem(int pUID)
        {
        }

        /// <summary>
        /// Issues updates to all active systems
        /// </summary>
        /// <param name="pGameTime"></param>
        public void Update(GameTime pGameTime)
        {
            // Update each system present in _systems list
            foreach (ISystem s in _systems)
            {
                ((IUpdatable)s).Update(pGameTime);
            }
        }
    }
}