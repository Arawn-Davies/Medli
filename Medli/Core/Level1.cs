using System;
using Cosmos.Core;
using Medli.Common;

namespace Medli.Core
{ 
    public class Runtime
    {
		public static PIC pic;
		public static readonly CPU cpu = new CPU();
		public static void Level1Init()
		{
			AreaInfo.CoreDevInfo.WriteDevicePrefix("RAM", "Initializing Memory Monitor...");
			CoreDevices.MemMon = new MemoryManager();
		}
	}
}
