using System;
using System.Collections.Generic;
using System.Text;
using MedliSystem = Medli.System;

namespace Medli.Apps
{
	public class Dir : Command
	{
		public override string Name
		{
			get
			{
				return "dir";
			}
		}

		public override string Summary
		{
			get
			{
				return "Lists the files in the current directory.";
			}
		}

		public override void Execute(string param)
		{
			MedliSystem.FS.Dir();
		}

	}
}