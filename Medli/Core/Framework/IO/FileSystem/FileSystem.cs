/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medli.Core.Framework.IO.FileSystem
{
    public class FileSystem
    {
        public static VirtualFileSystem Root = new VirtualFileSystem(); // this is the root filesystem......
       
        public static void DetectDrives()
        {
            for (int i = 0; i < Cosmos.Hardware.BlockDevice.Partition.Devices.Count; i++)
            {
                if (Cosmos.Hardware.BlockDevice.Partition.Devices[i] is Cosmos.Hardware.BlockDevice.Partition)
                {
                    if(GruntyOS.HAL.GLNFS.isGFS(((Cosmos.Hardware.BlockDevice.Partition)Cosmos.Hardware.BlockDevice.BlockDevice.Devices[i])))
                    {
                        GruntyOS.HAL.GLNFS fs = new GruntyOS.HAL.GLNFS(((Cosmos.Hardware.BlockDevice.Partition)Cosmos.Hardware.BlockDevice.BlockDevice.Devices[i]));
                        Drive drv = new Drive();
                        GruntyOS.HAL.Devices.device dev = new GruntyOS.HAL.Devices.device();
                        Console.WriteLine("GLNFS PARTITION FOUND");
                        dev.name = @"?\\Harddrive\Partition" + i.ToString();
                        dev.dev = ((Cosmos.Hardware.BlockDevice.Partition)Cosmos.Hardware.BlockDevice.BlockDevice.Devices[i]);
                        drv.DeviceFile = dev.name;
                        GruntyOS.HAL.Devices.dev.Add(dev);
                        Root.AddDrive(drv);
                    }
                }
            }
        }
    }
}
*/