using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Apps
{
	public class Time : Command
	{
		public override string Name
		{
			get { return "time"; }
		}

		public override string Summary
		{
			get { return "Displays the current time."; }
		}

		public override void Execute(string param)
		{
			Kernel.MedliTime.printTime();
		}
	}
}