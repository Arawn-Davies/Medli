using System;
using Medli.Hardware;
using Medli.Common;
using System.IO;
using Medli.Common.Services;
using MDFS;
using Medli.Common.Drivers;

namespace Medli.System
{
	public class Level3
	{
		/// <summary>
		/// System ring init method - ran once at boot
		/// </summary>
		public static void Init()
		{
			HW.Init();
			//Thread.Sleep(500);
			Console.WriteLine("FileSystem service...");
			FSService.Init();
			Console.WriteLine("Filesystem: " + FSService.Active);
            if (FSService.Active == true)
            {
                for (int i = 1; i < SystemFunctions.IDEs.Length; i++)
                {
                    new DiskListing(i, SystemFunctions.IDEs[i]);
                }
                InstallService.Init();
            }

            SystemCalls MEFAPI = new SystemCalls();
            for (int i = 0; i < Kernel.Drivers.Count; i++)
            {
                if (Kernel.Drivers[i].Init())
                {
                    Console.WriteLine(Kernel.Drivers[i].Name + "' loaded sucessfully");
                }
                else
                {
                    Console.WriteLine("Failure loading module '" + Kernel.Drivers[i].Name + "'");
                    Console.ReadKey();
                }
            }
        }
		/// <summary>
		/// Checks the Virtual File System to see if there are any usable disks
		/// </summary>
		/// <returns>True if any disks are present, false if not</returns>
		
		public static void ReadHostname()
		{
			try
			{
				if (File.Exists(SysFiles.Hostname))
                    Kernel.Hostname = File.ReadAllText(SysFiles.Hostname);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine("There was an error while reading the Medli hostname.");
				Console.WriteLine("Please enter a new hostname:");
				Console.Write("Hostname:");
				string hostname = Console.ReadLine();
                Kernel.Hostname = hostname;
				FS.del(SysFiles.Hostname, false);
				File.WriteAllText(SysFiles.Hostname, hostname);
			}
		}
	}

}
