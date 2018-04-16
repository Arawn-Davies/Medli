using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace Medli.Common
{
	public class AreaInfo
	{
		public static KernelAreaInfo HALinfo = new KernelAreaInfo(ConsoleColor.Green, "HAL");
		public static DeviceAreaInfo HALDevInfo = new DeviceAreaInfo(HALinfo);
		public static KernelAreaInfo CoreInfo = new KernelAreaInfo(ConsoleColor.Red, "Core");
		public static DeviceAreaInfo CoreDevInfo = new DeviceAreaInfo(CoreInfo);
		public static KernelAreaInfo SystemInfo = new KernelAreaInfo(ConsoleColor.Blue, "System");
		public static DeviceAreaInfo SystemDevInfo = new DeviceAreaInfo(SystemInfo);
	}

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

		public static string Host;
		public static string KernelVersion = "0.0.4";
		public static bool IsVirtualised;
    }

	public class DeviceAreaInfo
	{
		public KernelAreaInfo kernelArea;
		public DeviceAreaInfo(KernelAreaInfo kArea)
		{
			kernelArea = kArea;
		}
		public void WriteDevicePrefix(string device, string task, ConsoleColor fgcolor = ConsoleColor.White)
		{
			Console.Write("[");
			Console.ForegroundColor = kernelArea.areaColor;
			Console.Write(device);
			Console.ForegroundColor = fgcolor;
			Console.Write("] " + task + "\n");
		}
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
		public void WriteAreaPrefix(string task, ConsoleColor fgcolor = ConsoleColor.White)
		{
			Console.Write("[");
			Console.ForegroundColor = this.areaColor;
			Console.Write(this.areaName);
			Console.ForegroundColor = fgcolor;
			Console.Write("] " + task + "\n");
		}
	}
}
