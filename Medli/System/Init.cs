using System;
using System.Collections.Generic;
using System.Text;
using Medli.Hardware;
using Medli.Common;
using Sys = Cosmos.System;
using System.IO;

namespace Medli.System
{
    public class SYSPBE
    {
		public static KernelAreaInfo SystemKernelInfo = new KernelAreaInfo(ConsoleColor.Blue, "System");
		public static void Init()
		{
			HALPBE.Init();
			Sys.FileSystem.VFS.VFSManager.RegisterVFS(KernelVariables.vFS);
			if (CheckVolumes() == false)
			{
				Console.WriteLine("Running Medli in Live User mode.");
				Console.WriteLine("FS operations are disabled!");
				KernelVariables.IsLive = true;
			}
			else
			{
				if (File.Exists(Paths.System + @"live.user"))
				{
					KernelVariables.IsLive = true;
				}
				else
				{
					KernelVariables.IsLive = false;
				}

				foreach (string dir in Paths.OSDirectories)
				{
					FS.mkdir(dir, true);
				}
			}
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
    }
}
