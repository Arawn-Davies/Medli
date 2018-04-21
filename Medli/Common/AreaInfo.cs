using System;
using System.Collections.Generic;
using Medli.System;

namespace Medli.Common
{
	public class AreaInfo
	{
		public static SysConsole CommonConsole = new SysConsole(null);
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

	public class DeviceAreaInfo
	{
		public KernelAreaInfo kernelArea;
		public DeviceAreaInfo(KernelAreaInfo kArea)
		{
			kernelArea = kArea;
		}
		public void WriteDevicePrefix(string device, string task, ConsoleColor fgcolor = ConsoleColor.White)
		{
			SysConsole.Write("[");
			SysConsole.set_ForegroundColor(kernelArea.areaColor);
			SysConsole.Write(device);
			SysConsole.set_ForegroundColor(fgcolor);
			SysConsole.Write("] " + task + "\n");
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
			SysConsole.Write("[");
			SysConsole.set_ForegroundColor(this.areaColor);
			SysConsole.Write(this.areaName);
			SysConsole.set_ForegroundColor(fgcolor);
			SysConsole.Write("] " + task + "\n");
		}
	}
}
