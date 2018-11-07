using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Hardware
{
    class Devices
    {
		public static List<Devices.device> dev = new List<Devices.device>();

		public static Cosmos.HAL.BlockDevice.BlockDevice getDevice(string name)
		{
			for (int index = 0; index < Devices.dev.Count; ++index)
			{
				if (Devices.dev[index].name == name)
					return Devices.dev[index].dev;
			}
			throw new Exception("Device not found!");
		}

		public class device
		{
			public string name;
			public Cosmos.HAL.BlockDevice.BlockDevice dev;
		}
    }
}
