using System;
using System.Collections.Generic;
using System.Text;
using MDFS;
using MDFS.Physical;
using Cosmos.HAL.BlockDevice;

namespace Medli.System.MDFS
{
    public class MDFileSystem
    {
        /// <summary>
        /// Drive partition upon which the filesystem resides
        /// Only visisble to internal methods & properties
        /// </summary>
        private Partition _partition;

        /// <summary>
        /// (Readonly) Retrieves the partition upon which the filesystem resides from the _partition property
        /// </summary>
        public Partition Partition
        {
            get
            {
                return _partition;
            }
        }

        /// <summary>
        /// Returns block size of this FileSystem's partition
        /// </summary>
        public ulong BlockSize
        {
            get
            {
                return _partition.BlockSize;
            }
        }

        /// <summary>
        /// Returns block count of this FileSystem's partition
        /// </summary>
        public ulong BlockCount
        {
            get
            {
                return _partition.BlockCount;
            }
        }

        /// <summary>
        /// The filesystem that is currently in use
        /// </summary>
        public static MDFileSystem nFS = null;

        /// <summary>
        /// Constructor for a filesystem object
        /// Runs test for valid FS on specified partition
        /// </summary>
        /// <param name="part"></param>
        public MDFileSystem(Partition part)
        {
            _partition = part;
            if (!IsValidFS())
            {

            }
        }

        /// <summary>
        /// Generates a new FS block structure on specified filesystem
        /// </summary>
        /// <param name="part"></param>
        /// <returns></returns>
        private bool GenerateFS(Partition part)
        {
            return true;
        }

        /// <summary>
        /// Tests to see if partition object (_partition) contains a valid MDFS filesystem block structure
        /// </summary>
        /// <returns></returns>
        public bool IsValidFS()
        {
            return true;
        }

    }
}
