/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using System.Collections.Generic;
using Medli.System.Framework.Core;

namespace Medli.System.Framework.Crypto
{
    /// <summary>
    /// A hash developed by Splitty
    /// </summary>
    public static class RockPotato
    {
        public static string Hash(string input)
        {
            if (input == "") input = "RockPotato";
            byte[] chars = new byte[input.Length + 1];

            // Fill byte array
            for (int i = 0; i < input.Length; i++)
            {
                chars[i] = (byte)input[i];
            }

            uint seed = 0;

            // Calculate the seed
            for (int i = 0; i < input.Length; i++)
            {
                seed += (uint)(chars[i] * chars[i] >> i + 1);
            }

            // Allocate memory
            Memory.MemAlloc(sizeof(ulong));

            ulong final = 0;

            // Calculate the value
            for (int i = 0; i < input.Length; i++)
            {
                final += seed * chars[i];
            }

            // Expand the value to a length of 20
            int attempts = 0;
            do
            {
                final *= 2;
                final <<= ++attempts + ++attempts;
            } while (final.ToString().Length < 16);

            return final.ToString();
        }
    }
}
