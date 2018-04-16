using System;
using System.Collections.Generic;
using System.Text;
using IL2CPU.API.Attribs;
using Cosmos.Core;

namespace Medli.Core
{
	public class BusIOPort
	{
		protected static IOPort IO;
		public static UInt16 Port;

		public BusIOPort(UInt16 port)
		{
			Port = port;
			IO = new IOPort(port);
		}

		public byte Byte
		{
			get
			{
				return IO.Byte;
			}
			set
			{
				IO.Byte = Byte;
			}
		}
		public UInt16 Word
		{
			get
			{
				return IO.Word;
			}
			set
			{
				IO.Word = Word;
			}
		}
		public UInt32 DWord
		{
			get
			{
				return IO.DWord;
			}
			set
			{
				IO.DWord = DWord;
			}
		}
	}

	public abstract class BusIO
	{
		protected static void Write8(UInt16 aPort, byte aData)
		{
			IOPort port = new IOPort(aPort);
			port.Byte = aData;
		}
		static protected void Write16(UInt16 aPort, UInt16 aData)
		{
			IOPort port = new IOPort(aPort);
			port.Word = aData;
		}
		protected static void Write32(UInt16 aPort, UInt32 aData)
		{
			IOPort port = new IOPort(aPort);
			port.DWord = aData;
		}

		protected static byte Read8(UInt16 aPort)
		{
			IOPort port = new IOPort(aPort);
			return port.Byte;
		}
		protected static UInt16 Read16(UInt16 aPort)
		{
			IOPort port = new IOPort(aPort);
			return port.Word;
		}
		protected static UInt32 Read32(UInt16 aPort)
		{
			IOPort port = new IOPort(aPort);
			return port.DWord;
		}

		protected static void WriteByte(ushort aPort, byte aData)
		{
			IOPort port = new IOPort(aPort);
			port.Byte = aData;
		}
		static protected void WriteWord(ushort aPort, ushort aData)
		{
			IOPort port = new IOPort(aPort);
			port.Word = aData;
		}
		protected static void WriteDWord(ushort aPort, UInt32 aData)
		{
			IOPort port = new IOPort(aPort);
			port.DWord = aData;
		}

		protected static byte ReadByte(ushort aPort)
		{
			IOPort port = new IOPort(aPort);
			return port.Byte;
		}
		protected static UInt16 ReadWord(ushort aPort)
		{
			IOPort port = new IOPort(aPort);
			return port.Word;
		}
		protected static UInt32 ReadDWord(ushort aPort)
		{
			IOPort port = new IOPort(aPort);
			return port.DWord;
		}
	}
}
