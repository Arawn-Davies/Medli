using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.IO;

namespace Medli.Common.Services
{
	public class FSService : Service
	{
		public static Sys.FileSystem.CosmosVFS vFS;
		public FSService()
		{
			ServiceName = "FSSRV";
			Priority = AccessPriority.MID;
			Active = false;
		}

		public bool CheckVolumes()
		{
			var volumes = vFS.GetVolumes();
			foreach (var vol in volumes)
			{
				return true;
			}
			return false;
		}

		public override bool Init()
		{
			base.Init();
			vFS = new Sys.FileSystem.CosmosVFS();
			Sys.FileSystem.VFS.VFSManager.RegisterVFS(vFS);
			if (CheckVolumes() == false) {
				Console.WriteLine("Running Medli in Live User mode.");
				Console.WriteLine("FS operations are disabled!");
				KernelVariables.IsLive = true;
				Active = false;
				return false;
			}
			else
			{
				if (File.Exists(Paths.System + @"live.user")) {
					Console.WriteLine("OS in recovery mode! Live User mode enabled...");
					KernelVariables.IsLive = true;
					Paths.CurrentDirectory = "LIVE";
					Active = false;
					return false;
				}
				else
				{
					KernelVariables.IsLive = false;
					foreach (string dir in Paths.OSDirectories) {
						if (!Directory.Exists(dir))
						{
							AreaInfo.SystemDevInfo.WriteDevicePrefix("FS", "Creating directory " + dir + "...");
							System.FS.mkdir(dir, true);
						}
					}
					System.SYSPBE.ReadHostname();
					Active = true;
					return true;
				}
			}
		}
	}
}
