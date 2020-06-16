using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    /// <summary>
    /// Stores position data
    /// </summary>
    public interface IPosition
    {
        /// <summary>
        /// float named 'XPos' for defining entity X position
        /// </summary>
        float XPos { get; set; }

        /// <summary>
        /// float named 'YPos' for defining entity Y position
        /// </summary>
        float YPos { get; set; }
    }
}