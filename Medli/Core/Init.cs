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
		private static KernelAreaInfo caInfo = new KernelAreaInfo(ConsoleColor.Red, "Core");
		public static PIC pic;
		public static readonly CPU cpu = new CPU();
		public static void Init()
		{
			caInfo.WriteAreaPrefix(); Console.WriteLine(" Initialising CPU...");
			caInfo.WriteAreaPrefix(); Console.WriteLine(" Initialising Interrupt Descriptor Table...");
			Cosmos.Core.INTs.Dummy();
			pic = new PIC();
			cpu.UpdateIDT(true);
			Thread.Sleep(500);
			caInfo.WriteAreaPrefix(); Console.WriteLine(" Initialising SSE extensions...");
			cpu.InitSSE();
			Thread.Sleep(500);
			caInfo.WriteAreaPrefix(); Console.WriteLine(" Initialising math processor extensions...");
			cpu.InitFloat();
			Thread.Sleep(500);
		}
    }
}
