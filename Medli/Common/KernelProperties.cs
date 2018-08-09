using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace Medli
{
    public partial class Kernel
    {
		public enum GFXDriver
		{
			VMWareSVGA,
			VBE,
			VGA
		}
		public static GFXDriver graphicsDriver;
		public enum Hypervisor
		{
			VirtualBox,
			VMWare, 
			Bochs,
			QEMU,
			VirtualPC,
			RealShit
		}
		public static Hypervisor VM;

		public static string Host;
		public static bool IsVirtualised;
    }
}
