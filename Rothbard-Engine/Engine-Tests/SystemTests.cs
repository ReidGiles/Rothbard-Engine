using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Rothbard_Engine;

namespace Engine_Tests
{
    /// <summary>
    /// System test class. Ensures that alll systems are capable of operation on the required data.
    /// </summary>
    [TestClass]
    public class SystemTests
    {
        /// <summary>
        /// Test a Collider system with expected data.
        /// </summary>
        [TestMethod]
        public void CollisionSystemTest()
        {
            // Arrange
            ISystem collisionSystem = new CollisionSystem();
            IDictionary<Guid, IDictionary<Type, IComponent>> entityComponentLink;
            entityComponentLink = new Dictionary<Guid, IDictionary<Type, IComponent>>();
            bool success;

            // Act
            try
            {
                collisionSystem.Set(entityComponentLink);
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }

            // Assert
            Assert.IsTrue(success);
        }

        /// <summary>
        /// Test a Render system with expected data.
        /// </summary>
        [TestMethod]
        public void RenderSystemTest()
        {
            // Arrange
            ISystem renderSystem = new RenderSystem();
            IDictionary<Guid, IDictionary<Type, IComponent>> entityComponentLink;
            entityComponentLink = new Dictionary<Guid, IDictionary<Type, IComponent>>();
            bool success;

            // Act
            try
            {
                renderSystem.Set(entityComponentLink);
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }

            // Assert
            Assert.IsTrue(success);
        }
    }
}