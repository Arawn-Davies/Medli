using System;
using System.Collections.Generic;
using System.Text;
using MedliSystem = Medli.System;

namespace Medli.Apps
{
	public class Move : Command
	{
		public override string Name
		{
			get
			{
				return "move";
			}
		}

		public override string Summary
		{
			get
			{
				return "Moves the specified file to the specified directory\nmove [src] [dest]";
			}
		}

		public override void Execute(string param)
		{
			string[] args = param.Split(' ');
			MedliSystem.FS.mv(args[0], args[1]);
		}

	}
}