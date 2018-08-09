using System;
using Cosmos.Core;
using Medli.Common;

namespace Medli.Core
{ 
    public class PrebootEnvironment
    {
		public static PIC pic;
		public static readonly CPU cpu = new CPU();
		public static void Init()
		{
			Console.Clear();
			//Cosmos.Core.INTs.Dummy();
			//pic = new PIC();
			//Extensions.MConsole.Clear();
			//Console CoreConsole = new System.Console(textScreen);
			//AreaInfo.CoreDevInfo.WriteDevicePrefix("CPU", "Initialising CPU...");
			//AreaInfo.CoreDevInfo.WriteDevicePrefix("IDT", "Initialising Interrupt Descriptor Table...");
			//Thread.Sleep(500);
			//cpu.UpdateIDT(true);
			//Interrupt.OverrideHandlers();
			//Thread.Sleep(500);
			//AreaInfo.CoreDevInfo.WriteDevicePrefix("SSE", "Initialising SSE extensions...");
			//cpu.InitSSE();
			//Thread.Sleep(500);
			//AreaInfo.CoreDevInfo.WriteDevicePrefix("FPU", "Initialising math processor extensions...");
			/*
             * We liked to use SSE for all floating point operation and end to mix SSE / x87 in Cosmos code
             * but sadly in x86 this resulte impossible as Intel not implemented some needed instruction (for example conversion
             * for long to double) so - in some rare cases - x87 continue to be used. I hope passing to the x32 or x64 IA will solve
             * definively this problem.
             */
			//cpu.InitFloat();
			//Thread.Sleep(500);
			//AreaInfo.CoreDevInfo.WriteDevicePrefix("PWR", "Starting ACPI Services...");
			//ACPI.Start();
			//Thread.Sleep(500);
			AreaInfo.CoreDevInfo.WriteDevicePrefix("RAM", "Initializing Memory Monitor...");
			//Thread.Sleep(500);
			CoreDevices.MemMon = new MemoryManager();
			//Thread.Sleep(500);
		}
	}
}
