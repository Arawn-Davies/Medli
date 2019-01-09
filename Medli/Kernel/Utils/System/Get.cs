﻿using System;
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
ram_info    - RAM information
ram_used    - Total amount of used RAM
ram_free    - Total amount of free RAM
ram_total   - Total amount of installed RAM
host        - System host
lscpu       - Lists installed CPU(s)
lspci       - Lists PCI devices
list_vol(s) - Lists the filesystem volumes"; }
		}

		public override void Execute(string param)
		{
			if (param == "sysinfo")
			{
				SystemFunctions.PrintInfo();
			}
            else if (param == "ram_info")
            {
                SystemFunctions.PrintRAMInfo();
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
            else if (param == "lscpu")
            {
                SystemFunctions.lscpu();
            }
            else if (param == "list_vols")
			{
				FS.ListVols();
			}
			else if (param == "list_vol")
			{
				FS.ListVol();
			}
		}
	}
}