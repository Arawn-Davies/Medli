using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Medli.Common
{
    class SysFiles
    {
		public static string Hostname = Paths.SystemData + Path.DirectorySeparatorChar + "host.sys";
		public static string DefaultLog = Paths.SystemLogs + Path.DirectorySeparatorChar + "sys.log";
		public static string EnvironmentVariables = Paths.System + Path.DirectorySeparatorChar + "vars.txt";

	}
}
