using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medli.Applications;

namespace Medli.Apps
{
	/// <summary>
	/// Help class, called by mshell
	/// </summary>
	public class Help
	{
		/*
         * A very primitive paging system (not RAM paging - manpages etc...)
         * Tidied up a bit, might avoid the text-spilling-onto-next-line issue but certainly doesn't eliminate it
         */
		/// <summary>
		/// Creates multiple pages of 'help' so its not listed out in one go,
		/// makes for easier reading of available commands
		/// </summary>
		/// <param name="pageno"></param>
		/// 
		public static void Run(string args)
		{
			if (args == "1" || args == "apps")
			{
				Pages(1);
			}
			else if (args == "2" || args == "fs")
			{
				Pages(2);
			}
			else if (args == "3" || args == "sys")
			{
				Pages(3);
			}
			else if (args == "full")
			{
				Full();
			}
			else if (args == "specific")
			{
				Console.WriteLine("Enter specific command:");
				string topic = Console.ReadLine();
				Specific(topic);
			}
		}
		public static void SysHelp()
		{
			Console.WriteLine("panic            Starts a harmless kernel panic");
		}
		public static void AppHelp()
		{
			Console.WriteLine("cview <file>     Prints the contents of a file onto the screen.");
			Console.WriteLine("cedit <file>     Launches the text editor");
			Console.WriteLine("miv              " + "Launches the MIV advanced text editor");
			Console.WriteLine("echo             Prints text to the console");
			Console.WriteLine("shell2           Launches the new shell (W.I.P)");
			Console.WriteLine("run <file>       Executes the script passed as <file>");
			Console.WriteLine("devenv <file>    Launches the Medli Application IDE");
			Console.WriteLine("launch <file>    Launches the application ending in .ma");
			Console.WriteLine("cowsay <msg>     Launches the cowsay application");
		}
		public static void FSHelp()
		{
			Console.WriteLine("echo             Prints text onto the console");
			Console.WriteLine("mkdir            Makes a directory");
			Console.WriteLine("dir              Prints a list of directories in the current directory");
			Console.WriteLine("cd               Changes the current directory");
			Console.WriteLine("mv <src> <dest>  Moves the source file to the destination");
			Console.WriteLine("clear            Clears the screen");
			Console.WriteLine("getVol           Displays a list of detected disk volumes");
		}
		public static void Pages(int pageno)
		{
			if (pageno == 1)
			{
				Console.WriteLine("Help page: " + pageno);
				AppHelp();
				Console.WriteLine("Press any key...");
				Console.ReadKey(true);
				Console.WriteLine(" ");
			}
			else if (pageno == 2)
			{
				Console.WriteLine("Help page: " + pageno);
				FSHelp();
				Console.WriteLine("Press any key...");
				Console.ReadKey(true);
				Console.WriteLine(" ");
			}
			else if (pageno == 3)
			{
				Console.WriteLine("Help page: " + pageno);
				SysHelp();
				Console.WriteLine("Press any key...");
				Console.ReadKey(true);
				Console.WriteLine(" ");
			}
			else
			{
				Console.Clear();
				Full();
			}
		}
		/// <summary>
		/// prints out all help pages after each other
		/// </summary>
		public static void Full()
		{
			Pages(1);
			Pages(2);
			Pages(3);
		}
		/// <summary>
		/// Gets the detailed help for a specific command given to the method
		/// </summary>
		/// <param name="topic"></param>
		public static void Specific(string topic)
		{
			if (topic == "panic" || topic == "panic critical")
			{
				Console.WriteLine("panic\tStarts a harmless kernel panic");
				Console.WriteLine("panic critical\tStarts a critical yet harmless kernel panic");
			}
			else if (topic == "cv")
			{
				Console.WriteLine("cv <file>\t");
			}
			else if (topic == "cp")
			{
				Console.WriteLine("cp <file>\t");
			}
			else if (topic == "getram")
			{
				Console.WriteLine("getram           Gets the amount of system RAM in megabytes");
			}
			else if (topic == "")
			{
				Full();
			}
			else
			{
				Console.WriteLine(topic + ": Not a valid command.");
				Full();
			}
		}
	}
}
