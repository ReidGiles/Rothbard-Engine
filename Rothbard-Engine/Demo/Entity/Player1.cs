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
    /// Stores Player1 behaviour logic
    /// </summary>
    class Player1 : IKeyboardListener
    {
        // DECLARE a Guid, call it '_guid'
        private Guid _guid;

        // DECLARE an IKeyboardInput, call it '_args'
        private IKeyboardInput _args;

        // DECLARE a bool, call it '_inputFlag'
        private bool _inputFlag;

        /// <summary>
        /// Constructor for Player2
        /// </summary>
        /// <param name="pGuid"></param>
        public Player1(Guid pGuid)
        {
            // SET '_guid' to 'pGuid'
            _guid = pGuid;
        }

        /// <summary>
        /// Receives keyboard event data to control entity movement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>

        public void OnNewKeyboardInput(object sender, IKeyboardInput args)
        {
            // SET '_args' to 'args'
            _args = args;

            // SET '_inputFlag' to true
            _inputFlag = true;

            // IF '_inputFlag' is set to true
            if (_inputFlag)
            {
                // FOR each key that is currently being pressed
                foreach (Keys k in _args.GetInputKey())
                {
                    // IF the W key is pressed AND the paddle is not at the top border THEN move the paddle up
                    if (k == Keys.W && ((IPosition)args.GetEntityComponents()[_guid][typeof(Position)]).YPos > 0)
                        ((IPosition)args.GetEntityComponents()[_guid][typeof(Position)]).YPos -= ((IMove)args.GetEntityComponents()[_guid][typeof(Move)]).Speed.Y;
                    // IF the S key is pressed AND the paddle is not at the bottom of the screen THEN move the paddle down
                    if (k == Keys.S && ((IPosition)args.GetEntityComponents()[_guid][typeof(Position)]).YPos < 900 - 100)
                        ((IPosition)args.GetEntityComponents()[_guid][typeof(Position)]).YPos += ((IMove)args.GetEntityComponents()[_guid][typeof(Move)]).Speed.Y;
                }
            }
        }
    }
}