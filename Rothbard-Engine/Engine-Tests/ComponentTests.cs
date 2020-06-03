using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
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
            Rectangle expectedRectangle = new Rectangle(20, 40, 5, 10);
            string expectedTag = "tagTest";

            // Act
            colliderComponent.Rectangle = new Rectangle(20, 40, 5, 10);
            colliderComponent.Tag = "tagTest";

            // Assert
            Assert.AreEqual(expectedRectangle, colliderComponent.Rectangle, "Collider component 'Rectangle' property initialised incorrectly");
            Assert.AreEqual(expectedTag, colliderComponent.Tag, "Collider component 'Tag' property initialised incorrectly");
        }

        [TestMethod]
        public void InputListenerComponentTest()
        {
            // Arrange
            IInputListener inputListenerComponent = new InputListener();
            bool expectedKeyboardListener = true;
            bool expectedMouseListener = false;

            // Act
            inputListenerComponent.KeyboardListener = true;
            inputListenerComponent.MouseListener = false;

            // Assert
            Assert.AreEqual(expectedKeyboardListener, inputListenerComponent.KeyboardListener, "InputListener component 'KeyboardListener' property initialised incorrectly");
            Assert.AreEqual(expectedMouseListener, inputListenerComponent.MouseListener, "InputListener component 'MouseListener' property initialised incorrectly");
        }

        [TestMethod]
        public void MoveComponentTest()
        {
            // Arrange
            IMove moveComponent = new Move();
            Vector2 expectedVelocity = new Vector2(5, 10);
            Vector2 expectedAcceleration = new Vector2(10, 20);
            Vector2 expectedDamping = new Vector2(20, 40);

            // Act
            moveComponent.Velocity = new Vector2(5, 10);
            moveComponent.Acceleration = new Vector2(10, 20);
            moveComponent.Damping = new Vector2(20, 40);

            // Assert
            Assert.AreEqual(expectedVelocity, moveComponent.Velocity, "Move component 'Velocity' property initialised incorrectly");
            Assert.AreEqual(expectedAcceleration, moveComponent.Acceleration, "Move component 'Acceleration' property initialised incorrectly");
            Assert.AreEqual(expectedDamping, moveComponent.Damping, "Move component 'Damping' property initialised incorrectly");
        }

        [TestMethod]
        public void PositionComponentTest()
        {
            // Arrange
            IPosition positionComponent = new Position();
            float expectedXPos = 18.8f;
            float expectedYPos = 9.4f;

            // Act
            positionComponent.XPos = 18.8f;
            positionComponent.YPos = 9.4f;

            // Assert
            Assert.AreEqual(expectedXPos, positionComponent.XPos, "Position component 'XPos' property initialised incorrectly");
            Assert.AreEqual(expectedYPos, positionComponent.YPos, "Position component 'YPos' property initialised incorrectly");
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
