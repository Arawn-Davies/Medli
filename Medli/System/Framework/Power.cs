/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using System.Text;
using Medli.Core.Framework;

namespace Medli.System.Framework
{
    public class Power
    {
        public static void Shutdown()
        {
			Cosmos.System.Power.Shutdown();
        }
        public static void Reboot()
        {
            Cosmos.System.Power.Reboot();
        }
    }
}