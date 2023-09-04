/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using System.Collections.Generic;
// IDT code by Grunt
namespace Medli.System.Framework.Core
{
    public class IDT
    {
        public delegate void ISR();
        public static ISR[] idt = new ISR[0xFF];
        public static void Remap()
        {
            Medli.Core.Framework.IDT.Remap();
        }
        private void idt_handler()
        {
            Medli.Core.Framework.IDT.idt_handler();
        }

        public static void SetGate(byte int_num, ISR handler)
        {
            SetGate(int_num, handler);
        }

    }
}
