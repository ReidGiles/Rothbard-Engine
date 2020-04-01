using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    public interface IMove
    {
        Vector2 Velocity { get; set; }
        Vector2 Acceleration { get; set; }
        Vector2 Damping { get; set; }
    }
}
