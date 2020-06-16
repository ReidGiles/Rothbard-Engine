using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    /// <summary>
    /// Collision event data
    /// </summary>
    class CollisionHandler : EventArgs, ICollisionInput
    {
        // DECLARE a Guid[], call it '_entityKeys
        private Guid[] _entityKeys;

        // DECLARE a string[], call it '_entityTags'
        private string[] _entityTags;

        // DECLARE an IDictionary of type <Guid, IDictionary<Type, IComponent>>, call it '_entityComponents'
        private IDictionary<Guid, IDictionary<Type, IComponent>> _entityComponents;

        /// <summary>
        /// Constructor for Collision Handler
        /// </summary>
        /// <param name="entityKeys"></param>
        /// <param name="entityNames"></param>
        /// <param name="entityComponents"></param>
        public CollisionHandler(Guid[] entityKeys, string[] entityTags, IDictionary<Guid, IDictionary<Type, IComponent>> entityComponents)
        {
            // INITIALISE '_entityKeys'
            _entityKeys = entityKeys;

            // INITIALISE '_entityTags'
            _entityTags = entityTags;

            // INITIALISE '_entityComponents'
            _entityComponents = entityComponents;
        }

        /// <summary>
        /// Returns an array containing two colliding entity keys
        /// </summary>
        /// <returns></returns>
        public Guid[] GetEntityKeys()
        {
            return _entityKeys;
        }

        /// <summary>
        /// Returrs an array containing two colliding entity tags
        /// </summary>
        /// <returns></returns>
        public string[] GetEntityTags()
        {
            return _entityTags;
        }

        /// <summary>
        /// Returns a dictionary containing the components of each collided entity
        /// </summary>
        /// <returns></returns>
        public IDictionary<Guid, IDictionary<Type, IComponent>> GetEntityComponents()
        {
            return _entityComponents;
        }
    }
}