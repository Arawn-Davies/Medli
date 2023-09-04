/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using System.Collections.Generic;
using Medli.Core.Framework;
// IDT code by Grunt
namespace Medli.Core.Framework
{
    public class IDT
    {
        public delegate void ISR();
        public static ISR[] idt = new ISR[0xFF];
        public static void Remap()
        {
            IO.PortIO.OutB(0x20, 0x11);
            IO.PortIO.OutB(0xA0, 0x11);
            IO.PortIO.OutB(0x21, 0x20);
            IO.PortIO.OutB(0xA1, 0x28);
            IO.PortIO.OutB(0x21, 0x04);
            IO.PortIO.OutB(0xA1, 0x02);
            IO.PortIO.OutB(0x21, 0x01);
            IO.PortIO.OutB(0xA1, 0x01);
            IO.PortIO.OutB(0x21, 0x0);
            IO.PortIO.OutB(0xA1, 0x0);
        }
        public static void idt_handler()
        {
            int num = 0;
            if (idt[num] != null)
            {
                idt[num]();
            }
        }

        public static void SetGate(byte int_num, ISR handler)
        {
            idt[int_num] = handler;
        }

    }
}
