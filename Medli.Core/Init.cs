using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Core;

namespace Medli.Core
{
    public class PrebootEnvironment
    {
		public static PIC pic;
		public static readonly CPU cpu = new CPU();
		public static void Init()
		{
			INTs.Dummy();
			pic = new PIC();
			cpu.UpdateIDT(true);
			cpu.InitSSE();
			cpu.InitFloat();
			Cosmos.Core.Memory.Heap.Init();
		}
    }
}
