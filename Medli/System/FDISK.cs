using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.HAL.BlockDevice;

namespace Medli.System
{
    class FDISK
    {
		private ushort getShort(ushort first, byte second)
		{
			ushort n = (ushort)(second << 10 | first);
			return n;
		}
		private ushort getShort1(ushort first)
		{
			ushort y = (ushort)(int)(first & 0x3F);
			ushort x = (ushort)((first << 10) & 63); // the last 6 bits
			return y;
		}
		private ushort getShort2(ushort first)
		{
			return (ushort)(int)(first >> 10);

		}

		Core.BinaryWriter bw = new Core.BinaryWriter(new Core.MemoryStream(512));


		public void Execute()
		{
			Console.Clear();
			string devn = "/dev/sda";
			AtaPio bd = (AtaPio) Hardware.Devices.getDevice(devn);
			bd.ReadBlock(0, 1, bw.BaseStream.Data);
			Console.WriteLine("Medli Disk Utility (MDisk)");
			Console.WriteLine("Enter command (m for help)");
			while (true)
			{
				Console.Write("> ");
				string command = Console.ReadLine();
				if (command == "n")
				{
					Console.Write("Partition(1-4):");
					string part = Console.ReadLine();
					Console.Write("Blocks:");
					int size = Common.Extensions.StringToInt(Console.ReadLine());
					bool greater_than_one = false;

					int address = 446;
					byte head_start = 1;
					ushort start_sect = 1;
					byte start_cyln = 1;
					uint rel_sect = 1;
					if (part == "1")
					{
						address = 446;
					}
					else if (part == "2")
						address = 462;
					else if (part == "3")
						address = 478;
					else if (part == "4")
						address = 494;
					if (address != 446)
					{
						Core.BinaryReader br = new Core.BinaryReader(bw.BaseStream);
						br.BaseStream.Position = address - 16;
						br.BaseStream.Position++;
						br.BaseStream.Position += 3;
						head_start = br.BaseStream.Read();
						byte b1 = br.BaseStream.Read();
						byte b2 = br.BaseStream.Read();
						ushort us = BitConverter.ToUInt16(new byte[] { b1, b2 }, 0);
						start_sect = getShort1(us);
						start_cyln = (byte)getShort2(us);
						rel_sect = br.ReadUInt32();
						greater_than_one = true;
					}
					bw.BaseStream.Position = address;
					bw.Write((byte)0);

					bw.Write(head_start);
					bw.Write((ushort)getShort(start_sect, start_cyln));
					bw.Write((byte)1);

					uint c = (uint)(size / 12);
					if (greater_than_one)
						c = (uint)((rel_sect + size) / 12);
					bw.Write((byte)(c * 6));

					bw.Write((ushort)getShort(12, (byte)c));
					bw.Write((uint)rel_sect);
					bw.Write((uint)size);



				}
				else if (command == "a")
				{
					Console.Write("Partition(1-4):");
					string part = Console.ReadLine();
					int address = 462;
					if (part == "1")
					{
						address = 446;
					}
					else if (part == "2")
						address = 462;
					else if (part == "3")
						address = 478;
					else if (part == "4")
						address = 494;

					if (bw.BaseStream.Data[address] == 0)
						bw.BaseStream.Data[address] = (byte)1;
					else
						bw.BaseStream.Data[address] = (byte)0;
				}
				else if (command == "t")
				{
					Console.Write("Partition(1-4):");

					string part = Console.ReadLine();
					Console.Write("System Label: ");
					int t = Common.Extensions.StringToInt(Console.ReadLine());
					int address = 462;

					if (part == "1")
					{
						address = 446;
					}
					else if (part == "2")
						address = 462;
					else if (part == "3")
						address = 478;
					else if (part == "4")
						address = 494;
					address += 5;
					bw.BaseStream.Position = address;
					bw.Write((byte)(uint)t);
				}
				else if (command == "q")
					break;
				else if (command == "w")
				{
					Console.WriteLine("Writing to partition table...");
					bw.BaseStream.Close();
					bd.WriteBlock(0, 1, bw.BaseStream.Data);
					Console.WriteLine("Changes saved!");
					break;
				}


				else if (command == "d")
				{
					Console.Write("Partition(1-4):");
					string part = Console.ReadLine();
					int address = 446;

					if (part == "1")
					{
						address = 446;
					}
					else if (part == "2")
						address = 462;
					else if (part == "3")
						address = 478;
					else if (part == "4")
						address = 494;
					bw.BaseStream.Position = address;
					for (int i = 1; i < 16; i++)
					{
						bw.Write((byte)0);
					}
				}

				else if (command == "help" || command == "m")
				{
					Console.WriteLine(@"Command (m for help): m
Command action
   a   toggle a bootable flag
   d   delete a partition
   m   print this menu
   n   add a new partition
   p   print the partition table
   q   quit
   t   change a partition's system id
   w   write table to disk and exit");
				}
			}

		}


	}
}
