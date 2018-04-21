using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmos.Core;

namespace Medli.Core.IOGroups {
    public class PCI : IOGroups {
        public IOPort ConfigAddressPort = new IOPort(0xCF8);
        public IOPort ConfigDataPort = new IOPort(0xCFC);
    }
}
