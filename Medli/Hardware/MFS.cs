using System;
using System.Collections.Generic;
using System.Text;
using Medli.Core;

namespace Medli.Hardware
{
    public class MFS
    {
		protected static Core.Device Disk;
		public enum FileType
		{
			Executable,
			Text,
			Script,
			Hybrid,
		}

		public enum FileAttribute
		{
			ReadOnly,
			WriteOnly,
			Hybrid,
		}

		public struct File
		{
			public string Name;
			public int index;
			public ushort[] Data;
			public FileType Type;
			public FileAttribute Attribute;
			public uint LBA;
			public uint LBAE;
		}

		public struct Folder
		{
			public string Name;
			public int index;
		}

		public static File[] Files;

		public static Folder[] Folders;
		public void InitFileSystem(Core.Device aDevice)
		{
			Disk = aDevice;
		}

		public void ChangeDisk(Core.Device aDevice)
		{
			Disk = aDevice;
		}

		public static void ReadFile(string Name)
		{
			for (int i = 0; i < Files.Length; i++)
			{
				if (Files[i].Name == Name)
				{
					Files[i].Data = Disk.ReadBlock(Files[i].LBA);
					break;
				}
			}
		}
		public void WriteFile(string Name)
		{
			for (int i = 0; i < Files.Length; i++)
			{
				if (Files[i].Name == Name)
				{
					Disk.WriteBlock(Files[i].LBA, Files[i].Data);
					break;
				}
			}
		}

		//OS not ready for Dir listing Yet. we need multitasking first.
		public string[] ListRootDirs()
		{
			return new string[2];
		}

		public string[] ListDirs(string RootDir)
		{
			//string[] temp0;
			return new string[2];
		}
		public string[] ListFiles(string RootDir)
		{
			return new string[2];
		}
	}
}
