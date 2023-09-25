/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using Medli.Core.Framework;
using Cosmos.Debug.Kernel;
using Medli.Main;

namespace Medli.System.Framework
{
    public static class Bootscreen
    {
        /// <summary>
        /// BootScreen debugger, I'm getting a stack overflow somewhere...
        /// </summary>
        private static Debugger debugger = new Debugger("Bootscreen");
        public enum Effect : byte
        {
            SlideFromLeft,
            SlideFromRight,
            SlideFromTop,
            SlideFromBottom,
            Typewriter,
            Matrix
        }
        /// <summary>
        /// Shows the BootScreen and a specified effect
        /// </summary>
        /// <param name="OSname"></param>
        /// <param name="efx"></param>
        /// <param name="color"></param>
        /// <param name="ms_sleep"></param>
        public static void Show(string OSname, Effect efx, ConsoleColor color, int ms_sleep)
        {
            debugger.Send("Bootscreen.Show");
            if (ms_sleep % 2 == 1) ms_sleep++;
            switch (efx)
            {
                case Effect.SlideFromLeft:
                    debugger.Send("slide-from-left");
                    for (int i = 0; i < AConsole.WindowWidth / 2 - OSname.Length / 2; i++)
                    {
                        AConsole.Clear();
                        AConsole.CursorLeft = i;
                        string fill = "";
                        for (int x = 0; x < i; x++) fill += " ";
                        AConsole.Write(fill);
                        AConsole.Write(OSname, color, false, true);
                        RTC.Sleep(ms_sleep);
                    }
                    break;
                case Effect.SlideFromRight:
                    debugger.Send("slide-from-right");
                    for (int i = AConsole.WindowWidth - OSname.Length;
                        i > AConsole.WindowWidth / 2 - OSname.Length / 2; i--)
                    {
                        AConsole.Clear();
                        AConsole.CursorLeft = i;
                        AConsole.Write(OSname, color, false, true);
                        RTC.Sleep(ms_sleep);
                    }
                    break;
                case Effect.SlideFromTop:
                    debugger.Send("slide-from-top");
                    for (int i = 0; i < AConsole.WindowHeight / 2; i++)
                    {
                        AConsole.Clear();
                        AConsole.CursorTop = i;
                        AConsole.WriteLine(OSname, color, true, false);
                        RTC.Sleep(ms_sleep);
                    }
                    break;
                case Effect.SlideFromBottom:
                    debugger.Send("slide-from-bottom");
                    for (int i = AConsole.WindowHeight - 1; i > AConsole.WindowHeight / 2; i--)
                    {
                        AConsole.Clear();
                        AConsole.CursorTop = i;
                        AConsole.WriteLine(OSname, color, true, false);
                        RTC.Sleep(ms_sleep);
                    }
                    break;
                case Effect.Typewriter:
                    debugger.Send("typewriter");
                    AConsole.CursorLeft = AConsole.WindowWidth / 2 - OSname.Length / 2;
                    foreach (char chr in OSname)
                    {
                        AConsole.Write(chr.ToString(), color, false, true);
                        RTC.Sleep(ms_sleep);
                    }
                    break;

                case Effect.Matrix:
                    debugger.Send("matrix");
                    int sec1 = Hardware.RTC.Now.Second;
                    int sec2 = sec1;
                    do { sec2 = Hardware.RTC.Now.Second; } while (sec1 == sec2);
                    int sec3;
                    if (sec2 <= 56) sec3 = sec2 + 3;
                    else if (sec2 == 57) sec3 = 1;
                    else if (sec2 == 58) sec3 = 2;
                    else if (sec2 == 59) sec3 = 3;
                    else sec3 = 3;
                    int tmr = 0;
                    int tmrx = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        for (int ih = 0; ih < AConsole.WindowHeight; ih++)
                        {
                            for (int iw = 0; iw < AConsole.WindowWidth; iw++)
                            {
                                if (tmr == 11) tmr = 0;
                                if (tmrx == 4) tmrx = 0;
                                tmr++;
                                if (tmr == 0) AConsole.Write("#", ConsoleColor.Magenta);
                                if (tmrx == 3) AConsole.Write("*", ConsoleColor.Green);
                                if (tmr == 2) { AConsole.Write(";", ConsoleColor.Red); ++tmrx; }
                                if (tmrx == 1) AConsole.Write("+", ConsoleColor.Yellow);
                                if (tmr == 4) { AConsole.Write("~", ConsoleColor.Blue); ++tmrx; }
                                if (tmrx == 2) AConsole.Write("&", ConsoleColor.Cyan);
                                AConsole.Write(OSname, ConsoleColor.White, true, true);
                            }
                        }
                    }
                    break;
            }
        }
    }
}
