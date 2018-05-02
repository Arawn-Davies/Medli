using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Hardware.Drivers.Storage
{
	class FDD : Core.Device
	{
		//It would be Better  to create a Device Class
		//if u  create all storage drivers can use ReadBlock, WriteBlock Etc.

		private static byte status = 0;
		private static byte[] DataBuffer = new byte[512];

		public static DeviceStatus Status = DeviceStatus.Unknown;

		public static void PrintBuffer()
		{
			for (int p = 0; p < 512; p++)
			{
				if (p != 511)
				{
					Console.Write(DataBuffer[p].ToString() + ",");
				}
				else
				{
					Console.WriteLine(DataBuffer[p].ToString());
				}
			}
		}

		public enum DeviceStatus
		{
			TimeOut = 1,
			Reset = 2,
			Unknown = 3,
			DriverTooSlow = 4,
			WriteProtect = 5,
			TransferError = 6,
		}

		private enum Controller
		{
			STRA = 0x3F0, // read-only
			STRB = 0x3F1, // read-only
			DOR = 0x3F2,
			TDR = 0x3F3,
			MSR = 0x3F4, // read-only
			DSR = 0x3F4, // write-only
			DF = 0x3F5,
			DIR = 0x3F7, // read-only
			CCR = 0x3F7  // write-only
		};

		private static bool IRQReceived = false;

		public static void Init(bool force)
		{
			Cosmos.Core.INTs.SetIrqHandler(0x06, HandleIRQ);
			if ((byte)GetVersion() == 0x90 & force == false)
			{
				ResetFloppyEx();
			}
			else if (force == true)
			{
				ResetFloppyEx();
			}
			else
			{
				//Device is Not Suported So how can you know the Status?
				Status = DeviceStatus.Unknown;
			}
		}

		public static void HandleIRQ(ref Cosmos.Core.INTs.IRQContext aContext)
		{
			Console.WriteLine("IRQ6");
			IRQReceived = true;
		}

		private static byte GetVersion()
		{
			Write8((ushort)Controller.DF, 0x10);//Specify
			return Read8((ushort)Controller.DF);
		}

		private static void ResetFloppyEx()
		{
			IRQReceived = false;
			// Enter, then exit reset mode.
			Write8((ushort)Controller.DSR, 0x02);
			Write8((ushort)Controller.DOR, 0x08);//No IRQs
			for (int i = 0; i < 500; i++)
			{
				status = Read8((ushort)Controller.MSR);
				if ((status & 0x80) == 0x80)
				{
					Status = DeviceStatus.Reset;
					break;
				}
				else if (i == 499)
				{
					Status = DeviceStatus.TimeOut;
				}
			}
			for (int i = 0; i < 4; i++)
			{
				SenseInterrupt(true);
			}
			Write8((ushort)Controller.CCR, 0x00);// 500Kbps -- for 1.44M floppy
			Specify(1);
		}

		private static void Specify(byte PIOEnable)
		{
			Write8((ushort)Controller.DF, 0x3);//Specify
			Write8((ushort)Controller.DF, (8 << 4) | 0xf);//SRT_value = 8 << 4 | HUT_value = 15
			Write8((ushort)Controller.DF, (5 << 1) | 0x1);//HLT_value = 5 << 1 | NDMA = 1
		}

		private static void SenseInterrupt(bool isReset)
		{
			Write8((ushort)Controller.DF, 0x08);
			for (int i = 0; i < 500; i++)
			{
				status = Read8((ushort)Controller.STRA);
				if ((status & 0xC0) == 0xC0 & isReset == true)
				{
					break;
				}
				else if ((status & 0x20) == 0x20 & isReset == false)
				{
					break;
				}
			}
		}
		//Switch to LBA addressing instead
		public static void ReadBlock(byte head, byte drive, byte cylinder, byte sector)
		{
			//MT bit = 0x80
			//MFM bit = 0x40
			//Need some code to check if seeking pass cylinder 
			Write8((ushort)Controller.DF, (0x40 | 0x06));
			Write8((ushort)Controller.DF, (byte)((head << 2) | drive));
			Write8((ushort)Controller.DF, cylinder);
			Write8((ushort)Controller.DF, (byte)((head << 2) | drive));
			Write8((ushort)Controller.DF, sector);
			Write8((ushort)Controller.DF, 0x2);
			Write8((ushort)Controller.DF, 0x1);//one sector
			Write8((ushort)Controller.DF, 0x1b);
			Write8((ushort)Controller.DF, 0xff);

			//Transfer Data
			for (int i = 0; i < 100; i++)
			{
				if ((Read8((ushort)Controller.MSR) & 0x80) == 0x80)
				{
					//Transfer Data
					for (int p = 0; p < 512; p++)
					{
						DataBuffer[p] = Read8((ushort)Controller.DF);
					}
					break;
				}
				else if (i == 499)
				{
					Status = DeviceStatus.TimeOut;
				}
			}

			for (int i = 0; i < 500; i++)
			{
				status = Read8((ushort)Controller.STRB);
				if ((status & 0x2) == 0x2)
				{
					Status = DeviceStatus.TransferError;
					break;
				}
				else if ((status & 0x10) == 0x10)
				{
					Status = DeviceStatus.DriverTooSlow;
					break;
				}
				else if ((status & 0x2) == 0x2)
				{
					Status = DeviceStatus.WriteProtect;
					break;
				}
			}
		}
		//Switch to LBA addressing instead
		public static void WriteBlock(byte head, byte drive, byte cylinder, byte sector)
		{
			//MT bit = 0x80
			//MFM bit = 0x40
			//Need some code to check if seeking pass cylinder 
			Write8((ushort)Controller.DF, (0x40 | 0x05));
			Write8((ushort)Controller.DF, (byte)((head << 2) | drive));
			Write8((ushort)Controller.DF, cylinder);
			Write8((ushort)Controller.DF, (byte)((head << 2) | drive));
			Write8((ushort)Controller.DF, sector);
			Write8((ushort)Controller.DF, 0x2);
			Write8((ushort)Controller.DF, 0x1);//one sector
			Write8((ushort)Controller.DF, 0x1b);
			Write8((ushort)Controller.DF, 0xff);

			//Transfer Data
			for (int i = 0; i < 100; i++)
			{
				if ((Read8((ushort)Controller.MSR) & 0x80) == 0x80)
				{
					//Transfer Data
					for (int p = 0; p < 512; p++)
					{
						Write8((ushort)Controller.DF, DataBuffer[p]);
					}
					break;
				}
				else if (i == 499)
				{
					Status = DeviceStatus.TimeOut;
				}
			}

			for (int i = 0; i < 500; i++)
			{
				status = Read8((ushort)Controller.STRB);
				if ((status & 0x2) == 0x2)
				{
					Status = DeviceStatus.TransferError;
					break;
				}
				else if ((status & 0x10) == 0x10)
				{
					Status = DeviceStatus.DriverTooSlow;
					break;
				}
				else if ((status & 0x2) == 0x2)
				{
					Status = DeviceStatus.WriteProtect;
					break;
				}
			}
		}
	}
}