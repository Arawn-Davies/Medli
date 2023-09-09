/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using Medli.Core.Framework;
using IO = Medli.Core.Framework.IO;

namespace Medli.System.Framework.Core
{
    public static class PIT
    {
        public static void Mode0(uint frequency)
        {
            Medli.Core.Framework.PIT.Mode0(frequency);
        }
        public static void Mode2(uint frequency)
        {
            Medli.Core.Framework.PIT.Mode2(frequency);
        }
        public static void Beep(uint frequency)
        {
            Medli.Core.Framework.PIT.Beep(frequency);
        }

        public static void SleepSeconds(uint seconds)
        {
            SleepMilliseconds(seconds * 1000);
        }
        public static void SleepMilliseconds(uint milliseconds)
        {
            Medli.Core.Framework.PIT.SleepMilliseconds(milliseconds);
        }
    }
}
