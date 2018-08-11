using System;
using System.Collections.Generic;
using System.Text;
//using Cosmos.HAL.BlockDevice;
using MDFS.Physical;
using MDFS;

namespace MDFS.Physical
{
	public class Old
	{
		
		/// <summary>
		/// Partitioning function for devices that presents a 
		/// list of the devices to choose from to be partitioned.
		/// </summary>
		/// <param name="list">The list of the devices to choose from</param>
		public static void CreatePartitions(IDE[] list)
		{
			IDE Device = null;
			int partnum = 0;
			ulong DispCount = 0;
			MDUtils.WriteLine("Welcome to the MedliOS Partitioning Tool");
			do
			{
				MDUtils.WriteLine("Which device do you want to use?");
				for (int i = 0; i < list.Length; i++)
				{
					MDUtils.WriteLine(" --- Device N." + (i + 1) + " Size: approximately " + (uint)((((list[i].BlockSize * list[i].BlockCount) / 1024) / 1024) + 1) + " MB");
				}
				String nums = MDUtils.ReadLine("Insert Number: ");
				int num = int.Parse(nums) - 1;
				if (num >= 0 && num < list.Length)
				{
					Device = list[num];
					DispCount = list[num].BlockCount - 1;
				}
			} while (Device == null);
			MDUtils.WriteLine("How many primary partitions do you want to have? (Max. 4)");
			do
			{
				String nums = MDUtils.ReadLine("Insert Number: ");
				partnum = int.Parse(nums);
			} while (partnum == 0 || partnum > 4);
			uint mbrpos = 446;
			Byte[] type = new Byte[] { 0x00, 0x00, 0x00, 0x00 };
			uint[] StartBlock = new uint[] { 1, 0, 0, 0 };
			uint[] BlockNum = new uint[] { 0, 0, 0, 0 };
			for (int i = 0; i < partnum; i++)
			{
				type[i] = 0xFA;
				String nums = MDUtils.ReadLine("How many blocks for Partition N. " + (i + 1) + "? (Max: " + ((uint)(DispCount - (uint)(partnum - (i + 1)))).ToString() + "): ");
				uint num = (uint)int.Parse(nums);
				if (num >= 0 && num <= DispCount - (uint)(partnum - (i + 1)))
				{
					BlockNum[i] = num;
					if (i < partnum - 1)
					{
						StartBlock[i + 1] = (num) + StartBlock[i];
					}
					DispCount = DispCount - (num);
				}
				else
				{
					i--;
				}
			}
			Byte[] data = Device.NewBlockArray(1);
			Device.ReadBlock(0, 1, data);
			for (int i = 0; i < 4; i++)
			{
				mbrpos += 4;
				data[mbrpos] = type[i];
				mbrpos += 4;
				Byte[] b = BitConverter.GetBytes(StartBlock[i]);
				MDFSUtils.CopyByteToByte(b, 0, data, (int)mbrpos, b.Length);
				mbrpos += 4;
				b = BitConverter.GetBytes(BlockNum[i]);
				MDFSUtils.CopyByteToByte(b, 0, data, (int)mbrpos, b.Length);
				mbrpos += 4;
				Device.WriteBlock(StartBlock[i], 1, Device.NewBlockArray(1));
				MDUtils.WriteLine("Partition N. " + (i + 1) + " Start: " + (StartBlock[i]).ToString() + " BlockCount: " + (BlockNum[i]).ToString());
			}
			Device.WriteBlock(0, 1, data);
		}
	}


	/// <summary>
	/// Defines a disk listing
	/// </summary>
	public class MDFSUtil
	{
		/// <summary>
		/// Static List of DiskListings
		/// </summary>
		public static List<MDFSUtil> DiskListings = new List<MDFSUtil>();
		/// <summary>
		/// The DiskListing's BlockDevice
		/// </summary>
		public IDE Disk;
		/// <summary>
		/// The DiskListing's Disk Number
		/// </summary>
		public int DiskNumber;
		/// <summary>
		/// Constructor for a Disk Listing
		/// </summary>
		/// <param name="num"></param>
		/// <param name="disk"></param>
		public MDFSUtil(int num, IDE disk)
		{
			DiskNumber = num;
			Disk = disk;
			DiskListings.Add(this);
		}
		/// <summary>
		/// String containing information about the Disk Listing
		/// </summary>
		public string Info
		{
			get
			{
				return ("disk: " + DiskNumber + " Size: " + Disk.Size + " MBs");
			}
		}
		/// <summary>
		/// Prints information about the DiskListing
		/// </summary>
		public void PrintInfo()
		{
			Console.WriteLine(Info);
		}
	}

	/// <summary>
	/// The Disk Utility class, containing methods and properties
	/// </summary>
	public class DiskUtil
	{
		/// <summary>
		/// Prints information about the currently selected disk, if any is selected
		/// </summary>
		public static void PrintSelectedDisk()
		{
			if (SelectedDisk != null)
			{

				SelectedDisk.PrintInfo();
			}
			else
			{
				Console.WriteLine("No disk is currently selected!");
			}
		}
		/// <summary>
		/// Defines the selected DiskListing
		/// </summary>
		public static MDFSUtil SelectedDisk;

