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

            // INSTANTIATE input manager
            _inputManager = new InputManager();

            // INSTANTIATE collision system
            _collisionSystem = new CollisionSystem();

            // INSTANTIATE system manager
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

            // Add render system to system manager
            _systemManager.AddSystem(new RenderSystem(_spriteBatch, _graphics, Content));

            // Add collision system to system manager
            _systemManager.AddSystem(_collisionSystem);

            // Add input manager to system manager
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
            // Update the input manager
            ((IUpdatable)_inputManager).Update(gameTime);

            // Update base
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // Set background to transparent
            GraphicsDevice.Clear(Color.Transparent);

            // Update the system manager
            ((IUpdatable)_systemManager).Update(gameTime);


            base.Draw(gameTime);
        }

        /// <summary>
        /// Creates a game entity and assigns starting components
        /// </summary>
        /// <param name="name"></param>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        /// <param name="texture"></param>
        /// <param name="speed"></param>
        /// <param name="keyboardListener"></param>
        /// <param name="mouseListener"></param>
        /// <returns></returns>
        public Guid Spawn(string name, float xPos, float yPos, Texture2D texture, Vector2 speed, bool keyboardListener, bool mouseListener)
        {
            // Request a unique entity Guid
            Guid entity = _entityManager.Request();

            // Request a new position component
            IComponent position = _componentManager.Request<Position>();
            // Request a new render component
            IComponent render = _componentManager.Request<Render>();
            // Request a new move component
            IComponent move = _componentManager.Request<Move>();
            // Request a new input listener component
            IComponent inputListener = _componentManager.Request<InputListener>();
            // Request a new collider component
            IComponent collider = _componentManager.Request<Collider>();

            // SET position component 'XPos' property
            ((Position)position).XPos = xPos; ((Position)position).YPos = yPos;
            // SET render component 'Texture' property
            ((Render)render).Texture = texture;
            // SET move component 'Speed' property
            ((Move)move).Speed = speed;
            // SET input listener component 'KeyboardListener' property
            ((InputListener)inputListener).KeyboardListener = keyboardListener; ((InputListener)inputListener).MouseListener = mouseListener;
            // SET collider component 'Rectangle' property
            ((Collider)collider).Rectangle = new Rectangle(Convert.ToInt32(xPos), Convert.ToInt32(yPos), texture.Width, texture.Height);
            // SET collider component 'Tag' property
            ((Collider)collider).Tag = name;

            // Assign position component to entity
            _componentManager.Assign(position, entity);
            // Assign render component to entity
            _componentManager.Assign(render, entity);
            // Assign move component to entity
            _componentManager.Assign(move, entity);
            // Assign input listener component to entity
            _componentManager.Assign(inputListener, entity);
            // Assign collider component to entity
            _componentManager.Assign(collider, entity);

            // return entity Guid
            return entity;
        }

        /// <summary>
        /// Loads and returns a texture
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public Texture2D LoadTexture(string filename)
        {
            // Return texture loaded via Content at passed file location
            return Content.Load<Texture2D>(filename);
        }

        /// <summary>
        /// Subscribe a collision listener
        /// </summary>
        /// <param name="listener"></param>
        public void SubscribeListener(ICollisionListener listener)
        {
            // Subscribe passed collision listener to the collision system
            ((ICollisionPublisher)_collisionSystem).AddListener(listener.OnNewCollision);
        }

        /// <summary>
        /// Subscribe an keyboard listener
        /// </summary>
        /// <param name="listener"></param>
        public void SubscribeKeyboardListener(IKeyboardListener listener)
        {
            // Subscribe passed keyboard listener to the input manager
            _inputManager.AddListener((listener).OnNewKeyboardInput);
        }

        /// <summary>
        /// Return a list of components associated with a specific entity
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public IList<IComponent> GetComponents(Guid guid)
        {
            // Request components of a specific entity from the component manager
            return _componentManager.Get(guid);
        }

        /// <summary>
        /// Terminates an entity and its components
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool TerminateEntity(Guid entity)
        {
            // Attempt to terminate the entity and its components
            try
            {
                _componentManager.Terminate(entity);
                _entityManager.Terminate(entity);

                return true;
            }
            // Return false if failed
            catch
            {
                return false;
            }
        }
    }
}