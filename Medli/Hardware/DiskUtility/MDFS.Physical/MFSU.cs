using System;
using System.Collections.Generic;
using MDFS.Physical;
using Cosmos.HAL;

namespace MDFS
{
    /// <summary>
    /// Defines a disk listing
    /// </summary>
    public class DiskListing
    {
        /// <summary>
        /// Static List of DiskListings
        /// </summary>
        public static List<DiskListing> DiskListings = new List<DiskListing>();

        /// <summary>
        /// Static List of PartitionListings
        /// </summary>
        public List<PartitionListing> PartitionListings = new List<PartitionListing>();

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
        public DiskListing(int num, IDE disk)
        {
            DiskNumber = num + 1;
            Disk = disk;
            DiskListings.Add(this);
            int pnum = 0;
            foreach (PrimaryPartition Partition in disk.PrimaryPartitions)
            {
                pnum += 1;
                PartitionListings.Add(new PartitionListing(pnum, this, Partition.Infos));
            }
        }

        /// <summary>
        /// String containing information about the Disk Listing
        /// </summary>
        public string Info
        {
            get
            {
                return ("Disk: " + DiskNumber + " Size: " + Disk.Size + " MBs");
            }
        }

        public void PartInfo()
        {
            foreach (PartitionListing partition in PartitionListings)
            {
                Console.WriteLine(partition.Info);
            }
        }

        /// <summary>
        /// Prints information about the DiskListing
        /// </summary>
        public void PrintInfo()
        {
            Console.WriteLine("\t" + Info);
        }
    }

    /// <summary>
    /// Defines a partition listing
    /// </summary>
    public class PartitionListing
    {
        public DiskListing Disk;
        public int PartNum;
        public PartitionInfo Partition;
        public uint Size;
        public byte ID;

        public PartitionListing(int num, DiskListing disk, PartitionInfo part)
        {
            this.Disk = disk;
            this.PartNum = num;
            this.Partition = part;
            this.Size = part.TotalSize;
            this.ID = part.SystemID;
        }

        public string Info
        {
            get
            {
                return ("Disk: " + this.Disk.DiskNumber + ", Partition: " + this.PartNum + ", Type: " + this.ID + ", Size: " + this.Size + "MBs");
            }
        }
    }

    /// <summary>
    /// The Disk Utility class, containing methods and properties
    /// </summary>
    public class MFSUtility
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
        public static DiskListing SelectedDisk = null;

		/// <summary>
		/// Defines the selected disk number. Default is 999 (invalid)
		/// </summary>
		public static int SelectedDiskNumber = 999;

        /// <summary>
        /// Main Disk Utility method, with the list of IDE devices passed as the parameter
        /// TODO - Remove the requirement for the IDE array to be passed as array - or move detection to INIT1
        /// </summary>
        /// <param name="List"></param>
        public static void Main(IDE[] List)
        {

            bool running = true;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine("Welcome to the Medli File System Utility [MFSU]");
            Console.WriteLine("");
            while (running == true)
            {
                Console.WriteLine("");
                Console.WriteLine("1) List Disks 2) Select Disks 3) List Partitions\n4) Create Partitions 5) Exit disk utility");
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
                    DiskPartInfo();
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
        }
        /// <summary>
        /// Selects a DiskListing from the list
        /// </summary>
        public static void SelectDisk()
        {
            SelectedDisk = null;
            do
            {
                Console.WriteLine("Which disk do you wish to use?\n");
                ListDisks();
                string nums = Console.ReadLine();
                int num = int.Parse(nums) - 1;
                if (num >= 0 && num < DiskListing.DiskListings.Count)
                {
                    SelectedDisk = DiskListing.DiskListings[num];
					SelectedDiskNumber = num;
				}
            }
            while (SelectedDisk == null || SelectedDiskNumber == 999);
        }

        /// <summary>
        /// Lists each of the disks from the list
        /// </summary>
        public static void ListDisks()
        {
			Console.WriteLine(DiskListing.DiskListings.Count + " disks found!");
			int i = 0;
            for (i = 0; i < DiskListing.DiskListings.Count; i++)
            {
                if (i == SelectedDiskNumber)
                {
                    Console.WriteLine("*\t" + DiskListing.DiskListings[i].Info);
                }
                else
                {
					DiskListing.DiskListings[i].PrintInfo();
                }
            }
        }

        /// <summary>
        /// Lists the partitions in the specified disk
        /// </summary>
        /// <param name="Device"></param>
        public static void DiskPartInfo()
        {
            if (SelectedDisk != null)
            {
                SelectedDisk.PartInfo();
            }
            else
            {
                Console.WriteLine("No disk selected!\n");
            }
        }

        //public static void ListPartitions(IDE Device)
        //{
        //	if (Device == null)
        //	{
        //		Console.WriteLine("No disk selected!\n");
        //	}
        //	else
        //	{
        //		MBR mbr = Device.MBR;
        //		PartitionInfo[] partitions = mbr.Partitions;
        //		if ((partitions.Length > 0) && (partitions.Length <= 4))
        //		{
        //			foreach (PartitionInfo part in partitions)
        //			{
        //				Console.WriteLine("Partition ID: " + part.SystemID + "  Size: " + part.TotalSize + " MBs");
        //			}
        //		}
        //		else
        //		{
        //			Console.WriteLine("No partitions detected!\n");
        //		}
        //	}
        //}


        /// <summary>
        /// Creates partitions on the selected disk
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
                    Utilities.CopyByteToByte(b, 0, data, (int)mbrpos, b.Length);
                    mbrpos += 4;
                    b = BitConverter.GetBytes(BlockNum[i]);
                    Utilities.CopyByteToByte(b, 0, data, (int)mbrpos, b.Length);
                    mbrpos += 4;
                    SelectedDisk.Disk.WriteBlock(StartBlock[i], 1, SelectedDisk.Disk.NewBlockArray(1));
                }
                SelectedDisk.Disk.WriteBlock(0, 1, data);
                DiskPartInfo();
            }
        }
    }
}