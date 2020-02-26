using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    class InputListener : IComponent
    {
        public bool KeyboardListener { get; set; }
        public bool MouseListener { get; set; }
    }
}