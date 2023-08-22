using System;
using System.Collections.Generic;
using System.Text;
using IL2CPU.API.Attribs;
using Cosmos.Core;
using AIC.Core.IO;

namespace Medli.Core
{
	public class BusIO
	{
		protected static void Write8(UInt16 aPort, byte aData)
		{
            PortIO.OutB(aPort, aData);
		}
		static protected void Write16(UInt16 aPort, UInt16 aData)
		{
            PortIO.OutW(aPort, aData);
        }
		protected static void Write32(UInt16 aPort, UInt32 aData)
		{
            PortIO.OutL(aPort, aData);
        }
		protected static byte Read8(UInt16 aPort)
		{
            return PortIO.InB(aPort);
		}
		protected static UInt16 Read16(UInt16 aPort)
		{
            return PortIO.InW(aPort);
		}
		protected static UInt32 Read32(UInt16 aPort)
		{
            return PortIO.InL(aPort);
		}
	}
}
