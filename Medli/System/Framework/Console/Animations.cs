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

namespace Medli.System.Framework
{
    public static partial class AConsole
    {
        public static class Animation
        {
            public static void RollUp(uint mspause)
            {
                for (int i = 0; i < 26; i++)
                {
                    for (int j = 0; j < 81; j++)
                    {
                        AConsole.Write(" ");
                    }
                    Medli.Core.Framework.PIT.SleepMilliseconds(mspause);
                }
                AConsole.Clear();
            }
            public static void RollDown(uint mspause)
            {
                for (int i = 0; i < 26; i++)
                {
                    for (int j = 0; j < 81; j++)
                    {
                        AConsole.Write(" ");
                        Medli.Core.Framework.PIT.SleepMilliseconds(mspause);
                    }
                }
                AConsole.Clear();
            }
        }
    }
}
