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
    public abstract class Stream
    {
        public static bool canRead;
        public static bool canWrite;
        public static uint Position;
        public static byte Read()
        {
            if (canRead)
            {
                uint tmp = Position;
                Position++;
                return Stream.ReadByte(tmp);
            }
            else
                throw new Exception("Can not read!");
        }
        public static void Write(byte b)
        {
            if (canWrite)
            {
                uint tmp = Position;
                Position++;
                Stream.WriteByte(tmp, b);
            }
            else
                throw new Exception("Can not Write!");
        }
        public static void Flush()
        {
        }
        public static void Close()
        {
            Flush();
        }
        public static byte ReadByte(uint p)
        {
            throw new Exception("Read not implemented!");
        }
        public static byte WriteByte(uint p, byte b)
        {
            throw new Exception("Write not implemented!");
        }
    }
}
