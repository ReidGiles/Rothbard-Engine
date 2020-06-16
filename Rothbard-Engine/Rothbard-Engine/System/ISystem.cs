using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    public interface ISystem
    {
        /// <summary>
        /// Keeps 'entityComponentLink' updated
        /// </summary>
        /// <param name="pDictionary"></param>
        void Set(IDictionary<Guid, IDictionary<Type, IComponent>> pDictionary);
    }
}