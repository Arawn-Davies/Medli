using System;
using System.Collections.Generic;
using System.Text;
using Medli.Core;
using Cosmos.HAL;
using Medli.Common;
using System.Threading;

namespace Medli.Hardware
{
	
    public class HALPBE
    {
		

		public static void Init()
		{
			PrebootEnvironment.Init();
			AreaInfo.HALinfo.WriteAreaPrefix(); Console.WriteLine(" Hardware setup under way...");
			AreaInfo.HALinfo.WriteAreaPrefix(); Console.WriteLine(" PCI Setup...");
			PCISetup();
			Thread.Sleep(500);
			AreaInfo.HALinfo.WriteAreaPrefix(); Console.WriteLine(" Detecting host...");
			DetectHyperVisor();
			Thread.Sleep(500);
			AreaInfo.HALinfo.WriteAreaPrefix(); Console.WriteLine(" Detecting graphics hardware...");
			GraphicsHardwareSetup();
			Thread.Sleep(500);
		}

		public static void PCISetup()
		{
			HAL.dArea = deviceArea.PCI;
			AreaInfo.HALDevInfo.WriteDevicePrefix("PCI");
			Console.WriteLine("\tDetecting PCI Devices...");
			HAL.PCIDevices = new List<PCIDevice>();
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

		public static void DetectHyperVisor()
		{
			HAL.dArea = deviceArea.VIRT;
			AreaInfo.HALDevInfo.WriteDevicePrefix("VIRT");
			Console.WriteLine("\tDetecting host platform...");
			PCIDevice Virtualizor = PCI.GetDevice((VendorID)PCIDevicesExtended.VendorID.Virtualbox, (DeviceID)PCIDevicesExtended.DeviceID.VirtualBox);
			KernelProperties.VM = KernelProperties.Hypervisor.VirtualBox;
			KernelProperties.Host = PCIDevicesExtended.DeviceIDStr(PCIDevicesExtended.DeviceID.VirtualBox);
			if (Virtualizor == null)
			{
				Virtualizor = PCI.GetDevice(VendorID.VMWare, DeviceID.SVGAIIAdapter);
				KernelProperties.VM = KernelProperties.Hypervisor.VMWare;
				KernelProperties.Host = PCIDevicesExtended.VendorIDStr(PCIDevicesExtended.VendorID.VMWare);
				if (Virtualizor == null)
				{
					KernelProperties.IsVirtualised = false;
					KernelProperties.VM = KernelProperties.Hypervisor.RealShit;
					KernelProperties.Host = "Non-virtualised hardware or unrecognised host";
				}
			}
		}

		private static void GraphicsHardwareSetup()
		{
			HAL.dArea = deviceArea.GFX;
			AreaInfo.HALDevInfo.WriteDevicePrefix("GFX");
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
			HAL.PCIDevices.Add(xPCIDevice);
			if (xPCIDevice.ClassCode == 0x6 && xPCIDevice.Subclass == 0x4)
			{
				CheckBus(xPCIDevice.SecondaryBusNumber);
			}
		}

	}
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
			AreaInfo.HALDevInfo.WriteDevicePrefix("PCI");
			int count = 0;
			foreach (PCIDevice device in PCIDevices)
			{
				Console.WriteLine(device.bus + ":" + device.slot + ":" + device.function + " " + PCIDevice.DeviceClass.GetTypeString(device) + ": " + PCIDevice.DeviceClass.GetDeviceString(device));
				count++;
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