using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Apps
{
	public class Echo : Application
	{
		public Echo() : base()
		{
			Name = "Echo";
			CMD_Call = "echo";
			HelpText = "Prints text onto the console";
			Usage = "text";
		}

		public override void Main()
		{
			RunHelp();
		}

		public override void Main(string arg)
		{
			Console.WriteLine(arg);
		}

		public override void Main(string[] args)
		{
			Console.WriteLine(String.Join(" ", args));
		}
	}
}
