using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    public interface ISystem
    {
        void Set(IDictionary<Guid, IDictionary<Type, IComponent>> pDictionary);
    }
}
