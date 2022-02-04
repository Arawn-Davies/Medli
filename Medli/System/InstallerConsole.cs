using System;
using System.Collections.Generic;
using System.Text;
using AConsole = AIC.Main.AConsole;
using AIC.Main.Extensions;

namespace Medli.System
{
    public partial class Installer
    {

        /// <summary>
        /// Initializes the Medli installer console screen by 
        /// setting the default colour, the title and cursor position
        ///         
        ///         ////////////////////////////////////////////////////////////////////////////////
        ///         ---Menu bar---
        /// </summary>
        /// <param name="is_login">if set to <c>true</c> [is login].</param>
        public static void ScreenSetup(bool is_login = false)
        {
            Console.BackgroundColor = DefaultColour;
            Console.Clear();
            //TODO
            Console.CursorTop = 0;
            Console.CursorLeft = 0;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.White;
            if (is_login == false)
            {
                Console.WriteLine("                                Medli Installer                                 ");
            }
            if (is_login == true)
            {
                Console.WriteLine("                                Welcome to Medli                                ");
            }
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorTop = 7;
            Console.CursorLeft = 7;
        }

        /// <summary>
        /// Custom Write method for the installer console, sets the cursor position
        /// </summary>
        /// <param name="text"></param>
        public static void Write(string text)
        {
            Console.CursorLeft = 7;
            Console.Write(text);
            Console.CursorLeft = 7;
        }

        /// <summary>
        /// Prints the suffix.
        /// </summary>
        /// <param name="text">The text.</param>
        public static void WriteSuffix(string text)
        {
            Console.Write(text + "\n");
            Console.CursorLeft = 7;
        }

        /// <summary>
        /// Prints the prefix.
        /// </summary>
        /// <param name="text">The text.</param>
        public static void WritePrefix(string text)
        {
            Console.CursorLeft = 7;
            Console.Write(text);
        }

        /// <summary>
        /// Custom WriteLine method for the installer console, sets the cursor position
        /// </summary>
        /// <param name="text"></param>
        public static void WriteLine(string text)
        {
            Write("\n");
            Console.CursorLeft = 7;
            Console.Write(text + "\n");
            Console.CursorLeft = 7;
        }

        /// <summary>
        /// Console.ReadLine method with indent of 7, used by the installer
        /// </summary>
        /// <returns></returns>
        public static string ReadLine()
        {
            Console.CursorLeft = 7;
            Console.CursorTop += 1;
            string text = Console.ReadLine();
            Console.CursorLeft = 7;
            text = text + "";
            return text;
        }

        /// <summary>
        /// Redirect method of PressAnyKey, indented by 7
        /// </summary>
        /// <param name="text"></param>
        public static void PressAnyKey(string text = "Press any key to continue...")
        {
            Console.CursorLeft = 7;
            WriteLine(text);
            Console.ReadKey(true);
            Console.CursorLeft = 7;
        }

        /// <summary>
        /// The default colour for the installation console
        /// </summary>
        private static ConsoleColor DefaultColour = ConsoleColor.Blue;

    }
}
