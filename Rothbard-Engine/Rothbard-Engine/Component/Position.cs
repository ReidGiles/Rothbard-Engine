using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    class Position : IComponent
    {
        // DECLARE an IDictionary of type Vector2, call it '_positions'
        private IDictionary<Guid, Vector2> _positions;

        /// <summary>
        /// Constructor for Position
        /// </summary>
        public Position()
        {
            // INSTANTIATE _positions
            _positions = new Dictionary<Guid, Vector2>();
        }

        public void Set(Guid pGuid, Vector2 pPosition)
        {
            _positions.Add(pGuid, pPosition);
        }

        public void Set(Guid pGuid, float pX, float pY)
        {
            Vector2 vector2 = new Vector2(pX, pY);
            _positions.Add(pGuid, vector2);
        }

        public Vector2 Get(Guid pGuid)
        {
            return _positions[pGuid];
        }

        public void Remove(Guid pGuid)
        {
            _positions.Remove(pGuid);
        }
    }
}