using System;
using Medli.Hardware;
using Medli.Common;
using System.IO;
using Medli.Common.Services;
using MDFS;

namespace Medli.System
{
	public class SystemBootEnvironment
	{
		/// <summary>
		/// System ring init method - ran once at boot
		/// </summary>
		public static void Init()
		{
			HALPBE.Init();
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
				if (File.Exists(SysFiles.HostnameFile))
                    Kernel.Hostname = File.ReadAllText(SysFiles.HostnameFile);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine("There was an error while reading the Medli hostname.");
				Console.WriteLine("Please enter a new hostname:");
				Console.Write("Hostname:");
				string hostname = Console.ReadLine();
                Kernel.Hostname = hostname;
				FS.del(SysFiles.HostnameFile, false);
				File.WriteAllText(SysFiles.HostnameFile, hostname);
			}
		}
	}

}
