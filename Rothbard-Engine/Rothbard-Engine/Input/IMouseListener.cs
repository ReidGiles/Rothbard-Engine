using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine.Input
{
    interface IMouseListener
    {
        void OnNewMouseInput(object sender, IMouseInput args);
    }
}
