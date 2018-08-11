using System;
using System.Collections.Generic;
using System.Text;
using Medli.Core;
using Cosmos.HAL;
using Medli.Common;
using System.Threading;
using Medli.Hardware.Drivers;
using Cosmos.Core;

namespace Medli.Hardware
{
	public class HAL
	{
		public static PIT pit = new PIT();

		public static SerialPort1 COM1;
		public static SerialPort2 COM2;
		public static SerialPort3 COM3;
		public static SerialPort4 COM4;

		public static deviceArea dArea;
		public static List<PCIDevice> PCIDevices;
		/// <summary>
		/// LSPCI listing all PCI devices attached
		/// </summary>
		public static void ListPCIDevices()
		{
			dArea = deviceArea.PCI;
			AreaInfo.HALDevInfo.WriteDevicePrefix("PCI", "Listing PCI Devices...");
			int count = 0;
			foreach (PCIDevice device in PCIDevices)
			{
				Console.WriteLine(device.bus + ":" + device.slot + ":" + device.function + " " + PCIDevice.DeviceClass.GetTypeString(device) + ": " + PCIDevice.DeviceClass.GetDeviceString(device));
				count++;
				if (count == 19)
				{
					Console.Write(":");
					Console.ReadKey(true);
					count = 0;
				}
			}
		}
	}

    public class IO
    {
        public static byte inb (ushort port)
        {
            IOPort io = new IOPort(port);
            return io.Byte;
        }

        public static ushort inw (ushort port)
        {
            IOPort io = new IOPort(port);
            return io.Word;
        }

        public static void outb (ushort port, byte data)
        {
            IOPort io = new IOPort(port);
            io.Byte = data;
        }

        public static void outw (ushort port, ushort data)
        {
            IOPort io = new IOPort(port);
            io.Word = data;
        }
    }

	public enum deviceArea
	{
		PCI,
		USB,
		IO,
		GFX,
		NET,
		RTC,
		VIRT
	}
}
