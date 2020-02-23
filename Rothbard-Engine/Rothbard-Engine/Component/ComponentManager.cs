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
        private IDictionary<string, IList<IComponent>> _components;

        // DECLARE an IDictionary of type IDictionary, call it '_entityComponentLink'
        private IDictionary<Guid, IDictionary<string, IComponent>> _entityComponentLink;

        /// <summary>
        /// Constructor for the ComponentManager
        /// </summary>
        public ComponentManager()
        {
            _components = new Dictionary<string, IList<IComponent>>();

            _entityComponentLink = new Dictionary<Guid, IDictionary<string, IComponent>>();
        }

        /// <summary>
        /// Returns an IList of all components with the requested name
        /// </summary>
        /// <param name="pComponentName"></param>
        public IList<IComponent> Get(string pComponentName)
        {
            IList<IComponent> components = new List<IComponent>();
            if (_components.Keys != null)
            {
                foreach (string componentName in _components.Keys)
                {
                    if (componentName == pComponentName)
                    {
                        foreach (IComponent component in _components[componentName])
                        {
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
            IList<IComponent> components = new List<IComponent>();
            if (_entityComponentLink.Keys != null)
            {
                foreach (Guid entity in _entityComponentLink.Keys)
                {
                    if (entity == pEntity)
                    {
                        foreach (IComponent component in _entityComponentLink[entity].Values)
                        {
                            components.Add(component);
                        }
                        Console.WriteLine("CM: Component retrieved");
                        return components;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Terminates all components associated with the requested entity
        /// </summary>
        /// <param name="pEntity"></param>
        public void Terminate(Guid pEntity)
        {
            IList<IComponent> _toBeTerminated = Get(pEntity);
        }

        /// <summary>
        /// Terminates a single component with the requested name and associated with the requested entity
        /// </summary>
        /// <param name="pEntity"></param>
        /// <param name="pComponentName"></param>
        public void Terminate(Guid pEntity, string pComponentName)
        {

        }

        /// <summary>
        /// Terminates all components associated with the requested name
        /// </summary>
        /// <param name="pComponentName"></param>
        public void Terminate(string pComponentName)
        {

        }

        public void Request(IComponent pComponent, string pComponentName, Guid pEntity)
        {        
            if (_components.Keys != null)
            {
                bool componentFound = false;
                foreach (string componentName in _components.Keys)
                {
                    if (componentName == pComponentName)
                    {
                        _components[componentName].Add(pComponent);
                        componentFound = true;
                        Console.WriteLine("CM: Component addeded to existing list");
                        break;
                    }
                }
                if (!componentFound)
                {
                    IList<IComponent> newComponentList = new List<IComponent>();
                    _components.Add(pComponentName, newComponentList);
                    Console.WriteLine("CM: Component addeded to new list");
                }
            }

            if (_entityComponentLink.Keys != null)
            {
                bool componentFound = false;
                foreach (Guid entity in _entityComponentLink.Keys)
                {
                    if (entity == pEntity)
                    {
                        _entityComponentLink[entity].Add(pComponentName, pComponent);
                        componentFound = true;
                        Console.WriteLine("CM: Component added to existing dictionary");
                        break;
                    }
                }
                if (!componentFound)
                {
                    IDictionary<string, IComponent> _newComponentDictionary = new Dictionary<string, IComponent>();
                    _entityComponentLink.Add(pEntity, _newComponentDictionary);
                    Console.WriteLine("CM: Component addeded to new dictionary");
                }
            }            
        }
    }
}