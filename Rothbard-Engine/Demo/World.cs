using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Rothbard_Engine;

namespace Demo
{
    /// <summary>
    /// Manages the game world and logic
    /// </summary>
    class World : IUpdatable
    {
        // DECLARE a Demo, call it 'demo'
        private Demo _demo;

        // DECLARE a Player1, call it '_player1'
        private Player1 _player1;

        // DECLARE a Player2, call it '_player2'
        private Player2 _player2;

        // DECLARE a Ball, call it '_ball'
        private Ball _ball;

        /// <summary>
        /// Constructor for World
        /// </summary>
        /// <param name="demo"></param>
        public World(Demo demo)
        {
            // SET '_demo' to 'demo'
            _demo = demo;
        }

        /// <summary>
        /// Loads game world pre-reqs
        /// </summary>
        public void Load()
        {
            // INITIALISE '_player1' with a call to the engine method 'Spawn()'
            _player1 = new Player1(_demo.Spawn("player", 25, 900 / 2, _demo.LoadTexture("Paddle"), new Vector2(5, 5), true, false));
            // INITIALISE '_player2' with a call to the engine method 'Spawn()'
            _player2 = new Player2(_demo.Spawn("player", 1600 - 25 - _demo.LoadTexture("Paddle").Width, 900 / 2, _demo.LoadTexture("Paddle"), new Vector2(5, 5), true, false));
            // INITIALISE '_ball' with a call to the engine method 'Spawn()'
            _ball = new Ball(_demo.Spawn("ball", 1600 / 2, 900 / 2, _demo.LoadTexture("Ball"), new Vector2(5, 5), false, false));

            // SUBSCRIBE '_ball' as a collision listener with a call to the engine method 'SubscribeListener()'
            _demo.SubscribeListener(_ball);

            // SUBSCRIBE '_player1' as a keyboard listener with a call to the engine method 'SubscribeKeyboardListener()'
            _demo.SubscribeKeyboardListener(_player1);
            // SUBSCRIBE '_player2' as a collision listener with a call to the engine method 'SubscribeKeyboardListener()'
            _demo.SubscribeKeyboardListener(_player2);
        }

        /// <summary>
        /// Updates the game world
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            // Update '_ball'
            _ball.Update(gameTime);

            // Give '_ball' reference to it's components
            _ball.SetComponents(_demo.GetComponents(_ball.GetGuid()));
        }
    }
}