﻿using System;
using System.Collections.Generic;
using System.Text;
using CCore = Cosmos.Core;
using IL2CPU.API.Attribs;
using Medli.Common;
using IRQContext = Cosmos.Core.INTs.IRQContext;

namespace Medli.Core
{
    [Plug(Target = typeof(Cosmos.Core.INTs))]
    public class INTs
	{
        //private static uint mlastKnownAddress;
        //public static void HandleInterrupt_00(ref IRQContext aContext) => HandleException(aContext.EIP, "Divide by zero", "EDivideByZero", ref aContext, aContext.EIP);
        //public static void HandleInterrupt_01(ref IRQContext aContext) => HandleException(aContext.EIP, "Debug Exception", "Debug Exception", ref aContext); 
        //public static void HandleInterrupt_02(ref IRQContext aContext) => HandleException(aContext.EIP, "Non Maskable Interrupt Exception", "Non Maskable Interrupt Exception", ref aContext); 
        //public static void HandleInterrupt_03(ref IRQContext aContext) => HandleException(aContext.EIP, "Breakpoint Exception", "Breakpoint Exception", ref aContext); 
        //public static void HandleInterrupt_04(ref IRQContext aContext) => HandleException(aContext.EIP, "Into Detected Overflow Exception", "Into Detected Overflow Exception", ref aContext); 
        //public static void HandleInterrupt_05(ref IRQContext aContext) => HandleException(aContext.EIP, "Out of Bounds Exception", "Out of Bounds Exception", ref aContext); 
        //public static void HandleInterrupt_06(ref IRQContext aContext) => HandleException(aContext.EIP, "Invalid Opcode", "EInvalidOpcode", ref aContext, mlastKnownAddress);

        //public static void HandleInterrupt_07(ref IRQContext aContext) => HandleException(aContext.EIP, "No Coprocessor Exception", "No Coprocessor Exception", ref aContext); 
        //public static void HandleInterrupt_08(ref IRQContext aContext) => HandleException(aContext.EIP, "Double Fault Exception", "Double Fault Exception", ref aContext); 
        //public static void HandleInterrupt_09(ref IRQContext aContext) => HandleException(aContext.EIP, "Coprocessor Segment Overrun Exception", "Coprocessor Segment Overrun Exception", ref aContext); 
        //public static void HandleInterrupt_0A(ref IRQContext aContext) => HandleException(aContext.EIP, "Bad TSS Exception", "Bad TSS Exception", ref aContext); 
        //public static void HandleInterrupt_0B(ref IRQContext aContext) => HandleException(aContext.EIP, "Segment Not Present", "Segment Not Present", ref aContext); 
        //public static void HandleInterrupt_0C(ref IRQContext aContext) => HandleException(aContext.EIP, "Stack Fault Exception", "Stack Fault Exception", ref aContext); 
        //public static void HandleInterrupt_0D(ref IRQContext aContext) => HandleException(aContext.EIP, "General Protection Fault", "GPF", ref aContext);

        //public static void HandleInterrupt_0E(ref IRQContext aContext) => HandleException(aContext.EIP, "Page Fault Exception", "Page Fault Exception", ref aContext);
        //public static void HandleInterrupt_0F(ref IRQContext aContext) => HandleException(aContext.EIP, "Unknown Interrupt Exception", "Unknown Interrupt Exception", ref aContext);
        //public static void HandleInterrupt_10(ref IRQContext aContext) => HandleException(aContext.EIP, "x87 Floating Point Exception", "Coprocessor Fault Exception", ref aContext);
        //public static void HandleInterrupt_11(ref IRQContext aContext) => HandleException(aContext.EIP, "Alignment Exception", "Alignment Exception", ref aContext);
        //public static void HandleInterrupt_12(ref IRQContext aContext) => HandleException(aContext.EIP, "Machine Check Exception", "Machine Check Exception", ref aContext); 
        //public static void HandleInterrupt_13(ref IRQContext aContext) => HandleException(aContext.EIP, "SIMD Floating Point Exception", "SIMD Floating Point Exception", ref aContext); 

        /// <summary>
        /// Handles kernel exceptions (DIVIDE BY ZERO etc.)
        /// </summary>
        /// <param name="eDescription">Exception description</param>
        /// <param name="eName">Name of the exception</param>
        /// <param name="context">Cause of the exception</param>
        /// <param name="LastKnownAddressValue">Last known address in memory (Where in RAM the exception occurred)</param>
        public static void HandleException(uint aEIP, string aDescription, string aName, ref IRQContext ctx, uint lastKnownAddressValue = 0)
        {
            const string xHex = "0123456789ABCDEF";

            string ctxinterrupt = "";
            ctxinterrupt = ctxinterrupt + xHex[(int)((ctx.Interrupt >> 4) & 0xF)];
            ctxinterrupt = ctxinterrupt + xHex[(int)(ctx.Interrupt & 0xF)];

            string lastsknowaddress = "";

            if (lastKnownAddressValue != 0)
            {
                lastsknowaddress = lastsknowaddress + xHex[(int)((lastKnownAddressValue >> 28) & 0xF)];
                lastsknowaddress = lastsknowaddress + xHex[(int)((lastKnownAddressValue >> 24) & 0xF)];
                lastsknowaddress = lastsknowaddress + xHex[(int)((lastKnownAddressValue >> 20) & 0xF)];
                lastsknowaddress = lastsknowaddress + xHex[(int)((lastKnownAddressValue >> 16) & 0xF)];
                lastsknowaddress = lastsknowaddress + xHex[(int)((lastKnownAddressValue >> 12) & 0xF)];
                lastsknowaddress = lastsknowaddress + xHex[(int)((lastKnownAddressValue >> 8) & 0xF)];
                lastsknowaddress = lastsknowaddress + xHex[(int)((lastKnownAddressValue >> 4) & 0xF)];
                lastsknowaddress = lastsknowaddress + xHex[(int)(lastKnownAddressValue & 0xF)];
            }

            FatalError.Crash(aName, aDescription, lastsknowaddress, ctxinterrupt);
        }
    }
}