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
    /// <summary>
    /// Stores individual entity behaviour logic
    /// </summary>
    class Hostile : ICollisionListener, IUpdatable
    {
        private Guid _guid;

        private IList<IComponent> _components;

        public Hostile(Guid pGuid)
        {
            _guid = pGuid;

            _components = new List<IComponent>();
    }

        public void OnNewCollision(object sender, ICollisionInput args)
        {
            Guid entity1 = args.GetEntityKeys()[0];
            Guid entity2 = args.GetEntityKeys()[1];

            if (entity1 == _guid || entity2 == _guid)
            {
                _components.OfType<Move>().First().Velocity *= -1;
            }
        }

        public void SetComponents(IList<IComponent> pComponents)
        {
            _components = pComponents;
        }

        public Guid GetGuid()
        {
            return _guid;
        }

        public void Update(GameTime gameTime)
        {
            //((IPosition)args.GetEntityComponents()[_guid][typeof(Position)]).XPos += ((IMove)args.GetEntityComponents()[_guid][typeof(Move)]).Velocity.X;
            //((IPosition)args.GetEntityComponents()[_guid][typeof(Position)]).YPos += ((IMove)args.GetEntityComponents()[_guid][typeof(Move)]).Velocity.Y;

            if (_components.Count > 0)
                _components.OfType<Position>().First().XPos += _components.OfType<Move>().First().Velocity.X;
        }
    }
}