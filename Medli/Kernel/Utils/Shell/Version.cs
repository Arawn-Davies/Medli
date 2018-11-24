using System;
using System.Collections.Generic;
using System.Text;
using Medli.Common;

namespace Medli.Apps
{
	public class Version : Command
	{
		public override string Name
		{
			get { return "version"; }
		}

		public override string Summary
		{
			get { return "Displays version information about Medli."; }
		}

		public override void Execute(string param)
		{
			if (param.CompareTo("") == 0 || param.CompareTo("ver") == 0)
			{
				DisplayVersion();
			}
			else
			{
				Help();
			}
		}

		private void DisplayVersion()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Medli Copyright 2018 Siaranite Solutions");
			Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("Medli v");
			Console.WriteLine(Kernel.KernelVersion);
			Console.WriteLine();
		}

		public override void Help()
		{
			Console.WriteLine("version [ver|dev]");
			Console.Write("  "); Console.WriteLine(Summary);
			Console.WriteLine();
			Console.WriteLine("  ver: Displays the version information.");
			Console.WriteLine("  dev: Displays information about the developers.");
		}
	}
}