		/// <summary>
		/// Main Disk Utility method, with the list of IDE devices passed as the parameter
		/// </summary>
		/// <param name="List"></param>
		public static void Main(IDE[] List)
		{
            
			bool running = true;
			Console.BackgroundColor = ConsoleColor.Blue;
			Console.Clear();
			Console.WriteLine("Welcome to the Medli Disk FileSystem Utility [MDFS]");
			Console.WriteLine("");
			while (running == true)
			{
				PrintSelectedDisk();
				Console.WriteLine("");
				Console.WriteLine("1) List Disks");
				Console.WriteLine("2) Select Disks");
				Console.WriteLine("3) List Partitions");
				Console.WriteLine("4) Create Partitions");
				Console.WriteLine("5) Exit disk utility");
                Console.WriteLine("");
                Console.Write(">");
                string option = Console.ReadLine().ToLower();
				if (option == "1")
				{
					ListDisks();
				}
				else if (option == "2")
				{
					SelectDisk();
				}
				else if (option == "3")
				{
					ListPartitions(SelectedDisk.Disk);
				}
				else if (option == "4")
				{
					CreatePartitions();
				}
				else if (option == "quit" || option == "exit" || option == "5")
				{
					running = false;
				}
				else
				{
					Console.WriteLine(option + ": Invalid option!");
				}
			}
			Console.Clear();
		}
		/// <summary>
		/// Selects a DiskListing from the list
		/// </summary>
		public static void SelectDisk()
		{
			SelectedDisk = null;
			do
			{
				Console.WriteLine("Which disk do you wish to use?");
				ListDisks();
				string nums = Console.ReadLine();
				int num = int.Parse(nums) - 1;
				if (num >= 0 && num < MDFSUtil.DiskListings.Count)
				{
					SelectedDisk = MDFSUtil.DiskListings[num];
				}
			}
			while (SelectedDisk == null);
		}

		/// <summary>
		/// Lists each of the disks from the list
		/// </summary>
		public static void ListDisks()
		{
			foreach (MDFSUtil disklist in MDFSUtil.DiskListings)
			{
				if (disklist == SelectedDisk)
				{
					Console.WriteLine("* " + disklist.Info);
				}
				else
				{
					disklist.PrintInfo();
				}
			}
		}

		/// <summary>
		/// Lists the partitions in the specified disk
		/// </summary>
		/// <param name="Device"></param>
		public static void ListPartitions(IDE Device)
		{
			if (Device == null)
			{
				Console.WriteLine("No disk selected!");
			}
			else
			{
				MBR mbr = Device.MBR;
				PartitionInfo[] partitions = mbr.Partitions;
				if ((partitions.Length > 0) && (partitions.Length <= 4))
				{
					foreach (PartitionInfo part in partitions)
					{
						Console.WriteLine(part.SystemID);
					}
				}
				else
				{
					Console.WriteLine("No partitions detected!");
				}
			}
		}

		/// <summary>
		/// Creates partitions on the selected DiskListing
		/// </summary>
		public static void CreatePartitions()
		{
			if (SelectedDisk == null)
			{
				Console.WriteLine("No disk is currently selected!");
			}
			else
			{
				int PartitionNumber = 0;
				ulong DisplayCount = SelectedDisk.Disk.BlockCount - 1;
				Console.WriteLine("How many primary partitions do you want to have? (Max. 4)");
				do
				{
					Console.WriteLine("Insert number");
					String nums = Console.ReadLine();
					PartitionNumber = int.Parse(nums);
				}
				while (PartitionNumber == 0 || PartitionNumber > 4);

				uint mbrpos = 446;
				Byte[] type = new Byte[] { 0x00, 0x00, 0x00, 0x00 };
				uint[] StartBlock = new uint[] { 1, 0, 0, 0 };
				uint[] BlockNum = new uint[] { 0, 0, 0, 0 };
				for (int i = 0; i < PartitionNumber; i++)
				{
					type[i] = 0xFA;
					Console.WriteLine("How many blocks for Partition N. " + (i + 1) + "? (Max: " + ((uint)(DisplayCount - (uint)(PartitionNumber - (i + 1)))).ToString() + "): ");
					String nums = Console.ReadLine();
					uint num = (uint)int.Parse(nums);
					if (num >= 0 && num <= DisplayCount - (uint)(PartitionNumber - (i + 1)))
					{
						BlockNum[i] = num;
						if (i < PartitionNumber - 1)
						{
							StartBlock[i + 1] = (num) + StartBlock[i];
						}
						DisplayCount = DisplayCount - (num);
					}
					else
					{
						i--;
					}
				}
				Byte[] data = SelectedDisk.Disk.NewBlockArray(1);
				SelectedDisk.Disk.ReadBlock(0, 1, data);
				for (int i = 0; i < 4; i++)
				{
					mbrpos += 4;
					data[mbrpos] = type[i];
					mbrpos += 4;
					Byte[] b = BitConverter.GetBytes(StartBlock[i]);
					MDFSUtils.CopyByteToByte(b, 0, data, (int)mbrpos, b.Length);
					mbrpos += 4;
					b = BitConverter.GetBytes(BlockNum[i]);
					MDFSUtils.CopyByteToByte(b, 0, data, (int)mbrpos, b.Length);
					mbrpos += 4;
					SelectedDisk.Disk.WriteBlock(StartBlock[i], 1, SelectedDisk.Disk.NewBlockArray(1));
				}
				SelectedDisk.Disk.WriteBlock(0, 1, data);
				ListPartitions(SelectedDisk.Disk);
			}
		}
	}
}
