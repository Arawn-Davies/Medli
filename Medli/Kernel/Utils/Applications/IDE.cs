using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIC.Main;
using System.IO;
using Medli.Common;
using Medli.System;

namespace Medli.Apps
{
	/// <summary>
	/// Cocoapad Development Environment class
	/// contains methods needed for the editor to function
	/// </summary>
	class IDE : Command
	{
        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public override string Name
		{
			get
			{
				return "devenv";
			}
		}

        /// <summary>
        /// Gets the summary for the command.
        /// </summary>
        public override string Summary
		{
			get
			{
				return "Launches the development environment";
			}
		}

        /// <summary>
        /// Executes the specified file in 'param'.
        /// </summary>
        /// <param name="param">The file path of the application file.</param>
        public override void Execute(string param)
		{
			if (param != "" && param.Length < 5 && param.EndsWith(".ma"))
			{
				Screen.SaveBuffer();
				Console.Clear();
				IDE.Run(param);
				Screen.RestoreBuffer();
			}
			else
			{
				Console.WriteLine("The IDE may only be used to create (.ma) Medli application files.");
			}
		}

        /// <summary>
        /// The application title
        /// </summary>
        public static string AppTitle;
        /// <summary>
        /// The application description
        /// </summary>
        public static string AppDesc;
		public static string AppAuthor;
		/// <summary>
		/// The current text inside the editor is stored in a string
		/// </summary>
		public static string text = "";
		/// <summary>
		/// Boolean to see whether CocoaEdit is running or not
		/// </summary>
		public static bool running = true;

        /// <summary>
        /// Draws the screen.
        /// </summary>
        private static void DrawScreen()
		{
			AConsole.Fill(ConsoleColor.Blue);
			Console.CursorTop = 0;
			Console.BackgroundColor = ConsoleColor.Gray;
			Console.WriteLine(" Medli Application IDE ");
			Console.BackgroundColor = ConsoleColor.Blue;
			Console.CursorTop = 3;
		}
        /// <summary>
        /// the application info.
        /// </summary>
        private static void AppInfo()
		{
			DrawScreen();
			Console.WriteLine("Enter the application title:");
			AppTitle = "Title=" + Console.ReadLine();
			Console.WriteLine("Enter the application description:");
			AppDesc = "Desc=" + Console.ReadLine();
			Console.WriteLine("Enter the application author:");
			AppAuthor = "Author=" + Console.ReadLine();
			DrawScreen();
			Console.WriteLine(AppTitle + "\n" + AppDesc + "\n" + AppAuthor);
			text = AppTitle + Environment.NewLine + AppDesc + Environment.NewLine + AppAuthor + Environment.NewLine;
		}

		/// <summary>
		/// Main method for the Cocoapad Development Environment
		/// Originally from Chocolate OS (proto-Medli)
		/// </summary>
		/// <param name="file"></param>
		public static void Run(string file)
		{
			DrawScreen();
			Console.WriteLine("The Medli Application IDE is an Integrated Development Environment");
			Console.WriteLine("users can use to develop applications for Medli.");
			Console.WriteLine("The same basic commands are used as Cocoapad Editor, but with a few");
			Console.WriteLine("extra commands to allow for the creation and running of apps.\n");
			Console.WriteLine("IDE commands:");
			Console.WriteLine("$END - Exits the IDE without saving");
			Console.WriteLine("$SAVE - Saves the current file");
			Console.WriteLine("$RESET - Resets the IDE and file to start again from fresh");
			Console.WriteLine("$RUN - Saves the file and executes it in the Medli Application Launcher");
			Extensions.PressAnyKey("Press any key to begin!");
			DrawScreen();
			text = "";
			AppInfo();
			string line;
			var num = 4;
			while (running == true)
			{
				Console.Write(num + ": ");
				num = num + 1;
				line = Console.ReadLine();
				if (line == "$END")
				{
					if (text != File.ReadAllText(file))
					{
						Console.WriteLine("Would you like to save first?");
						string notsaved = Console.ReadLine();
						if (notsaved == "y")
						{
							File.Create(Paths.CurrentDirectory + @"\" + file);
							File.WriteAllText(Paths.CurrentDirectory + @"\" + file, text);
							running = false;
						}
						else if (notsaved == "n")
						{
							running = false;
						}
					}
				}
				if (line == "$RESET")
				{
					text = "";
					AppInfo();
				}
				if (line == "$SAVE")
				{
					if (!text.EndsWith("EOF"))
					{
						text += "EOF";
					}
					File.WriteAllText(Paths.CurrentDirectory + @"\" + file, text);
					running = false;
					Extensions.PressAnyKey();
				}
				if (line == "$RUN")
				{
					if (!text.EndsWith("EOF"))
					{
						text += "EOF";
					}
					File.WriteAllText(Paths.CurrentDirectory + @"\" + file, text);
					running = false;
					Console.Clear();
					AppLauncher.PreExecute(file);
					Extensions.PressAnyKey();
				}
				text += (Environment.NewLine + line);
				if (Console.CursorTop == 24)
				{
					DrawScreen();
				}
			}
			AConsole.Fill(ConsoleColor.Black);
		}


	}
}