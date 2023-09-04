/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using System.Collections.Generic;
//Some code was used in GruntTheDivine's infinity kernel. He gave permission for it to be made public.
namespace Medli.System.Framework.Core
{
    public class IRQ
    {
        public static void SetMask(byte IRQline)
        {
            Medli.Core.Framework.IRQ.SetMask(IRQline);
        }
        public static void ClearMask(byte IRQline)
        {
            Medli.Core.Framework.IRQ.ClearMask(IRQline);
        }
    }
}
