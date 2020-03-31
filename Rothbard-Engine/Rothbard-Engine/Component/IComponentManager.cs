using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    interface IComponentManager
    {
        IComponent Request<T>() where T : IComponent, new();
        void Assign(IComponent pComponent, Guid pEntity);
        void Terminate(Guid pEntity);
        IList<IComponent> Get(Type pcomponentType);
        IDictionary<Guid, IDictionary<Type, IComponent>> Get();
    }
}