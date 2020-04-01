using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    public interface IInputListener
    {
        bool KeyboardListener { get; set; }
        bool MouseListener { get; set; }
    }
}
