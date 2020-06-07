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

        private Player _player;

        private IList<Hostile> _hostiles;

        /// <summary>
        /// Constructor for World
        /// </summary>
        /// <param name="demo"></param>
        public World(Demo demo)
        {
            _demo = demo;
            _hostiles = new List<Hostile>();
        }

        public void Load()
        {
            _player = new Player(_demo.Spawn("player", 700, 100, _demo.LoadTexture("Hostile"), new Vector2(5, 5), true, false));
            _demo.SubscribeListener(_player);

            _hostiles.Add(new Hostile(_demo.Spawn("hostile", 5, 50, _demo.LoadTexture("Hostile"), new Vector2(2, 0), false, false)));
            _hostiles.Add(new Hostile(_demo.Spawn("hostile", 5, 250, _demo.LoadTexture("Hostile"), new Vector2(2, 0), false, false)));
            _hostiles.Add(new Hostile(_demo.Spawn("hostile", 5, 450, _demo.LoadTexture("Hostile"), new Vector2(2, 0), false, false)));
            _hostiles.Add(new Hostile(_demo.Spawn("hostile", 5, 650, _demo.LoadTexture("Hostile"), new Vector2(2, 0), false, false)));
            foreach (Hostile hostile in _hostiles)
            {
                _demo.SubscribeListener(hostile);
            }

            _demo.SubscribeKeyboardListener(_player);
        }

        public void Update(GameTime gameTime)
        {
            _player.Update(gameTime);
            foreach (Hostile hostile in _hostiles)
            {
                hostile.Update(gameTime);
                hostile.SetComponents(_demo.GetComponents(hostile.GetGuid()));
            }
        }
    }
}