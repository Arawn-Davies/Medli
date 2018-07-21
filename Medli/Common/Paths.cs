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
			AreaInfo.SystemDevInfo.WriteDevicePrefix("FS", "Creating directory " + Users + "...");
			Directory.CreateDirectory(Users);
			AreaInfo.SystemDevInfo.WriteDevicePrefix("FS", "Creating directory " + RootUser + "...");
			Directory.CreateDirectory(RootUser);
			AreaInfo.SystemDevInfo.WriteDevicePrefix("FS", "Creating directory " + Guest + "...");
			Directory.CreateDirectory(Guest);
			AreaInfo.SystemDevInfo.WriteDevicePrefix("FS", "Creating directory " + Apps + "...");
			Directory.CreateDirectory(Apps);
			AreaInfo.SystemDevInfo.WriteDevicePrefix("FS", "Creating directory " + x86Apps + "...");
			Directory.CreateDirectory(x86Apps);
			AreaInfo.SystemDevInfo.WriteDevicePrefix("FS", "Creating directory " + AppTemp + "...");
			Directory.CreateDirectory(AppTemp);
			AreaInfo.SystemDevInfo.WriteDevicePrefix("FS", "Creating directory " + System + "...");
			Directory.CreateDirectory(System);
			AreaInfo.SystemDevInfo.WriteDevicePrefix("FS", "Creating directory " + SystemData + "...");
			Directory.CreateDirectory(SystemData);
			AreaInfo.SystemDevInfo.WriteDevicePrefix("FS", "Creating directory " + SystemLogs + "...");
			Directory.CreateDirectory(SystemLogs);
			AreaInfo.SystemDevInfo.WriteDevicePrefix("FS", "Creating directory " + Libraries + "...");
			Directory.CreateDirectory(Libraries);
			AreaInfo.SystemDevInfo.WriteDevicePrefix("FS", "Creating directory " + Modules + "...");
			Directory.CreateDirectory(Modules);
			AreaInfo.SystemDevInfo.WriteDevicePrefix("FS", "Creating directory " + Temp + "...");
			Directory.CreateDirectory(Temp);
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

		public static string Users = Root + @"\Users";
		public static string RootUser = Root + @"\root";
		public static string Guest = Users + @"\Guest";

		public static string Apps = Root + @"\Apps";
		public static string AppTemp = Apps + @"\Temp";
		public static string x86Apps = Apps + @"\x86";

		public static string System = Root + @"\System";
		public static string SystemData = System + @"\Data";
		public static string SystemLogs = System + @"\Logs";
		public static string Libraries = System + @"\Libraries";
		public static string Modules = System + @"\Modules";

		public static string Temp = Root + @"\Temp";

		public static string CurrentDirectory = Root;

	}
}
