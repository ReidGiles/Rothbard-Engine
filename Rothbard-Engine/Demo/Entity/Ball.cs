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

        private int _facingDirectionX;
        private int _facingDirectionY;

        public Ball(Guid pGuid)
        {
            _guid = pGuid;

            _components = new List<IComponent>();

            _facingDirectionX = 1;
            _facingDirectionY = 1;

        }

        public void OnNewCollision(object sender, ICollisionInput args)
        {
            Guid entity1 = args.GetEntityKeys()[0];
            Guid entity2 = args.GetEntityKeys()[1];
            IDictionary<Guid, IDictionary<Type, IComponent>> entityComponents = new Dictionary<Guid, IDictionary<Type, IComponent>>();

            if (entity1 == _guid || entity2 == _guid)
            {
                _facingDirectionX *= -1;

                //_components.OfType<Move>().First().Velocity = new Vector2(_components.OfType<Move>().First().Velocity.X + 2, _components.OfType<Move>().First().Velocity.Y);
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

        public void Update(GameTime pGameTime)
        {
            if (_components.Count > 0)
            {

                _components.OfType<Position>().First().XPos += (_components.OfType<Move>().First().Velocity.X * _facingDirectionX);
                _components.OfType<Position>().First().YPos += (_components.OfType<Move>().First().Velocity.Y * _facingDirectionY);

                if (_components.OfType<Position>().First().YPos > 900 - 60)
                    _facingDirectionY *= -1;
                if (_components.OfType<Position>().First().YPos < 0)
                    _facingDirectionY *= -1;
            }
        }      
    }
}