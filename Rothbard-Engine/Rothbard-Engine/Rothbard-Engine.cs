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

        private SpriteBatch _spriteBatch;

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
            _systemManager = new SystemManager(_componentManager);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _systemManager.AddSystem(new RenderSystem(_spriteBatch, _graphics, Content));
            Guid e1 = _entityManager.Request(); Guid e2 = _entityManager.Request();
            Position e1p = new Position(); e1p.XPos = 5; e1p.YPos = 5;
            Position e2p = new Position(); e2p.XPos = 50; e2p.YPos = 50;
            Render e1r = new Render(); e1r.Texture = Content.Load<Texture2D>("Hostile");
            Render e2r = new Render(); e2r.Texture = Content.Load<Texture2D>("Hostile");
            _componentManager.Assign(e1p, e1);
            _componentManager.Assign(e1r, e1);
            _componentManager.Assign(e2p, e2);
            _componentManager.Assign(e2r, e2);
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
            //((IUpdatable)_systemManager).Update(gameTime);
            ((IUpdatable)_entityManager).Update(gameTime);
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
            base.Draw(gameTime);
        }
    }
}