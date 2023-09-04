/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;

namespace Medli.System.Framework.Crypto
{
    /// <summary>
    /// Rot13
    /// </summary>
	public static class ROT13
    {
        private static char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
        private static char[] rot13 = "NOPQRSTUVWXYZABCDEFGHIJKLMnopqrstuvwxyzabcdefghijklm".ToCharArray();
        public static string encrypt(string str)
        {
            string retstr = string.Empty;
            for (int x = 0; x < str.Length; x++)
            {
                for (int y = 0; y < 53; y++)
                {
                    if (y > 51) { retstr += str[x]; }
                    else if (str[x] == alphabet[y]) { retstr += rot13[y]; break; }
                }
            }
            return retstr;
        }
        public static string decrypt(string str)
        {
            return encrypt(str);
        }
    }
    /// <summary>
    /// Holy cow...
    /// </summary>
    public static class ROT26
    {
        /// <summary>
        /// That's a joke, isn't it!?
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string encrypt(string str)
        {
            return "DUMBNESS DETECTED!\nrot26(str) == rot13(rot13(str)) == str";
        }
        /// <summary>
        /// That's a joke, isn't it!?
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string decrypt(string str)
        {
            return "DUMBNESS DETECTED!\nrot26(str) == rot13(rot13(str)) == str";
        }
    }
    public static class ROT47
    {
        private static char[] alphabet = "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~".ToCharArray();
        private static char[] rot47 = "PQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNO".ToCharArray();
        public static string encrypt(string str)
        {
            string retstr = string.Empty;
            for (int x = 0; x < str.Length; x++)
            {
                for (int y = 0; y < 95; y++)
                {
                    if (y > 93) { retstr += str[x]; }
                    else if (str[x] == alphabet[y]) { retstr += rot47[y]; break; }
                }
            }
            return retstr;
        }
        public static string decrypt(string str)
        {
            return encrypt(str);
        }
    }
}
