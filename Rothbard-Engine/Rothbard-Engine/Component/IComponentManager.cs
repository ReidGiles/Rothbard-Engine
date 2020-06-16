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
    interface IComponentManager
    {
        /// <summary>
        /// Factory method for creating components of type IComponent
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IComponent Request<T>() where T : IComponent, new();

        /// <summary>
        /// Assigns a component to a specified entity
        /// </summary>
        /// <param name="pComponent"></param>
        /// <param name="pEntity"></param>
        void Assign(IComponent pComponent, Guid pEntity);

        /// <summary>
        /// Terminates all components associated with the requested entity
        /// </summary>
        /// <param name="pEntity"></param>
        void Terminate(Guid pEntity);

        /// <summary>
        /// Returns an IList of all components with the requested name
        /// </summary>
        /// <param name="pcomponentType"></param>
        IList<IComponent> Get(Type pcomponentType);

        /// <summary>
        /// Returns an IList of all components associated with the requested entity
        /// </summary>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        IList<IComponent> Get(Guid pGuid);

        /// <summary>
        /// Return the entity component link dictionary
        /// </summary>
        /// <returns></returns>
        IDictionary<Guid, IDictionary<Type, IComponent>> Get();
    }
}