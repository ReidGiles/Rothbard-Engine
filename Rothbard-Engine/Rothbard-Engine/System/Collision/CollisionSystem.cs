using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    class CollisionSystem : ISystem, IUpdatable
    {
        // DECLARE an IDictionary of type IDictionary, call it '_entityComponentLink'
        private IDictionary<Guid, IDictionary<Type, IComponent>> _entityComponentLink;
        public CollisionSystem()
        {
            // INSTANTIATE _entityComponentLink
            _entityComponentLink = new Dictionary<Guid, IDictionary<Type, IComponent>>();
        }

        public void Set(IDictionary<Guid, IDictionary<Type, IComponent>> pDictionary)
        {
            _entityComponentLink = pDictionary;
        }

        public void Update(GameTime pGameTime)
        {
            foreach (Guid entity in _entityComponentLink.Keys)
            {
                ICollider collider = ((ICollider)_entityComponentLink[entity][typeof(Collider)]);
                IPosition position = ((IPosition)_entityComponentLink[entity][typeof(Position)]);
                ((ICollider)_entityComponentLink[entity][typeof(Collider)]).Rectangle = new Rectangle(Convert.ToInt32(position.XPos), Convert.ToInt32(position.YPos), collider.Rectangle.Width, collider.Rectangle.Height);
            }

                for (int i = 0; i < _entityComponentLink.Count; i++)
            {
                Guid entity1 = _entityComponentLink.Keys.ElementAt(i);
                for (int j = i + 1; j < _entityComponentLink.Count; j++)
                {
                    Guid entity2 = _entityComponentLink.Keys.ElementAt(j);

                    if (((ICollider)_entityComponentLink[entity1][typeof(Collider)]).Rectangle.Intersects(((ICollider)_entityComponentLink[entity2][typeof(Collider)]).Rectangle))
                    {
                        Console.WriteLine("Collision");
                    }
                }
            }
        }
    }
}