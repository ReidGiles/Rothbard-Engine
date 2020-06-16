using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    /// <summary>
    /// Stores all render data for an entity
    /// </summary>
    public class Render : IComponent, IRender
    {
        /// <summary>
        /// Texture2D named 'Texture' to define an entities texture
        /// </summary>
        public Texture2D Texture { get; set; }
    }
}