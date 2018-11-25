using System;
using System.Collections.Generic;
using System.Text;
using Medli;

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
			Medli.Date.printDate();
		}
	}
}