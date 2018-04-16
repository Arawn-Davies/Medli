using System;
using System.Collections.Generic;
using System.Text;

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

		public static string Root = "0:\\";

		public static string Users = Root + "Users\\";
		public static string RootUser = Users + "root\\";
		public static string Guest = Users + "Guest\\";

		public static string Apps = Root + "Apps\\";
		public static string AppTemp = Apps + "Temp\\";
		public static string x86Apps = Apps + "x86\\";

		public static string System = Root + "System\\";
		public static string SystemData = System + "Data\\";
		public static string Libraries = System + "Libraries\\";
		public static string Modules = System + "Modules\\";

		public static string Temp = Root + "Temp\\";

		public static string CurrentDirectory = Root;

	}
}
