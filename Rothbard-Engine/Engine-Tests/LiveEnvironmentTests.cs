using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Rothbard_Engine;
using Demo;

namespace Engine_Tests
{
    /// <summary>
    /// Live environment test class. Ensures that public facing engine methods repsond appropriately to expected and unexpected data.
    /// </summary>
    [TestClass]
    public class LiveEnvironmentTests : RothbardEngine
    {
        /// <summary>
        /// Test the LoadTexture engine method for expected results
        /// </summary>
        [TestMethod]
        public void LoadTextureTest()
        {
            if (_ready)
            {
                // Arrange
                Texture2D expectedTexture;
                Texture2D actualTexture;
                expectedTexture = Content.Load<Texture2D>("paddle");

                // Act
                actualTexture = LoadTexture("paddle");

                // Assert
                Assert.AreEqual(expectedTexture, actualTexture, "LoadTexture method did not load the expected texture");
            }
        }

        /// <summary>
        /// Test the SubscribeListener engine method for expected results
        /// </summary>
        [TestMethod]
        public void CollisionSubscriptionTest()
        {
            if (_ready)
            {
                // Arrange
                ICollisionListener listener;
                listener = new Ball(new Guid());
                bool success;

                // Act
                try
                {
                    SubscribeListener(listener);
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

        /// <summary>
        /// Test the SubscribeKeyboardListener engine method for expected results
        /// </summary>
        [TestMethod]
        public void KeyboardSubscriptionTest()
        {
            if (_ready)
            {
                // Arrange
                IKeyboardListener listener;
                listener = new Player1(new Guid());
                bool success;

                // Act
                try
                {
                    SubscribeKeyboardListener(listener);
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

        /// <summary>
        /// Test the GetComponents engine method for expected results
        /// </summary>
        [TestMethod]
        public void ComponentRetrievalTest()
        {
            if (_ready)
            {
                // Arrange
                IList<IComponent> components;
                Guid player;
                int componentsFound = 0;
                bool success = false;

                // Act
                try
                {
                    player = Spawn("player", 25, 900 / 2, LoadTexture("Paddle"), new Vector2(5, 5), true, false);
                    components = GetComponents(player);

                    foreach (IComponent component in components)
                    {
                        if (component.GetType() == typeof(Move))
                        {
                            componentsFound += 1;
                        }
                        if (component.GetType() == typeof(Render))
                        {
                            componentsFound += 1;
                        }
                        if (component.GetType() == typeof(Position))
                        {
                            componentsFound += 1;
                        }
                        if (component.GetType() == typeof(InputListener))
                        {
                            componentsFound += 1;
                        }
                        if (component.GetType() == typeof(Collider))
                        {
                            componentsFound += 1;
                        }
                    }

                    if (componentsFound == 5)
                    {
                        success = true;
                    }
                    else success = false;
                }
                catch (Exception)
                {
                    success = false;
                }

                // Assert
                Assert.IsTrue(success);
            }
        }

        /// <summary>
        /// Test the Spawn engine method for expected results
        /// </summary>
        [TestMethod]
        public void EntitySpawnTest()
        {
            if (_ready)
            {
                // Arrange
                Guid player;
                bool success;

                // Act
                try
                {
                    player = Spawn("player", 25, 900 / 2, LoadTexture("Paddle"), new Vector2(5, 5), true, false);
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

        /// <summary>
        /// Test the TerminateEntity engine method for expected results
        /// </summary>
        [TestMethod]
        public void EntityTerminationTest()
        {
            if (_ready)
            {
                // Arrange
                Guid player;
                bool success;

                // Act
                try
                {
                    player = Spawn("player", 25, 900 / 2, LoadTexture("Paddle"), new Vector2(5, 5), true, false);
                    TerminateEntity(player);
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
}