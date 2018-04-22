using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Apps
{
	public class Date : Command
	{
		public override string Name
		{
			get { return "date"; }
		}

		public override string Summary
		{
			get { return "Displays the current date."; }
		}

		public override void Execute(string param)
		{
			Kernel.MedliTime.printDate();
		}
	}
}