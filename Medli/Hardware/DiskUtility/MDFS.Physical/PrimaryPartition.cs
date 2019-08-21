using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.HAL.BlockDevice;

namespace MDFS.Physical
{
	public class PrimaryPartition : Partition
	{
		/// <summary>
		/// The primary partition's block device
		/// </summary>
		BlockDevice HostDevice;

		/// <summary>
		/// The primary partition's starting sector
		/// </summary>
		ulong StartingSector;

		/// <summary>
		/// Partition Information instance for this partition
		/// </summary>
		private PartitionInfo _infos;

		/// <summary>
		/// Readonly public property for partition info instance
		/// </summary>
		public PartitionInfo Infos
		{
			get
			{
				return _infos;
			}
		}

		/// <summary>
		/// Constructor for a primary partition
		/// </summary>
		/// <param name="aHost"></param>
		/// <param name="aStartingSector"></param>
		/// <param name="aSectorCount"></param>
		/// <param name="info"></param>
		public PrimaryPartition(BlockDevice aHost, ulong aStartingSector, ulong aSectorCount, PartitionInfo info)
			: base(aHost, aStartingSector, aSectorCount)
		{
			HostDevice = aHost;
			StartingSector = aStartingSector;
			mBlockCount = aSectorCount;
			mBlockSize = aHost.BlockSize;
			_infos = info;
		}


		/// <summary>
		/// Reads the specified number of blocks from the specified partition
		/// </summary>
		/// <param name="aBlockNo">Starting block number</param>
		/// <param name="aBlockCount">Number of blocks to read</param>
		/// <param name="aData">byte[] array to read to</param>
		public override void ReadBlock(ulong aBlockNo, ulong aBlockCount, ref byte[] aData)
		{
			UInt64 HostBlockNumber = StartingSector + aBlockNo;
			CheckBlockNo(HostBlockNumber, aBlockCount);
			HostDevice.ReadBlock(HostBlockNumber, aBlockCount, ref aData);
		}

		/// <summary>
		/// Writes the specified byte[] array to the specified block and number of blocks
		/// </summary>
		/// <param name="aBlockNo">Starting block number</param>
		/// <param name="aBlockCount">Number of blocks to write to</param>
		/// <param name="aData">Byte[] array containing data to be written</param>
		public override void WriteBlock(ulong aBlockNo, ulong aBlockCount, ref byte[] aData)
		{
			UInt64 HostBlockNumber = StartingSector + aBlockNo;
			CheckBlockNo(HostBlockNumber, aBlockCount);
			HostDevice.WriteBlock(HostBlockNumber, aBlockCount, ref aData);
		}
	}
}
