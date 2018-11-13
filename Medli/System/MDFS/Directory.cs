using System;
using System.Collections.Generic;
using System.Text;
using MDFS;
using MDFS.Physical;
using Cosmos.HAL.BlockDevice;

namespace Medli.System.MDFS
{
    public class MDDirectory : MDEntry
    {
        /// <summary>
        /// The FullName (Path+Name) of the Current Directory
        /// </summary>
        public String FullName
        {
            get
            {
                return MDFileSystem.ConcatDirectory(_path, Name);
            }
        }

        /// <summary>
        /// Creates a new Directory Object
        /// </summary>
        /// <param name="partition">The partition to use</param>
        /// <param name="blockNumber">The block number we want to 
use</param>
        /// <param name="path">The path of the new directory</param>
        public MDDirectory(Partition partition, ulong blockNumber, 
String path)
        {
            
        }
    }
}
