using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    public interface ICollider
    {
        Rectangle Rectangle { get; set; }
        string Tag { get; set; }
    }
}