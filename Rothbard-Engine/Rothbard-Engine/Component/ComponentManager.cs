using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    /// <summary>
    /// Manages all components
    /// </summary>
    class ComponentManager : IComponentManager
    {
        // DECLARE an IDictionary of type IList, call it '_components'
        private IDictionary<Type, IList<IComponent>> _components;

        // DECLARE an IDictionary of type IDictionary, call it '_entityComponentLink'
        private IDictionary<Guid, IDictionary<Type, IComponent>> _entityComponentLink;

        /// <summary>
        /// Constructor for the ComponentManager
        /// </summary>
        public ComponentManager()
        {
            // INSTANTIATE _components
            _components = new Dictionary<Type, IList<IComponent>>();

            // INSTANTIATE _entityComponentLink
            _entityComponentLink = new Dictionary<Guid, IDictionary<Type, IComponent>>();
        }

        /// <summary>
        /// Factory method for creating components of type IComponent
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IComponent Request<T>() where T : IComponent, new()
        {
            return new T();
        }

        /// <summary>
        /// Returns an IList of all components with the requested name
        /// </summary>
        /// <param name="pcomponentType"></param>
        public IList<IComponent> Get(Type pcomponentType)
        {
            // DECLARE an IList, call it 'components'
            IList<IComponent> components;

            // INSTANTIATE components
            components = new List<IComponent>();

            // IF _components contains at least one key
            if (_components.Keys != null)
            {
                // For every type in _components keys
                foreach (Type componentType in _components.Keys)
                {
                    // IF the key is equal to the passed type
                    if (componentType == pcomponentType)
                    {
                        // For every component of specified type in _components
                        foreach (IComponent component in _components[componentType])
                        {
                            // Add component to 'components'
                            components.Add(component);
                        }
                        return components;
                    }
                }
            }            
            return null;
        }

        /// <summary>
        /// Returns an IList of all components associated with the requested entity
        /// </summary>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        public IList<IComponent> Get(Guid pEntity)
        {
            // DECLARE an IList, call it 'components'
            IList<IComponent> components;

            // INSTANTIATE components
            components = new List<IComponent>();

            // IF _entityComponentLink contains at least one key
            if (_entityComponentLink.Keys != null)
            {
                // For every entity in _entityComponentLink keys
                foreach (Guid entity in _entityComponentLink.Keys)
                {
                    // If the key is equal to the passed entity Guid
                    if (entity == pEntity)
                    {
                        // For every component associated with the passed entity
                        foreach (IComponent component in _entityComponentLink[entity].Values)
                        {
                            // Add component to 'components'
                            components.Add(component);
                        }
                        return components;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Return the entity component link dictionary
        /// </summary>
        /// <returns></returns>
        public IDictionary<Guid, IDictionary<Type, IComponent>> Get()
        {
            return _entityComponentLink;
        }

        /// <summary>
        /// Terminates all components associated with the requested entity
        /// </summary>
        /// <param name="pEntity"></param>
        public void Terminate(Guid pEntity)
        {
            // Remove passed entity from the dictionary
            _entityComponentLink.Remove(pEntity);
        }

        /// <summary>
        /// Terminates a single component with the requested name and associated with the requested entity
        /// </summary>
        /// <param name="pEntity"></param>
        /// <param name="pcomponentType"></param>
        public void Terminate(Guid pEntity, Type pcomponentType)
        {

        }

        /// <summary>
        /// Terminates all components associated with the requested name
        /// </summary>
        /// <param name="pcomponentType"></param>
        public void Terminate(Type pcomponentType)
        {
        }

        /// <summary>
        /// Assigns a component to a specified entity
        /// </summary>
        /// <param name="pComponent"></param>
        /// <param name="pEntity"></param>
        public void Assign(IComponent pComponent, Guid pEntity)
        {
            // IF _entityComponentLink contains at least one key
            if (_entityComponentLink.Keys != null)
            {
                // Declare a bool and set it false to track if requested entity exists
                bool entityFound = false;

                // For every Guid in _entityComponentLink keys
                foreach (Guid entity in _entityComponentLink.Keys)
                {
                    // If the entity is equal to the passed entity
                    if (entity == pEntity)
                    {
                        // Assign the passed component to the requested entity in _entityComponentLink
                        _entityComponentLink[entity].Add(pComponent.GetType(), pComponent);

                        // Flag component found
                        entityFound = true;

                        Console.WriteLine("CM: Component added to existing dictionary");

                        break;
                    }
                }

                // If requested entity was not found as an existing key in _entityComponentLink, create a new entry
                if (!entityFound)
                {
                    // Create a new dictionary to store the new entities components
                    IDictionary<Type, IComponent> newComponentDictionary = new Dictionary<Type, IComponent>();

                    // Add starting component to newComponentDictionary
                    newComponentDictionary.Add(pComponent.GetType(), pComponent);

                    // Link the new entity and its component dictionary as an entry in _entityComponentLink
                    _entityComponentLink.Add(pEntity, newComponentDictionary);

                    Console.WriteLine("CM: Component addeded to new dictionary");
                }
            }
            
        }
    }
}