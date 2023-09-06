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
    public class BinaryWriter
    {
        public static Stream BaseStream;
        public BinaryWriter(Stream stream)
        {
            BaseStream = stream;
        }
        public static void Write(byte dat)
        {
            BinaryWriter.Write(dat);
        }
        public static void Write(short dat)
        {
            byte[] data = BitConverter.GetBytes(dat);
            for (int i = 0; i < data.Length; i++)
                Write(data[i]);
        }
        public static void Write(int dat)
        {
            byte[] data = BitConverter.GetBytes(dat);
            for (int i = 0; i < data.Length; i++)
                Write(data[i]);
        }
        public static void Write(long dat)
        {
            byte[] data = BitConverter.GetBytes(dat);
            for (int i = 0; i < data.Length; i++)
                Write(data[i]);
        }
        public static void Write(ushort dat)
        {
            byte[] data = BitConverter.GetBytes(dat);
            for (int i = 0; i < data.Length; i++)
                Write(data[i]);
        }
        public static void Write(uint dat)
        {
            byte[] data = BitConverter.GetBytes(dat);
            for (int i = 0; i < data.Length; i++)
                Write(data[i]);
        }
        public static void Write(ulong dat)
        {
            byte[] data = BitConverter.GetBytes(dat);
            for (int i = 0; i < data.Length; i++)
                Write(data[i]);
        }
        public static void Write(bool dat)
        {
            if (dat)
                Write((byte)1);
            else
                Write((byte)0);
        }
        public static void Write(byte[] data)
        {
            for (int i = 0; i < data.Length; i++)
                Write(data[i]);
        }
        public static void Write(string dat)
        {
            Write((ushort)dat.Length);
            foreach (byte b in dat)
            {
                Write(b);
            }
        }
    }
}
