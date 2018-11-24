using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIC_Framework;
using System.IO;
using Medli.Common;

namespace Medli.Apps
{
    /// <summary>
    /// Cocoapad Editor class
    /// contains methods needed for the editor to function
    /// </summary>
    class MIDE : Command
    {
		public override string Name
		{
			get
			{
				return "devenv";
			}
		}

		public override string Summary
		{
			get
			{
				return "";
			}
		}

		public override void Execute(string param)
		{
			throw new NotImplementedException();
		}

		public static string AppTitle;
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

		private static void DrawScreen()
        {
            AConsole.Fill(ConsoleColor.Blue);
            Console.CursorTop = 0;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine(" Medli Application IDE ");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.CursorTop = 3;
        }
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
        /// Main method for the Cocoapad edit
        /// Originally from Chocolate OS (pre-Medli) but won't rename this application
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