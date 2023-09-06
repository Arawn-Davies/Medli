/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using System.Collections.Generic;

namespace Medli.System.Framework
{
    // For use instead of using System.Console directly, but still calls System.Console

    /// <summary>
    /// Medli Framework Console class
    /// </summary>
    public static partial class AConsole
    {
        private static int indent = 0;
        /// <summary>
        /// ForegroundColor Property
        /// </summary>
        public static ConsoleColor ForegroundColor { get { return AConsole.ForegroundColor; } set { AConsole.ForegroundColor = value; } }
        /// <summary>
        /// BackgroundColor Property
        /// </summary>
        public static ConsoleColor BackgroundColor { get { return AConsole.BackgroundColor; } set { AConsole.BackgroundColor = value; } }
        /// <summary>
        /// CursorTop Property
        /// </summary>
        public static int CursorTop { get { return Console.CursorTop; } set { AConsole.CursorTop = value; } }
        /// <summary>
        /// CursorLeft Property
        /// </summary>
        public static int CursorLeft { get { return Console.CursorLeft; } set { AConsole.CursorLeft = value; } }
        /// <summary>
        /// WindowWidth Property
        /// </summary>
        public static int WindowWidth { get { return Console.WindowWidth; } set { AConsole.WindowWidth = value; } }
        /// <summary>
        /// WindowHeight Property
        /// </summary>
        public static int WindowHeight { get { return AConsole.WindowHeight; } set { AConsole.WindowHeight = value; } }
        /// <summary>
        /// KeyAvailable Property
        /// </summary>
        public static bool KeyAvailable { get { return AConsole.KeyAvailable; } }
        /// <summary>
        /// Write Method
        /// </summary>
        /// <param name="chr">The char to write</param>
        /// <param name="color">The color of the text</param>
        /// <param name="xcenter">Horizontal centered?</param>
        /// <param name="ycenter">Vertical centered?</param>
        public static void Write(char chr = char.MinValue, ConsoleColor color = ConsoleColor.White, bool xcenter = false, bool ycenter = false)
        {
            Write(chr.ToString(), color, xcenter, ycenter);
        }
        /// <summary>
        /// Write Method
        /// </summary>
        /// <param name="chr">The char to write</param>
        /// <param name="color">The color of the text</param>
        /// <param name="xcenter">Horizontal centered?</param>
        /// <param name="ycenter">Vertical centered?</param>
        public static void WriteEx(char chr = char.MinValue, ConsoleColor color = ConsoleColor.White, ConsoleColor backColor = ConsoleColor.Black, bool xcenter = false, bool ycenter = false)
        {
            WriteEx(chr.ToString(), color, backColor, xcenter, ycenter);
        }
        /// <summary>
        /// Write Method
        /// </summary>
        /// <param name="text">The text to write</param>
        /// <param name="color">The color of the text</param>
        /// <param name="xcenter">Horizontal centered?</param>
        /// <param name="ycenter">Vertical centered?</param>
        public static void Write(string text = "", ConsoleColor color = ConsoleColor.White, bool xcenter = false, bool ycenter = false)
        {
            ConsoleColor originalColor = ForegroundColor;
            ForegroundColor = color;
            int X = CursorLeft + indent;
            if (xcenter) CursorLeft = ((WindowWidth / 2) - (text.Length / 2));
            int Y = CursorTop;
            if (ycenter) CursorTop = ((WindowHeight / 2) - 1);
            AConsole.Write(text);
            if (xcenter) CursorLeft = X;
            if (ycenter) CursorTop = Y;
            ForegroundColor = originalColor;
        }
        /// <summary>
        /// Write Method
        /// </summary>
        /// <param name="text">The text to write</param>
        /// <param name="color">The color of the text</param>
        /// <param name="backcolor">The background color of the text</param>
        /// <param name="xcenter">Horizontal centered?</param>
        /// <param name="ycenter">Vertical centered?</param>
        public static void WriteEx(string text = "", ConsoleColor ForeColor = ConsoleColor.White, ConsoleColor BackColor = ConsoleColor.Black, bool xcenter = false, bool ycenter = false)
        {
            ConsoleColor originalColor = ForegroundColor;
            ConsoleColor originalColor2 = BackgroundColor;
            ForegroundColor = ForeColor;
            BackgroundColor = BackColor;
            int X = CursorLeft + indent;
            if (xcenter) CursorLeft = ((WindowWidth / 2) - (text.Length / 2));
            int Y = CursorTop;
            if (ycenter) CursorTop = ((WindowHeight / 2) - 1);
            AConsole.Write(text);
            if (xcenter) CursorLeft = X;
            if (ycenter) CursorTop = Y;
            ForegroundColor = originalColor;
            BackgroundColor = originalColor2;
        }
        /// <summary>
        /// WriteLine Method
        /// </summary>
        /// <param name="text">The text to write</param>
        /// <param name="color">The color of the text</param>
        /// <param name="xcenter">Horizontal centered?</param>
        /// <param name="ycenter">Vertical centered?</param>
        public static void WriteLine(string text = "", ConsoleColor color = ConsoleColor.White, bool xcenter = false, bool ycenter = false)
        {
            ConsoleColor originalColor = ForegroundColor;
            ForegroundColor = color;
            int X = CursorLeft + indent;
            if (xcenter) CursorLeft = ((WindowWidth / 2) - (text.Length / 2));
            int Y = CursorTop;
            if (ycenter) CursorTop = ((WindowHeight / 2) - 1);
            AConsole.WriteLine(text);
            if (xcenter) CursorLeft = X;
            if (ycenter) CursorTop = Y;
            ForegroundColor = originalColor;
        }
        /// <summary>
        /// WriteLine Method
        /// </summary>
        /// <param name="text">The text to write</param>
        /// <param name="color">The color of the text</param>
        /// <param name="backcolor">The background color of the text</param>
        /// <param name="xcenter">Horizontal centered?</param>
        /// <param name="ycenter">Vertical centered?</param>
        public static void WriteLineEx(string text = "", ConsoleColor color = ConsoleColor.White, ConsoleColor backcolor = ConsoleColor.Black, bool xcenter = false, bool ycenter = false)
        {
            ConsoleColor originalColor = ForegroundColor;
            ConsoleColor originalColor2 = BackgroundColor;
            ForegroundColor = color;
            BackgroundColor = backcolor;
            int X = CursorLeft + indent;
            if (xcenter) CursorLeft = ((WindowWidth / 2) - (text.Length / 2));
            int Y = CursorTop;
            if (ycenter) CursorTop = ((WindowHeight / 2) - 1);
            AConsole.WriteLine(text);
            if (xcenter) CursorLeft = X;
            if (ycenter) CursorTop = Y;
            ForegroundColor = originalColor;
            BackgroundColor = originalColor2;
        }
        /// <summary>
        /// Fills the Console Background with a color
        /// </summary>
        /// <param name="color"></param>
        public static void Fill(ConsoleColor color)
        {
            ConsoleColor backup = Console.BackgroundColor;
            Console.BackgroundColor = color;
            Console.BackgroundColor = Console.BackgroundColor;
            Console.Clear();
            Console.BackgroundColor = backup;
            Console.CursorTop = 0;
        }
        /// <summary>
        /// Clear Method
        /// </summary>
        public static void Clear() { AConsole.Clear(); }
        /// <summary>
        /// Wipes the first two lines and writes a text (e.g. "YourOSName")
        /// at the horizontal center of the first line
        /// </summary>
        /// <param name="text">The text to write</param>
        /// <param name="color">The color of the text</param>
        public static void PrintAlias(string text, ConsoleColor color)
        {
            int curTop = CursorTop;
            int curLeft = CursorLeft;
            for (int i = 0; i < 2; i++)
            {
                CursorTop = i;
                for (int ix = 0; ix < WindowWidth; ix++) Write(" ");
            }
            CursorTop = 0;
            WriteLine(text, color, true);
            if (curTop >= 2) CursorTop = curTop;
            else CursorTop = 2;
            CursorLeft = curLeft;
        }
        /// <summary>
        /// Inserts a line break
        /// </summary>
        public static void NewLine() { WriteLine(); }
        /// <summary>
        /// System.Console.Read()-Implementation
        /// </summary>
        /// <returns></returns>
        public static int Read() { return Console.Read(); }
        /// <summary>
        /// System.Console.ReadKey()-Implementation
        /// </summary>
        /// <returns></returns>
        public static ConsoleKeyInfo ReadKey() { return Console.ReadKey(); }
        public static ConsoleKeyInfo ReadKey(bool print) { return Console.ReadKey(print); }
        /// <summary>
        /// System.Console.ReadLine()-Implementation
        /// </summary>
        /// <returns></returns>
        public static string ReadLine() { return Console.ReadLine(); }
        /// <summary>
        /// Sets a custom indent
        /// </summary>
        /// <param name="_indent"></param>
        public static void SetIndent(int _indent)
        {
            indent = _indent;
        }
    }
}
