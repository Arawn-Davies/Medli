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
			AreaInfo.CoreDevInfo.WriteDevicePrefix("CPU", "Initialising CPU...");
			AreaInfo.CoreDevInfo.WriteDevicePrefix("IDT", "Initialising Interrupt Descriptor Table...");
			Cosmos.Core.INTs.Dummy();
			pic = new PIC();
			cpu.UpdateIDT(true);
			Interrupt.OverrideHandlers();
			Thread.Sleep(500);
			AreaInfo.CoreDevInfo.WriteDevicePrefix("SSE", "Initialising SSE extensions...");
			cpu.InitSSE();
			Thread.Sleep(500);
			AreaInfo.CoreDevInfo.WriteDevicePrefix("FPU", "Initialising math processor extensions...");
			cpu.InitFloat();
			Thread.Sleep(500);
			AreaInfo.CoreDevInfo.WriteDevicePrefix("RAM", "Detecting RAM properties and status...");
			CoreDevices.MemMon = new MemoryManager();
		}
	}
}
