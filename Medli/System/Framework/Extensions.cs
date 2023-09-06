/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medli.Core.Framework;

namespace Medli.System.Framework
{
    public static class NumericExtensions
    {

        public static string Hex(this byte[] value)
        {
            int offset = 0;
            int length = -1;

            if (length < 0)
                length = value.Length - offset;
            var builder = new StringBuilder(length * 2);
            int b;
            for (int i = offset; i < length + offset; i++)
            {
                b = value[i] >> 4;
                builder.Append((char)(55 + b + (b - 10 >> 31 & -7)));
                b = value[i] & 0xF;
                builder.Append((char)(55 + b + (b - 10 >> 31 & -7)));
            }
            return builder.ToString();
        }
        public static uint MsToHz(this int ms)
        {
            return (uint)(1000 / ms);
        }
        public static uint MsToHz(this uint ms)
        {
            return 1000 / ms;
        }
    }
    public static class KernelExtensions
    {
        /// <summary>
        /// Press-any-key prompt
        /// By default, it says 'Press any key to continue, but it can be overriden with parrameter 'text'
        /// </summary>
        /// <param name="text"></param>
        public static void PressAnyKey(string text = "Press any key to continue...")
        {
            Console.WriteLine(text);
            Console.ReadKey(true);
        }
        /// <summary>
        /// Reboots Medli operating system
        /// </summary>
        public static void Reboot()
        {
            ACPI.Reboot();
        }
        /// <summary>
        /// Shuts down the computer running the OS
        /// </summary>
        public static void Shutdown()
        {
            Cosmos.System.Power.Shutdown();
        }
        public static void SleepSeconds(uint value)
        {
            Medli.Core.Framework.PIT.SleepSeconds(value);
        }
        public static void SleepMilliseconds(uint value)
        {
            Medli.Core.Framework.PIT.SleepMilliseconds(value);
        }
        /// <summary>
        /// Returns the total amount of RAM
        /// </summary>
        /// <returns></returns>
        public static uint GetMemory()
        {
            return GetRAM.GetAmountOfRAM + 1;
        }
        public static void ShowBootscreen(
            string OSname,
            Bootscreen.Effect efx,
            ConsoleColor color,
            int ticks = 10000000
            )
        {
            Bootscreen.Show(OSname, efx, color, ticks);
        }
        public static void AllocMemory(uint aLength)
        {
            Heap.MemAlloc(aLength);
        }
    }
    public static class StringExtensions
    {
        public static string SHA256(this string str)
        {
            return Crypto.SHA256.Hash(str);
        }
        public static string ROT13(this string str)
        {
            return Crypto.ROT13.encrypt(str);
        }
        public static string ROT47(this string str)
        {
            return Crypto.ROT13.encrypt(str);
        }
        public static string MD55(this string str)
        {
            return Crypto.MD5.Hash(str);
        }
        public static string RockPotato(this string str)
        {
            return Crypto.RockPotato.Hash(str);
        }
        /// <summary>
        /// Checks if the string starts with [string]
        /// </summary>
        /// <param name="__str"></param>
        /// <param name="__expression"></param>
        /// <returns></returns>
        public static bool _StartsWith(this string __str, string __expression)
        {
            string str = "";
            if (__expression.Length <= __str.Length)
            {
                for (int i = 0; i < __expression.Length; i++)
                {
                    str += __str[i];
                    if (str == __expression) return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Checks if the string ends with [string]
        /// </summary>
        /// <param name="__str"></param>
        /// <param name="__expression"></param>
        /// <returns></returns>
        public static bool _EndsWith(this string __str, string __expression)
        {
            string str = "";
            if (__expression.Length <= __str.Length)
            {
                for (int i = __str.Length - 1 - (__expression.Length - 1); i == __str.Length - 1; i++)
                {
                    str += __str[i];
                    if (str == __expression) return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Returns the char at position [string[index]]
        /// </summary>
        /// <param name="str"></param>
        /// <param name="null_based_index"></param>
        /// <returns></returns>
        public static char _GetCharAt(this string str, int null_based_index)
        {
            if (null_based_index >= 0 && null_based_index < str.Length)
                return str[null_based_index];
            else
            {
                Bluescreen.Init("string._GetCharAt", "null_based_index must be >= 0 and <= the length of the string");
                return char.MinValue;
            }
        }
        /// <summary>
        /// Removes the char at position [string[index]]
        /// </summary>
        /// <param name="str"></param>
        /// <param name="null_based_index"></param>
        /// <returns></returns>
        public static string _RemoveCharAt(this string str, int null_based_index)
        {
            if (null_based_index < str.Length)
            {
                string _str = "";
                for (int i = 0; i < null_based_index; i++) _str += str[i];
                for (int i = null_based_index + 1; i < str.Length; i++) _str += str[i];
                return _str;
            }
            else
            {
                Bluescreen.Init("string._GetCharAt", "null_based_index must be >= 0 and <= the length of the string");
                return str;
            }
        }
    }
}
