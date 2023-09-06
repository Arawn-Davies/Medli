using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Medli.System.Framework;
using Medli.Common;

namespace Medli.Apps
{
    class Cpview : Command
    {
		public override void Execute(string param)
		{
			if (param != "" && param != null)
			{
				ViewFile(param);
			}
		}
		public override string Name
		{
			get
			{
				return "cpview";
			}
		}
		public override string Summary
		{
			get
			{
				return "Prints the contents of a file onto the screen.";
			}
		}
		private static void DrawScreen()
        {
            AConsole.Fill(ConsoleColor.Blue);
            Console.CursorTop = 0;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine(" Cocoapad Viewer ");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.CursorTop = 3;
        }
        public static void ViewFile(string file)
        {
            DrawScreen();
            try
            {
                if (File.Exists(Paths.CurrentDirectory + @"\" + file))
                {
                    string[] lines = File.ReadAllLines(Paths.CurrentDirectory + @"\" + file);
                    foreach (string line in lines)
                    {
                        Console.WriteLine(line);
                    }
                }
                else if (!File.Exists(Paths.CurrentDirectory + @"\" + file))
                {
                    CommandConsole.InvalidCommand(file, 2);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Extensions.PressAnyKey();
        }
    }
}
