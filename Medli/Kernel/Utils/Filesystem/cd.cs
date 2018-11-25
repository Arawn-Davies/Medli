using System;
using System.Collections.Generic;
using System.Text;
using MedliSystem = Medli.System;
using System.IO;
using Medli.System;

namespace Medli.Apps
{
	public class cd : Command
	{
		public override string Name
		{
			get
			{
				return "cd";
			}
		}

		public override string Summary
		{
			get
			{
				return @"Changes to the specified directoy";
			}
		}

		public override void Execute(string param)
		{
			if (param == "..")
			{
				FS.CDP();
			}
			else
			{
				FS.cd(param);
			}
		}

	}
}