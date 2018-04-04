using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Hardware
{
	public class ATAPI : Core.BusIO
	{
		private const UInt16 SectorSize = 2048;
		private const UInt32 LBA = 0;
		public static UInt16[] DataBuffer = new UInt16[256];
		public static bool IRQReceived = false;

		public static void HandleIRQ(ref Cosmos.Core.INTs.IRQContext aContext)
		{
			Console.WriteLine("IRQ15");
			IRQReceived = true;
		}

		public static void PrintBuffer()
        {
            for (int p = 0; p < 256; p++)
            {
                if (p != 255)
                {
                    Console.Write(DataBuffer[p].ToString() + ",");
                }
                else
                {
                    Console.WriteLine(DataBuffer[p].ToString());
                }
            }
        }

		public static void Init()
		{
			//Secondary
			Cosmos.Core.INTs.SetIrqHandler(0x0F, HandleIRQ);
			Write8(0x1F6, 0xA0);//Enable IRQs
			Write8(0x3F6, 0x00);//Enable IRQs
		}

		public static void ReadBlock(ulong aBlockNo, ulong aBlockCount, byte[] aData)
		{
			IRQReceived = false;
			Write8(0x1F6, (0xA0 | (1 << 4)));
			Write8(0x1F1, 0);//Not DMA

			Write8(0x1F4, (byte)(SectorSize & 0xff));
			Write8(0x1F5, (byte)(SectorSize >> 8));
			Write8(0x1F7, 0xA0);

			byte status = 0;
			bool ReadIsOk = false;
			for (int i = 0; i < 500; i++)
			{
				status = Read8(0x1F7);
				if ((status & 0xff) != 0x1)
				{
					ReadIsOk = true;
					break;
				}
			}
			if (ReadIsOk == true)
			{
				Console.WriteLine("Ok to Transfer!");
			}
			else
			{
				Console.WriteLine("TimeOut!");
			}


			Write8(0x1F0, 0xA8);//Read Sector
			Write8(0x1F0, 0);
			Write8(0x1F0, (byte)((LBA >> 0x18) & 0xFF));//MSB
			Write8(0x1F0, (byte)((LBA >> 0x10) & 0xFF));
			Write8(0x1F0, (byte)((LBA >> 0x08) & 0xFF));
			Write8(0x1F0, (byte)((LBA >> 0x00) & 0xFF));//LSB
			Write8(0x1F0, 0);
			Write8(0x1F0, 0);
			Write8(0x1F0, 0);
			Write8(0x1F0, 1);//Sector Count
			Write8(0x1F0, 0);
			Write8(0x1F0, 0);


			while (IRQReceived == false) { }

			for (int i = 0; i < 256; i++)
			{
				DataBuffer[i] = Read16(0x1F0);
			}
			IRQReceived = false;
		}

		public static void WriteBlock(ulong aBlockNo, ulong aBlockCount, byte[] aData)
		{
			throw new NotImplementedException();
		}
	}
}
