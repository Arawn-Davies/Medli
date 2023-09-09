/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using System.Collections.Generic;
using Cosmos.Core;

namespace Medli.Core.Framework.IO
{
    public static class PortIO
    {
        /// <summary>
        /// Reads a byte
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public static byte InB(ushort port)
        {
            IOPort io = new IOPort(port);
            return io.Byte;
            //return IOPort.Read8(port);
        }
        /// <summary>
        /// Reads a 16 bit word
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public static ushort InW(ushort port)
        {
            IOPort io = new IOPort(port);
            return io.Word;
            //return IOPort.Read16(port);
        }
        /// <summary>
        /// Reads a 32 bit word
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public static uint InL(ushort port)
        {
            IOPort io = new IOPort(port);
            return io.DWord;
            //return IOPort.Read32(port);
        }
        /// <summary>
        /// Writes a byte
        /// </summary>
        /// <param name="port"></param>
        /// <param name="data"></param>
        public static void OutB(ushort port, byte data)
        {
            IOPort io = new IOPort(port);
            io.Byte = data;
            //IOPort.Write8(port, data);
        }
        /// <summary>
        /// Writes a 16 bit word
        /// </summary>
        /// <param name="port"></param>
        /// <param name="data"></param>
        public static void OutW(ushort port, ushort data)
        {
            IOPort io = new IOPort(port);
            io.Word = data;
            //IOPort.Write16(port, data);
        }
        /// <summary>
        /// Writes a 32 bit word
        /// </summary>
        /// <param name="port"></param>
        /// <param name="data"></param>
        public static void OutL(ushort port, uint data)
        {
            IOPort io = new IOPort(port);
            io.DWord = data;
            //IOPort.Write32(port, data);
        }
    }
}
