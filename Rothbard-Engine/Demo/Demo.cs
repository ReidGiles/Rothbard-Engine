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
        // DECLARE a World, call it '_world'
        private World _world;

        /// <summary>
        /// Constructor for Demo
        /// </summary>
        public Demo()
        {
            // INSTANTIATE '_world'
            _world = new World(this);
        }

        /// <summary>
        /// Loads the game world
        /// </summary>
        private void Begin()
        {
            // Load the game world
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
            // Update the world if it exists
            if (_world != null)
                _world.Update(gameTime);
        }
    }
}