using System;
namespace Medli.Apps
{
	public class Clear : Command
	{
		public override string Name
		{
			get { return "cls"; }
		}

		public override string Summary
		{
			get { return "Clears the screen."; }
		}

		public override void Execute(string param)
		{
			Console.Clear();
		}

	}
}