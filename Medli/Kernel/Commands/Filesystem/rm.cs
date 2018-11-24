using System;
using System.Collections.Generic;
using System.Text;
using MedliSystem = Medli.System;
using System.IO;
using Medli.System;

namespace Medli.Apps
{
	public class rm : Command
	{
		public override string Name
		{
			get
			{
				return "rm";
			}
		}

		public override string Summary
		{
			get
			{
				return @"Removes the specified file/directory
Directory: rm -r [arg]
File:      rm [arg]";
			}
		}

		public override void Execute(string param)
		{
			string[] args = param.Split(' ');
			if (args[0] == "-r")
			{
				FS.del(args[1], true);
			}
			else
			{
				FS.del(args[0], false);
			}
		}

	}
}