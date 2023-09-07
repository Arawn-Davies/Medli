using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makar.Ring0
{
    public class OSLvl0
    {
        MemoryMonitor memmtr = new MemoryMonitor();
        public static void PrintInfo()
        {
            Console.WriteLine("Total RAM: " + MemoryMonitor.GetTotalMemory());
            Console.WriteLine("RAM Available: " + MemoryMonitor.GetFreeMemory);
            Console.WriteLine("RAM in use: " + MemoryMonitor.GetUsedMemory());
            Console.WriteLine("Percentage used: " + MemoryMonitor.UsedPercentage);
            Console.WriteLine("Percentage free: " + MemoryMonitor.FreePercentage);
        }
    }
}
