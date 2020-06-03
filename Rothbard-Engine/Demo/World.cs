using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Rothbard_Engine;

namespace Demo
{
    class World : ICollisionListener
    {
        private Demo _demo;

        /// <summary>
        /// Constructor for World
        /// </summary>
        /// <param name="demo"></param>
        public World(Demo demo)
        {
            _demo = demo;
        }

        public void Load()
        {
            _demo.Spawn(700, 100, _demo.LoadTexture("Hostile"), new Vector2(10, 10), true, false);
            _demo.Spawn(5, 50, _demo.LoadTexture("Hostile"), new Vector2(2, 0), false, false);
            _demo.Spawn(5, 250, _demo.LoadTexture("Hostile"), new Vector2(2, 0), false, false);
            _demo.Spawn(5, 450, _demo.LoadTexture("Hostile"), new Vector2(2, 0), false, false);
            _demo.Spawn(5, 650, _demo.LoadTexture("Hostile"), new Vector2(2, 0), false, false);
        }

        /// <summary>
        /// Receives collision data from the collision system
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnNewCollision(object sender, ICollisionInput args)
        {
            Guid entity1 = args.GetEntityKeys()[0];
            Guid entity2 = args.GetEntityKeys()[1];
            ((IMove)args.GetEntityComponents()[entity2][typeof(Move)]).Velocity = ((IMove)args.GetEntityComponents()[entity1][typeof(Move)]).Velocity;
            ((IInputListener)args.GetEntityComponents()[entity2][typeof(InputListener)]).KeyboardListener = true;
            //((IPosition)args.GetEntityComponents()[entity1][typeof(Position)]).XPos += ((IMove)args.GetEntityComponents()[entity2][typeof(Move)]).Velocity.X;
        }
    }
}