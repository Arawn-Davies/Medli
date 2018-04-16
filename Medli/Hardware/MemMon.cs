using System;
using System.Collections.Generic;
using System.Text;
using Medli.Core;

namespace Medli.Hardware
{
    public class MemMon
    {
		public MemMon()
		{
			MemoryManager.GetTotalMemory();
			MemoryManager.Original = MemoryManager.GetUsedMemory;
		}
		public void PrintInfo()
		{
			Console.WriteLine("Total memory: " + TotalMemory.ToString());
			Console.WriteLine("Used memory: " + UsedMemory.ToString() + " ");
			Console.Write(UsedPercentage + "%");
			Console.WriteLine("Free memory: " + FreeMemory.ToString() + " ");
			Console.Write(FreePercentage + "%");
		}

		public uint OriginalMemoryUsage = MemoryManager.Original;
		public uint UsedPercentage = (MemoryManager.GetUsedMemory * 100) / MemoryManager.TotalMemory;
		public uint FreePercentage = (MemoryManager.FreeMemory * 100) / MemoryManager.TotalMemory;
		public uint FreeMemory = MemoryManager.FreeMemory;
		public uint UsedMemory = MemoryManager.GetUsedMemory;
		public uint TotalMemory = MemoryManager.TotalMemory;
    }
}
