using System;
using System.Collections.Generic;
using Sys = Cosmos.System;
using Medli.Common;
using Medli.System;

namespace Medli
{
    public static partial class Kernel
    {
		public static List<Service> Services = new List<Service>();
        public static System.AConsole.Console AConsole;
        public static string Consolemode = "VGATextmode";
        public static Cosmos.HAL.PCSpeaker speaker = new Cosmos.HAL.PCSpeaker();
    }
}
