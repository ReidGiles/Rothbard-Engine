using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    public interface ICollisionListener
    {
        void OnNewCollision(object sender, ICollisionInput args);
    }
}