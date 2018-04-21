using System;
using Cosmos.HAL.BlockDevice;
using Medli.Hardware.Drivers.BlockDevice;
using Medli.Core.IOGroups;
using Cosmos.HAL;

namespace Medli.Hardware.Drivers.BlockDevice
{
    public class IDE
    {
        private static PCIDevice xDevice = Cosmos.HAL.PCI.GetDeviceClass(ClassID.MassStorageController,
                                                                  SubclassID.IDEInterface);
        internal static void InitDriver()
        {
            if (xDevice != null)
            {
				Common.AreaInfo.HALDevInfo.WriteDevicePrefix("ATA", "ATA Primary Master");
                Initialize(ATA.ControllerIdEnum.Primary, ATA.BusPositionEnum.Master);
				//Console.WriteLine("ATA Primary Slave");
				//Initialize(Ata.ControllerIdEnum.Primary, Ata.BusPositionEnum.Slave);
				Common.AreaInfo.HALDevInfo.WriteDevicePrefix("ATA", "ATA Secondary Master");
                Initialize(ATA.ControllerIdEnum.Secondary, ATA.BusPositionEnum.Master);
                //Console.WriteLine("ATA Secondary Slave");
                //Initialize(Ata.ControllerIdEnum.Secondary, Ata.BusPositionEnum.Slave);
            }
        }

        private static void Initialize(ATA.ControllerIdEnum aControllerID, ATA.BusPositionEnum aBusPosition)
        {
            var xIO = aControllerID == ATA.ControllerIdEnum.Primary ? Core.CoreDevices.ATA1 : Core.CoreDevices.ATA2;
            var xATA = new ATAPIO(xIO, aControllerID, aBusPosition);
            if (xATA.DriveType == ATAPIO.SpecLevel.Null)
                return;
            else if (xATA.DriveType == ATAPIO.SpecLevel.ATA)
            {
                BlockDevice.Devices.Add(xATA);
				Common.AreaInfo.HALDevInfo.WriteDevicePrefix("ATA", "ATA device with speclevel ATA found.");
            }
            else if (xATA.DriveType == ATAPIO.SpecLevel.ATAPI)
            {
				Common.AreaInfo.HALDevInfo.WriteDevicePrefix("ATA", "device with speclevel ATAPI found, which is not supported yet!");
                return;
            }
            var xMbrData = new byte[512];
            xATA.ReadBlock(0UL, 1U, xMbrData);
            var xMBR = new MBR(xMbrData);

            if (xMBR.EBRLocation != 0)
            {
                //EBR Detected
                var xEbrData = new byte[512];
                xATA.ReadBlock(xMBR.EBRLocation, 1U, xEbrData);
                var xEBR = new EBR(xEbrData);

                for (int i = 0; i < xEBR.Partitions.Count; i++)
                {
                    //var xPart = xEBR.Partitions[i];
                    //var xPartDevice = new BlockDevice.Partition(xATA, xPart.StartSector, xPart.SectorCount);
                    //BlockDevice.BlockDevice.Devices.Add(xPartDevice);
                }
            }

			// TODO Change this to foreach when foreach is supported
			Common.AreaInfo.HALDevInfo.WriteDevicePrefix("ATA", "Number of MBR partitions found:" + xMBR.Partitions.Count);
            for(int i = 0; i < xMBR.Partitions.Count; i++)
            {
                var xPart = xMBR.Partitions[i];
                if (xPart == null)
                {
                    Console.WriteLine("Null partition found at idx: " + i);
                }
                else
                {
                    var xPartDevice = new Partition(xATA, xPart.StartSector, xPart.SectorCount);
                    BlockDevice.Devices.Add(xPartDevice);
                    Console.WriteLine("Found partition at idx: " + i);
                }
            }
        }
    }
}
