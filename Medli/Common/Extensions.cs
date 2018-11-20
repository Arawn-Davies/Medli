using System;
using System.Collections.Generic;

namespace Medli.Common
{
    public class Extensions
    {
		public static int StringToInt(string dat)
		{
			string str = "";
			foreach (byte num in dat)
				str = ((char)num).ToString() + str;
			dat = str;
			int num1 = 0;
			int num2 = 1;
			foreach (byte num3 in dat)
			{
				int num4 = (int)num3 - 48;
				num1 += num4 * num2;
				num2 *= 10;
			}
			return num1;
		}

        /// <summary>
        /// Small and simple method saves typing this method out over and over again - only has to be called once
        /// </summary>
        public static void PressAnyKey()
        {
            PressAnyKey("Press any key to continue...");
        }
        public static void PressAnyKey(string text)
        {
            Console.WriteLine(text);
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
