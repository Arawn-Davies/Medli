using System;
using System.Collections.Generic;
using System.Text;
using Medli.Hardware;
using Medli.Common;
using Sys = Cosmos.System;
using System.IO;
using System.Threading;
using Medli.Common.Services;

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
					KernelVariables.Hostname = File.ReadAllText(SysFiles.HostnameFile);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine("There was an error while reading the Medli hostname.");
				Console.WriteLine("Please enter a new hostname:");
				Console.Write("Hostname:");
				string hostname = Console.ReadLine();
				KernelVariables.Hostname = hostname;
				FS.del(SysFiles.HostnameFile, false);
				File.WriteAllText(SysFiles.HostnameFile, hostname);
			}
		}
	}

}
