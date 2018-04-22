using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Medli.Apps
{
	public class Script : Command
	{
		public override string Name
		{
			get { return "run"; }
		}

		public override string Summary
		{
			get { return "Runs the specified script file. (ending in .mds)"; }
		}

		public override void Execute(string param)
		{
			try
			{
				if (param.EndsWith(".mds"))
				{
					string[] lines = File.ReadAllLines(param);
					foreach (string line in lines)
					{
						Kernel.CommandConsole.Parse(line);
					}
					Console.WriteLine("");
				}
				else
				{
					Console.WriteLine("Not a valid Medli Shellscript file.");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
