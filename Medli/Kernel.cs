using System;
using System.Collections.Generic;
using Sys = Cosmos.System;
using Medli.Common;
using Medli.System;
using Medli.System.MDFS;
using MDFS.Physical;

namespace Medli
{
    public static partial class Kernel
    {
        /// <summary>
        /// The filesystem object which will allow access to files on MDFS partition
        /// </summary>
        public static MDFileSystem fs;

        /// <summary>
        /// Development bool as to whether or not MDFS is to be used
        /// </summary>
        private static bool UseMDFS = true;
        
        /// <summary>
        /// List of kernel services
        /// </summary>
		public static List<Service> Services = new List<Service>();

        /// <summary>
        /// The partition that is to be formatted with MDFS
        /// </summary>
        private static PrimaryPartition FSPartition;
        public static void FileSystemINIT()
        {
            if (UseMDFS == true)
            {
                IDE[] IDEs = IDE.Devices.ToArray();
                MDFS.MDUtils.WriteLine("Number of IDE disks: " + IDEs.Length);
                MDFS.MDUtils.WriteLine("Looking for valid partitions...");
                for (int i = 0; i < IDEs.Length; i++)
                {
                    PrimaryPartition[] parts = IDEs[i].PrimaryPartitions;
                    for (int j = 0; j < parts.Length; j++)
                    {
                        if (parts[j].Infos.SystemID == 0xFA)
                        {
                            FSPartition = parts[j];
                        }
                    }
                }
                if (FSPartition == null)
                {
                    FS.MFSU();
                    MDFS.MDUtils.WriteLine("The machine needs to be restarted.");
                }

                fs = new MDFileSystem(FSPartition);
                MDFileSystem.MapFS("/", fs);
            }
        }
    }
}
