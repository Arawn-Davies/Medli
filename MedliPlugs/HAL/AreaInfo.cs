using System;
using System.Collections.Generic;

namespace MedliPlugs.HAL
{
	public class AreaInfo
	{
		public static SetupInfo HALInfo = new SetupInfo(ConsoleColor.Green, "HAL");
		public static DeviceAreaInfo HALDevInfo = new DeviceAreaInfo(HALInfo);
		public static SetupInfo CoreInfo = new SetupInfo(ConsoleColor.Red, "Core");
		public static DeviceAreaInfo CoreDevInfo = new DeviceAreaInfo(CoreInfo);
		public static SetupInfo SystemInfo = new SetupInfo(ConsoleColor.Blue, "System");
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
		public SetupInfo areaInfo;
		public DeviceAreaInfo(SetupInfo kArea)
		{
			areaInfo = kArea;
		}
		public void WriteDevicePrefix(string device, string task, ConsoleColor fgcolor = ConsoleColor.White)
		{
			Console.Write("[");
			Console.ForegroundColor = areaInfo.areaColor;
			Console.Write(device);
			Console.ForegroundColor = fgcolor;
			Console.Write("] " + task + "\n");
		}
	}

	public class SetupInfo
	{
		public SetupInfo(ConsoleColor aC, string aName)
		{
			areaColor = aC;
			areaName = aName;
		}
		public global::System.ConsoleColor areaColor;
		public string areaName;
		public void WriteAreaPrefix(string task, ConsoleColor fgcolor = ConsoleColor.White)
		{
			Console.Write("[");
			Console.ForegroundColor = areaColor;
			Console.Write(areaName);
			Console.ForegroundColor = fgcolor;
			Console.Write("] " + task + "\n");
		}
	}
}
