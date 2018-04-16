using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Core;
using Medli.Common;
using System.Threading;

namespace Medli.Core
{
	public enum coreArea
	{
		CPU,
		RAM,
		IDT,
		IO,
		SSE,
		Math
	}
    public class PrebootEnvironment
    {
		public static coreArea cArea;
		public static PIC pic;
		public static readonly CPU cpu = new CPU();
		public static void Init()
		{
			AreaInfo.CoreInfo.WriteAreaPrefix("Initialising CPU...");
			AreaInfo.CoreInfo.WriteAreaPrefix("Initialising Interrupt Descriptor Table...");
			Cosmos.Core.INTs.Dummy();
			pic = new PIC();
			cpu.UpdateIDT(true);
			Interrupt.OverrideHandlers();
			Thread.Sleep(500);
			AreaInfo.CoreInfo.WriteAreaPrefix("Initialising SSE extensions...");
			cpu.InitSSE();
			Thread.Sleep(500);
			AreaInfo.CoreInfo.WriteAreaPrefix("Initialising math processor extensions...");
			cpu.InitFloat();
			Thread.Sleep(500);
		}
	}
}
