﻿using Cosmos.Core;

namespace Medli.Core.IOGroups
{
    public class PIC : IOGroups
    {
        public readonly IOPort Cmd = new IOPort(0x20);
        public readonly IOPort Data = new IOPort(0x21);

        internal PIC(bool aSlave)
        {
            byte aBase = (byte) (aSlave ? 0xA0 : 0x20);
            Cmd = new IOPort(aBase);
            Data = new IOPort((byte) (aBase + 1));
        }
    }
}
