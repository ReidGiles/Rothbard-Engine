using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    public class MoveSystem : ISystem, IUpdatable, IKeyboardListener
    {
        // DECLARE an IDictionary of type IDictionary, call it '_entityComponentLink'
        private IDictionary<Guid, IDictionary<Type, IComponent>> _entityComponentLink;

        // args to store the keyboard inputs
        private IKeyboardInput _args;

        private bool _inputFlag;

        /// <summary>
        /// Consttructor for MoveSystem
        /// </summary>
        public MoveSystem()
        {
            // INSTANTIATE _entityComponentLink
            _entityComponentLink = new Dictionary<Guid, IDictionary<Type, IComponent>>();

            _inputFlag = false;
        }

        /// <summary>
        /// Receives keyboard events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnNewKeyboardInput(object sender, IKeyboardInput args)
        {
            // on keyboard event set the keyboard input to args
            _args = args;
            _inputFlag = true;
        }

        public void Set(IDictionary<Guid, IDictionary<Type, IComponent>> pDictionary)
        {
            _entityComponentLink = pDictionary;
        }

        public void Update(GameTime pGameTime)
        {
        }
    }
}
