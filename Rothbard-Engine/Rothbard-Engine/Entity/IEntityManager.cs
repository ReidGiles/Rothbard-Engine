using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    interface IEntityManager
    {
        Guid Request();
        void Terminate(Guid pGuid);
    }
}
