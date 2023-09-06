/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using System.Collections.Generic;
using Medli.Main;
using Medli.Core.Framework;

namespace Medli.System.Framework
{
    public static class Bluescreen
    {
        /// <summary>
        /// Initiates a Bluescreen.
        /// </summary>
        /// <param name="error">Error title or exception name</param>
        /// <param name="description">Error description</param>
        /// <param name="critical">Critical error?</param>
        public static void Init(
            string error = "Something went wrong!",
            string description = "Unknown exception",
            bool critical = false)
        {
            DrawOOPS();
            if (description.Length + 33 < AConsole.WindowHeight)
            {
                AConsole.CursorTop = 2; AConsole.CursorLeft = 33;
                ConsoleColor errcolor = ConsoleColor.White;
                if (critical) errcolor = ConsoleColor.Red;
                AConsole.WriteLineEx(error, errcolor, ConsoleColor.Blue);
                AConsole.CursorTop = 4; AConsole.CursorLeft = 70;
                AConsole.WriteLineEx(description, ConsoleColor.White, ConsoleColor.Blue);
            }
            else
            {
                AConsole.CursorTop = 12; AConsole.CursorLeft = 2;
                ConsoleColor errcolor = ConsoleColor.White;
                if (critical) errcolor = ConsoleColor.Red;
                AConsole.WriteLineEx(error, errcolor, ConsoleColor.Blue);
                AConsole.CursorTop = 14; AConsole.CursorLeft = 2;
                AConsole.WriteLineEx(description, ConsoleColor.White, ConsoleColor.Blue);
            }
            if (!critical)
            {
                AConsole.CursorTop = AConsole.WindowHeight - 1;
                AConsole.WriteEx("Press the [Enter]-key to resume", ConsoleColor.White, ConsoleColor.Blue);
                AConsole.CursorTop++;
                AConsole.ReadLine();
                AConsole.Clear();
            }
            else
            {
                AConsole.CursorTop = AConsole.WindowHeight - 4;
                AConsole.WriteLineEx("Press the [Enter]-key to shutdown", ConsoleColor.White, ConsoleColor.Blue);
                AConsole.CursorTop++;
                AConsole.WriteLineEx("If it doesn't work, press the RESET-button on your computer.", ConsoleColor.White, ConsoleColor.Blue);
                AConsole.CursorTop++;
                AConsole.ReadLine();
                Cosmos.System.Power.Shutdown();
            }
        }
        public static void Init(Exception ex, bool critical = false)
        {
            DrawOOPS();
            if (ex.Message.Length + 33 < AConsole.WindowHeight)
            {
                AConsole.CursorTop = 2; AConsole.CursorLeft = 33;
                ConsoleColor errcolor = ConsoleColor.White;
                if (critical) errcolor = ConsoleColor.Red;
                //AConsole.WriteLineEx(ex.Source, errcolor, ConsoleColor.Blue);
                AConsole.CursorTop = 3; AConsole.CursorLeft = 70;
                AConsole.WriteLineEx(ex.Message, ConsoleColor.White, ConsoleColor.Blue);
            }
            else
            {
                AConsole.CursorTop = 12; AConsole.CursorLeft = 2;
                ConsoleColor errcolor = ConsoleColor.White;
                if (critical) errcolor = ConsoleColor.Red;
                //AConsole.WriteLineEx(ex.Source, errcolor, ConsoleColor.Blue);
                AConsole.CursorTop = 13; AConsole.CursorLeft = 2;
                AConsole.WriteLineEx(ex.Message, ConsoleColor.White, ConsoleColor.Blue);
            }
            if (!critical)
            {
                AConsole.CursorTop = AConsole.WindowHeight - 3;
                AConsole.WriteEx("Press the [Enter]-key to resume", ConsoleColor.White, ConsoleColor.Blue);
                AConsole.CursorTop++;
                AConsole.ReadLine();
                AConsole.Clear();
            }
            else
            {
                AConsole.CursorTop = AConsole.WindowHeight - 4;
                AConsole.WriteEx("Press the [Enter]-key to shutdown", ConsoleColor.White, ConsoleColor.Blue);
                AConsole.CursorTop++;
                AConsole.WriteEx("If it doesn't work, press the RESET-button on your computer.", ConsoleColor.White, ConsoleColor.Blue);
                AConsole.CursorTop++;
                AConsole.ReadLine();
                Cosmos.System.Power.Shutdown();
            }
        }
        private static void DrawOOPS()
        {
            AConsole.Fill(ConsoleColor.Blue);
            string[] arrOOPS = new string[] {
                "=====  =====   =====   =====  =====   |",
                "=      =    =  =    =  =   =  =    =  |",
                "=====  ======  ======  =   =  ======  |",
                "=      =    =  =    =  =   =  =    =  |",
                "=====  =    =  =    =  =====  =    =  O"};
            AConsole.CursorTop = 2;
            foreach (string str in arrOOPS)
            {
                AConsole.CursorLeft = 2;
                AConsole.WriteLineEx(str, ConsoleColor.White, ConsoleColor.Blue);
            }
        }
        /// <summary>
        /// Kernel Panic
        /// </summary>
        public static void Panic(string err, string desc, string lka, ref Cosmos.Core.INTs.IRQContext aContext)
        {
            AConsole.Clear();
            AConsole.Fill(ConsoleColor.Black);
            AConsole.CursorTop = 2;
            AConsole.WriteLineEx("kpanic occurred at :" + lka, ConsoleColor.Black, ConsoleColor.White);
            AConsole.WriteLineEx("Error: " + err, ConsoleColor.Black, ConsoleColor.White);
            AConsole.WriteLineEx("Description: " + desc, ConsoleColor.Black, ConsoleColor.White);
            AConsole.WriteLine("\n");
            AConsole.WriteLine("Debug info:");
            AConsole.WriteLine("\n");
            AConsole.WriteLine("eip: " + aContext.EIP);
            AConsole.WriteLine("eax: " + aContext.EAX + " edx: " + aContext.EDX + " ecx: " + aContext.ECX + " ebx: " + aContext.EBX);
            AConsole.WriteLine("esi: " + aContext.ESI + " edi: " + aContext.EDI + " ebp: " + aContext.EBP + " esp: " + aContext.ESP);

            // Enter an infinite loop
            while (true)
            {

            }
        }
        public static void Panic()
        {
            AConsole.Clear();
            AConsole.Fill(ConsoleColor.Red);
            AConsole.CursorTop = 2;
            AConsole.WriteLineEx("KERNEL PANIC", ConsoleColor.White, ConsoleColor.Red, true);
            AConsole.WriteLine("\n");
            string message = "CRITICAL KERNEL EXCEPTION\nPLEASE CONTACT YOUR SOFTWARE MANUFACTURER";
            AConsole.WriteLineEx(message, ConsoleColor.White, ConsoleColor.Red, true);
            // Enter an infinite loop
            while (true)
            {

            }
        }
    }
}
