using System;
using System.Collections.Generic;
using System.Text;
using Medli.Core;

namespace Medli.Hardware.Drivers.Storage
{
	public class ATAPI : BusIO
	{
        public enum Cmd : byte
        {
            // Test Unit Ready
            TUR = 0x00,
            // Enable Write Cache
            EnableWC = 0x02,
            Inquiry = 0x12,
            // 28-bit verify
            V28 = 0x40,
            ReadPio = 0x20,
            ReadPioExt = 0x24,
            ReadDma = 0xC8,
            ReadDmaExt = 0x25,
            WritePio = 0x30,
            WritePioExt = 0x34,
            WriteDma = 0xCA,
            WriteDmaExt = 0x35,
            CacheFlush = 0xE7,
            CacheFlushExt = 0xEA,
            Packet = 0xA0,
            IdentifyPacket = 0xA1,
            Identify = 0xEC,
            Read = 0xA8,
            Eject = 0x1B,
            ReadTOC = 0x43
        }


        /*1F0 (Read and Write): Data Register
          1F1 (Read): Error Register
          1F1 (Write): Features Register
          1F2 (Read and Write): Sector Count Register
          1F3 (Read and Write): LBA Low Register
          1F4 (Read and Write): LBA Mid Register
          1F5 (Read and Write): LBA High Register
          1F6 (Read and Write): Drive/Head Register
          1F7 (Read): Status Register
          1F7 (Write): Command Register
          3F6 (Read): Alternate Status Register
          3F6 (Write): Device Control Register*/
        //Interrupt not working
        // private const byte[] ReadToc = { 0x43 , 0, 1, 0, 0, 0, 0, 0, 12, 0x40, 0, 0 };

        private const UInt16 SectorSize = 2048;
		private const UInt32 LBA = 0;
		public static UInt16[] DataBuffer = new UInt16[256];
		public static bool IRQReceived = false;
		public static void Init()
		{
			//Secondary
			Cosmos.Core.INTs.SetIrqHandler(0x0F, HandleIRQ);
			Write8(0x1F6, 0xA0);//Enable IRQs
			Write8(0x3F6, 0x00);//Enable IRQs
		}
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
					Console.Write(DataBuffer[p] + ",");
				}
				else
				{
					Console.WriteLine(DataBuffer[p]);
				}
			}
		}

        public static void Eject()
        {
            IRQReceived = false;
            Write8(0x1F7, (byte) Cmd.Packet);
            byte[] eject = new byte[12]
            {
                0x1B, 0, 0, 0, 0x02, 0, 0, 0, 0, 0, 0, 0
            };
            for (int i = 0; i < eject.Length; i++)
            {
                Write8(0x1F0, eject[i]);
            }

        }

		public static void ReadBlock(uint lba)
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
			Write8(0x1F0, (byte)((lba >> 0x18) & 0xFF));//MSB
			Write8(0x1F0, (byte)((lba >> 0x10) & 0xFF));
			Write8(0x1F0, (byte)((lba >> 0x08) & 0xFF));
			Write8(0x1F0, (byte)((lba >> 0x00) & 0xFF));//LSB
			Write8(0x1F0, 0);
			Write8(0x1F0, 0);
			Write8(0x1F0, 0);
			Write8(0x1F0, 1);//Sector Count
			Write8(0x1F0, 0);
			Write8(0x1F0, 0);

            Console.WriteLine("Sent ATAPI package");
            Console.WriteLine(IRQReceived);
            while (IRQReceived == true) ;

			for (int i = 0; i < 256; i++)
			{
				DataBuffer[i] = Read16(0x1F0);
			}
			IRQReceived = false;

		}
	}
}
