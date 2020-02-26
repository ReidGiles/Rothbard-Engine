using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    class MoveSystem : ISystem, IUpdatable, IKeyboardListener
    {
        // DECLARE an IDictionary of type IDictionary, call it '_entityComponentLink'
        private IDictionary<Guid, IDictionary<Type, IComponent>> _entityComponentLink;

        // args to store the keyboard inputs
        private IKeyboardInput _args;

        private bool _inputFlag;

        /// <summary>
        /// Consttructor for MoveSystem
        /// </summary>
        public MoveSystem()
        {
            // INSTANTIATE _entityComponentLink
            _entityComponentLink = new Dictionary<Guid, IDictionary<Type, IComponent>>();

            // set args
            _args = new KeyboardHandler();

            _inputFlag = false;
        }

        /// <summary>
        /// Receives keyboard events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnNewKeyboardInput(object sender, IKeyboardInput args)
        {
            // on keyboard event set the keyboard input to args
            _args = args;
            _inputFlag = true;
        }

        public void Set(IDictionary<Guid, IDictionary<Type, IComponent>> pDictionary)
        {
            _entityComponentLink = pDictionary;
        }

        public void Update(GameTime pGameTime)
        {
            foreach (Guid entity in _entityComponentLink.Keys)
            {
                /*Vector2 velocity = ((IMove)_entityComponentLink[entity][typeof(Move)]).Velocity;
                Vector2 position = new Vector2(((IPosition)_entityComponentLink[entity][typeof(Position)]).XPos, ((IPosition)_entityComponentLink[entity][typeof(Position)]).YPos);
                velocity *= ((IMove)_entityComponentLink[entity][typeof(Move)]).Damping;
                velocity += ((IMove)_entityComponentLink[entity][typeof(Move)]).Acceleration;
                position += velocity;*/

                //((IPosition)_entityComponentLink[entity][typeof(Position)]).XPos += ((IMove)_entityComponentLink[entity][typeof(Move)]).Velocity.X;
                //((IPosition)_entityComponentLink[entity][typeof(Position)]).YPos += ((IMove)_entityComponentLink[entity][typeof(Move)]).Velocity.Y;

                if (((InputListener)_entityComponentLink[entity][typeof(InputListener)]).KeyboardListener)
                {
                    if (_inputFlag)
                    {
                        // NOTE: Make keys generic, set by user in component
                        foreach (Keys k in _args.GetInputKey())
                        {
                            if (k == Keys.Left)
                                ((IPosition)_entityComponentLink[entity][typeof(Position)]).XPos -= ((IMove)_entityComponentLink[entity][typeof(Move)]).Velocity.X;
                            if (k == Keys.Right)
                                ((IPosition)_entityComponentLink[entity][typeof(Position)]).XPos += ((IMove)_entityComponentLink[entity][typeof(Move)]).Velocity.X;
                            if (k == Keys.Up)
                                ((IPosition)_entityComponentLink[entity][typeof(Position)]).YPos -= ((IMove)_entityComponentLink[entity][typeof(Move)]).Velocity.Y;
                            if (k == Keys.Down)
                                ((IPosition)_entityComponentLink[entity][typeof(Position)]).YPos += ((IMove)_entityComponentLink[entity][typeof(Move)]).Velocity.Y;
                        }
                    }
                }
                else
                {
                    ((IPosition)_entityComponentLink[entity][typeof(Position)]).XPos += ((IMove)_entityComponentLink[entity][typeof(Move)]).Velocity.X;
                    ((IPosition)_entityComponentLink[entity][typeof(Position)]).YPos += ((IMove)_entityComponentLink[entity][typeof(Move)]).Velocity.Y;
                }
            }
        }
    }
}
