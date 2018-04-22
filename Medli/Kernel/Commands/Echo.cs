using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Apps
{
	public class EchoCommand : Command
	{
		public override string Name
		{
			get { return "echo"; }
		}

		public override string Summary
		{
			get { return "Duplicates text you enter to the console."; }
		}

		public override void Execute(string param)
		{
			Console.WriteLine(param);
			Console.WriteLine();
		}

		public override void Help()
		{
			Console.WriteLine("echo [text]");
			Console.WriteLine("  Duplicates text you enter to the console.");
			Console.WriteLine("  [text]: The text to duplicate.");
		}

	}
}
