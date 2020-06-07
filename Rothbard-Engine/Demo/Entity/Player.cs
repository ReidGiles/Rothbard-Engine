using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Rothbard_Engine;

namespace Demo
{
    /// <summary>
    /// Stores individual entity behaviour logic
    /// </summary>
    class Player : ICollisionListener, IKeyboardListener, IUpdatable
    {
        private Guid _guid;

        // args to store the keyboard inputs
        private IKeyboardInput _args;

        private bool _inputFlag;

        public Player(Guid pGuid)
        {
            _guid = pGuid;

            _inputFlag = false;
        }

        public void OnNewCollision(object sender, ICollisionInput args)
        {
            Guid entity1 = args.GetEntityKeys()[0];
            Guid entity2 = args.GetEntityKeys()[1];

            if (entity1 == _guid || entity2 == _guid)
            {
                if (args.GetEntityTags()[0] == "hostile" || args.GetEntityTags()[1] == "hostile")
                {
                }
                //((IMove)args.GetEntityComponents()[entity2][typeof(Move)]).Velocity = ((IMove)args.GetEntityComponents()[entity1][typeof(Move)]).Velocity;
                //((IInputListener)args.GetEntityComponents()[entity2][typeof(InputListener)]).KeyboardListener = true;
            }
        }

        public void OnNewKeyboardInput(object sender, IKeyboardInput args)
        {
            // on keyboard event set the keyboard input to args
            _args = args;
            _inputFlag = true;

            if (_inputFlag)
            {
                // NOTE: Make keys generic, set by user in component
                foreach (Keys k in _args.GetInputKey())
                {
                    if (k == Keys.Left)
                        ((IPosition)args.GetEntityComponents()[_guid][typeof(Position)]).XPos -= ((IMove)args.GetEntityComponents()[_guid][typeof(Move)]).Velocity.X;
                    if (k == Keys.Right)
                        ((IPosition)args.GetEntityComponents()[_guid][typeof(Position)]).XPos += ((IMove)args.GetEntityComponents()[_guid][typeof(Move)]).Velocity.X;
                    if (k == Keys.Up)
                        ((IPosition)args.GetEntityComponents()[_guid][typeof(Position)]).YPos -= ((IMove)args.GetEntityComponents()[_guid][typeof(Move)]).Velocity.Y;
                    if (k == Keys.Down)
                        ((IPosition)args.GetEntityComponents()[_guid][typeof(Position)]).YPos += ((IMove)args.GetEntityComponents()[_guid][typeof(Move)]).Velocity.Y;
                }
            }
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}