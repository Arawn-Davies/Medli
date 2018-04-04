using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace Medli.Common
{
	public enum KernelAreas
	{
		CPU,
		RAM,
		Core,
		HAL,
		SYS,
		Kernel,
		Userspace,
		FS,
		IO
	}
    public class KernelProperties
    {
		public static bool Running;
		public static string KernelVersion = "0.0.1";

    }
}
