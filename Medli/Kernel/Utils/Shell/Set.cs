using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Apps
{
	public class Set : Command
	{
		public override string Name
		{
			get { return "$"; }
		}

		public override string Summary
		{
			get
			{
				return @"Sets the variable to contain the specified contents
$ [arg] [arg] (-u)
-u forces the updating of an argument";
			}
		}

		public override void Execute(string param)
		{
			if (param != "" && param != null)
			{
				if (param == "save")
				{
					EnvironmentVariables.SaveVars();
				}
				else if (param == "load")
				{
					EnvironmentVariables.ReadVars();
				}
				else if (param == "print")
				{
					EnvironmentVariables.PrintVars();
				}
				else
				{
					string[] args = param.Split(' ');
					if (param.EndsWith(" -u"))
					{
						EnvironmentVariables.Store(args[0], param.Substring(args[0].Length + 1), true);
					}
					else
					{
						EnvironmentVariables.Store(args[0], param.Substring(args[0].Length + 1), false);
					}
				}
			}
			
			
		}
	}
}
