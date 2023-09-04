/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medli.Core.Framework.IO
{
    public unsafe class MemoryStream : Stream
    {
        private static bool eof;
        public static bool EOF { get { return eof; } }
        private static byte* data;
        private uint length;
        public MemoryStream(byte* dat)
        {
            eof = false;
            length = sizeof(uint);
            data = dat;
        }
        public MemoryStream(byte[] dat)
        {
            eof = false;
            length = (uint)dat.Length;
            fixed (byte* ptr = dat)
            {
                data = ptr;
            }
        }
        new internal byte ReadByte(uint p)
        {
            if (p > length) eof = true; else eof = false;
            if (!eof) return data[p];
            else return byte.MinValue;
        }
        new internal void WriteByte(uint p, byte b)
        {
            if (p > length) eof = true; else eof = false;
            if (!eof) data[p] = b;
        }
    }
}