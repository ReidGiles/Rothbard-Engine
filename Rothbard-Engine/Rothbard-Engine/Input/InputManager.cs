using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{

    /// <summary>
    /// Constructor for InputManager
    /// </summary>
    class InputManager : IInputManager, IUpdatable
    {
        private event EventHandler<IKeyboardInput> NewKeyboardInput;
        private event EventHandler<IMouseInput> NewMouseInput;

        /// <summary>
        /// Constructor for InputManager
        /// </summary>
        public InputManager()
        {
        }

        /// <summary>
        /// Publisher method, contacts all listeners
        /// </summary>
        protected virtual void OnNewKeyboardInput()
        {
            // pass the parameters into the new keybaord input then add to NewKeyboardInput
            IKeyboardInput args = new KeyboardHandler();
            NewKeyboardInput(this, args);
        }

        /// <summary>
        /// Publisher method, contacts all listeners
        /// </summary>
        /// <param name="args"></param>
        protected virtual void OnNewMouseInput(IMouseInput args)
        {
            // pass the parameters into the new keybaord input then add to NewKeyboardInput
            NewMouseInput(this, args);
        }

        public void AddListener(EventHandler<IKeyboardInput> handler)
        {
            NewKeyboardInput += handler;

        }

        public void AddListener(EventHandler<IMouseInput> handler)
        {
            NewMouseInput += handler;
        }

        public void Update(GameTime pGameTime)
        {
            // look for changes in the input

            if (NewKeyboardInput != null)
            {
                // update listeners
                IKeyboardInput args = new KeyboardHandler();
                if (args.GetInputKey().Length > 0)
                    OnNewKeyboardInput();
            }

            if (NewMouseInput != null)
            {
                // update listeners
                IMouseInput args = new MouseHandler();
                if (args.GetMouseVal() != null)
                {
                    OnNewMouseInput(args);
                }
            }
        }
    }
}