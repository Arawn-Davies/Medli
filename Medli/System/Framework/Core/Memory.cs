/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using System.Collections.Generic;
using Medli.Core.Framework;

namespace Medli.System.Framework.Core
{
    public static class Memory
    {
        public static void MemAlloc(uint length)
        {
            Medli.Core.Framework.Memory.MemAlloc(length);
        }
        public static void MemRemove(byte start, uint offset, uint length)
        {
            Medli.Core.Framework.Memory.MemRemove(start, offset, length);
        }
        public static void MemCopy(byte source, byte destination, uint offset, uint length)
        {
            Medli.Core.Framework.Memory.MemCopy(source, destination, offset, length);
        }
        public static void MemMove(byte source, byte destination, uint offset, uint length)
        {
            Medli.Core.Framework.Memory.MemMove(source, destination, offset, length);
        }
        public static bool MemCompare(byte source1, byte source2, uint offset, uint length)
        {
            return Medli.Core.Framework.Memory.MemCompare(source1, source2, offset, length);
        }
    }
}
