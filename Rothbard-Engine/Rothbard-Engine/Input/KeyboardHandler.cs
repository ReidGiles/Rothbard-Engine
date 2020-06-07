using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    class KeyboardHandler : EventArgs, IKeyboardInput
    {
        // list of Keys
        Keys[] _inputKey;

        private IDictionary<Guid, IDictionary<Type, IComponent>> _entityComponentLink;

        public KeyboardHandler(IDictionary<Guid, IDictionary<Type, IComponent>> entityComponentLink)
        {
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

        public IDictionary<Guid, IDictionary<Type, IComponent>> GetEntityComponents()
        {
            IDictionary<Guid, IDictionary<Type, IComponent>> entityComponents;
            entityComponents = new Dictionary<Guid, IDictionary<Type, IComponent>>();
            foreach (Guid entity in _entityComponentLink.Keys)
            {
                if (((InputListener)_entityComponentLink[entity][typeof(InputListener)]).KeyboardListener)
                {
                    entityComponents.Add(entity, _entityComponentLink[entity]);
                }
            }
            return entityComponents;
        }
    }
}