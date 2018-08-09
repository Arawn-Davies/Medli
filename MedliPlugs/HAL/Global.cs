using System;
using System.Collections.Generic;
using System.Text;
using IL2CPU.API.Attribs;
using Cosmos.HAL;
using Cosmos.Core;
using Medli.Common;

namespace MedliPlugs.HAL
{
	/*
	[Plug(Target = typeof(Cosmos.HAL.Global))]
	public static class Global
	{

		static public PIT PIT = new PIT();

		static public void Init(TextScreenBase textScreen)
		{

			Cosmos.Core.Global.Init();

			Console.WriteLine("[Medli Operating System v" + KernelVariables.KernelVersion + " - Made by Arawn Davies]");
			AreaInfo.SystemDevInfo.WriteDevicePrefix("SYS", "Starting Medli kernel...");

			ACPI.Start();
			AreaInfo.CoreDevInfo.WriteDevicePrefix("PWR", "ACPI Initialization");

			PCI.Setup();
			AreaInfo.HALDevInfo.WriteDevicePrefix("PCI", "PCI Devices Scan");

			//Cosmos.HAL.BlockDevice.IDE.InitDriver();
			AreaInfo.HALDevInfo.WriteDevicePrefix("STR", "IDE Driver Initialization");

			//Cosmos.HAL.BlockDevice.AHCI.InitDriver();
			AreaInfo.HALDevInfo.WriteDevicePrefix("STR", "AHCI Driver Initialization");

			Cosmos.HAL.Global.PS2Controller.Initialize();
			AreaInfo.SystemDevInfo.WriteDevicePrefix("PS2", "PS/2 Controller Initialization");

			AreaInfo.SystemDevInfo.WriteDevicePrefix("SYS", "Kernel successfully initialized!");

		}
	}*/
}
