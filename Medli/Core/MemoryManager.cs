using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Core;

namespace Medli.Core
{
	public class MemoryManager
	{
		public static uint id = 0;
		public static uint GetUsedMemory = 0;
		public static uint TotalMemory = 0;
		public static uint Percentage = 0;
		public static uint FreeMemory = 0;
		private const uint div = 1048576;
		public static uint Original;
		public static void InitEx()
		{
			CheckUsedMemory();
			Original = GetUsedMemory;
		}
		public static void CheckUsedMemory()
		{
			uint UsedRAM = CPU.GetEndOfKernel() + 2048;
			//UsedMemory = Cosmos.Core.
			//UsedMemory = Cosmos.Core.Heap.GetUsedMemory();//Get Used Memory
			GetUsedMemory = UsedRAM / div;//Convert to MB
		}
		public static void GetTotalMemory()
		{
			TotalMemory = CPU.GetAmountOfRAM() + 1;
		}
		public void Monitor()
		{
			CheckUsedMemory();
			GetTotalMemory();
			FreeMemory = TotalMemory - GetUsedMemory;
			Percentage = (GetUsedMemory * 100) / TotalMemory;
			Console.WriteLine("Mem Usage: " + GetUsedMemory.ToString());
			Console.WriteLine("Total Mem: " + TotalMemory.ToString());
			Console.WriteLine("Free Mem:" + FreeMemory.ToString());
		}

		public static uint GetFreeMem()
		{

			/*
			uint addr = 0;
			for (int i = 0; i < id; i++)
			{
				if (Cosmos.Core.Memory.RAT.)
				if (Cosmos.Core.Memory.Old.Heap.Blocks[i].Header == 0)
				{
					addr = Cosmos.Core.Heap.Blocks[i].Base;
					break;
				}
			}
			*/
			return TotalMemory - GetUsedMemory;
		}
	}
}
