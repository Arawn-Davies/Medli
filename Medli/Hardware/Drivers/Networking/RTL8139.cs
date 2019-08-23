using System;
using System.Collections.Generic;
using System.Text;
using Medli.Hardware;
using Medli.Core;
using Cosmos.HAL;
using Cosmos.Core;

namespace Medli.Hardware.Drivers.Networking
{
	public class RTL8139 : BusIO
	{
		static byte[] rxbuffer = new byte[8192 + 16 + 1500];

		private const ushort IOAddr = 0;
		public enum Regs
		{
			MAC0_5 = IOAddr + 0x00,
			MAR0_7 = IOAddr + 0x08,
			RBSTART = IOAddr + 0x30,
			CMD = IOAddr + 0x37,
			IMR = IOAddr + 0x3C,
			ISR = IOAddr + 0x3E,
			RCR = IOAddr + 0x44,
		}
		public static void Init()
		{
			INTs.SetIrqHandler(0x07, HandleIRQ2);
			SoftReset();
			InitRxBuffer();
		}

		public static void HandleIRQ2(ref INTs.IRQContext aContext)
		{
			Console.WriteLine("IRQ2");
		}

		public static void SoftReset()
		{
			Write8((ushort)Regs.CMD, 0x10);//Software Reset
										   //Check If Device is still in reset mode
			for (int i = 0; i < 100; i++)
			{
				if ((Read8((ushort)Regs.CMD) & 0x10) != 0x10)
				{
					break;
				}
			}
		}

		private unsafe static void InitRxBuffer()
		{
			uint pointer;

			fixed (byte* ptr = &rxbuffer[0])
			{
				uint* p = (uint*)ptr;
				pointer = (uint)&p;
			}
			Write32((ushort)Regs.RBSTART, pointer);
			Write16((ushort)Regs.IMR, 0x0005);// Sets the TOK and ROK bits high //Enable IRQs
			Write16((ushort)Regs.RCR, 0xf | (1 << 7)); // (1 << 7) is the WRAP bit, 0xf is AB+AM+APM+AAP
			Write8((ushort)Regs.CMD, 0x0C);
		}
	}
}
