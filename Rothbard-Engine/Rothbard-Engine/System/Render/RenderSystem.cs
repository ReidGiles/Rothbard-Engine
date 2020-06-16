using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
    public class RenderSystem : ISystem, IUpdatable
    {
        // DECLARE an IDictionary of type IDictionary, call it '_entityComponentLink'
        private IDictionary<Guid, IDictionary<Type, IComponent>> _entityComponentLink;

        // DECLARE a SpriteBatch, call it '_spriteBatch'
        private SpriteBatch _spriteBatch;

        // DECLARE a GraphicsDeviceManager, call it '_graphicsDeviceManager'
        private GraphicsDeviceManager _graphicsDeviceManager;

        // DECLARE a ContentManager, call it '_contentManager'
        private ContentManager _contentManager;

        /// <summary>
        /// Constructorr for render system
        /// </summary>
        public RenderSystem(SpriteBatch pSpriteBatch, GraphicsDeviceManager pGraphicsDeviceManager, ContentManager pContentManager)
        {
            // INSTANTIATE _entityComponentLink
            _entityComponentLink = new Dictionary<Guid, IDictionary<Type, IComponent>>();

            // SET '_spriteBatch' to 'pSpriteBatch'
            _spriteBatch = pSpriteBatch;

            // SET '_graphicsDeviceManager' to 'pGraphicsDeviceManager'
            _graphicsDeviceManager = pGraphicsDeviceManager;

            // SET '_contentManager' to 'pContentManager'
            _contentManager = pContentManager;

            Console.WriteLine("RS: Instantiated");
        }

        /// <summary>
        /// Updates the _entityComponentLink dictionary
        /// </summary>
        /// <param name="pDictionary"></param>
        public void Set(IDictionary<Guid, IDictionary<Type, IComponent>> pDictionary)
        {
            // SET '_entityComponentLink' to 'pDictionary'
            _entityComponentLink = pDictionary;
        }

        /// <summary>
        /// Updates the Render System
        /// </summary>
        /// <param name="pGameTime"></param>
        public void Update(GameTime pGameTime)
        {
            _spriteBatch.Begin();

            // FOREACH entity in the entity component link dictionary -> render the entity onto the scene
            foreach (Guid entity in _entityComponentLink.Keys)
            {
                float x = ((IPosition)_entityComponentLink[entity][typeof(Position)]).XPos;
                float y = ((IPosition)_entityComponentLink[entity][typeof(Position)]).YPos;
                Texture2D texture = ((IRender)_entityComponentLink[entity][typeof(Render)]).Texture;
                _spriteBatch.Draw(texture, new Vector2(x, y), Color.White);
            }

            _spriteBatch.End();
            
        }
    }
}