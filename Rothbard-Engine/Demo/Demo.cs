using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Rothbard_Engine;

namespace Demo
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Demo : RothbardEngine
    {
        private World _world;

        /// <summary>
        /// Constructor for Demo
        /// </summary>
        public Demo()
        {
            _world = new World(this);
        }

        private void Begin()
        {
            _world.Load();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Update engine
            base.Update(gameTime);
            // Check if engine is ready for use
            if (_ready)
            {
                // Begin demo
                Begin();
                _ready = false;
            }
            if (_world != null)
                _world.Update(gameTime);
        }
    }
}