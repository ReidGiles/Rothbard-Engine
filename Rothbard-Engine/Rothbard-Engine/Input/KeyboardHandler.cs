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
    class KeyboardHandler : EventArgs, IKeyboardInput
    {
        // DECLARE a Keys[], call it '_inputKey'
        private Keys[] _inputKey;

        // DECLARE an IDictionary of type <Guid, IDictionary<Type, IComponent>>, call it '_entityComponentLink'
        private IDictionary<Guid, IDictionary<Type, IComponent>> _entityComponentLink;

        /// <summary>
        /// Constructor for KeyboardHandler
        /// </summary>
        /// <param name="entityComponentLink"></param>
        public KeyboardHandler(IDictionary<Guid, IDictionary<Type, IComponent>> entityComponentLink)
        {
            // INITIALISE _entityComponentLink
            _entityComponentLink = entityComponentLink;
        }

        /// <summary>
        /// Returns keys pressed on keyboard
        /// </summary>
        public Keys[] GetInputKey()
        {
            // get the state of keys
            KeyboardState keyboardState = Keyboard.GetState();
            // add the pressed keys to the list _inputKeys
            _inputKey = keyboardState.GetPressedKeys();
            //return _inputKeys
            return _inputKey;
        }

        /// <summary>
        /// Return a list of components associated with the entity if that entity is a keyboard listener
        /// </summary>
        /// <returns></returns>
        public IDictionary<Guid, IDictionary<Type, IComponent>> GetEntityComponents()
        {
            // DECLARE an IDictionary of type <Guid, IDictionary<Type, IComponent>>, call it 'entityComponents'
            IDictionary<Guid, IDictionary<Type, IComponent>> entityComponents;

            // INSTANTIATE 'entityComponents'
            entityComponents = new Dictionary<Guid, IDictionary<Type, IComponent>>();

            // FOR every key of type Guid in _entityComponentLink
            foreach (Guid entity in _entityComponentLink.Keys)
            {
                // IF the entity has an InputListener component with 'KeyBoard' listener property set to true
                if (((InputListener)_entityComponentLink[entity][typeof(InputListener)]).KeyboardListener)
                {
                    // Add the entity and all associated components to 'entityComponents'
                    entityComponents.Add(entity, _entityComponentLink[entity]);
                }
            }
            return entityComponents;
        }
    }
}