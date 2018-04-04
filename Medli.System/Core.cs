using System;
using System.Collections.Generic;
using System.Text;
using Medli.Hardware;

namespace Medli.System
{
    public class CoreInfo
    {
		public static MemMon memoryManager = new MemMon();
		public static void PrintInfo()
		{
			memoryManager.PrintInfo();
		}
    }
}
