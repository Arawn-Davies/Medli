using System;
using Cosmos.Core;
using Medli.Common;

namespace Medli.Core
{ 
    public class Level1
    {
		public static PIC pic;
		public static readonly CPU cpu = new CPU();
		public static void Init()
		{
			AreaInfo.CoreDevInfo.WriteDevicePrefix("RAM", "Initializing Memory Monitor...");
			CoreDevices.MemMon = new MemoryManager();
		}
	}
}
