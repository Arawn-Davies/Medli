using System;
using IL2CPU.API.Attribs;
using Cosmos.HAL;
using Cosmos.Core;

namespace MedliPlugs.HAL
{
    [Plug(Target = typeof(Cosmos.HAL.Global))]
    public static class Global
    {

        static public void Init(TextScreenBase textScreen)
        {

            Console.WriteLine("Medli Operating System v" + Medli.Kernel.KernelVersion);
            Console.WriteLine("Developed by Siaranite Solutions & Aura Systems");

            AreaInfo.HALInfo.WriteAreaPrefix("Starting Medli...");
            AreaInfo.HALDevInfo.WriteDevicePrefix("PCI", "Scanning PCI devices...");
            PCI.Setup();

            AreaInfo.HALDevInfo.WriteDevicePrefix("ACPI", "Initialising power management");
            ACPI.Start();

            AreaInfo.HALDevInfo.WriteDevicePrefix("IDE", "Initialising storage drivers... (1/2)");
            Cosmos.HAL.BlockDevice.IDE.InitDriver();
            AreaInfo.HALDevInfo.WriteDevicePrefix("AHCI", "Initialising storage drivers... (2/2)");
            Cosmos.HAL.BlockDevice.AHCI.InitDriver();

            AreaInfo.HALDevInfo.WriteDevicePrefix("PS/2", "Initialising input drivers...");
            Cosmos.HAL.Global.PS2Controller.Initialize();

            //Cosmos.Core.Processing.ProcessorScheduler.Initialize();
            //Aura_OS.System.CustomConsole.WriteLineOK("Processor Scheduler Initialization");

            AreaInfo.HALInfo.WriteAreaPrefix("Medli Drivers + Services successfully initialised!");

        }
    }
}
