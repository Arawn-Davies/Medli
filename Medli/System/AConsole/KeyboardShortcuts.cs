﻿using Cosmos.System;
using System;
using Sys = System;

namespace Medli.System.AConsole
{
    class KeyboardShortcuts
    {

        public static bool Close()
        {
            ConsoleKeyInfo key;

            key = Sys.Console.ReadKey(true);

            if (key.Key == ConsoleKey.C && KeyboardManager.ControlPressed)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
