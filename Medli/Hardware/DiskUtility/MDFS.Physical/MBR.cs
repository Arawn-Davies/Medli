using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.HAL.BlockDevice;

namespace MDFS.Physical
{
    public class MBR
    {
		private List<PartitionInfo> _Partitions = new List<PartitionInfo>();

		/// <summary>
		/// An array containing all patitions
		/// </summary>
		public PartitionInfo[] Partitions
		{
			get
			{
				return _Partitions.ToArray();
			}
		}

		private BlockDevice blockDevice;

		/// <summary>
		/// The Byte Array containing the bootable code of the MBR
		/// </summary>
		public readonly Byte[] Bootable = new Byte[440];

		/// <summary>
		/// The Disk signature
		/// </summary>
		public readonly UInt32 Signature = 0;

		/// <summary>
		/// Initializes a new MBR object getting the content of the first block of the disk
		/// </summary>
		/// <param name="aMBR">Byte rapresentation of the first disk block</param>
		public MBR(byte[] aMBR, BlockDevice device)
		{
			this.blockDevice = device;
			MDFSUtils.CopyByteToByte(aMBR, 0, Bootable, 0, 440);
			Signature = BitConverter.ToUInt32(aMBR, 440);
			ParsePartition(aMBR, 446);
			ParsePartition(aMBR, 462);
			ParsePartition(aMBR, 478);
			ParsePartition(aMBR, 494);
		}

		private void ParsePartition(byte[] aMBR, UInt32 aLoc)
		{
			byte xSystemID = aMBR[aLoc + 4];
			// SystemID = 0 means no partition
			if (xSystemID != 0)
			{
				UInt32 xStartSector = BitConverter.ToUInt32(aMBR, (int)aLoc + 8);
				UInt32 xSectorCount = BitConverter.ToUInt32(aMBR, (int)aLoc + 12);

				var xPartInfo = new PartitionInfo(xSystemID, xStartSector, xSectorCount, blockDevice.BlockSize);
				_Partitions.Add(xPartInfo);
			}
		}

	}
}
