using IL2CPU.API.Attribs;
using System;
using static Cosmos.Core.INTs;

namespace MedliPlugs
{
    [Plug(Target = typeof(Cosmos.Core.INTs))]
    public class INTs
	{
        /// <summary>
        /// Handles kernel exceptions (DIVIDE BY ZERO etc.)
        /// </summary>
        /// <param name="eDescription">Exception description</param>
        /// <param name="eName">Name of the exception</param>
        /// <param name="context">Cause of the exception</param>
        /// <param name="LastKnownAddressValue">Last known address in memory (Where in RAM the exception occurred)</param>
        public static void HandleException(uint aEIP, string aDescription, string aName, ref IRQContext ctx, uint LastKnownAddressValue = 0)
        {
            string error = ctx.Interrupt.ToString();
            const string xHex = "0123456789ABCDEF";

            string ctxinterrupt = "";
            ctxinterrupt = ctxinterrupt + xHex[(int)((ctx.Interrupt >> 4) & 0xF)];
            ctxinterrupt = ctxinterrupt + xHex[(int)(ctx.Interrupt & 0xF)];

            string LastKnownAddress = "";

            if (LastKnownAddressValue != 0)
            {
                LastKnownAddress = LastKnownAddress + xHex[(int)((LastKnownAddressValue >> 28) & 0xF)];
                LastKnownAddress = LastKnownAddress + xHex[(int)((LastKnownAddressValue >> 24) & 0xF)];
                LastKnownAddress = LastKnownAddress + xHex[(int)((LastKnownAddressValue >> 20) & 0xF)];
                LastKnownAddress = LastKnownAddress + xHex[(int)((LastKnownAddressValue >> 16) & 0xF)];
                LastKnownAddress = LastKnownAddress + xHex[(int)((LastKnownAddressValue >> 12) & 0xF)];
                LastKnownAddress = LastKnownAddress + xHex[(int)((LastKnownAddressValue >> 8) & 0xF)];
                LastKnownAddress = LastKnownAddress + xHex[(int)((LastKnownAddressValue >> 4) & 0xF)];
                LastKnownAddress = LastKnownAddress + xHex[(int)(LastKnownAddressValue & 0xF)];
            }
            AIC_Framework.Bluescreen.Panic(aName, aDescription, LastKnownAddress, ref ctx);
        }
    }
    class FatalError
    {
        public const string ErrorSplash = @"A fatal error has occurred and Medli was shutdown to protect your computer
from further damage. If this is the first time you have seen this error, press
any key to restart your computer. This error may have occurred due to newly
installed or older failing hardware. 

Error information can be found below:";

        public static void Crash(string exception, string description, string lastknownaddress, string ctxinterrupt)
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Clear();

            Console.CursorTop += 1;
            Console.WriteLine(ErrorSplash);
            Console.CursorTop += 1;
            // Print exception information
            //Console.WriteLine("Kernel version: " + Kernel.KernelVersion);
            Console.WriteLine("CPU Exception: " + ctxinterrupt);
            Console.WriteLine("Exception: " + exception);
            Console.WriteLine("Exception description: " + description);
            if (lastknownaddress != "")
            {
                Console.WriteLine("Last known address: " + lastknownaddress);
            }
            Console.CursorTop = 24;
            Console.WriteLine("Press any key to restart...");
            Console.ReadKey(true);
            Cosmos.System.Power.Reboot();
        }
    }
}