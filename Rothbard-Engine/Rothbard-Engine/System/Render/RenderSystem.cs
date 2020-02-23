using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    /// <summary>
    /// Acts upon position and render components to render relevant entities in the world
    /// </summary>
    class RenderSystem : ISystem, IUpdatable
    {
        // DECLARE an IDictionary of type Texture2D, call it '_textures'
        private IDictionary<Guid, Texture2D> _textures;

        // DECLARE an IDictionary of type Vector2, call it '_positions'
        private IDictionary<Guid, Vector2> _positions;

        /// <summary>
        /// Constructorr for render system
        /// </summary>
        public RenderSystem()
        {
            // INSTANTIATE _textures
            _textures = new Dictionary<Guid, Texture2D>();

            // INSTANTIATE _positions
            _positions = new Dictionary<Guid, Vector2>();

            Console.WriteLine("RS: Instantiated");
        }

        public void Update(GameTime pGameTime)
        {
        }
    }
}