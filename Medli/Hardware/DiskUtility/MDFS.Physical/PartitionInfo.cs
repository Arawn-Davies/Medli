using System;
using System.Collections.Generic;
using System.Text;

namespace MDFS.Physical
{
    public class PartitionInfo
    {
		public UInt32 TotalSize
		{
			get
			{
				return (uint)(((BlockSize * SectorCount) / 1024) / 1024) + 1;
				//return StartSector * SectorCount;
			}
		}

		/// <summary>
		/// The partition's FS ID
		/// </summary>
		public readonly byte SystemID;
		/// <summary>
		/// The partition's starting sector
		/// </summary>
		public readonly UInt32 StartSector;
		/// <summary>
		/// The number of sectors in the partition
		/// </summary>
		public readonly UInt32 SectorCount;

		public readonly UInt64 BlockSize;

		/// <summary>
		/// Constructor for a new partition
		/// </summary>
		/// <param name="SysID"></param>
		/// <param name="startSector"></param>
		/// <param name="sectCount"></param>
		public PartitionInfo(byte SysID, UInt32 startSector, UInt32 sectCount, UInt64 blockSize)
		{
			SystemID = SysID;
			StartSector = startSector;
			SectorCount = sectCount;
			BlockSize = blockSize;
		}
    }
}
