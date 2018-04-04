using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Hardware
{
    class PCIDevicesExtended
    {
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
