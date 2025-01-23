using Cosmos.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace MedliX.Ring0
{
    public class MemoryMonitor
    {
        public static uint GetUsedMemory()
        {
            uint UsedRAM = CPU.GetEndOfKernel() + 1024;
            return UsedRAM / div;
        }
        public static uint FreePercentage;
        public static uint UsedPercentage = (GetUsedMemory() * 100) / GetTotalMemory();
        public static uint GetFreeMemory = GetTotalMemory() - GetUsedMemory();
        private const uint div = 1048576;

        public static uint GetTotalMemory()
        {
            return CPU.GetAmountOfRAM() + 1;
        }
        public void Monitor()
        {
            GetTotalMemory();
            GetFreeMemory = GetTotalMemory() - GetUsedMemory();
            UsedPercentage = (GetUsedMemory() * 100) / GetTotalMemory();
            FreePercentage = 100 - UsedPercentage;
        }
        public MemoryMonitor()
        {
            this.Monitor();
        }
    }
}