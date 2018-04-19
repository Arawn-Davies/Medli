using System;
using System.Collections.Generic;
using System.Text;
using Medli.Core;

namespace Medli.Hardware
{
	public class MemoryMonitoring
	{

		public static void PrintTotal()
		{
			CoreDevices.MemMon.Monitor();
			Console.WriteLine("Total memory: " + MemoryManager.TotalMemory + " MBs");
		}
		public static void PrintUsed()
		{
			CoreDevices.MemMon.Monitor();
			Console.Write("Used memory: " + MemoryManager.GetUsedMemory() + " MBs, ");
			Console.WriteLine(CoreDevices.MemMon.UsedPercentage + "%");
		}
		public static void PrintFree()
		{
			CoreDevices.MemMon.Monitor();
			Console.Write("Free memory: " + CoreDevices.MemMon.FreeMemory + " MBs, ");
			Console.WriteLine(CoreDevices.MemMon.FreePercentage + "%");
		}
		public static void PrintInfo()
		{
			PrintTotal();
			PrintUsed();
			PrintFree();
		}
	}
}
