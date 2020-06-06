using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Rothbard_Engine;

namespace Demo
{
    /// <summary>
    /// Stores individual entity behaviour logic
    /// </summary>
    class Hostile : ICollisionListener
    {
        private Guid _guid;

        public Hostile(Guid pGuid)
        {
            _guid = pGuid;
        }

        public void OnNewCollision(object sender, ICollisionInput args)
        {
            Guid entity1 = args.GetEntityKeys()[0];
            Guid entity2 = args.GetEntityKeys()[1];

            if (entity1 == _guid || entity2 == _guid)
            {
                ((IMove)args.GetEntityComponents()[entity2][typeof(Move)]).Velocity = ((IMove)args.GetEntityComponents()[entity1][typeof(Move)]).Velocity;
                ((IInputListener)args.GetEntityComponents()[entity2][typeof(InputListener)]).KeyboardListener = true;
            }
        }
    }
}
