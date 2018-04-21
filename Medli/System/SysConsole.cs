using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Text;

namespace Medli.System
{
	public class SysConsole
	{
		private const byte LineFeed = (byte)'\n';
		private const byte CarriageReturn = (byte)'\r';
		private const byte Tab = (byte)'\t';
		private const byte Space = (byte)' ';

		protected int mX = 0;
		public int X
		{
			get { return mX; }
			set
			{
				mX = value;
				UpdateCursor();
			}
		}

		protected int mY = 0;
		public int Y
		{
			get { return mY; }
			set
			{
				mY = value;
				UpdateCursor();
			}
		}

		public int Cols
		{
			get { return mText.Cols; }
		}

		public int Rows
		{
			get { return mText.Rows; }
		}

		protected Hardware.TextScreenBase mText;

		public SysConsole(Hardware.TextScreenBase textScreen)
		{
			if (textScreen == null)
			{
				mText = new Hardware.TextScreen();
			}
			else
			{
				mText = textScreen;
			}
		}

		public void Clear()
		{
			mText.Clear();
			mX = 0;
			mY = 0;
			UpdateCursor();
		}

		//TODO: This is slow, batch it and only do it at end of updates
		protected void UpdateCursor()
		{
			mText.SetCursorPos(mX, mY);
		}

