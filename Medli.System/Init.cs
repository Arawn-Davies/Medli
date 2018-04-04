using System;
using System.Collections.Generic;
using System.Text;
using Medli.Hardware;
using Medli.Common;

namespace Medli.System
{
    public class SYSPBE
    {
		public static KernelAreaInfo SystemKernelInfo = new KernelAreaInfo(ConsoleColor.Blue, "System");
		public static void Init()
		{
			HALPBE.Init();
		}
    }
}
