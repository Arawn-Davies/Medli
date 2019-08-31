using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Core;
using AIC.Core;

namespace Medli.Core
{
	public class MemoryManager
	{
		public static uint GetUsedMemory()
		{
			uint UsedRAM = CPU.GetEndOfKernel() + 1024;
			return UsedRAM / div;
		}
		public static uint TotalMemory = GetRAM.GetAmountOfRAM;
		public uint FreePercentage;
		public uint UsedPercentage = (GetUsedMemory() * 100) / TotalMemory;
		public uint FreeMemory = TotalMemory - GetUsedMemory();
		private const uint div = 1048576;

		public static void GetTotalMemory()
		{
			TotalMemory = GetRAM.GetAmountOfRAM + 1;
		}
		public void Monitor()
		{
			GetTotalMemory();
			FreeMemory = TotalMemory - GetUsedMemory();
			UsedPercentage = (GetUsedMemory() * 100) / TotalMemory;
			FreePercentage = 100 - UsedPercentage;
		}
		public MemoryManager()
		{
			this.Monitor();
		}
	}
}
