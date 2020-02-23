using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    class Render : IComponent
    {
        // DECLARE an IDictionary of type Texture2D, call it '_textures'
        private IDictionary<Guid, Texture2D> _textures;

        /// <summary>
        /// Constructor for Render
        /// </summary>
        public Render()
        {
            // INSTANTIATE _textures
            _textures = new Dictionary<Guid, Texture2D>();
        }

        public void Set(Guid pGuid, Texture2D pTexture2D)
        {
            _textures.Add(pGuid, pTexture2D);
        }

        public Texture2D Get(Guid pGuid)
        {
            return _textures[pGuid];
        }

        public void Remove(Guid pGuid)
        {
            _textures.Remove(pGuid);
        }
    }
}