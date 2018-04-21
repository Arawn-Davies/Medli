using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Core;

namespace Medli.Core.IOGroups
{
    public class Mouse : IOGroups
    {
        public readonly IOPort p60 = new IOPort(0x60);
        public readonly IOPort p64 = new IOPort(0x64);
    }
}
