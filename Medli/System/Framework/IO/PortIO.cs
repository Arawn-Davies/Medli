/*
Copyright (c) 2012-2013, dewitcher Team
All rights reserved.

Redistribution and use in source and binary forms, with or without modification,
are permitted provided that the following conditions are met:

* Redistributions of source code must retain the above copyright notice
   this list of conditions and the following disclaimer.

* Redistributions in binary form must reproduce the above copyright notice,
  this list of conditions and the following disclaimer in the documentation
  and/or other materials provided with the distribution.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR
IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR
CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER
IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF
THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

namespace Medli.System.Framework.IO
{
    public static class PortIO
    {
        /// <summary>
        /// Reads a byte
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public static byte inb(ushort port)
        {
            return Cosmos.Core.IOPort.Read8(port);
        }
        /// <summary>
        /// Reads a 16 bit word
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public static ushort inw(ushort port)
        {
            return Cosmos.Core.IOPort.Read16(port);
        }
        /// <summary>
        /// Reads a 32 bit word
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public static uint InL(ushort port)
        {
            return Cosmos.Core.IOPort.Read16(port);
        }
        /// <summary>
        /// Writes a byte
        /// </summary>
        /// <param name="port"></param>
        /// <param name="data"></param>
        public static void OutB(ushort port, byte data)
        {
            Cosmos.Core.IOPort.Write8(port, data);
        }
        /// <summary>
        /// Writes a 16 bit word
        /// </summary>
        /// <param name="port"></param>
        /// <param name="data"></param>
        public static void OutW(ushort port, ushort data)
        {
            Cosmos.Core.IOPort.Write16(port, data);
        }
        /// <summary>
        /// Writes a 32 bit word
        /// </summary>
        /// <param name="port"></param>
        /// <param name="data"></param>
        public static void OutL(ushort port, uint data)
        {
            Cosmos.Core.IOPort.Write32(port, data);
        }
    }
}
