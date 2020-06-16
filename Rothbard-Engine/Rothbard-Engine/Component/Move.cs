using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    /// <summary>
    ///  Stores all move data for an entity
    /// </summary>
    public class Move : IComponent, IMove
    {
        /// <summary>
        /// Vector2 named 'Velocity' for defining entity velocity
        /// </summary>
        public Vector2 Velocity { get; set; }

        /// <summary>
        /// Vector2 named 'Acceleration' for defining entity acceleration
        /// </summary>
        public Vector2 Acceleration { get; set; }

        /// <summary>
        /// Vector2 named 'Damping' for defining entity damping
        /// </summary>
        public Vector2 Damping { get; set; }

        /// <summary>
        /// Vector2 named 'Speed' for defining entity speed
        /// </summary>
        public Vector2 Speed { get; set; }

        /// <summary>
        /// Float named 'Rotation' for defining entity rotation
        /// </summary>
        public float Rotation { get; set; }
    }
}