using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    /// <summary>
    /// Stores keyboard event data
    /// </summary>
    public interface IKeyboardInput
    {
        /// <summary>
        /// Returns keys pressed on keyboard
        /// </summary>
        Keys[] GetInputKey();

        /// <summary>
        /// Return a list of components associated with the entity if that entity is a keyboard listener
        /// </summary>
        /// <returns></returns>
        IDictionary<Guid, IDictionary<Type, IComponent>> GetEntityComponents();
    }
}