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
		public static void Init(Hardware.TextScreenBase textScreen)
		{
			Cosmos.Core.INTs.Dummy();
			pic = new PIC();
			Extensions.MConsole.Clear();
			System.SysConsole CoreConsole = new System.SysConsole(textScreen);
			AreaInfo.CoreDevInfo.WriteDevicePrefix("CPU", "Initialising CPU...");
			AreaInfo.CoreDevInfo.WriteDevicePrefix("IDT", "Initialising Interrupt Descriptor Table...");
			//Thread.Sleep(1000);
			//cpu.UpdateIDT(true);
			//Interrupt.OverrideHandlers();
			//Thread.Sleep(1000);
			AreaInfo.CoreDevInfo.WriteDevicePrefix("SSE", "Initialising SSE extensions...");
			cpu.InitSSE();
			Thread.Sleep(1000);
			AreaInfo.CoreDevInfo.WriteDevicePrefix("FPU", "Initialising math processor extensions...");
			/*
             * We liked to use SSE for all floating point operation and end to mix SSE / x87 in Cosmos code
             * but sadly in x86 this resulte impossible as Intel not implemented some needed instruction (for example conversion
             * for long to double) so - in some rare cases - x87 continue to be used. I hope passing to the x32 or x64 IA will solve
             * definively this problem.
             */
			cpu.InitFloat();
			Thread.Sleep(1000);
			AreaInfo.CoreDevInfo.WriteDevicePrefix("PWR", "Starting ACPI Services...");
			ACPI.Start();
			Thread.Sleep(1000);
			AreaInfo.CoreDevInfo.WriteDevicePrefix("RAM", "Initializing Memory Monitor...");
			Thread.Sleep(1000);
			CoreDevices.MemMon = new MemoryManager();
			Thread.Sleep(1000);
		}
	}
}
