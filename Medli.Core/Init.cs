using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Core;
using Medli.Common;

namespace Medli.Core
{
    public class PrebootEnvironment
    {
		private static KernelAreaInfo CoreAreaInfo = new KernelAreaInfo(ConsoleColor.Cyan, "Core");
		public static PIC pic;
		public static readonly CPU cpu = new CPU();
		public static void Init()
		{
			CoreAreaInfo.WriteAreaPrefix();
			INTs.Dummy();
			pic = new PIC();
			cpu.UpdateIDT(true);
			cpu.InitSSE();
			cpu.InitFloat();
		}
    }
}
