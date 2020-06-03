using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Rothbard_Engine;

namespace Engine_Tests
{
    [TestClass]
    public class SystemTests
    {
        [TestMethod]
        public void CollisionSystemTest()
        {
            // Arrange
            ISystem collisionSystem = new CollisionSystem();

            // Act

            // Assert
        }

        [TestMethod]
        public void MoveSystemTest()
        {
            // Arrange
            ISystem moveSystem = new MoveSystem();

            // Act

            // Assert
        }

        [TestMethod]
        public void RenderSystemTest()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}