using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    /// <summary>
    /// Stores render data
    /// </summary>
    public interface IRender
    {
        /// <summary>
        /// Texture2D named 'Texture' to define an entities texture
        /// </summary>
        Texture2D Texture { get; set; }
    }
}