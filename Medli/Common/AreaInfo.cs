using System;
using System.Collections.Generic;

namespace Medli.Common
{
    /// <summary>
    /// Listings of the information areas
    /// </summary>
    public class AreaInfo
	{
        /// <summary>
        /// The Hardware Abstraction Layer info
        /// </summary>
        public static KernelAreaInfo HALinfo = new KernelAreaInfo(ConsoleColor.Green, "HAL");
        /// <summary>
        /// The HAL device info
        /// </summary>
        public static DeviceAreaInfo HALDevInfo = new DeviceAreaInfo(HALinfo);
        /// <summary>
        /// The core/cpu information
        /// </summary>
        public static KernelAreaInfo CoreInfo = new KernelAreaInfo(ConsoleColor.Red, "Core");
        /// <summary>
        /// The core device information
        /// </summary>
        public static DeviceAreaInfo CoreDevInfo = new DeviceAreaInfo(CoreInfo);
        /// <summary>
        /// The system information
        /// </summary>
        public static KernelAreaInfo SystemInfo = new KernelAreaInfo(ConsoleColor.Blue, "System");
        /// <summary>
        /// The system device information
        /// </summary>
        public static DeviceAreaInfo SystemDevInfo = new DeviceAreaInfo(SystemInfo);
	}

    /// <summary>
    /// Enum of system subcomponents
    /// </summary>
    public enum KernelArea
	{
        /// <summary>
        /// The cpu
        /// </summary>
        CPU,
        /// <summary>
        /// The ram
        /// </summary>
        RAM,
        /// <summary>
        /// The core
        /// </summary>
        Core,
        /// <summary>
        /// The Hardware Abstraction Layer subsystem
        /// </summary>
        HAL,
        /// <summary>
        /// The system
        /// </summary>
        SYS,
        /// <summary>
        /// The kernel
        /// </summary>
        Kernel,
        /// <summary>
        /// The userspace subsystem
        /// </summary>
        Userspace,
        /// <summary>
        /// The filesystem
        /// </summary>
        FS,
        /// <summary>
        /// The input/output subsystem
        /// </summary>
        IO
    }

    /// <summary>
    /// Class definition for the device information areas
    /// </summary>
    public class DeviceAreaInfo
	{
        /// <summary>
        /// The area of the kernel responsible
        /// </summary>
        public KernelAreaInfo kernelArea;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceAreaInfo"/> class.
        /// </summary>
        /// <param name="kArea">The k area.</param>
        public DeviceAreaInfo(KernelAreaInfo kArea)
		{
			kernelArea = kArea;
		}
        /// <summary>
        /// Writes the device prefix.
        /// </summary>
        /// <param name="device">The device.</param>
        /// <param name="task">The task.</param>
        /// <param name="fgcolor">The fgcolor.</param>
        public void WriteDevicePrefix(string device, string task, ConsoleColor fgcolor = ConsoleColor.White)
		{
			Console.Write("[");
			Console.ForegroundColor = kernelArea.areaColor;
			Console.Write(device);
			Console.ForegroundColor = fgcolor;
			Console.Write("] " + task + "\n");
		}
	}

    /// <summary>
    /// Class definition for the different kernel areas responsible for each component
    /// </summary>
    public class KernelAreaInfo
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="KernelAreaInfo"/> class.
        /// </summary>
        /// <param name="aC">a c.</param>
        /// <param name="aName">a name.</param>
        public KernelAreaInfo(ConsoleColor aC, string aName)
		{
			areaColor = aC;
			areaName = aName;
		}

        /// <summary>
        /// The area color
        /// </summary>
        public global::System.ConsoleColor areaColor;

        /// <summary>
        /// The area name
        /// </summary>
        public string areaName;

        /// <summary>
        /// Writes the area prefix.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="fgcolor">The fgcolor.</param>
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
