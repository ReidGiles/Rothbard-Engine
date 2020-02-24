using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    interface IComponentManager
    {
        void Request(IComponent pComponent, Guid pEntity);
        void Terminate(Guid pEntity);
        IList<IComponent> Get(Type pcomponentType);
    }
}