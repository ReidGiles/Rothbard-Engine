using Microsoft.Xna.Framework;

namespace Rothbard_Engine
{
    /// <summary>
    /// Interface for classes that require update loop functionality
    /// </summary>
    public interface IUpdatable
    {
        /// <summary>
        /// Update loop, receives GameTime
        /// </summary>
        /// <param name="pGameTime"></param>
        void Update(GameTime pGameTime);
    }
}