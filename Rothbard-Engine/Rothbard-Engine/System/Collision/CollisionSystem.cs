using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    class CollisionSystem : ISystem, ICollisionPublisher, IUpdatable
    {
        // DECLARE an IDictionary of type IDictionary, call it '_entityComponentLink'
        private IDictionary<Guid, IDictionary<Type, IComponent>> _entityComponentLink;

        private event EventHandler<ICollisionInput> NewCollisionHandler;

        /// <summary>
        /// Constructor for the Collision System
        /// </summary>
        public CollisionSystem()
        {
            // INSTANTIATE _entityComponentLink
            _entityComponentLink = new Dictionary<Guid, IDictionary<Type, IComponent>>();
        }

        /// <summary>
        /// Published method, contacts all listeners
        /// </summary>
        /// <param name="entityKeys"></param>
        /// <param name="entityTags"></param>
        private void OnNewCollision(Guid[] entityKeys, string[] entityTags, IDictionary<Guid, IDictionary<Type, IComponent>> entityComponents)
        {
            ICollisionInput args = new CollisionHandler(entityKeys, entityTags, entityComponents);
            if (NewCollisionHandler != null)
                NewCollisionHandler(this, args);
        }

        /// <summary>
        /// Subscription method, used to store reference to listeners
        /// </summary>
        /// <param name="handler"></param>
        public void AddListener(EventHandler<ICollisionInput> handler)
        {
            // Subscribe event handler
            NewCollisionHandler += handler;
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

                    string entity1Tag = ((ICollider)_entityComponentLink[entity1][typeof(Collider)]).Tag;
                    string entity2Tag = ((ICollider)_entityComponentLink[entity2][typeof(Collider)]).Tag;

                    Rectangle entity1Rectangle = ((ICollider)_entityComponentLink[entity1][typeof(Collider)]).Rectangle;
                    Rectangle entity2Rectangle = ((ICollider)_entityComponentLink[entity2][typeof(Collider)]).Rectangle;

                    if (entity1Rectangle.Intersects(entity2Rectangle))
                    {
                        IDictionary<Guid, IDictionary<Type, IComponent>> entityComponents;
                        entityComponents = new Dictionary<Guid, IDictionary<Type, IComponent>>();
                        entityComponents.Add(entity1, _entityComponentLink[entity1]);
                        entityComponents.Add(entity2, _entityComponentLink[entity2]);

                        OnNewCollision(new Guid[] { entity1, entity2 }, new string[] { entity1Tag, entity2Tag }, entityComponents);
                    }
                }
            }
        }
    }
}