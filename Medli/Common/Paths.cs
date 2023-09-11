using System.Collections.Generic;
using System.IO;
using Medli.System;

namespace Medli.Common
{
    class Paths
    {
		//public Cosmos.System.FileSystem.Listing.DirectoryEntry vol = FS.FSService.vFS.GetVolume(CurrentDirectory);
		public static void CreateDirectories()
		{
			if (!Directory.Exists(Users))
			{
				AreaInfo.SystemDevInfo.WriteDevicePrefix("FS", "Creating directory " + Users + "...");
				FS.Makedir(Users, true);
			}
			if (!Directory.Exists(RootUser))
			{
				AreaInfo.SystemDevInfo.WriteDevicePrefix("FS", "Creating directory " + RootUser + "...");
				FS.Makedir(Root, true);
			}
			if (!Directory.Exists(Guest))
			{
				AreaInfo.SystemDevInfo.WriteDevicePrefix("FS", "Creating directory " + Guest + "...");
				FS.Makedir(Guest, true);
			}
			if (!Directory.Exists(Apps))
			{
				AreaInfo.SystemDevInfo.WriteDevicePrefix("FS", "Creating directory " + Apps + "...");
				FS.Makedir(Apps, true);
			}
			if (!Directory.Exists(x86Apps))
			{
				AreaInfo.SystemDevInfo.WriteDevicePrefix("FS", "Creating directory " + x86Apps + "...");
				FS.Makedir(x86Apps, true);
			}
			if (!Directory.Exists(AppTemp))
			{
				AreaInfo.SystemDevInfo.WriteDevicePrefix("FS", "Creating directory " + AppTemp + "...");
				FS.Makedir(AppTemp, true);
			}
			if (!Directory.Exists(System))
			{
				AreaInfo.SystemDevInfo.WriteDevicePrefix("FS", "Creating directory " + System + "...");
				FS.Makedir(System, true);
			}
			if (!Directory.Exists(SystemData))
			{
				AreaInfo.SystemDevInfo.WriteDevicePrefix("FS", "Creating directory " + SystemData + "...");
				FS.Makedir(SystemData, true);
			}
			if (!Directory.Exists(SystemLogs))
			{
				AreaInfo.SystemDevInfo.WriteDevicePrefix("FS", "Creating directory " + SystemLogs + "...");
				FS.Makedir(SystemLogs, true);
			}
			if (!Directory.Exists(Libraries))
			{
				AreaInfo.SystemDevInfo.WriteDevicePrefix("FS", "Creating directory " + Libraries + "...");
				FS.Makedir(Libraries, true);
			}
			if (!Directory.Exists(Modules))
			{
				AreaInfo.SystemDevInfo.WriteDevicePrefix("FS", "Creating directory " + Modules + "...");
				FS.Makedir(Modules, true);
			}
			if (!Directory.Exists(Temp))
			{
				AreaInfo.SystemDevInfo.WriteDevicePrefix("FS", "Creating directory " + Temp + "...");
				FS.Makedir(Temp, true);
			}
		}


		public static string[] OSDirectories = new string[]
		{
			Users,
			RootUser,
			Guest,
			Apps,
			AppTemp,
			x86Apps,
			System,
			SystemData,
			SystemLogs,
			Libraries,
			Modules,
			Temp,
		};

		public static string Root = @"0:\";

		public static string Users = Root + @"Users";
		public static string RootUser = Root + @"root";
		public static string Guest = Users + @"\Guest";

		public static string Apps = Root + @"Apps";
		public static string AppTemp = Apps + @"\Temp";
		public static string x86Apps = Apps + @"\x86";

		public static string System = Root + @"System";
		public static string SystemData = System + @"\Data";
		public static string SystemLogs = System + @"\Logs";
		public static string Libraries = System + @"\Libraries";
		public static string Modules = System + @"\Modules";

		public static string Temp = Root + @"Temp";

        public static string Separator = @"\";

        public static string CurrentDirectory = Root;

	}
}
