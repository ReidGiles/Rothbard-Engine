using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    public class Collider : IComponent, ICollider
    {
        public Rectangle Rectangle { get; set; }
        public string Tag { get; set; }
    }
}