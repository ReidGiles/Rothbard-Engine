using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    /// <summary>
    /// Stores collider data
    /// </summary>
    public interface ICollider
    {
        /// <summary>
        /// Rectange named 'Rectange' for defining entity collision rectange
        /// </summary>
        Rectangle Rectangle { get; set; }

        /// <summary>
        /// string named 'Tag' for defining entity collision identifier
        /// </summary>
        string Tag { get; set; }
    }
}