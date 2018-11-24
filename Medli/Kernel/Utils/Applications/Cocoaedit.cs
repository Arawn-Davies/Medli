using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIC_Framework;
using System.IO;
using Medli.Common;
using Medli.System;

namespace Medli.Apps
{
    /// <summary>
    /// Cocoapad Editor class
    /// contains methods needed for the editor to function
    /// </summary>
    class Cpedit : Command
    {
		public override string Name
		{
			get
			{
				return "cpedit";
			}
		}

		public override string Summary
		{
			get
			{
				return "Launches the CocoaPad text editor";
			}
		}

		public override void Execute(string param)
		{
			Screen.SaveBuffer();
			Run(param);
			Screen.RestoreBuffer();
		}

		/// <summary>
		/// The current text inside the editor is stored in a string
		/// </summary>
		public static string text = "";
        /// <summary>
        /// Boolean to see whether Cocoapad is running or not
        /// </summary>
        public static bool running = true;

		private static void DrawScreen()
        {
            AConsole.Fill(ConsoleColor.Blue);
            Console.CursorTop = 0;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine(" Cocoapad Editor ");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.CursorTop = 3;
        }
        /// <summary>
        /// Main method for the Cocoapad edit
        /// Originally from Chocolate OS (pre-Medli) but won't rename this application
        /// </summary>
        /// <param name="file"></param>
        public static void Run(string file)
        {
            DrawScreen();
            Console.WriteLine("Cocoapad is a multi line text editor you can use to create many files.");
            Console.WriteLine("Once you have finished you can type '$SAVE' to save your file or '$END'");
            Console.WriteLine("to close without saving. '$RESET' can be used to start the file again from\nfresh, but use with caution!");
            Console.WriteLine("\nFilenames can currently only have 3 letter extensions but this will be fixed in the future.");
            //MEnvironment.PressAnyKey("Press any key to begin!");
            Console.WriteLine("Press any key to begin!");
            Console.ReadKey(true);
            DrawScreen();
            text = "";
            string line;
            var num = 1;
            while (running == true)
            {
                Console.Write(num + ": ");
                num = num + 1;
                line = Console.ReadLine();
                if (line == "$END")
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
                if (line == "$RESET")
                {
                    text = "";
                    DrawScreen();
                }
                if (line == "$SAVE")
                {
                    File.Create(Paths.CurrentDirectory + @"\" + file);
                    File.WriteAllText(Paths.CurrentDirectory + @"\" + file, text);
                    running = false;
                }
                text = text + (Environment.NewLine + line);
                if (Console.CursorTop == 24)
                {
                    DrawScreen();
                }
            }
            AConsole.Fill(ConsoleColor.Black);
        }
	}
}