using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Apps
{
    class ColorChanger : Command
    {
		public override string Name
		{
			get
			{
				return "colour";
			}
		}
		public override string Summary
		{
			get
			{
				return "Changes the back/foreground colour of the terminal";
			}
		}
		public override void Execute(string param)
		{
			
		}
		enum ConsoleColors
        {
            black = ConsoleColor.Black,
            white = ConsoleColor.White,

            darkred = ConsoleColor.DarkRed,
            darkblue = ConsoleColor.DarkBlue,
            darkcyan = ConsoleColor.DarkCyan,
            darkmagenta = ConsoleColor.DarkMagenta,
            darkgreen = ConsoleColor.DarkGreen,
            darkgray = ConsoleColor.DarkGray,
            darkyellow = ConsoleColor.DarkYellow,

            red = ConsoleColor.Red,
            blue = ConsoleColor.Blue,
            green = ConsoleColor.Green,

            yellow = ConsoleColor.Yellow,
            cyan = ConsoleColor.Cyan,
            magenta = ConsoleColor.Magenta,
            gray = ConsoleColor.Gray,
        }
        public static void ChangeBGC(string color)
        {
            #region BGColorChange
            if (color == "1") {
                Console.BackgroundColor = ConsoleColor.DarkRed; }
            else if (color == "2") {
                Console.BackgroundColor = ConsoleColor.DarkBlue; }
            else if (color == "3") {
                Console.BackgroundColor = ConsoleColor.DarkCyan; }
            else if (color == "4") {
                Console.BackgroundColor = ConsoleColor.DarkMagenta; }
            else if (color == "5") {
                Console.BackgroundColor = ConsoleColor.DarkGreen; }
            else if (color == "6") {
                Console.BackgroundColor = ConsoleColor.DarkGray; }
            else if (color == "7") {
                Console.BackgroundColor = ConsoleColor.Red; }
            else if (color == "8") {
                Console.BackgroundColor = ConsoleColor.Blue; }
            else if (color == "9") {
                Console.BackgroundColor = ConsoleColor.Cyan; }
            else if (color == "10") {
                Console.BackgroundColor = ConsoleColor.Magenta; }
            else if (color == "11") {
                Console.BackgroundColor = ConsoleColor.Green; }
            else if (color == "12") {
                Console.BackgroundColor = ConsoleColor.Gray; }
            else if (color == "13") {
                Console.BackgroundColor = ConsoleColor.Yellow; }
            else if (color == "14") {
                Console.BackgroundColor = ConsoleColor.DarkYellow; }
            else if (color == "15") {
                Console.BackgroundColor = ConsoleColor.Black; }
            else if (color == "0") {
                Console.BackgroundColor = ConsoleColor.White; }
            #endregion
            else
            {
                Console.WriteLine("Invalid colour, valid options are 0 - 15");

            }
        }
        public static void ChangeFGC(string color)
        {
            #region FGColorChange
            if (color == "a") {
                Console.ForegroundColor = ConsoleColor.DarkRed; }
            else if (color == "b") {
                Console.ForegroundColor = ConsoleColor.DarkBlue; }
            else if (color == "c") {
                Console.ForegroundColor = ConsoleColor.DarkCyan; }
            else if (color == "d") {
                Console.ForegroundColor = ConsoleColor.DarkMagenta; }
            else if (color == "e") {
                Console.ForegroundColor = ConsoleColor.DarkGreen; }
            else if (color == "f") {
                Console.ForegroundColor = ConsoleColor.DarkGray; }
            else if (color == "g") {
                Console.ForegroundColor = ConsoleColor.Red; }
            else if (color == "h") {
                Console.ForegroundColor = ConsoleColor.Blue; }
            else if (color == "i") {
                Console.ForegroundColor = ConsoleColor.Cyan; }
            else if (color == "j") {
                Console.ForegroundColor = ConsoleColor.Magenta; }
            else if (color == "k") {
                Console.ForegroundColor = ConsoleColor.Green; }
            else if (color == "l") {
                Console.ForegroundColor = ConsoleColor.Gray; }
            else if (color == "m") {
                Console.ForegroundColor = ConsoleColor.Yellow; }
            else if (color == "n") {
                Console.ForegroundColor = ConsoleColor.DarkYellow; }
            else if (color == "o") {
                Console.ForegroundColor = ConsoleColor.Black; }
            else if (color == "p") {
                Console.ForegroundColor = ConsoleColor.White; }
            #endregion
            else
            {
                Console.WriteLine("Invalid colour, valid options are a - p");

            }
        }
    }
}
