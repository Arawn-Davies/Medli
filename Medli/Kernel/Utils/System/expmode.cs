using System;
using System.Collections.Generic;
using System.Text;
using Medli.Common;
using Medli.System;
using Sys = Cosmos.System;
using AC = AIC.Main.AConsole;

namespace Medli.Apps
{
	public class ExperimentalMode : Command
	{
		public override string Name
		{
			get { return "expmode"; }
		}

		public override string Summary
		{
			get { return "Switches the kernel's experimental features on/off"; }
		}

		public override void Execute(string param)
		{
			if (param.ToLower().Contains("on"))
            {
                Kernel.ExperimentalMode = true;
            }
            else if (param.ToLower().Contains("off"))
            {
                Kernel.ExperimentalMode = false;
            }
            else
            {
                AC.Error.WriteLine("Use either On/Off. Keeping experimental features disabled.");
            }
		}
	}
}