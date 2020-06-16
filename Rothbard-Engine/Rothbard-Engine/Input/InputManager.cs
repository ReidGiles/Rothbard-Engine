using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{

    /// <summary>
    /// Manages input management events
    /// </summary>
    class InputManager : IInputManager, ISystem, IUpdatable
    {
        // DECLARE an IDictionary of type <Guid, IDictionary<Type, IComponent>>, call it '_entityComponentLink'
        private IDictionary<Guid, IDictionary<Type, IComponent>> _entityComponentLink;

        // DECLARE an EventHandler of type <IKeyboardInput>, call it 'NewKeboardInput'
        private event EventHandler<IKeyboardInput> NewKeyboardInput;

        // DECLARE an EventHandler of type <IMouseInput>, call it 'NewMouseInput'
        private event EventHandler<IMouseInput> NewMouseInput;

        /// <summary>
        /// Constructor for InputManager
        /// </summary>
        public InputManager()
        {
            // INSTANTIATE _entityComponentLink
            _entityComponentLink = new Dictionary<Guid, IDictionary<Type, IComponent>>();
        }

        /// <summary>
        /// Publisher method, contacts all listeners
        /// </summary>
        private void OnNewKeyboardInput()
        {
            // DECLARE and INSTANTIATE a new KeyboardHandler, call it 'args' and pass it '_entityComponentLink'
            IKeyboardInput args = new KeyboardHandler(_entityComponentLink);

            // Trigger NewKeyboardInput events, passing it 'args'
            NewKeyboardInput(this, args);
        }

        /// <summary>
        /// Publisher method, contacts all listeners
        /// </summary>
        /// <param name="args"></param>
        protected virtual void OnNewMouseInput(IMouseInput args)
        {
            // Trigger NewMouseInput events, passing it 'args'
            NewMouseInput(this, args);
        }

        /// <summary>
        /// Subscribe handler as a listener for keyboard events
        /// </summary>
        /// <param name="handler"></param>
        public void AddListener(EventHandler<IKeyboardInput> handler)
        {
            // Subscribe passed handler to 'NewKeyboardInput'
            NewKeyboardInput += handler;

        }

        /// <summary>
        /// Subscribe handler as a listener for mouse events
        /// </summary>
        /// <param name="handler"></param>
        public void AddListener(EventHandler<IMouseInput> handler)
        {
            // Subscribe passed handler to 'NewMouseInput'
            NewMouseInput += handler;
        }

        /// <summary>
        /// Updates the _entityComponentLink dictionary
        /// </summary>
        /// <param name="pDictionary"></param>
        public void Set(IDictionary<Guid, IDictionary<Type, IComponent>> pDictionary)
        {
            _entityComponentLink = pDictionary;
        }

        /// <summary>
        /// Updates the input manager, checking for changes in input
        /// </summary>
        /// <param name="pGameTime"></param>
        public void Update(GameTime pGameTime)
        {
            // IF there are keyboard listeners
            if (NewKeyboardInput != null)
            {
                // DELCARE and INSTANTIATE a new KeyboardHandler and pass it 'entityComponentLink, call it 'args'
                IKeyboardInput args = new KeyboardHandler(_entityComponentLink);

                // IF a key has been pressed then trigger keyboard event
                if (args.GetInputKey().Length > 0)
                    OnNewKeyboardInput();
            }

            // IF there are mouse listeners
            if (NewMouseInput != null)
            {
                // DELCARE and INSTANTIATE a new MouseHandler and pass it 'entityComponentLink, call it 'args'
                IMouseInput args = new MouseHandler();

                // IF a key has been pressed then trigger mouse event
                if (args.GetMouseVal() != null)
                {
                    OnNewMouseInput(args);
                }
            }
        }
    }
}