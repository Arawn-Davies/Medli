using System;
using System.Collections.Generic;
using System.Text;
using XSharp;
using XSharp.Assembler;
using XSharp.x86;
using IL2CPU.API.Attribs;
using Cosmos.Core;

namespace Medli.Core
{
	public abstract class BusIO
	{
		//TODO: Reads and writes can use this to get port instead of argument
		static protected void Write8(UInt16 aPort, byte aData) { } // Plugged
		static protected void Write16(UInt16 aPort, UInt16 aData) { } // Plugged
		static protected void Write32(UInt16 aPort, UInt32 aData) { } // Plugged

		static protected byte Read8(UInt16 aPort) { return 0; } // Plugged
		static protected UInt16 Read16(UInt16 aPort) { return 0; } // Plugged
		static protected UInt32 Read32(UInt16 aPort) { return 0; } // Plugged
	}

	[Plug(Target = typeof(BusIO))]
	public class BusIOImpl
	{
		public static void Write8(UInt16 aPort, byte aData)
		{
			//TODO: This is a lot of work to write to a single port.
			// We need to have some kind of inline ASM option that can
			// emit a single out instruction
			IOPort io = new IOPort(aPort);
			io.Byte = aData;
		}
		public static void Write16(UInt16 aPort, UInt16 aData)
		{
			IOPort io = new IOPort(aPort);
			io.Word = aData;
		}
		public static void Write32(UInt16 aPort, UInt32 aData)
		{
			IOPort io = new IOPort(aPort);
			io.DWord = aData;
		}
		public static byte Read8(UInt16 aPort)
		{
			IOPort io = new IOPort(aPort);
			return io.Byte;
		}

		public static UInt16 Read16(UInt16 aPort)
		{
			IOPort io = new IOPort(aPort);
			return io.Word;
		}
		public static UInt32 Read32(UInt16 aPort)
		{
			IOPort io = new IOPort(aPort);
			return io.DWord;
		}
	}
}
