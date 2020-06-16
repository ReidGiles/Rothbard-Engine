using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    class EntityManager : IEntityManager, IUpdatable
    {
        private IDictionary<Guid, bool> _entities;

        /// <summary>
        /// Constructor for Entity
        /// </summary>
        public EntityManager()
        {
            _entities = new Dictionary<Guid, bool>();
        }

        public Guid Request()
        {
            Guid entity = Guid.NewGuid();
            _entities.Add(entity, false);
            Console.WriteLine("EM: Entity created");
            return entity;
        }

        public void Terminate(Guid pGuid)
        {
            _entities[pGuid] = true;
        }

        public void Update(GameTime pGameTime)
        {
            if (_entities != null)
            {
                foreach (Guid entity in _entities.Keys.ToList())
                {
                    if (_entities[entity])
                    {
                        _entities.Remove(entity);
                        Console.WriteLine("EM: Entity terminated");
                    }
                }
            }
        }
    }
}