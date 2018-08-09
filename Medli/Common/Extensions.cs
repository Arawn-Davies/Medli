using System;
using System.Collections.Generic;

namespace Medli.Common
{
    public class Extensions
    {
		public static void PAKTC()
		{
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey(true);
		}

		public static byte[] AddToArray (byte[] bArray, byte NewByte)
		{
			byte[] newArray = new byte[bArray.Length + 1];
			bArray.CopyTo(newArray, 1);
			newArray[0] = NewByte;
			return newArray;
		}
    }
}
