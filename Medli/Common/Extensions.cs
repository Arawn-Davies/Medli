using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Common
{
    public class Extensions
    {
		public static byte[] AddToArray (byte[] bArray, byte NewByte)
		{
			byte[] newArray = new byte[bArray.Length + 1];
			bArray.CopyTo(newArray, 1);
			newArray[0] = NewByte;
			return newArray;
		}
    }
}
