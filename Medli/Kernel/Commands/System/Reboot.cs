using System;
using System.Collections.Generic;
using System.Text;
using Medli.Common;
using Medli.System;
using Sys = Cosmos.System;

namespace Medli.Apps
{
	public class Reboot : Command
	{
		public override string Name
		{
			get { return "reboot"; }
		}

		public override string Summary
		{
			get { return "Closes applications and reboots the system."; }
		}

		public override void Execute(string param)
		{
			usr_vars.SaveVars();
			Sys.Power.Reboot();
		}
	}
}