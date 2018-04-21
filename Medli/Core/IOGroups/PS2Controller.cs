using Cosmos.Core;

namespace Medli.Core.IOGroups
{
    public class PS2Controller
    {
        public readonly IOPort Data = new IOPort(0x60);
        public readonly IOPortRead Status = new IOPortRead(0x64);
        public readonly IOPortWrite Command = new IOPortWrite(0x64);
    }
}
