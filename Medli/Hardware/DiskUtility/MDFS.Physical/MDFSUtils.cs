using System;
using System.Collections.Generic;
using System.Text;

namespace MDFS
{
    public class MDFSUtils
    {
		public static String byteArrayToByteString(Byte[] inp)
		{
			Byte ch = 0x00;
			String ret = "";

			String[] pseudo = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
				"A", "B", "C", "D", "E", "F" };

			for (int i = 0; i < inp.Length; i++)
			{
				ret += "0x";
				ch = (byte)(inp[i] & 0xF0);
				ch = (byte)(ch >> 4);
				ch = (byte)(ch & 0x0F); 
										
				ret += pseudo[(int)ch].ToString(); 
												   
				ch = (byte)(inp[i] & 0x0F); 
				ret += pseudo[(int)ch].ToString(); 
												   
				ret += " ";
			}
			return ret;
		}

		public static bool StringContains(String instr, char[] chars)
		{
			for (int i = 0; i < chars.Length; i++)
			{
				if (Contains(instr, chars[i]))
				{
					return true;
				}
			}
			return false;
		}

		private static bool Contains(string instr, char p)
		{
			for (int i = 0; i < instr.Length; i++)
			{
				if (instr[i] == p)
				{
					return true;
				}
			}
			return false;
		}

		public static int CopyByteToByte(byte[] Data, int dind, byte[] arr, int arrind, int many)
		{
			int i = 0;
			int j = arrind;
			for (i = dind; i < many + dind && i < Data.Length; i++)
			{
				arr[j++] = Data[i];
			}
			while (j < many + arrind)
			{
				arr[j++] = 0;
			}
			return i;
		}

		public static int CopyByteToByte(byte[] Data, int dind, byte[] arr, int arrind, int many, bool writeallzero)
		{
			int i = 0;
			int j = arrind;
			for (i = dind; i < many + dind && i < Data.Length; i++)
			{
				arr[j++] = Data[i];
			}
			while (writeallzero && j < many + arrind)
			{
				arr[j++] = 0;
			}
			return i;
		}

		public static int CopyCharToByte(Char[] Data, int dind, byte[] arr, int arrind, int many)
		{
			int i = 0;
			int j = arrind;
			for (i = dind; i < many && i < Data.Length; i++)
			{
				arr[j++] = (byte)Data[i];
			}
			while (j < many)
			{
				arr[j++] = 0;
			}
			return i;
		}

		public static int CopyByteToChar(byte[] Data, int dind, Char[] arr, int arrind, int many)
		{
			int i = 0;
			int j = arrind;
			for (i = dind; i < many && i < Data.Length; i++)
			{
				arr[j++] = (Char)Data[i];
			}
			while (j < many)
			{
				arr[j++] = '\0';
			}
			return i;
		}

		public static string CharToString(char[] text)
		{
			String ret = "";
			for (int i = 0; i < text.Length; i++)
			{
				ret += text[i];
			}
			return ret;
		}
	}
}
