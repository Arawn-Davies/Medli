using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AIC_Framework;
using Medli.Common;

namespace Medli.Applications
{
    class Cpview
    {
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
                    Shell.InvalidCommand(file, 2);
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
