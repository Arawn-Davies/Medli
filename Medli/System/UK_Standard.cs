using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.HAL;
using Cosmos.System.ScanMaps;

namespace Medli.System
{
    class UK_Standard : Sys.ScanMapBase
    {
		public UK_Standard()
		{

		}
		protected override void InitKeys()
		{
			_keys = new List<Sys.KeyMapping>(102);


			#region Keys

			/*     Scan  Norm Shift Ctrl Alt     Num  Caps ShCaps ShNum Sys.ConsoleKeyEx */
			_keys.Add(new Sys.KeyMapping(0x00, Sys.ConsoleKeyEx.NoName));
			_keys.Add(new Sys.KeyMapping(0x01, Sys.ConsoleKeyEx.Escape));
			/* 1 -> 9 */
			_keys.Add(new Sys.KeyMapping(0x02, '1', '!', '1', '1', '!', '1', Sys.ConsoleKeyEx.D1));
			_keys.Add(new Sys.KeyMapping(0x03, '2', '"', '2', '2', '"', '2', Sys.ConsoleKeyEx.D2));
			_keys.Add(new Sys.KeyMapping(0x04, '3', '£', '3', '3', '£', '3', Sys.ConsoleKeyEx.D3));
			_keys.Add(new Sys.KeyMapping(0x05, '4', '$', '4', '4', '$', '4', Sys.ConsoleKeyEx.D4));
			_keys.Add(new Sys.KeyMapping(0x06, '5', '%', '5', '5', '%', '5', Sys.ConsoleKeyEx.D5));
			_keys.Add(new Sys.KeyMapping(0x07, '6', '^', '6', '6', '^', '6', Sys.ConsoleKeyEx.D6));
			_keys.Add(new Sys.KeyMapping(0x08, '7', '&', '7', '7', '&', '7', Sys.ConsoleKeyEx.D7));
			_keys.Add(new Sys.KeyMapping(0x09, '8', '*', '8', '8', '*', '8', Sys.ConsoleKeyEx.D8));
			_keys.Add(new Sys.KeyMapping(0x0A, '9', '(', '9', '9', '(', '9', Sys.ConsoleKeyEx.D9));
			_keys.Add(new Sys.KeyMapping(0x0B, '0', ')', '0', '0', ')', '0', Sys.ConsoleKeyEx.D0));
			/* -, =, Bksp, Tab */
			_keys.Add(new Sys.KeyMapping(0x0C, '-', '_', '-', '-', '_', '-', Sys.ConsoleKeyEx.Minus));
			_keys.Add(new Sys.KeyMapping(0x0D, '=', '+', '=', '=', '+', '=', Sys.ConsoleKeyEx.Equal));
			_keys.Add(new Sys.KeyMapping(0x0E, Sys.ConsoleKeyEx.Backspace));
			_keys.Add(new Sys.KeyMapping(0x0F, Sys.ConsoleKeyEx.Tab));
			/*      QWERTYUIOP[] */
			_keys.Add(new Sys.KeyMapping(0x10, 'q', 'Q', 'q', 'Q', 'q', 'Q', Sys.ConsoleKeyEx.Q));
			_keys.Add(new Sys.KeyMapping(0x11, 'w', 'W', 'w', 'W', 'w', 'W', Sys.ConsoleKeyEx.W));
			_keys.Add(new Sys.KeyMapping(0x12, 'e', 'E', 'e', 'E', 'e', 'E', Sys.ConsoleKeyEx.E));
			_keys.Add(new Sys.KeyMapping(0x13, 'r', 'R', 'r', 'R', 'r', 'R', Sys.ConsoleKeyEx.R));
			_keys.Add(new Sys.KeyMapping(0x14, 't', 'T', 't', 'T', 't', 'T', Sys.ConsoleKeyEx.T));
			_keys.Add(new Sys.KeyMapping(0x15, 'y', 'Y', 'y', 'Y', 'y', 'Y', Sys.ConsoleKeyEx.Y));
			_keys.Add(new Sys.KeyMapping(0x16, 'u', 'U', 'u', 'U', 'u', 'U', Sys.ConsoleKeyEx.U));
			_keys.Add(new Sys.KeyMapping(0x17, 'i', 'I', 'i', 'I', 'i', 'I', Sys.ConsoleKeyEx.I));
			_keys.Add(new Sys.KeyMapping(0x18, 'o', 'O', 'o', 'O', 'o', 'O', Sys.ConsoleKeyEx.O));
			_keys.Add(new Sys.KeyMapping(0x19, 'p', 'P', 'p', 'P', 'p', 'P', Sys.ConsoleKeyEx.P));
			_keys.Add(new Sys.KeyMapping(0x1A, '[', '{', '[', '{', '[', '{', Sys.ConsoleKeyEx.LBracket));
			_keys.Add(new Sys.KeyMapping(0x1B, ']', '}', ']', '}', ']', '}', Sys.ConsoleKeyEx.RBracket));
			/* ENTER, CTRL */
			_keys.Add(new Sys.KeyMapping(0x1C, Sys.ConsoleKeyEx.Enter));
			_keys.Add(new Sys.KeyMapping(0x1D, Sys.ConsoleKeyEx.LCtrl));
			/* ASDFGHJKL;'` */
			_keys.Add(new Sys.KeyMapping(0x1E, 'a', 'A', 'a', 'A', 'a', 'A', Sys.ConsoleKeyEx.A));
			_keys.Add(new Sys.KeyMapping(0x1F, 's', 'S', 's', 'S', 's', 'S', Sys.ConsoleKeyEx.S));
			_keys.Add(new Sys.KeyMapping(0x20, 'd', 'D', 'd', 'D', 'd', 'D', Sys.ConsoleKeyEx.D));
			_keys.Add(new Sys.KeyMapping(0x21, 'f', 'F', 'f', 'F', 'f', 'F', Sys.ConsoleKeyEx.F));
			_keys.Add(new Sys.KeyMapping(0x22, 'g', 'G', 'g', 'G', 'g', 'G', Sys.ConsoleKeyEx.G));
			_keys.Add(new Sys.KeyMapping(0x23, 'h', 'H', 'h', 'H', 'h', 'H', Sys.ConsoleKeyEx.H));
			_keys.Add(new Sys.KeyMapping(0x24, 'j', 'J', 'j', 'J', 'j', 'J', Sys.ConsoleKeyEx.J));
			_keys.Add(new Sys.KeyMapping(0x25, 'k', 'K', 'k', 'K', 'k', 'K', Sys.ConsoleKeyEx.K));
			_keys.Add(new Sys.KeyMapping(0x26, 'l', 'L', 'l', 'L', 'l', 'L', Sys.ConsoleKeyEx.L));
			_keys.Add(new Sys.KeyMapping(0x27, ';', ':', ';', ';', ':', ':', Sys.ConsoleKeyEx.Semicolon));
			_keys.Add(new Sys.KeyMapping(0x28, '\'', '@', '\'', '\'', '@', '@', Sys.ConsoleKeyEx.Apostrophe));
			_keys.Add(new Sys.KeyMapping(0x29, '`', '¬', '¬', '`', '¬', '¬', Sys.ConsoleKeyEx.Backquote));
			/* Left Shift*/
			_keys.Add(new Sys.KeyMapping(0x2A, Sys.ConsoleKeyEx.LShift));
			/* \ZXCVBNM,./ */
			_keys.Add(new Sys.KeyMapping(0x2B, '#', '~', '#', '#', '~', '~', Sys.ConsoleKeyEx.Backslash));
			_keys.Add(new Sys.KeyMapping(0x2C, 'z', 'Z', 'z', 'Z', 'z', 'Z', Sys.ConsoleKeyEx.Z));
			_keys.Add(new Sys.KeyMapping(0x2D, 'x', 'X', 'x', 'X', 'x', 'X', Sys.ConsoleKeyEx.X));
			_keys.Add(new Sys.KeyMapping(0x2E, 'c', 'C', 'c', 'C', 'c', 'C', Sys.ConsoleKeyEx.C));
			_keys.Add(new Sys.KeyMapping(0x2F, 'v', 'V', 'v', 'V', 'v', 'V', Sys.ConsoleKeyEx.V));
			_keys.Add(new Sys.KeyMapping(0x30, 'b', 'B', 'b', 'B', 'b', 'B', Sys.ConsoleKeyEx.B));
			_keys.Add(new Sys.KeyMapping(0x31, 'n', 'N', 'n', 'N', 'n', 'N', Sys.ConsoleKeyEx.N));
			_keys.Add(new Sys.KeyMapping(0x32, 'm', 'M', 'm', 'M', 'm', 'M', Sys.ConsoleKeyEx.M));
			_keys.Add(new Sys.KeyMapping(0x33, ',', '<', ',', ',', '<', '<', Sys.ConsoleKeyEx.Comma));
			_keys.Add(new Sys.KeyMapping(0x34, '.', '>', '.', '.', '>', '>', Sys.ConsoleKeyEx.Period));
			_keys.Add(new Sys.KeyMapping(0x35, '/', '?', '/', '/', '?', '/', Sys.ConsoleKeyEx.Slash)); // also numpad divide
																							   /* Right Shift */
			_keys.Add(new Sys.KeyMapping(0x36, Sys.ConsoleKeyEx.RShift));
			/* Print Screen */
			_keys.Add(new Sys.KeyMapping(0x37, '*', '*', '*', '*', '*', '*', Sys.ConsoleKeyEx.NumMultiply));
			// also numpad multiply
			/* Alt  */
			_keys.Add(new Sys.KeyMapping(0x38, Sys.ConsoleKeyEx.LAlt));
			/* Space */
			_keys.Add(new Sys.KeyMapping(0x39, ' ', Sys.ConsoleKeyEx.Spacebar));
			/* Caps */
			_keys.Add(new Sys.KeyMapping(0x3A, Sys.ConsoleKeyEx.CapsLock));
			/* F1-F12 */
			_keys.Add(new Sys.KeyMapping(0x3B, Sys.ConsoleKeyEx.F1));
			_keys.Add(new Sys.KeyMapping(0x3C, Sys.ConsoleKeyEx.F2));
			_keys.Add(new Sys.KeyMapping(0x3D, Sys.ConsoleKeyEx.F3));
			_keys.Add(new Sys.KeyMapping(0x3E, Sys.ConsoleKeyEx.F4));
			_keys.Add(new Sys.KeyMapping(0x3F, Sys.ConsoleKeyEx.F5));
			_keys.Add(new Sys.KeyMapping(0x40, Sys.ConsoleKeyEx.F6));
			_keys.Add(new Sys.KeyMapping(0x41, Sys.ConsoleKeyEx.F7));
			_keys.Add(new Sys.KeyMapping(0x42, Sys.ConsoleKeyEx.F8));
			_keys.Add(new Sys.KeyMapping(0x43, Sys.ConsoleKeyEx.F9));
			_keys.Add(new Sys.KeyMapping(0x44, Sys.ConsoleKeyEx.F10));
			_keys.Add(new Sys.KeyMapping(0x56, '\\', '|', '\\', '\\', '|', '|', Sys.ConsoleKeyEx.NoName));
			_keys.Add(new Sys.KeyMapping(0x57, Sys.ConsoleKeyEx.F11));
			_keys.Add(new Sys.KeyMapping(0x58, Sys.ConsoleKeyEx.F12));
			/* Num Lock, Scrl Lock */
			_keys.Add(new Sys.KeyMapping(0x45, Sys.ConsoleKeyEx.NumLock));
			_keys.Add(new Sys.KeyMapping(0x46, Sys.ConsoleKeyEx.ScrollLock));
			/* HOME, Up, Pgup, -kpad, left, center, right, +keypad, end, down, pgdn, ins, del */
			_keys.Add(new Sys.KeyMapping(0x47, '\0', '\0', '7', '\0', '\0', '\0', Sys.ConsoleKeyEx.Home, Sys.ConsoleKeyEx.Num7));
			_keys.Add(new Sys.KeyMapping(0x48, '\0', '\0', '8', '\0', '\0', '\0', Sys.ConsoleKeyEx.UpArrow, Sys.ConsoleKeyEx.Num8));
			_keys.Add(new Sys.KeyMapping(0x49, '\0', '\0', '9', '\0', '\0', '\0', Sys.ConsoleKeyEx.PageUp, Sys.ConsoleKeyEx.Num9));
			_keys.Add(new Sys.KeyMapping(0x4A, '-', '-', '-', '-', '-', '-', Sys.ConsoleKeyEx.NumMinus));
			_keys.Add(new Sys.KeyMapping(0x4B, '\0', '\0', '4', '\0', '\0', '\0', Sys.ConsoleKeyEx.LeftArrow, Sys.ConsoleKeyEx.Num4));
			_keys.Add(new Sys.KeyMapping(0x4C, '\0', '\0', '5', '\0', '\0', '\0', Sys.ConsoleKeyEx.Num5));
			_keys.Add(new Sys.KeyMapping(0x4D, '\0', '\0', '6', '\0', '\0', '\0', Sys.ConsoleKeyEx.RightArrow, Sys.ConsoleKeyEx.Num6));
			_keys.Add(new Sys.KeyMapping(0x4E, '+', '+', '+', '+', '+', '+', Sys.ConsoleKeyEx.NumPlus));
			_keys.Add(new Sys.KeyMapping(0x4F, '\0', '\0', '1', '\0', '\0', '\0', Sys.ConsoleKeyEx.End, Sys.ConsoleKeyEx.Num1));
			_keys.Add(new Sys.KeyMapping(0x50, '\0', '\0', '2', '\0', '\0', '\0', Sys.ConsoleKeyEx.DownArrow, Sys.ConsoleKeyEx.Num2));
			_keys.Add(new Sys.KeyMapping(0x51, '\0', '\0', '3', '\0', '\0', '\0', Sys.ConsoleKeyEx.PageDown, Sys.ConsoleKeyEx.Num3));
			_keys.Add(new Sys.KeyMapping(0x52, '\0', '\0', '0', '\0', '\0', '\0', Sys.ConsoleKeyEx.Insert, Sys.ConsoleKeyEx.Num0));
			_keys.Add(new Sys.KeyMapping(0x53, '\0', '\0', '.', '\0', '\0', '\0', Sys.ConsoleKeyEx.Delete, Sys.ConsoleKeyEx.NumPeriod));
			_keys.Add(new Sys.KeyMapping(0x54, Sys.ConsoleKeyEx.PrintScreen));
			_keys.Add(new Sys.KeyMapping(0x5b, Sys.ConsoleKeyEx.LWin));
			_keys.Add(new Sys.KeyMapping(0x5c, Sys.ConsoleKeyEx.RWin));
			_keys.Add(new Sys.KeyMapping(0xE1, Sys.ConsoleKeyEx.PauseBreak));
		

			#endregion
		}
	}
}
