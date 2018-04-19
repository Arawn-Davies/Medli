using System;
using System.Collections.Generic;
using System.Text;
using Medli.Hardware;

namespace Medli.System
{
	public class CoreInfo
	{
		public static void PrintUsedRAM()
		{
			MemoryMonitoring.PrintUsed();
		}
		public static void PrintTotalRAM()
		{
			MemoryMonitoring.PrintTotal();
		}
		public static void PrintFreeRAM()
		{
			MemoryMonitoring.PrintFree();
		}
		public static void PrintInfo()
		{
			MemoryMonitoring.PrintInfo();
		}
	}
}
