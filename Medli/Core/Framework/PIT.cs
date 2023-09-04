/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using AIC;
using IO = Medli.Core.Framework.IO;

namespace Medli.Core.Framework
{
    public static class NumericExtensions
    {
        public static uint MsToHz(this int ms)
        {
            return (uint)(1000 / ms);
        }
        public static uint MsToHz(this uint ms)
        {
            return (uint)(1000 / ms);
        }
    }
    public static class PIT
    {
        public static void Mode0(uint frequency)
        {
            IDT.Remap();
            uint divisor = 1193182 / frequency;
            IO.PortIO.OutB(0x43, 0x30);
            IO.PortIO.OutB(0x40, (byte)(divisor & 0xFF));
            IO.PortIO.OutB(0x40, (byte)((divisor >> 8) & 0xFF));
            IRQ.ClearMask(0);
            IRQ.ClearMask(15);
        }
        public static void Mode2(uint frequency)
        {
            IDT.Remap();
            uint divisor = 1193182 / frequency;
            IO.PortIO.OutB(0x43, 0x36);
            IO.PortIO.OutB(0x40, (byte)(divisor & 0xFF));
            IO.PortIO.OutB(0x40, (byte)((divisor >> 8) & 0xFF));
            IRQ.ClearMask(0);
            IRQ.ClearMask(15);
        }
        public static void Beep(uint frequency)
        {
            uint divisor = 1193182 / frequency;
            IO.PortIO.OutB(0x43, 0xB6);
            IO.PortIO.OutB(0x42, (byte)(divisor & 0xFF));
            IO.PortIO.OutB(0x42, (byte)((divisor >> 8) & 0xFF));
        }
        internal static bool called = false;
        public static void SleepSeconds(uint seconds)
        {
            SleepMilliseconds(seconds * 1000);
        }
        public static void SleepMilliseconds(uint milliseconds)
        {
            
            if (milliseconds <= 50)
            {
                called = false;
                Mode0(milliseconds.MsToHz());
                while (!called) { }
                called = false;
            }
            else
            {
                uint mod = milliseconds % 100;
                uint ms = milliseconds - mod;
                for (int i = 0; i < ms; i += 50)
                {
                    called = false;
                    Mode0(20);
                    while (!called) { }
                }
                called = false;
                ms = mod % 2;
                for (int i = 0; i < ms; i += 2)
                {
                    called = false;
                    Mode0(500);
                    while (!called) { }
                }
                called = false;
            }
        }
    }
}
