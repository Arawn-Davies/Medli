using System;
using System.Collections.Generic;
using System.Text;
using MedliSystem = Medli.System;

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
			MedliSystem.FS.Copy(args[0], args[1]);
		}

	}
}