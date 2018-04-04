using System;
using System.Collections.Generic;
using System.Text;
using Medli.Core;
using Cosmos.HAL;
using Medli.Common;

namespace Medli.Hardware
{
	public class HAL
	{
		public static void Setup()
		{
			PCIDevices = new List<PCIDevice>();
			if ((PCIDevice.GetHeaderType(0x0, 0x0, 0x0) & 0x80) == 0)
			{
				CheckBus(0x0);
			}
			else
			{
				for (ushort fn = 0; fn < 8; fn++)
				{
					if (PCIDevice.GetVendorID(0x0, 0x0, fn) != 0xFFFF) { break; }
					CheckBus(fn);
				}
			}
		}

		private static void CheckBus(ushort xBus)
		{
			for (ushort device = 0; device < 32; device++)
			{
				if (PCIDevice.GetVendorID(xBus, device, 0x0) == 0xFFFF)
				{
					continue;
				}
				CheckFunction(new PCIDevice(xBus, device, 0x0));
				if ((PCIDevice.GetHeaderType(xBus, device, 0x0) & 0x80) != 0)
				{
					for (ushort fn = 1; fn < 8; fn++)
					{
						if (PCIDevice.GetVendorID(xBus, device, fn) != 0xFFFF)
							CheckFunction(new PCIDevice(xBus, device, fn));
					}
				}
			}
		}

		private static void CheckFunction(PCIDevice xPCIDevice)
		{
			PCIDevices.Add(xPCIDevice);
			if (xPCIDevice.ClassCode == 0x6 && xPCIDevice.Subclass == 0x4)
			{
				CheckBus(xPCIDevice.SecondaryBusNumber);
			}
		}

		public static deviceArea dArea;
		public static List<PCIDevice> PCIDevices;
		public static void ListPCIDevices()
		{
			dArea = deviceArea.PCI;
			Setup();
			Console.WriteLine("[" + dArea + "]" + "\tDetecting PCI Devices...");
			foreach (PCIDevice device in PCIDevices)
			{
				Console.WriteLine("\tV-ID: " + device.VendorID + ", D-ID:"+ device.DeviceID);
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
		RTC
	}
    public class HALPBE
    {
		private static KernelAreaInfo HALinfo = new KernelAreaInfo(ConsoleColor.Cyan, "HAL");

		public static void Init()
		{
			PrebootEnvironment.Init();
			HALinfo.WriteAreaPrefix(); Console.WriteLine(" Hardware setup under way...");
			HAL.ListPCIDevices();
			DetectHyperVisor();
			GraphicsHardwareSetup();
		}

		public static void DetectHyperVisor()
		{
			Console.ForegroundColor = HALinfo.areaColor;
			Console.WriteLine("[" + HAL.dArea + "]");
			Console.ForegroundColor = ConsoleColor.White;
			PCIDevice Virtualisor = PCI.GetDevice((VendorID)PCIDevicesExtended.VendorID.Virtualbox, (DeviceID)PCIDevicesExtended.DeviceID.VirtualBox);
			KernelProperties.VM = KernelProperties.Hypervisor.VirtualBox;
			if (Virtualisor == null)
			{
				Virtualisor = PCI.GetDevice(VendorID.VMWare, DeviceID.SVGAIIAdapter);
				KernelProperties.VM = KernelProperties.Hypervisor.VMWare;
				if (Virtualisor == null)
				{
					KernelProperties.IsVirtualised = false;
					KernelProperties.VM = KernelProperties.Hypervisor.RealShit;
				}
			}
		}

		private static void GraphicsHardwareSetup()
		{
			HAL.dArea = deviceArea.GFX;
			Console.ForegroundColor = HALinfo.areaColor;
			Console.WriteLine("[" + HAL.dArea + "]");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("\tDetecting Graphics hardware...");
			foreach (PCIDevice pciDevice in HAL.PCIDevices)
			{
				if ((pciDevice.VendorID == (ushort)VendorID.VMWare))
				{
					if (pciDevice.DeviceID == (ushort)DeviceID.SVGAIIAdapter)
					{
						KernelProperties.graphicsDriver = KernelProperties.GFXDriver.VMWareSVGA;
						break;
					}
					continue;
				}
				else if (pciDevice.ClassCode == 0x03)
				{
					KernelProperties.graphicsDriver = KernelProperties.GFXDriver.VGA;
					break;
				}
				else
				{
					KernelProperties.graphicsDriver = KernelProperties.GFXDriver.VBE;
					break;
				}
			}
		}
	}
}