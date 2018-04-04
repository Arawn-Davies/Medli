using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace Medli.Common
{
	public enum KernelArea
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
		public static bool Running;
		public static string KernelVersion = "0.0.1";
		public static bool IsVirtualised;
    }
	public class KernelAreaInfo
	{
		public KernelAreaInfo(ConsoleColor aC, string aName)
		{
			areaColor = aC;
			areaName = aName;
		}
		public ConsoleColor areaColor;
		public string areaName;
		public void WriteAreaPrefix(ConsoleColor fgcolor = ConsoleColor.White)
		{
			Console.WriteLine("[");
			Console.ForegroundColor = this.areaColor;
			Console.Write(this.areaName);
			Console.ForegroundColor = fgcolor;
			Console.Write("]");
		}
	}
}
