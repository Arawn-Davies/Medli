using System;
using System.Collections.Generic;
using System.Text;
using Medli.Core;
using Cosmos.HAL;
using Medli.Common;
using System.Threading;

namespace Medli.Hardware
{
	public class HAL
	{

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
	public enum deviceArea
	{
		PCI,
		USB,
		IO,
		GFX,
		Network,
		RTC,
		VIRT
	}
}
