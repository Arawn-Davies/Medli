using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.HAL.BlockDevice;
using Medli.Common;

namespace MDFS.Physical
{
    public class IDE
    {
        /// <summary>
        /// Returns the size of the IDE device (with spec level of ATA)
        /// </summary>
		public UInt32 Size
		{
			get
			{
				return (uint)(((this.BlockCount * this.BlockSize) / 1024 ) / 1024) + 1;
			}
		}

		/// <summary>
		/// The BlockDevice specific to this class instance
		/// </summary>
		private BlockDevice blockDevice;

		public PrimaryPartition[] PrimaryPartitions
		{
			get
			{
				List<PrimaryPartition> l = new List<PrimaryPartition>();
				for (int i = 0; i < MBR.Partitions.Length; i++)
				{
					if (MBR.Partitions[i].SystemID != 0)
					{
						l.Add(new PrimaryPartition(blockDevice, MBR.Partitions[i].StartSector, MBR.Partitions[i].SectorCount, MBR.Partitions[i]));
					}
				}
				return l.ToArray();
			}
		}


		/// <summary>
		/// List of ATAPIO IDE Devices
		/// </summary>
		public static List<IDE> Devices
		{
			get
			{
				List<IDE> devs = new List<IDE>();
				Console.WriteLine(BlockDevice.Devices.Count + " block devices found!");
				for (int i = 0; i < BlockDevice.Devices.Count; i++)
				{
					if (BlockDevice.Devices[i] is ATA_PIO)
					{
						IDE device = new IDE((ATA_PIO)BlockDevice.Devices[i]);
						devs.Add(device);
						new DiskListing(i, device);
					}
				}
				return devs;
			}
		}

		/// <summary>
		/// Retrieves the master boot record of this class instance's BlockDevice
		/// </summary>
		public MBR MBR
		{
			get
			{
				Byte[] data = blockDevice.NewBlockArray(1);
				this.blockDevice.ReadBlock(0, 1, ref data);
				MBR m = new MBR(data, blockDevice);
				return m;
			}
		}

		/// <summary>
		/// The size of each block of the current Device
		/// </summary>
		public UInt64 BlockSize
		{
			get { return blockDevice.BlockSize; }
		}

		/// <summary>
		/// The number of blocks of the current Device
		/// </summary>
		public UInt64 BlockCount
		{
			get { return blockDevice.BlockCount; }
		}

		/// <summary>
		/// Retrieves a new byte array with a length of (num * BlockSize)
		/// </summary>
		/// <param name="num"></param>
		/// <returns>New byte[] Array</returns>
		public Byte[] NewBlockArray (uint num)
		{
			return blockDevice.NewBlockArray(num);
		}

		/// <summary>
		/// Constructor for the class instance, used for IO
		/// </summary>
		/// <param name="Device"></param>
		public IDE (ATA_PIO Device)
		{
			this.blockDevice = Device;
		}

		/// <summary>
		/// Reads the specified amount of blocks from the BlockDevice
		/// </summary>
		/// <param name="aBlockNo">Start block number</param>
		/// <param name="aBlockCount">Number of blocks</param>
		/// <param name="aData">Buffer to write to</param>
		public void ReadBlock(ulong aBlockNo, uint aBlockCount, byte[] aData)
		{
			blockDevice.ReadBlock(aBlockNo, aBlockCount, ref aData);
		}

		/// <summary>
		/// Writes the specified byte[] array to the specified block and number of blocks
		/// </summary>
		/// <param name="aBlockNo">Start block number</param>
		/// <param name="aBlockCount">Number of blocks</param>
		/// <param name="aData">Buffer to write to</param>
		public void WriteBlock(ulong aBlockNo, uint aBlockCount, byte[] aData)
		{
			blockDevice.WriteBlock(aBlockNo, aBlockCount, ref aData);
		}
	}
}
