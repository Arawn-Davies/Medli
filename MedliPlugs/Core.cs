using System;
using IL2CPU.API.Attribs;
using Cosmos.Core;
using AIC.Main;
using static Cosmos.Core.INTs;

namespace AICPlugs
{
    [Plug(Target = typeof(Cosmos.Core.INTs))]
    public class INTs
    {
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
            Bluescreen.Panic(aName, aDescription, LastKnownAddress, ref ctx);
        }
    }
}
