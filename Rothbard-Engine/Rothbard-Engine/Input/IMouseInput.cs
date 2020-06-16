﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rothbard_Engine
{
    interface IMouseInput
    {
        /// <summary>
        /// Returns mouse position
        /// </summary>
        /// <returns></returns>
        int[] GetMouseVal();
    }
}
