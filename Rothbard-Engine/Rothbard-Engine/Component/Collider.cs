using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    /// <summary>
    /// Stores all collider data for en entity
    /// </summary>
    public class Collider : IComponent, ICollider
    {
        /// <summary>
        /// Rectange named 'Rectange' for defining entity collision rectange
        /// </summary>
        public Rectangle Rectangle { get; set; }

        /// <summary>
        /// string named 'Tag' for defining entity collision identifier
        /// </summary>
        public string Tag { get; set; }
    }
}