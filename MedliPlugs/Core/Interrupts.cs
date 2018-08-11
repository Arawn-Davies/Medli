using IL2CPU.API.Attribs;
using Medli.Common;
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

            FatalError.Crash(aName, aDescription, LastKnownAddress, ctxinterrupt);
        }
    }
}