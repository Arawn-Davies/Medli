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
			AreaInfo.HALinfo.WriteAreaPrefix("Hardware setup under way...");
			PCISetup();
			DetectHyperVisor();
			GraphicsHardwareSetup();
			//AreaInfo.HALDevInfo.WriteDevicePrefix("COM", "Initializing serial communications stack...");
			//HAL.COM1 = new Drivers.SerialPort1();
			//HAL.COM2 = new Drivers.SerialPort2();
			//HAL.COM2.Initialize();
			//AreaInfo.HALDevInfo.WriteDevicePrefix("IDE", "Initializing IDE driver...");
			//AreaInfo.HALDevInfo.WriteDevicePrefix("AHCI", "Initializing AHCI driver...");
			//AreaInfo.HALDevInfo.WriteDevicePrefix("PS2", "Initializing PS2 controller...");
		}

		public static void PCISetup()
		{
			HAL.dArea = deviceArea.PCI;
			AreaInfo.HALDevInfo.WriteDevicePrefix("PCI", "Detecting PCI Devices...");
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
			AreaInfo.HALDevInfo.WriteDevicePrefix("VIRT", "Detecting host platform...");
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
			AreaInfo.HALDevInfo.WriteDevicePrefix("GFX", "Detecting Graphics hardware...");
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
}