using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Rothbard_Engine;

namespace Demo
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : RothbardEngine
    {
        public Game1()
        {
        }

        private void Begin()
        {
            Spawn(700, 100, LoadTexture("Hostile"), new Vector2(17, 17), true, false);
            Spawn(5, 50, LoadTexture("Hostile"), new Vector2(2, 0), false, false);
            Spawn(5, 250, LoadTexture("Hostile"), new Vector2(2, 0), false, false);
            Spawn(5, 450, LoadTexture("Hostile"), new Vector2(2, 0), false, false);
            Spawn(5, 650, LoadTexture("Hostile"), new Vector2(2, 0), false, false);
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
        }
    }
}