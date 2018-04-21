﻿using System;
using System.Collections.Generic;
using System.Text;
using Medli.Hardware;
using Medli.Common;
using Sys = Cosmos.System;
using System.IO;
using System.Threading;
using Medli.Hardware;

namespace Medli.System
{
    public class SYSPBE
    {
		/// <summary>
		/// System ring init method - ran once at boot
		/// </summary>
		public static void Init(TextScreenBase textScreen)
		{
			HALPBE.Init(textScreen);
			Thread.Sleep(500);
			Sys.FileSystem.VFS.VFSManager.RegisterVFS(KernelVariables.vFS);
			if (CheckVolumes() == false)
			{
				SysConsole.WriteLine("Running Medli in Live User mode.");
				SysConsole.WriteLine("FS operations are disabled!");
				KernelVariables.IsLive = true;
				Thread.Sleep(500);
			}
			else
			{
				if (File.Exists(Paths.System + @"live.user"))
				{
					SysConsole.WriteLine("OS in recovery mode! Live User mode enabled...");
					KernelVariables.IsLive = true;
					Paths.CurrentDirectory = "LIVE";
				}
				else
				{
					KernelVariables.IsLive = false;
					/*
					foreach (string dir in Paths.OSDirectories)
					{
						Console.WriteLine("Creating " + dir + "...");
						FS.mkdir(dir, true);
						Thread.Sleep(500);
					}
					*/
					Thread.Sleep(50); FS.mkdir(Paths.System, true);
					Thread.Sleep(50); FS.mkdir(Paths.SystemData, true);
					Thread.Sleep(50); FS.mkdir(Paths.Libraries, true);
					Thread.Sleep(50); FS.mkdir(Paths.Modules, true);
					Thread.Sleep(50); FS.mkdir(Paths.Apps, true);
					Thread.Sleep(50); FS.mkdir(Paths.x86Apps, true);
					Thread.Sleep(50); FS.mkdir(Paths.AppTemp, true);
					Thread.Sleep(50); FS.mkdir(Paths.Users, true);
					Thread.Sleep(50); FS.mkdir(Paths.RootUser, true);
					Thread.Sleep(50); FS.mkdir(Paths.Guest, true);
					Thread.Sleep(50); FS.mkdir(Paths.Temp, true);
					ReadHostname();
				}
			}
			SysConsole.WriteLine("Press any key to continue...");
			SysConsole.ReadKey(true);
		}

		/// <summary>
		/// Checks the Virtual File System to see if there are any usable disks
		/// </summary>
		/// <returns>True if any disks are present, false if not</returns>
		public static bool CheckVolumes()
		{
			var volumes = KernelVariables.vFS.GetVolumes();
			foreach (var vol in volumes)
			{
				return true;
			}
			return false;
		}
		public static void ReadHostname()
		{
			try
			{
				KernelVariables.Hostname = File.ReadAllText(SysFiles.HostnameFile);
			}
			catch (Exception ex)
			{
				SysConsole.WriteLine(ex.Message);
				SysConsole.WriteLine("There was an error while reading the Medli hostname.");
				SysConsole.WriteLine("Please enter a new hostname:");
				SysConsole.Write("Hostname:");
				string hostname = SysConsole.ReadLine();
				KernelVariables.Hostname = hostname;
				//FS.del(SysFiles.HostnameFile, false);
				//File.WriteAllText(SysFiles.HostnameFile, hostname);
			}
		}
    }
}
