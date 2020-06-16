using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    /// <summary>
    /// Manages the lifecycle of entities
    /// </summary>
    class EntityManager : IEntityManager
    {
        // DECLARE an IDictionary of type <Guid, Bool> to track entity lifecycle, call it '_entities'
        private IDictionary<Guid, bool> _entities;

        /// <summary>
        /// Constructor for Entity
        /// </summary>
        public EntityManager()
        {
            // INSTANTIATE _entities
            _entities = new Dictionary<Guid, bool>();
        }

        /// <summary>
        /// Creates, records and returns a new and unique entity
        /// </summary>
        /// <returns></returns>
        public Guid Request()
        {
            // DECLARE an INTANTIATE a new entity Guid, call it 'entity'
            Guid entity = Guid.NewGuid();

            // Add the new entity to _entities to track its lifecycle
            _entities.Add(entity, false);

            Console.WriteLine("EM: Entity created");

            return entity;
        }

        /// <summary>
        /// Flags a specified entity for termination
        /// </summary>
        /// <param name="pGuid"></param>
        public void Terminate(Guid pGuid)
        {
            // If _entities dictionary is not empty
            if (_entities != null)
            {
                // For each key of type Guid in _entities
                foreach (Guid entity in _entities.Keys.ToList())
                {
                    // If the key is equal to the passed entity
                    if (entity == pGuid)
                    {
                        // Remove the entity from the list
                        _entities.Remove(pGuid);

                        Console.WriteLine("EM: Entity terminated");
                    }
                }
            }
        }
    }
}