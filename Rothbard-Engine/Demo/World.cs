using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Rothbard_Engine;

namespace Demo
{
    class World : IUpdatable
    {
        private Demo _demo;

        private Player1 _player1;
        private Player2 _player2;

        private Ball _ball;

        /// <summary>
        /// Constructor for World
        /// </summary>
        /// <param name="demo"></param>
        public World(Demo demo)
        {
            _demo = demo;
        }

        public void Load()
        {
            _player1 = new Player1(_demo.Spawn("player", 25, 900 / 2, _demo.LoadTexture("Paddle"), new Vector2(5, 5), true, false));            
            _player2 = new Player2(_demo.Spawn("player", 1600 - 25 - _demo.LoadTexture("Paddle").Width, 900 / 2, _demo.LoadTexture("Paddle"), new Vector2(5, 5), true, false));           
            _ball = new Ball(_demo.Spawn("ball", 1600 / 2, 900 / 2, _demo.LoadTexture("Ball"), new Vector2(5, 5), false, false));

            _demo.SubscribeListener(_player1);
            _demo.SubscribeListener(_player2);
            _demo.SubscribeListener(_ball);

            _demo.SubscribeKeyboardListener(_player1);
            _demo.SubscribeKeyboardListener(_player2);
            _demo.SubscribeKeyboardListener(_ball);
        }

        public void Update(GameTime gameTime)
        {
            _player1.Update(gameTime);
            _player2.Update(gameTime);
            _ball.Update(gameTime);
            _ball.SetComponents(_demo.GetComponents(_ball.GetGuid()));
        }
    }
}