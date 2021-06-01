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
        /// </summary>
        /// <param name="color"></param>
        public static void ScreenSetup()
        {
            Console.BackgroundColor = DefaultColour;
            Console.Clear();
            //TODO
            Console.CursorTop = 0;
            Console.CursorLeft = 0;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                Medli Installer                                 ");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorTop = 7;
            Console.CursorLeft = 7;
        }

        /// <summary>
        /// Custom Write method for the installer console, sets the cursor position
        /// </summary>
        /// <param name="text"></param>
        private static void Write(string text)
        {
            Console.CursorLeft = 7;
            Console.Write(text);
            Console.CursorLeft = 0;
        }

        /// <summary>
        /// Custom WriteLine method for the installer console, sets the cursor position
        /// </summary>
        /// <param name="text"></param>
        public static void WriteLine(string text)
        {
            Write(text + "\n");
        }

        /// <summary>
        /// Console.ReadLine method with indent of 7, used by the installer
        /// </summary>
        /// <returns></returns>
        private static string ReadLine()
        {
            Console.CursorLeft = 7;
            Console.CursorTop += 1;
            string text = Console.ReadLine();
            Console.CursorLeft = 0;
            return text;
        }

        /// <summary>
        /// Redirect method of PressAnyKey, indented by 7
        /// </summary>
        /// <param name="text"></param>
        private static void PressAnyKey(string text)
        {
            Console.CursorLeft = 7;
            KernelExtensions.PressAnyKey(text);
            Console.CursorLeft = 7;
        }

        /// <summary>
        /// Same as above
        /// </summary>
        public static void PressAnyKey()
        {
            Console.CursorLeft = 7;
            KernelExtensions.PressAnyKey();
            Console.CursorLeft = 7;
        }

        /// <summary>
        /// The default colour for the installation console
        /// </summary>
        private static ConsoleColor DefaultColour = ConsoleColor.Blue;

    }
}
