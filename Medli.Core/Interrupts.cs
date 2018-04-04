using System;
using System.Collections.Generic;
using System.Text;
using static Cosmos.Core.INTs;
using IL2CPU.API.Attribs;

namespace Medli.Core
{
	[Plug(Target = typeof(Cosmos.Core.INTs))]
    public class Interrupts
    {
		/// <summary>
		/// Handles kernel exceptions (DIVIDE BY ZERO etc.)
		/// </summary>
		/// <param name="eDescription">Exception description</param>
		/// <param name="eName">Name of the exception</param>
		/// <param name="context">Cause of the exception</param>
		/// <param name="LastKnownAddressValue">Last known address in memory (Where in RAM the exception occurred)</param>
		public static void ExceptionHandler(string eDescription, string eName, ref IRQContext context, uint LastKnownAddressValue = 0)
		{
			const string hexadecimal = "0123456789ABCDEF";
			string contextinterrupt = "";
			contextinterrupt = contextinterrupt + hexadecimal[(int) ((context.Interrupt >> 4) & 0xF)];
			contextinterrupt = contextinterrupt + hexadecimal[(int) (context.Interrupt & 0xF)];

			string LKA = "";
			if (LastKnownAddressValue != 0)
			{
				LKA = LKA + hexadecimal[(int) ((LastKnownAddressValue >> 28) & 0xF)];
				LKA = LKA + hexadecimal[(int) ((LastKnownAddressValue >> 24) & 0xF)];
				LKA = LKA + hexadecimal[(int) ((LastKnownAddressValue >> 20) & 0xF)];
				LKA = LKA + hexadecimal[(int) ((LastKnownAddressValue >> 16) & 0xF)];
				LKA = LKA + hexadecimal[(int) ((LastKnownAddressValue >> 12) & 0xF)];
				LKA = LKA + hexadecimal[(int) ((LastKnownAddressValue >> 8) & 0xF)];
				LKA = LKA + hexadecimal[(int) ((LastKnownAddressValue >> 4) & 0xF)];
				LKA = LKA + hexadecimal[(int) (LastKnownAddressValue & 0xF)];

			}

			FatalError.Crash(eName, eDescription, LKA, contextinterrupt);
		}
    }
}
