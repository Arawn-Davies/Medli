using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.System.FileSystem;
using System.IO;

namespace Medli.Common.Services
{
	public class FSService
	{
		public static CosmosVFS vFS;

		public static string ServiceName = "FSSRV";

		public static AccessPriority Priority = AccessPriority.MID;

		public static bool Active = false;

		public static bool CheckVolumes()
		{
			var volumes = vFS.GetVolumes();
			foreach (var vol in volumes)
			{
				return true;
			}
			return false;
		}

		public static string ServicePath;

		public static LoggingService ServiceLogger;

		public static bool Init()
		{
            vFS = new CosmosVFS();
			Cosmos.System.FileSystem.VFS.VFSManager.RegisterVFS(vFS);
			if (CheckVolumes() == false) {
				Console.WriteLine("Running Medli in Live User mode.");
				Console.WriteLine("FS operations are disabled!");
				Kernel.IsLive = true;
				Active = false;
				return false;
			}
			else
			{
				if ((File.Exists(Paths.System + @"live.user")) || Kernel.IsLive == true)
                {
					Console.WriteLine("OS in recovery mode! Live User mode enabled...");
					Kernel.IsLive = true;
					Paths.CurrentDirectory = "LIVE";
					Active = false;
					return false;
				}
				else
				{
					/*
					int i = 0;
					for (i = 0; i < Paths.OSDirectories.Length; i++)
					{
						if (!Directory.Exists(Paths.OSDirectories[i]))
						{
							AreaInfo.SystemDevInfo.WriteDevicePrefix("FS", "Creating directory " + Paths.OSDirectories[i] + "...");
							System.FS.Makedir(Paths.OSDirectories[i], true);
						}
					}*/
					Paths.CreateDirectories();
                    ServiceLogger = new LoggingService(Paths.SystemLogs + @"\fs.log");
					ServiceLogger.Record("FS Service logger initialized.");
					Kernel.IsLive = false;
					System.SystemInit.ReadHostname();
                    Directory.SetCurrentDirectory(Paths.Root);
					Active = true;
					return true;
				}
			}
		}
	}
}
