using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rothbard_Engine;

namespace Engine_Tests
{
    [TestClass]
    public class ComponentTests
    {
        [TestMethod]
        public void ColliderComponentTest()
        {
            // Arrange
            ICollider colliderComponent = new Collider();

            // Act

            // Assert
        }

        [TestMethod]
        public void InputListenerComponentTest()
        {
            // Arrange
            IInputListener inputListenerComponent = new InputListener();

            // Act

            // Assert
        }

        [TestMethod]
        public void MoveComponentTest()
        {
            // Arrange
            IMove moveComponent = new Move();

            // Act

            // Assert
        }

        [TestMethod]
        public void PositionComponentTest()
        {
            // Arrange
            IPosition positionComponent = new Position();

            // Act

            // Assert
        }

        [TestMethod]
        public void RenderComponentTest()
        {
            // Arrange
            IRender renderComponent = new Render();

            // Act

            // Assert
        }

    }
}