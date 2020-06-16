using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    /// <summary>
    /// Manages collision components, collision event subscription and collision event publishing
    /// </summary>
    public class CollisionSystem : ISystem, ICollisionPublisher, IUpdatable
    {
        // DECLARE an IDictionary of type IDictionary, call it '_entityComponentLink'
        private IDictionary<Guid, IDictionary<Type, IComponent>> _entityComponentLink;

        // DECLARE an EventHandler of type ICollisionInput, call it 'NewCollisionHandler'
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
            // DECLARE and INSTANTIATE a new CollisionHandler, pass it 'entityKeys', 'entityTags' and 'entityComponents' and call it 'args'
            ICollisionInput args = new CollisionHandler(entityKeys, entityTags, entityComponents);

            // IF at least one collision listener is subscribed, publish collision event
            NewCollisionHandler?.Invoke(this, args);
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
            // SET '_entityComponentLink' to 'pDictionary'
            _entityComponentLink = pDictionary;
        }

        /// <summary>
        /// Update the collision system, checking for new collisions and publishing collisions as they occur
        /// </summary>
        /// <param name="pGameTime"></param>
        public void Update(GameTime pGameTime)
        {
            // FOR each key of type Guid in 'entityComponentLink'
            foreach (Guid entity in _entityComponentLink.Keys)
            {
                // DECLARE an ICollider, call it 'collider' and SET it to the collider component associated with the entity
                ICollider collider = ((ICollider)_entityComponentLink[entity][typeof(Collider)]);
                // DECLARE an IPosition, call it 'position' and SET it to the position component associated with the entity
                IPosition position = ((IPosition)_entityComponentLink[entity][typeof(Position)]);

                // SET the collision rectangle for the entity
                ((ICollider)_entityComponentLink[entity][typeof(Collider)]).Rectangle = new Rectangle(Convert.ToInt32(position.XPos), Convert.ToInt32(position.YPos), collider.Rectangle.Width, collider.Rectangle.Height);
            }

            for (int i = 0; i < _entityComponentLink.Count; i++)
            {
                // DECLARE a Guid, call it 'entity1' and SET it to the corrosponding dictionary key
                Guid entity1 = _entityComponentLink.Keys.ElementAt(i);
                for (int j = i + 1; j < _entityComponentLink.Count; j++)
                {
                    // DECLARE a Guid, call it 'entity2' and SET it to the corrosponding dictionary key
                    Guid entity2 = _entityComponentLink.Keys.ElementAt(j);

                    // DECLARE a string, call it 'entity1Tag' and SET it to the 'Tag' property of the Collider component associated with 'entity1'
                    string entity1Tag = ((ICollider)_entityComponentLink[entity1][typeof(Collider)]).Tag;
                    // DECLARE a string, call it 'entity2Tag' and SET it to the 'Tag' property of the Collider component associated with 'entity2'
                    string entity2Tag = ((ICollider)_entityComponentLink[entity2][typeof(Collider)]).Tag;

                    // DECLARE a Rectange, call it 'entity1Rectangle' and SET it to the 'Rectangle' property of the Collider component associated with 'entity1'
                    Rectangle entity1Rectangle = ((ICollider)_entityComponentLink[entity1][typeof(Collider)]).Rectangle;
                    // DECLARE a Rectange, call it 'entity2Rectangle' and SET it to the 'Rectangle' property of the Collider component associated with 'entity2'
                    Rectangle entity2Rectangle = ((ICollider)_entityComponentLink[entity2][typeof(Collider)]).Rectangle;

                    // IF 'entity1' has collided with 'entity2'
                    if (entity1Rectangle.Intersects(entity2Rectangle))
                    {
                        // DECLARE an IDictionary of type <Guid, IDictionary<Type, IComponent>>, call it 'entityComponents'
                        IDictionary<Guid, IDictionary<Type, IComponent>> entityComponents;
                        // INSTANTIATE 'entityComponents'
                        entityComponents = new Dictionary<Guid, IDictionary<Type, IComponent>>();

                        // Add 'entity1' along with it's components to 'entityComponents'
                        entityComponents.Add(entity1, _entityComponentLink[entity1]);
                        // Add 'entity2' along with it's components to 'entityComponents'
                        entityComponents.Add(entity2, _entityComponentLink[entity2]);

                        // Trigger a collision event, passing the collided entities and their components as arguments
                        OnNewCollision(new Guid[] { entity1, entity2 }, new string[] { entity1Tag, entity2Tag }, entityComponents);
                    }
                }
            }
        }
    }
}