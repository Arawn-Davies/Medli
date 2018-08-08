using System;
using System.Collections.Generic;
using System.Text;
using Medli.Common;
using Medli.System;

namespace Medli.Apps
{
	public class LSPCI : Command
	{
		public override string Name
		{
			get { return "lspci"; }
		}

		public override string Summary
		{
			get { return "Lists pci devices."; }
		}

		public override void Execute(string param)
		{
			SystemFunctions.lspci();
		}
	}
}