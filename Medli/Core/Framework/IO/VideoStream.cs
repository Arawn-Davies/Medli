/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.



using System;
using System.Collections.Generic;
// Have to optimize that..
// Grunt: Probally want to make this inherit Stream???? 
// Splitty: I will try it later =)
namespace Medli.Core.Framework.IO
{
    public unsafe class VideoStream
    {
        private MemoryStream stream;
        public VideoStream()
        {
            stream = new MemoryStream((byte*)0xB8000);
        }
        public byte ReadByte(uint p)
        {
            return stream.ReadByte(p);
        }
        public void WriteByte(uint p, byte b)
        {
            stream.WriteByte(p, b);
        }
    }
}
*/