using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    /// <summary>
    /// Stores all position data for an entity
    /// </summary>
    public class Position : IComponent, IPosition
    {
        /// <summary>
        /// float named 'XPos' for defining entity X position
        /// </summary>
        public float XPos { get; set; }

        /// <summary>
        /// float named 'YPos' for defining entity Y position
        /// </summary>
        public float YPos { get; set; }
    }
}