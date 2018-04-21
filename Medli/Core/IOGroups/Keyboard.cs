using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmos.Core;

namespace Medli.Core.IOGroups {
    public class Keyboard : IOGroups {
        public readonly IOPort Port60 = new IOPort(0x60);
    }
}
