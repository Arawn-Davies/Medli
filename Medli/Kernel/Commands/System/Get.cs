using System;
using System.Collections.Generic;
using System.Text;
using Medli.Common;
using Medli.System;
using Sys = Cosmos.System;

namespace Medli.Apps
{
	public class Get : Command
	{
		public override string Name
		{
			get { return "get"; }
		}

		public override string Summary
		{
			get { return @"Retrieves system information.
get [arg]
ram_info  - RAM information
ram_used  - Total amount of used RAM
ram_free  - Total amount of free RAM
ram_total - Total amount of installed RAM
host      - System host
lspci     - Lists PCI devices"; }
		}

		public override void Execute(string param)
		{
			if (param == "ram_info")
			{
				SystemFunctions.PrintInfo();
			}
			else if (param == "ram_used")
			{
				SystemFunctions.PrintUsedRAM();
			}
			else if (param == "ram_free")
			{
				SystemFunctions.PrintFreeRAM();
			}
			else if (param == "ram_total")
			{
				SystemFunctions.PrintTotalRAM();
			}
			else if (param == "host")
			{
				Console.WriteLine(Kernel.Host);
			}
			else if (param == "lspci")
			{
				SystemFunctions.lspci();
			}
		}
	}
}