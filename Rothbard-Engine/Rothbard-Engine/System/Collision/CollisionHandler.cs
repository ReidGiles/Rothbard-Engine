using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    class CollisionHandler : EventArgs, ICollisionInput
    {
        private Guid[] _entityKeys;
        private string[] _entityTags;
        private IDictionary<Guid, IDictionary<Type, IComponent>> _entityComponents;

        /// <summary>
        /// Constructor for Collision Handler
        /// </summary>
        /// <param name="entityKeys"></param>
        /// <param name="entityNames"></param>
        /// <param name="entityComponents"></param>
        public CollisionHandler(Guid[] entityKeys, string[] entityTags, IDictionary<Guid, IDictionary<Type, IComponent>> entityComponents)
        {
            _entityKeys = entityKeys;
            _entityTags = entityTags;
            _entityComponents = entityComponents;
        }

        public Guid[] GetEntityKeys()
        {
            return _entityKeys;
        }

        public string[] GetEntityTags()
        {
            return _entityTags;
        }

        public IDictionary<Guid, IDictionary<Type, IComponent>> GetEntityComponents()
        {
            return _entityComponents;
        }
    }
}