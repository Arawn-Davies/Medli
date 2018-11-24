using System;
using System.Collections.Generic;
using System.Text;
using MedliSystem = Medli.System;
using System.IO;
using Medli.System;

namespace Medli.Apps
{
	public class mkdir : Command
	{
		public override string Name
		{
			get
			{
				return "mkdir";
			}
		}

		public override string Summary
		{
			get
			{
				return "Makes a directory using the specified name";
			}
		}

		public override void Execute(string param)
		{
			FS.Makedir(Directory.GetCurrentDirectory() + param);
		}

	}
}