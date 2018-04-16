using System;
using System.Collections.Generic;
using System.Text;
using static Cosmos.Core.INTs;
using IL2CPU.API.Attribs;
using Medli.Common;
using IRQContext = Cosmos.Core.INTs.IRQContext;

namespace Medli.Core
{
	[Plug(Target = typeof(Cosmos.Core.INTs))]
	public class INTs
	{
		private static uint mlastKnownAddress;
		public static void HandleInterrupt_00(ref IRQContext aContext) {
			HandleException( "Divide by zero", "EDivideByZero", ref aContext, aContext.EIP); }
		public static void HandleInterrupt_01(ref IRQContext aContext) {
			HandleException( "Debug Exception", "Debug Exception", ref aContext); }
		public static void HandleInterrupt_02(ref IRQContext aContext) {
			HandleException( "Non Maskable Interrupt Exception", "Non Maskable Interrupt Exception", ref aContext); }
		public static void HandleInterrupt_03(ref IRQContext aContext) {
			HandleException( "Breakpoint Exception", "Breakpoint Exception", ref aContext); }
		public static void HandleInterrupt_04(ref IRQContext aContext) {
			HandleException( "Into Detected Overflow Exception", "Into Detected Overflow Exception", ref aContext); }
		public static void HandleInterrupt_05(ref IRQContext aContext) {
			HandleException( "Out of Bounds Exception", "Out of Bounds Exception", ref aContext); }
		public static void HandleInterrupt_06(ref IRQContext aContext)
		{
			// although mLastKnownAddress is a static, we need to get it here, any subsequent calls will change the value!!!
			var xLastKnownAddress = mlastKnownAddress;
			HandleException( "Invalid Opcode", "EInvalidOpcode", ref aContext, xLastKnownAddress);
		}
		public static void HandleInterrupt_07(ref IRQContext aContext) {
			HandleException( "No Coprocessor Exception", "No Coprocessor Exception", ref aContext); }
		public static void HandleInterrupt_08(ref IRQContext aContext) {
			HandleException( "Double Fault Exception", "Double Fault Exception", ref aContext); }
		public static void HandleInterrupt_09(ref IRQContext aContext) {
			HandleException( "Coprocessor Segment Overrun Exception", "Coprocessor Segment Overrun Exception", ref aContext); }
		public static void HandleInterrupt_0A(ref IRQContext aContext) {
			HandleException( "Bad TSS Exception", "Bad TSS Exception", ref aContext); }
		public static void HandleInterrupt_0B(ref IRQContext aContext) {
			HandleException( "Segment Not Present", "Segment Not Present", ref aContext); }
		public static void HandleInterrupt_0C(ref IRQContext aContext) {
			HandleException( "Stack Fault Exception", "Stack Fault Exception", ref aContext); }
		public static void HandleInterrupt_0D(ref IRQContext aContext)
		{
			if (GeneralProtectionFault != null)
			{
				GeneralProtectionFault(ref aContext);
			}
			else
			{
				HandleException( "General Protection Fault", "GPF", ref aContext);
			}
		}

		public static void HandleInterrupt_0E(ref IRQContext aContext) {
			HandleException( "Page Fault Exception", "Page Fault Exception", ref aContext); }
		public static void HandleInterrupt_0F(ref IRQContext aContext) {
			HandleException( "Unknown Interrupt Exception", "Unknown Interrupt Exception", ref aContext); }
		public static void HandleInterrupt_10(ref IRQContext aContext) {
			HandleException( "x87 Floating Point Exception", "Coprocessor Fault Exception", ref aContext); }
		public static void HandleInterrupt_11(ref IRQContext aContext) {
			HandleException( "Alignment Exception", "Alignment Exception", ref aContext); }
		public static void HandleInterrupt_12(ref IRQContext aContext) {
			HandleException( "Machine Check Exception", "Machine Check Exception", ref aContext); }
		public static void HandleInterrupt_13(ref IRQContext aContext) {
			HandleException( "SIMD Floating Point Exception", "SIMD Floating Point Exception", ref aContext); }

		/// <summary>
		/// Handles kernel exceptions (DIVIDE BY ZERO etc.)
		/// </summary>
		/// <param name="eDescription">Exception description</param>
		/// <param name="eName">Name of the exception</param>
		/// <param name="context">Cause of the exception</param>
		/// <param name="LastKnownAddressValue">Last known address in memory (Where in RAM the exception occurred)</param>
		private static void HandleException(string eDescription, string eName, ref IRQContext context, uint LastKnownAddressValue = 0)
		{
			const string hexadecimal = "0123456789ABCDEF";
			string contextinterrupt = "";
			contextinterrupt = contextinterrupt + hexadecimal[(int)((context.Interrupt >> 4) & 0xF)];
			contextinterrupt = contextinterrupt + hexadecimal[(int)(context.Interrupt & 0xF)];

			string LKA = "";
			if (LastKnownAddressValue != 0)
			{
				LKA = LKA + hexadecimal[(int)((LastKnownAddressValue >> 28) & 0xF)];
				LKA = LKA + hexadecimal[(int)((LastKnownAddressValue >> 24) & 0xF)];
				LKA = LKA + hexadecimal[(int)((LastKnownAddressValue >> 20) & 0xF)];
				LKA = LKA + hexadecimal[(int)((LastKnownAddressValue >> 16) & 0xF)];
				LKA = LKA + hexadecimal[(int)((LastKnownAddressValue >> 12) & 0xF)];
				LKA = LKA + hexadecimal[(int)((LastKnownAddressValue >> 8) & 0xF)];
				LKA = LKA + hexadecimal[(int)((LastKnownAddressValue >> 4) & 0xF)];
				LKA = LKA + hexadecimal[(int)(LastKnownAddressValue & 0xF)];

			}

			FatalError.Crash(eName, eDescription, LKA, contextinterrupt);
		}
	}
}