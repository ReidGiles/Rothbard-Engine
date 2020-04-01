using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    public interface ICollisionInput
    {
        /// <summary>
        /// Returns an array containing two colliding entity keys
        /// </summary>
        /// <returns></returns>
        Guid[] GetEntityKeys();
        /// <summary>
        /// Returrs an array containing two colliding entity tags
        /// </summary>
        /// <returns></returns>
        string[] GetEntityTags();
        /// <summary>
        /// Returns a dictionary containing the components of each collided entity
        /// </summary>
        /// <returns></returns>
        IDictionary<Guid, IDictionary<Type, IComponent>> GetEntityComponents();
    }
}