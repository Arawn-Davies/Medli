using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Hardware
{
    class PCIDevicesExtended
    {
		public static string VendorIDStr(VendorID vID)
		{
			if (vID == VendorID.Virtualbox)
				return "VirtualBox";
			else if (vID == VendorID.VMWare)
				return "VMWare";
			else
				return "UnknownID";
		}
		public static string DeviceIDStr(DeviceID dID)
		{
			if (dID == DeviceID.VirtualBox)
				return "Guest Service";
			else if (dID == DeviceID.SVGAII)
				return "SVGA II";
			else
				return "UnknownID";
		}
		public enum VendorID
		{
			Virtualbox = 0x80EE,
			VMWare = 0x15AD,
		}
		public enum DeviceID
		{
			VirtualBox = 0xCAFE,
			SVGAII = 0x1029
		}
	}
}
