using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Apps
{
	public class Echo : Command
	{
		public override string Name
		{
			get { return "echo"; }
		}

		public override string Summary
		{
			get
			{
				return @"Duplicates text you enter to the console.
cd $[arg] : Returns the contents of the speciied variable";
			}
		}

		public override void Execute(string param)
		{
			if (param.StartsWith("$"))
			{
				Console.WriteLine(usr_vars.Retrieve(param.Substring(1)));
			}
			else
			{
				Console.WriteLine(param);
			}
		}

		public override void Help()
		{
			Console.WriteLine("echo [text]");
			Console.WriteLine("  Duplicates text you enter to the console.");
			Console.WriteLine("  [text]: The text to duplicate.");
		}

	}
}
