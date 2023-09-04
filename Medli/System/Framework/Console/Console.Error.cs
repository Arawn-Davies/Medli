/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using System.Collections.Generic;

namespace AIC.Main
{
    public static partial class AConsole
    {
        public static class Error
        {
            public static void Write(string text)
            {
                AConsole.Write("[!] ERROR: " + text.ToUpper(), ConsoleColor.Red);
            }
            public static void WriteLine(string text)
            {
                AConsole.WriteLine("[!] ERROR: " + text.ToUpper(), ConsoleColor.Red);
            }
        }
    }
}
