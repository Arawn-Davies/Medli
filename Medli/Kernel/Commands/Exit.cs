using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Apps
{
	public class Exit : Command
	{
		public override string Name
		{
			get { return "exit"; }
		}

		public override string Summary
		{
			get { return "Closes the console."; }
		}

		public delegate void SimpleDelegate();

		private SimpleDelegate _exit;

		public Exit(SimpleDelegate exit)
		{
			_exit = exit;
		}

		public override void Execute(string param)
		{
			_exit();
		}

		public override void Help()
		{
			Console.WriteLine("exit");
			Console.WriteLine(" Closes the console.");
		}

	}
}