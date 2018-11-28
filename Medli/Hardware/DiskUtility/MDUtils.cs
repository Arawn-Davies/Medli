using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace MDFS
{
    class MDUtils
    {
		/// <summary>
		/// Writes a character on the screen
		/// </summary>
		/// <param name="ch">The character to write</param>
		/// <param name="textcolor">The foreground color you want</param>
		/// <param name="backcolor">The background color you want</param>
		public static void Write(Char ch, ConsoleColor textcolor, ConsoleColor backcolor)
		{
			ConsoleColor fc = Console.ForegroundColor;
			ConsoleColor bc = Console.BackgroundColor;
			Console.ForegroundColor = textcolor;
			Console.BackgroundColor = backcolor;
			Console.Write(ch);
			Console.ForegroundColor = fc;
			Console.BackgroundColor = bc;
		}

		/// <summary>
		/// Writes a string on the screen
		/// </summary>
		/// <param name="str">The string to write</param>
		/// <param name="textcolor">The foreground color you want</param>
		/// <param name="backcolor">The background color you want</param>
		public static void Write(String str, ConsoleColor textcolor, ConsoleColor backcolor)
		{
			int i = 0;
			Char[] chs = str.ToCharArray();
			for (i = 0; i < chs.Length; i++)
			{
				Write(chs[i], textcolor, backcolor);
			}
		}

		/// <summary>
		/// Writes a string on the screen with default backcolor
		/// </summary>
		/// <param name="str">The string to write</param>
		/// <param name="textcolor">The foreground color you want</param>
		public static void Write(String str, ConsoleColor textcolor)
		{
			Write(str, textcolor, ConsoleColor.Black);
		}

		/// <summary>
		/// Writes a string on the screen with default backcolor and forecolor
		/// </summary>
		/// <param name="str">The string to write</param>
		public static void Write(String str)
		{
			Write(str, ConsoleColor.White, ConsoleColor.Black);
		}

		/// <summary>
		/// Writes a string on the screen followed by a newLine
		/// </summary>
		/// <param name="str">The string to write</param>
		/// <param name="textcolor">The foreground color you want</param>
		/// <param name="backcolor">The background color you want</param>
		public static void WriteLine(String str, ConsoleColor textcolor, ConsoleColor backcolor)
		{
			ConsoleColor fc = Console.ForegroundColor;
			ConsoleColor bc = Console.BackgroundColor;
			Console.ForegroundColor = textcolor;
			Console.BackgroundColor = backcolor;
			Console.WriteLine(str);
			Console.ForegroundColor = fc;
			Console.BackgroundColor = bc;
		}

		/// <summary>
		/// Writes a string on the screen followed by a newLine with default backcolor
		/// </summary>
		/// <param name="str">The string to write</param>
		/// <param name="textcolor">The foreground color you want</param>
		public static void WriteLine(String str, ConsoleColor textcolor)
		{
			WriteLine(str, textcolor, ConsoleColor.Black);
		}

		/// <summary>
		/// Writes a string on the screen followed by a newLine with default backcolor and forecolor
		/// </summary>
		/// <param name="str">The string to write</param>
		public static void WriteLine(String str)
		{
			WriteLine(str, ConsoleColor.White, ConsoleColor.Black);
		}

		/// <summary>
		/// Writes a string on the last line of the screeen without creating a new one
		/// </summary>
		/// <param name="str">The string to write</param>
		public static void WriteOnLastLine(String str)
		{
			Cosmos.System.Global.Console.Y--;
			String s = str;
			for (int i = 0; i < Cosmos.System.Global.Console.Cols - str.Length - 1; i++)
			{
				s += "\0";
			}
			WriteLine(s);
		}

        /// <summary>
		/// Writes a string on the last line of the screeen without creating a new one
		/// </summary>
		/// <param name="str">The string to write</param>
		public static void WriteOnLastLine(Char chr)
        {
            String str = chr + "";
            WriteOnLastLine(str);
        }

        /// <summary>
        /// Reads a single key from the input
        /// </summary>
        public static ConsoleKeyInfo ReadAKey()
		{
			ConsoleKeyInfo k = Console.ReadKey(true);
			if (k.Modifiers == ConsoleModifiers.Alt || k.Modifiers == ConsoleModifiers.Control)
			{
				return ReadAKey();
			}
			return k;
		}

		/// <summary>
		/// Reads a line from the input
		/// </summary>
		public static String ReadLine()
		{
			return ReadLine(false);
		}

		/// <summary>
		/// Reads a single key from the input intercepting the rewriting or not (Password purposes)
		/// </summary>
		/// <param name="intercept">Intercept or not the readen line</param>
		public static String ReadLine(bool intercept)
		{
			String ret = "";
			ConsoleKeyInfo read;
			int startX = Sys.Global.Console.X;
			do
			{
				read = ReadAKey();
				if (read.Key != ConsoleKey.Enter && read.Key != ConsoleKey.Backspace)
				{
					if (!intercept)
					{
						Write(read.KeyChar, ConsoleColor.White, ConsoleColor.Black);
					}
					ret += read.KeyChar;
				}
				else if (read.Key == ConsoleKey.Backspace)
				{
					if (ret.Length > 0)
					{
						ret = ret.Substring(0, ret.Length - 1);
					}
					if (Sys.Global.Console.X > startX)
					{
						Sys.Global.Console.X--;
						Write(' ', ConsoleColor.White, ConsoleColor.Black);
						Sys.Global.Console.X--;
					}
				}
				else
				{
					WriteLine("");
				}
			} while (read.Key != ConsoleKey.Enter);
			return ret;
		}

		/// <summary>
		/// Reads a line from the input prepending a custom string
		/// </summary>
		/// <param name="str">String to show</param>
		public static string ReadLine(String str)
		{
			Write(str);
			return ReadLine();
		}

		/// <summary>
		/// Returns a bool that checks if the last line of the screen is empty or not
		/// </summary>
		public static bool LastLineIsEmpty()
		{
			int cur = Sys.Global.Console.X;
			if (cur != 0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		/// <summary>
		/// Ask the user if continue or not with the operation and returns a boolean
		/// </summary>
		public static bool Continue()
		{
			Write("Continue? Y/N (yes/no): ");
			ConsoleKeyInfo inf;
			do
			{
				inf = ReadAKey();
			}
			while (inf.Key != ConsoleKey.N && inf.Key != ConsoleKey.Y);
			WriteLine(inf.KeyChar.ToString());
			if (inf.Key == ConsoleKey.N)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		/// <summary>
		/// Writes on the screen a green line with text: "Done."
		/// </summary>
		public static void Done()
		{
			WriteLine("Done!", ConsoleColor.Green);
		}

		/// <summary>
		/// Writes a custom error on the screen in red colour
		/// </summary>
		/// <param name="str">The specified error string</param>
		public static void Error(String str)
		{
			if (!LastLineIsEmpty())
			{
				WriteLine("");
			}
			WriteLine(str, ConsoleColor.Red);
		}

		/// <summary>
		/// Writes custom message in green colour
		/// </summary>
		/// <param name="str">The specified message</param>
		public static void NoError(String str)
		{
			if (!LastLineIsEmpty())
			{
				WriteLine("");
			}
			WriteLine(str, ConsoleColor.Green);
		}
	}
}
