using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Medli.Common
{
    class Paths
    {
		public static List<string> OSDirectories = new List<string>()
		{
			Users,
			RootUser,
			Guest,
			Apps,
			AppTemp,
			x86Apps,
			System,
			SystemData,
			Libraries,
			Modules,
			Temp,
		};

		public static string Root = @"0:\";

		public static string Users = Root + "Users";
		public static string RootUser = Users + Path.DirectorySeparatorChar + "root";
		public static string Guest = Users + Path.DirectorySeparatorChar +  "Guest";

		public static string Apps = Root + "Apps";
		public static string AppTemp = Apps + Path.DirectorySeparatorChar + "Temp";
		public static string x86Apps = Apps + Path.DirectorySeparatorChar + "x86";

		public static string System = Root + "System";
		public static string SystemData = System + Path.DirectorySeparatorChar + "Data";
		public static string Libraries = System + Path.DirectorySeparatorChar + "Libraries";
		public static string Modules = System + Path.DirectorySeparatorChar + "Modules";

		public static string Temp = Root + "Temp";

		public static string CurrentDirectory = Root;

	}
}
