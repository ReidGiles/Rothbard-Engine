using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    class Position : IComponent, IPosition
    {
        public float XPos { get; set; }
        public float YPos { get; set; }
    }
}