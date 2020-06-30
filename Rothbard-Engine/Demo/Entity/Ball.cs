using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Rothbard_Engine;

namespace Demo
{
    public class Ball: ICollisionListener, IUpdatable
    {
        // DECLARE a Guid, call it '_guid'
        private Guid _guid;

        // DECLARE an IList<IComponent>, call it '_compoents'
        private IList<IComponent> _components;

        // DECLARE a Random, call it '_random'
        private Random _random;

        // DECLARE an int, call it '_facingDirectionX'
        private int _facingDirectionX;

        // DECLARE an int, call it '_facingDirectionY'
        private int _facingDirectionY;

        // DECLARE a bool, call it '_serveSwitch'
        private bool _serveSwitch;

        /// <summary>
        /// Constructor for Ball
        /// </summary>
        /// <param name="pGuid"></param>
        public Ball(Guid pGuid)
        {
            // SET '_guid' to 'pGuid'
            _guid = pGuid;

            // INSTANTIATE '_components'
            _components = new List<IComponent>();

            // INSTANTIATE '_random'
            _random = new Random();

            // SET '_facingDirectionX' to 1
            _facingDirectionX = 1;

            // SET '_facingDirectionY' to 1
            _facingDirectionY = 1;

            // SET '_serveSwitch' to true
            _serveSwitch = true;

        }

        /// <summary>
        /// Receives collision event data, used to drive ball bounce behaviour
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnNewCollision(object sender, ICollisionInput args)
        {
            // SET 'entity1' to the first collider entity
            Guid entity1 = args.GetEntityKeys()[0];

            // SET 'entity2' to the second collider entity
            Guid entity2 = args.GetEntityKeys()[1];

            // IF one of the collider entities is the ball
            if (entity1 == _guid || entity2 == _guid)
            {
                // Flip the balls direction
                _facingDirectionX *= -1;

                // Increment the balls speed by 2
                _components.OfType<Move>().First().Speed = new Vector2(_components.OfType<Move>().First().Speed.X + 2, _components.OfType<Move>().First().Speed.Y);
            }
        }

        /// <summary>
        /// Updates the '_components' list
        /// </summary>
        /// <param name="pComponents"></param>
        public void SetComponents(IList<IComponent> pComponents)
        {
            // SET '_components' to 'pComponents'
            _components = pComponents;
        }

        /// <summary>
        /// Retrieves the entities Guid
        /// </summary>
        /// <returns></returns>
        public Guid GetGuid()
        {
            return _guid;
        }

        /// <summary>
        /// Serves the ball from the centre of the screen with a random rotation
        /// </summary>
        public void Serve()
        {
            // IF '_serveSwitch' is set to true
            if (_serveSwitch)
            {
                // Reset ball speed
                _components.OfType<Move>().First().Speed = new Vector2(5, 5);

                // Reset ball location
                _components.OfType<Position>().First().XPos = 1600 / 2;
                _components.OfType<Position>().First().YPos = 900 / 2;

                // Randomise ball rotation
                _components.OfType<Move>().First().Rotation = (float)(Math.PI / 2 + (_random.NextDouble() * (Math.PI / 1.5F) - Math.PI / 3));

                // Randomise facing direction
                if (_random.Next(0, 2) == 1)
                {
                    _facingDirectionX *= -1;
                }

                // SET '_serveSwitch' to false
                _serveSwitch = false;
            }
        }

        /// <summary>
        /// Updates the ball, driving behaviour
        /// </summary>
        /// <param name="pGameTime"></param>
        public void Update(GameTime pGameTime)
        {
            // IF '_components' has been populated
            if (_components != null)
            {
                if (_components.Count > 0)
                {
                    // Serve the ball
                    Serve();

                    // Update ball velocity based on rotation
                    _components.OfType<Move>().First().Velocity = new Vector2((float)Math.Sin(_components.OfType<Move>().First().Rotation), (float)Math.Cos(_components.OfType<Move>().First().Rotation));

                    // Increment ball position by ball speed to simulate movement
                    _components.OfType<Position>().First().XPos += (_components.OfType<Move>().First().Speed.X * _facingDirectionX) * _components.OfType<Move>().First().Velocity.X;
                    _components.OfType<Position>().First().YPos += (_components.OfType<Move>().First().Speed.Y * _facingDirectionY) * _components.OfType<Move>().First().Velocity.Y;

                    // Flip _facingDirectionY if the ball hits the top or bottom of the screen
                    if (_components.OfType<Position>().First().YPos > 900 - 60)
                        _facingDirectionY *= -1;
                    if (_components.OfType<Position>().First().YPos < 0)
                        _facingDirectionY *= -1;

                    // IF the ball leaves the screen without hitting a paddle THEN serve the ball again
                    if (_components.OfType<Position>().First().XPos <= 0 || _components.OfType<Position>().First().XPos >= 1600)
                    {
                        // SET '_serveSwitch' to true
                        _serveSwitch = true;
                    }
                }
            }
        }      
    }
}