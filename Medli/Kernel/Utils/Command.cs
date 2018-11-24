using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Apps
{
	//public class Commands
	//{
	//	public List<string> CommandList = new List<string>()
	//	{
	//		"help",
	//		"miv",
	//		"getram",
	//		"shutdown",
	//		"lspci",
	//		"panic",
	//		"copy",
	//		"move",
	//		"rm",
	//		"cview",
	//		"cedit",
	//		"dir",
	//		"cowsay",
	//		"mkdir",
	//		"cd",
	//		"echo",
	//		"devenv",
	//		"run",
	//		"cls",
	//		"launch",
	//		"reboot",
	//		""
	//	};
	//}
    public abstract class Command
    {
		public abstract string Name
		{
			get;
		}

		/// <summary>
		/// Gets the summary for the command.
		/// </summary>
		public abstract string Summary
		{
			get;
		}

		public abstract void Execute(string param);

		public virtual void Help()
		{
			Console.WriteLine(Name);
			Console.WriteLine("\t" + Summary);
		}

	}
}
