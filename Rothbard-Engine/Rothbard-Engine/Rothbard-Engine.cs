using System;
using System.Collections.Generic;
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
        /// The collision system
        /// </summary>
        private ISystem _collisionSystem;

        /// <summary>
        /// The ssystem manager
        /// </summary>j
        private ISystemManager _systemManager;

        private SpriteBatch _spriteBatch;

        // boolean to declare the engine ready for use
        public bool _ready;

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

            // INSTANTIATE collision system
            _collisionSystem = new CollisionSystem();

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
        
            MoveSystem moveSystem = new MoveSystem();
            _inputManager.AddListener(((IKeyboardListener)moveSystem).OnNewKeyboardInput);

            _systemManager.AddSystem(moveSystem);
            _systemManager.AddSystem(new RenderSystem(_spriteBatch, _graphics, Content));
            _systemManager.AddSystem(_collisionSystem);
            _systemManager.AddSystem(_inputManager as ISystem);

            // Declare engine ready for use
            _ready = true;
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
            ((IUpdatable)_inputManager).Update(gameTime);
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

        public Guid Spawn(string name, float xPos, float yPos, Texture2D texture, Vector2 velocity, bool keyboardListener, bool mouseListener)
        {
            Guid entity = _entityManager.Request();

            IComponent position = _componentManager.Request<Position>();
            IComponent render = _componentManager.Request<Render>();
            IComponent move = _componentManager.Request<Move>();
            IComponent inputListener = _componentManager.Request<InputListener>();
            IComponent collider = _componentManager.Request<Collider>();

            ((Position)position).XPos = xPos; ((Position)position).YPos = yPos;
            ((Render)render).Texture = texture;
            ((Move)move).Velocity = velocity;
            ((InputListener)inputListener).KeyboardListener = keyboardListener; ((InputListener)inputListener).MouseListener = mouseListener;
            ((Collider)collider).Rectangle = new Rectangle(Convert.ToInt32(xPos), Convert.ToInt32(yPos), texture.Width, texture.Height);
            ((Collider)collider).Tag = name;

            _componentManager.Assign(position, entity);
            _componentManager.Assign(render, entity);
            _componentManager.Assign(move, entity);
            _componentManager.Assign(inputListener, entity);
            _componentManager.Assign(collider, entity);

            return entity;
        }

        public Texture2D LoadTexture(string filename)
        {
            return Content.Load<Texture2D>(filename);
        }

        /// <summary>
        /// Subscribe a collision listener
        /// </summary>
        /// <param name="listener"></param>
        public void SubscribeListener(ICollisionListener listener)
        {
            ((ICollisionPublisher)_collisionSystem).AddListener(listener.OnNewCollision);
        }

        /// <summary>
        /// Subscribe an keyboard listener
        /// </summary>
        /// <param name="listener"></param>
        public void SubscribeKeyboardListener(IKeyboardListener listener)
        {
            _inputManager.AddListener((listener).OnNewKeyboardInput);
        }

        public IList<IComponent> GetComponents(Guid guid)
        {
            return _componentManager.Get(guid);
        }
    }
}