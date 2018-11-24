using System;
using Medli.Common;

namespace Medli.Apps
{
	public class Pause : Command
	{
		public override string Name
		{
			get { return "pause"; }
		}

		public override string Summary
		{
			get { return "Prompts the user to press any key."; }
		}

		public override void Execute(string param)
		{
			if (param != null)
			{
				Extensions.PressAnyKey(param);
			}
			else
			{
				Extensions.PressAnyKey();
			}
		}

	}
}