		private void DoLineFeed()
		{
			mY++;
			mX = 0;
			if (mY == mText.Rows)
			{
				mText.ScrollUp();
				mY--;
			}
			UpdateCursor();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DoCarriageReturn()
		{
			mX = 0;
			UpdateCursor();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DoTab()
		{
			Write(Space);
			Write(Space);
			Write(Space);
			Write(Space);
		}

		public void Write(byte aChar)
		{
			mText[mX, mY] = aChar;
			mX++;
			if (mX == mText.Cols)
			{
				DoLineFeed();
			}
			UpdateCursor();
		}

		//TODO: Optimize this
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Write(byte[] aText)
		{
			if (aText == null)
			{
				return;
			}

			for (int i = 0; i < aText.Length; i++)
			{
				switch (aText[i])
				{
					case LineFeed:
						DoLineFeed();
						break;

					case CarriageReturn:
						DoCarriageReturn();
						break;

					case Tab:
						DoTab();
						break;

					/* Normal characters, simply write them */
					default:
						Write(aText[i]);
						break;
				}
			}
		}

		public ConsoleColor Foreground
		{
			get { return (ConsoleColor)(mText.GetColor() ^ (byte)((byte)Background << 4)); }
			set { mText.SetColors(value, Background); }
		}
		public ConsoleColor Background
		{
			get { return (ConsoleColor)(mText.GetColor() >> 4); }
			set { mText.SetColors(Foreground, value); }
		}

		public int CursorSize
		{
			get { return mText.GetCursorSize(); }
			set
			{
				// Value should be a percentage from [1, 100].
				if (value < 1 || value > 100)
					throw new ArgumentOutOfRangeException("value", value, "CursorSize value " + value + " out of range (1 - 100)");

				mText.SetCursorSize(value);
			}
		}

		public bool CursorVisible
		{
			get { return mText.GetCursorVisible(); }
			set { mText.SetCursorVisible(value); }
		}


		#region Write

		public static void Write(bool aBool)
		{
			Write(aBool.ToString());
		}

		/*
         * A .Net character can be effectevily more can one byte so calling the low level Console.Write() will be wrong as
         * it accepts only bytes, we need to convert it using the specified OutputEncoding but to do this we have to convert
         * it ToString first
         */
		public static void Write(char aChar) => Write(aChar.ToString());

		public static void Write(char[] aBuffer) => Write(aBuffer, 0, aBuffer.Length);

		/* Decimal type is not working yet... */
		//public static void Write(decimal aDecimal) => Write(aDecimal.ToString());

		public static void Write(double aDouble) => Write(aDouble.ToString());

		public static void Write(float aFloat) => Write(aFloat.ToString());

		public static void Write(int aInt) => Write(aInt.ToString());

		public static void Write(long aLong) => Write(aLong.ToString());

		/* Correct behaviour printing null should not throw NRE or do nothing but should print an empty string */
		public static void Write(object value) => Write((value ?? String.Empty));

		public static void Write(string aText)
		{
			var xConsole = GetConsole();
			if (xConsole == null)
			{
				// for now:
				return;
			}

			byte[] aTextEncoded = ConsoleOutputEncoding.GetBytes(aText);
			GetConsole().Write(aTextEncoded);
		}

		public static void Write(uint aInt) => Write(aInt.ToString());

		public static void Write(ulong aLong) => Write(aLong.ToString());

		public static void Write(string format, object arg0) => Write(String.Format(format, arg0));

		public static void Write(string format, object arg0, object arg1) => Write(String.Format(format, arg0, arg1));

		public static void Write(string format, object arg0, object arg1, object arg2) => Write(String.Format(format, arg0, arg1, arg2));

		public static void Write(string format, object arg0, object arg1, object arg2, object arg3) => Write(String.Format(format, arg0, arg1, arg2, arg3));

		public static void Write(string format, params object[] arg) => Write(String.Format(format, arg));

		public static void Write(char[] aBuffer, int aIndex, int aCount)
		{
			if (aBuffer == null)
			{
				throw new ArgumentNullException("aBuffer");
			}
			if (aIndex < 0)
			{
				throw new ArgumentOutOfRangeException("aIndex");
			}
			if (aCount < 0)
			{
				throw new ArgumentOutOfRangeException("aCount");
			}
			if ((aBuffer.Length - aIndex) < aCount)
			{
				throw new ArgumentException();
			}
			for (int i = 0; i < aCount; i++)
			{
				Write(aBuffer[aIndex + i]);
			}
		}

		//You'd expect this to be on System.Console wouldn't you? Well, it ain't so we just rely on Write(object value)
		//public static void Write(byte aByte) {
		//    Write(aByte.ToString());
		//}

		#endregion

		#region WriteLine

		public static void WriteLine() => Write(Environment.NewLine);

		public static void WriteLine(bool aBool) => WriteLine(aBool.ToString());

		public static void WriteLine(char aChar) => WriteLine(aChar.ToString());

		public static void WriteLine(char[] aBuffer) => WriteLine(new String(aBuffer));

		/* Decimal type is not working yet... */
		//public static void WriteLine(decimal aDecimal) => WriteLine(aDecimal.ToString());

		public static void WriteLine(double aDouble) => WriteLine(aDouble.ToString());

		public static void WriteLine(float aFloat) => WriteLine(aFloat.ToString());

		public static void WriteLine(int aInt) => WriteLine(aInt.ToString());

		public static void WriteLine(long aLong) => WriteLine(aLong.ToString());

		/* Correct behaviour printing null should not throw NRE or do nothing but should print an empty line */
		public static void WriteLine(object value) => Write((value ?? String.Empty) + Environment.NewLine);

		public static void WriteLine(string aText) => Write(aText + Environment.NewLine);

		public static void WriteLine(uint aInt) => WriteLine(aInt.ToString());

		public static void WriteLine(ulong aLong) => WriteLine(aLong.ToString());

		public static void WriteLine(string format, object arg0) => WriteLine(String.Format(format, arg0));

		public static void WriteLine(string format, object arg0, object arg1) => WriteLine(String.Format(format, arg0, arg1));

		public static void WriteLine(string format, object arg0, object arg1, object arg2) => WriteLine(String.Format(format, arg0, arg1, arg2));

		public static void WriteLine(string format, object arg0, object arg1, object arg2, object arg3) => WriteLine(String.Format(format, arg0, arg1, arg2, arg3));

		public static void WriteLine(string format, params object[] arg) => WriteLine(String.Format(format, arg));

		public static void WriteLine(char[] aBuffer, int aIndex, int aCount)
		{
			Write(aBuffer, aIndex, aCount);
			WriteLine();
		}


		private static ConsoleColor mForeground = ConsoleColor.White;
		private static ConsoleColor mBackground = ConsoleColor.Black;
		private static Encoding ConsoleInputEncoding = Encoding.ASCII;
		private static Encoding ConsoleOutputEncoding = Encoding.ASCII;

		private static readonly SysConsole mFallbackConsole = new SysConsole(null);

		private static SysConsole GetConsole()
		{
			return mFallbackConsole;
		}

		public static ConsoleColor get_BackgroundColor()
		{
			return mBackground;
		}

		public static void set_BackgroundColor(ConsoleColor value)
		{
			mBackground = value;
			//Cosmos.HAL.Global.TextScreen.SetColors(mForeground, mBackground);
			if (GetConsole() != null) GetConsole().Background = value;
		}

		public static bool get_CapsLock()
		{
			return Kernel.Global.CapsLock;
		}

		public static int get_CursorLeft()
		{
			var xConsole = GetConsole();
			if (xConsole == null)
			{
				// for now:
				return 0;
			}
			return GetConsole().X;
		}

		public static void set_CursorLeft(int x)
		{
			var xConsole = GetConsole();
			if (xConsole == null)
			{
				// for now:
				return;
			}

			if (x < get_WindowWidth())
			{
				xConsole.X = x;
			}
			else
			{
				WriteLine("x must be lower than the console width!");
			}
		}

		public static int get_CursorTop()
		{
			var xConsole = GetConsole();
			if (xConsole == null)
			{
				// for now:
				return 0;
			}
			return GetConsole().Y;
		}

		public static void set_CursorTop(int y)
		{
			var xConsole = GetConsole();
			if (xConsole == null)
			{
				// for now:
				return;
			}

			if (y < get_WindowHeight())
			{
				xConsole.Y = y;
			}
			else
			{
				WriteLine("y must be lower than the console height!");
			}
		}

		public static ConsoleColor get_ForegroundColor()
		{
			return mForeground;
		}

		public static void set_ForegroundColor(ConsoleColor value)
		{
			mForeground = value;
			//Cosmos.HAL.Global.TextScreen.SetColors(mForeground, mBackground);
			if (GetConsole() != null) GetConsole().Foreground = value;
		}

		public static Encoding get_InputEncoding()
		{
			return ConsoleInputEncoding;
		}

		public static void set_InputEncoding(Encoding value)
		{
			ConsoleInputEncoding = value;
		}

		public static Encoding get_OutputEncoding()
		{
			return ConsoleOutputEncoding;
		}


		public static void set_OutputEncoding(Encoding value)
		{
			ConsoleOutputEncoding = value;
		}

		public static bool get_NumberLock()
		{
			return Kernel.Global.NumLock;
		}

		//public static TextWriter get_Out() {
		//    WriteLine("Not implemented: get_Out");
		//    return null;
		//}


		public static int get_WindowHeight()
		{
			var xConsole = GetConsole();
			if (xConsole == null)
			{
				// for now:
				return 25;
			}
			return GetConsole().Rows;
		}

		public static int get_WindowWidth()
		{
			var xConsole = GetConsole();
			if (xConsole == null)
			{
				// for now:
				return 85;
			}
			return GetConsole().Cols;
		}

		/// <summary>
		/// The ArgumentOutOfRangeException check is now done at driver level in PCSpeaker - is it still needed here?
		/// </summary>
		/// <param name="aFrequency"></param>
		/// <param name="aDuration"></param>
		public static void Beep(int aFrequency, int aDuration)
		{
			if (aFrequency < 37 || aFrequency > 32767)
			{
				throw new ArgumentOutOfRangeException("Frequency must be between 37 and 32767Hz");
			}

			if (aDuration <= 0)
			{
				throw new ArgumentOutOfRangeException("Duration must be more than 0");
			}

			PCSpeaker.Beep((uint)aFrequency, (uint)aDuration);
		}

		/// <summary>
		/// Beep() is pure CIL
		/// Default implementation beeps for 200 milliseconds at 800 hertz
		/// In Cosmos, these are Cosmos.System.Duration.Default and Cosmos.System.Notes.Default respectively,
		/// and are used when there are no params 
		/// https://docs.microsoft.com/en-us/dotnet/api/system.console.beep?view=netcore-2.0
		/// </summary>
		public static void Beep()
		{
			Cosmos.System.PCSpeaker.Beep();
		}

		//  MoveBufferArea(int, int, int, int, int, int) is pure CIL

		public static int Read()
		{
			// TODO special cases, if needed, that returns -1
			KeyEvent xResult;

			if (KeyboardManager.TryReadKey(out xResult))
			{
				return xResult.KeyChar;
			}
			else
			{
				return -1;
			}
		}

		public static ConsoleKeyInfo ReadKey()
		{
			return ReadKey(false);
		}

		// ReadKey() pure CIL

		public static ConsoleKeyInfo ReadKey(bool intercept)
		{
			var key = KeyboardManager.ReadKey();
			if (intercept == false && key.KeyChar != '\0')
			{
				Write(key.KeyChar);
			}

			//TODO: Plug HasFlag and use the next 3 lines instead of the 3 following lines

			//bool xShift = key.Modifiers.HasFlag(ConsoleModifiers.Shift);
			//bool xAlt = key.Modifiers.HasFlag(ConsoleModifiers.Alt);
			//bool xControl = key.Modifiers.HasFlag(ConsoleModifiers.Control);

			bool xShift = (key.Modifiers & ConsoleModifiers.Shift) == ConsoleModifiers.Shift;
			bool xAlt = (key.Modifiers & ConsoleModifiers.Alt) == ConsoleModifiers.Alt;
			bool xControl = (key.Modifiers & ConsoleModifiers.Control) == ConsoleModifiers.Control;

			return new ConsoleKeyInfo(key.KeyChar, key.Key.ToConsoleKey(), xShift, xAlt, xControl);
		}

		public static String ReadLine()
		{
			var xConsole = GetConsole();
			if (xConsole == null)
			{
				// for now:
				return null;
			}
			List<char> chars = new List<char>(32);
			KeyEvent current;
			int currentCount = 0;

			while ((current = KeyboardManager.ReadKey()).Key != ConsoleKeyEx.Enter)
			{
				if (current.Key == ConsoleKeyEx.NumEnter) break;
				//Check for "special" keys
				if (current.Key == ConsoleKeyEx.Backspace) // Backspace
				{
					if (currentCount > 0)
					{
						int curCharTemp = GetConsole().X;
						chars.RemoveAt(currentCount - 1);
						GetConsole().X = GetConsole().X - 1;

						//Move characters to the left
						for (int x = currentCount - 1; x < chars.Count; x++)
						{
							Write(chars[x]);
						}

						Write(' ');

						GetConsole().X = curCharTemp - 1;

						currentCount--;
					}
					continue;
				}
				else if (current.Key == ConsoleKeyEx.LeftArrow)
				{
					if (currentCount > 0)
					{
						GetConsole().X = GetConsole().X - 1;
						currentCount--;
					}
					continue;
				}
				else if (current.Key == ConsoleKeyEx.RightArrow)
				{
					if (currentCount < chars.Count)
					{
						GetConsole().X = GetConsole().X + 1;
						currentCount++;
					}
					continue;
				}

				if (current.KeyChar == '\0') continue;

				//Write the character to the screen
				if (currentCount == chars.Count)
				{
					chars.Add(current.KeyChar);
					Write(current.KeyChar);
					currentCount++;
				}
				else
				{
					//Insert the new character in the correct location
					//For some reason, List.Insert() doesn't work properly
					//so the character has to be inserted manually
					List<char> temp = new List<char>();

					for (int x = 0; x < chars.Count; x++)
					{
						if (x == currentCount)
						{
							temp.Add(current.KeyChar);
						}

						temp.Add(chars[x]);
					}

					chars = temp;

					//Shift the characters to the right
					for (int x = currentCount; x < chars.Count; x++)
					{
						Write(chars[x]);
					}

					GetConsole().X -= (chars.Count - currentCount) - 1;
					currentCount++;
				}
			}
			WriteLine();

			char[] final = chars.ToArray();
			return new string(final);
		}

		public static void ResetColor()
		{
			set_BackgroundColor(ConsoleColor.Blue);
			set_ForegroundColor(ConsoleColor.White);
		}
		public static void SetCursorPosition(int left, int top)
		{
			set_CursorLeft(left);
			set_CursorTop(top);
		}
		#endregion
	}
}