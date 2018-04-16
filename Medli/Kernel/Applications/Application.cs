using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Apps
{
	public class Applications
	{
		public static Application help;
		public static Application echo;
		public static void Init()
		{
			help = new Help();
			echo = new Echo();
		}
	}
    public abstract class Application
    {
		public static List<Application> Applications = new List<Application>();

		public string Name
		{
			get
			{
				return Name;
			}
			set
			{
				Name = value;
			}
		}
		public string CMD_Call
		{
			get
			{
				return CMD_Call;
			}
			set
			{
				CMD_Call = value;
			}
		}

		public string HelpText;
		public string Usage;

		public void RunHelp()
		{
			Console.WriteLine(Name);
			Console.WriteLine("Syntax: " + CMD_Call + " <" + Usage + ">");
			Console.WriteLine(HelpText);
		}
		public abstract void Main();
		public abstract void Main(string arg);
		public abstract void Main(string[] args);
		public Application()
		{
			Applications.Add(this);
		}

    }
}
