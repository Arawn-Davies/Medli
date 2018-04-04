using System;
using System.Collections.Generic;
using System.Text;
using Medli.Core;
using Cosmos.HAL;

namespace Medli.Hardware
{
    public class HALPBE
    {
		public static void Init()
		{
			PrebootEnvironment.Init();
			Console.WriteLine("Detecting PCI Devices");
		}
    }
}
