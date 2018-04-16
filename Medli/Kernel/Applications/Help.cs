using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Apps
{
	public class Help : Application
	{
		public Help() : base()
		{
			Name = "Help";
			CMD_Call = "help";
			HelpText = "Views help for using the Medli operating system and applications";
			Usage = "command";
		}

		public override void Main()
		{
			Console.WriteLine("Not yet implemented!");
		}

		public override void Main(string arg)
		{
			Console.WriteLine("Not yet implemented!");
		}

		public override void Main(string[] args)
		{
			Console.WriteLine("Not yet implemented!");
		}
	}
}
