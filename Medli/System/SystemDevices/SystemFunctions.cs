using System;
using System.Collections.Generic;
using System.Text;
using Medli.Hardware;
using MDFS;
using MDFS.Physical;

namespace Medli.System
{
	public class SystemFunctions
	{
		public static IDE[] IDEs = IDE.Devices.ToArray();

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
        public static void PrintRAMInfo()
        {
            MemoryMonitoring.PrintInfo();
        }
		public static void PrintInfo()
		{
			PrintRAMInfo();
            lscpu();
		}
		public static void lspci()
		{
			HAL.ListPCIDevices();
		}
        public static void lscpu()
        {
            CPUInfo.LSCPU();
        }
    }
}
