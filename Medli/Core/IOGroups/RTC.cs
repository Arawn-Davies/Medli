using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmos.Core;

namespace Medli.Core.IOGroups {
    public class RTC : IOGroups {
        public readonly IOPort Address = new IOPort(0x70);
        public readonly IOPort Data = new IOPort(0x71);
    }
}
