using System;
using System.Collections.Generic;
using System.Text;
using Medli.Common;
using Medli.System;
using Sys = Cosmos.System;

namespace Medli.Apps
{
	public class Shutdown : Command
	{
		public override string Name
		{
			get { return "shutdown"; }
		}

		public override string Summary
		{
			get { return "Closes applications and powers down the system."; }
		}

		public override void Execute(string param)
		{
			usr_vars.SaveVars();
			Sys.Power.Shutdown();
		}
	}
}