using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Rothbard_Engine
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class RothbardEngine : Game
    {
        /// <summary>
        /// The graphics device manager
        /// </summary>
        private GraphicsDeviceManager _graphics;

        /// <summary>
        /// The entity manager
        /// </summary>
        private IEntityManager _entityManager;

        // DECLARE an IComponentManager, call it '_componentManager'
        private IComponentManager _componentManager;

        /// <summary>
        /// The scene manager
        /// </summary>
        private ISceneManager _sceneManager;

        /// <summary>
        /// The input manager
        /// </summary>
        private IInputManager _inputManager;

        /// <summary>
        /// The ssystem manager
        /// </summary>j
        private ISystemManager _systemManager;

        public RothbardEngine()
        {
            // INSTANTIATE graphics device manager
            _graphics = new GraphicsDeviceManager(this);
            // Set root directory for game content
            Content.RootDirectory = "Content";

            // set graphics height
            _graphics.PreferredBackBufferHeight = 900;

            // set graphics width
            _graphics.PreferredBackBufferWidth = 1600;           
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // INSTANTIATE entity manager
            _entityManager = new EntityManager();

            // INSTANTIATE componet manager
            _componentManager = new ComponentManager();

            // INSTANTIATE scene manager
            _sceneManager = new SceneManager();

            // INSTANTIATE input manager
            _inputManager = new InputManager();

            // INSTANTIATE scene manager
            _systemManager = new SystemManager();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            _systemManager.AddSystem(new RenderSystem());
            Guid e1 = _entityManager.Request();
            Guid e2 = _entityManager.Request();
            _componentManager.Request(new Position(), "position", e1);
            _componentManager.Request(new Render(), "render", e1);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Transparent);

            ((IUpdatable)_systemManager).Update(gameTime);
            ((IUpdatable)_entityManager).Update(gameTime);

            base.Draw(gameTime);
        }
    }
}