using System;
using System.Collections.Generic;
using System.Text;
using MSys = Medli.System;
using System.IO;
using Medli.Common;

namespace Medli.Apps
{
	public class Copy : Command
	{
		public override string Name
		{
			get
			{
				return "copy";
			}
		}

		public override string Summary
		{
			get
			{
				return "Copies the specified file to the specified destination";
			}
		}

		public override void Execute(string param)
		{
			string[] args = param.Split(' ');
			if (File.Exists(args[0]))
			{
				MSys.FS.Copy(Paths.CurrentDirectory + args[0], args[1]);
			}
			else
			{
				Console.WriteLine("File does not exist");
			}
		}

	}
}