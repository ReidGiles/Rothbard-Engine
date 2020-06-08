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
    class Ball: ICollisionListener, IKeyboardListener, IUpdatable
    {
        private Guid _guid;

        private IList<IComponent> _components;

        private Random _random;

        private int _facingDirectionX;
        private int _facingDirectionY;

        private bool _serveSwitch;

        public Ball(Guid pGuid)
        {
            _guid = pGuid;

            _components = new List<IComponent>();

            _random = new Random();

            _facingDirectionX = 1;
            _facingDirectionY = 1;

            _serveSwitch = true;

        }

        public void OnNewCollision(object sender, ICollisionInput args)
        {
            Guid entity1 = args.GetEntityKeys()[0];
            Guid entity2 = args.GetEntityKeys()[1];
            IDictionary<Guid, IDictionary<Type, IComponent>> entityComponents = new Dictionary<Guid, IDictionary<Type, IComponent>>();
            entityComponents.Remove(_guid);

            if (entity1 == _guid || entity2 == _guid)
            {
                _facingDirectionX *= -1;

                //if (((IMove)entityComponents[entityComponents.First().Key][typeof(Move)] ).Velocity.Y > 0 )

                _components.OfType<Move>().First().Speed = new Vector2(_components.OfType<Move>().First().Speed.X + 2, _components.OfType<Move>().First().Speed.Y);
            }
        }

        public void OnNewKeyboardInput(object sender, IKeyboardInput args)
        {
        }

        public void SetComponents(IList<IComponent> pComponents)
        {
            _components = pComponents;
        }

        public Guid GetGuid()
        {
            return _guid;
        }

        public void Serve()
        {
            if (_serveSwitch)
            {
                _components.OfType<Move>().First().Speed = new Vector2(5, 5);

                _components.OfType<Position>().First().XPos = 1600 / 2;
                _components.OfType<Position>().First().YPos = 900 / 2;

                _components.OfType<Move>().First().Rotation = (float)(Math.PI / 2 + (_random.NextDouble() * (Math.PI / 1.5F) - Math.PI / 3));

                if (_random.Next(0, 2) == 1)
                {
                    _facingDirectionX *= -1;
                }

                _serveSwitch = false;
            }
        }

        public void Update(GameTime pGameTime)
        {
            if (_components.Count > 0)
            {
                Serve();
                
                _components.OfType<Move>().First().Velocity = new Vector2((float)Math.Sin(_components.OfType<Move>().First().Rotation), (float)Math.Sin(_components.OfType<Move>().First().Rotation));

                _components.OfType<Position>().First().XPos += (_components.OfType<Move>().First().Speed.X * _facingDirectionX) * _components.OfType<Move>().First().Velocity.X;
                _components.OfType<Position>().First().YPos += (_components.OfType<Move>().First().Speed.Y * _facingDirectionY) * _components.OfType<Move>().First().Velocity.Y;

                if (_components.OfType<Position>().First().YPos > 900 - 60)
                    _facingDirectionY *= -1;
                if (_components.OfType<Position>().First().YPos < 0)
                    _facingDirectionY *= -1;

                if (_components.OfType<Position>().First().XPos <= 0 || _components.OfType<Position>().First().XPos >= 1600)
                {
                    _serveSwitch = true;
                }
            }
        }      
    }
}