using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    interface IKeyboardListener
    {
        void OnNewKeyboardInput(object sender, IKeyboardInput args);
    }
}
