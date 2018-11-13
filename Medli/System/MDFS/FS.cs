﻿using System;
using System.Collections.Generic;
using System.Text;
using MDFS;
using MDFS.Physical;
using Cosmos.HAL.BlockDevice;

namespace Medli.System.MDFS
{
    public class MDFileSystem
    {
        public static List<MDFileSystem> fileSystems = new List<MDFileSystem>();

#warning NotImplemented Property - MDFS ID
        // The following property is kept private until a working implementation is finished
        /// <summary>
        /// The filesystem's ID
        /// </summary>
        private int ID;

        public static String separator = "/";

        /// <summary>
        /// Drive partition upon which the filesystem resides
        /// Only visisble to internal methods & properties
        /// </summary>
        private Partition _partition;

        /// <summary>
        /// Filesystem signature - stored at the beginning of the partition
        /// </summary>
        private Byte[] fSignature = new byte[] { 0x4D, 0x65, 0x64, 0x6C, 0x69, 0x44, 0x46, 0x53 };

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


#warning NotImplemented Method - MapFS(MDFileSystem)
        // The following method is kept private until a working implementation is finished.
        /// <summary>
        /// Map a filesystem based on it's ID to the specified path
        /// </summary>
        /// <param name="fsPath"></param>
        /// <param name="fileSystem"></param>
        private static void MapFS(string fsPath, int id, MDFileSystem fileSystem)
        {
            foreach (MDFileSystem mDFS in fileSystems)
            {
                if (id == mDFS.ID)
                {

                }
            }
            cFS = fileSystem;
        }

        /// <summary>
        /// Concatenates a file and it's path location, resulting in full path
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fname"></param>
        /// <returns>Full path location of file</returns>
        public static string ConcatFile(string path, string fname)
        {
            String file = "";
            file = path.TrimEnd(separator.ToCharArray());
            if (file == null)
            {
                file = "";
            }
            if (fname != separator)
            {
                file += file += separator + fname;
            }
            else
            {
                file = separator;
            }
            return file;
        }

        /// <summary>
        /// Concatenates a directory and it's path location, resulting in full path
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dir"></param>
        /// <returns>Full path location of directory</returns>
        public static string ConcatDirectory(string path, string dir)
        {
            String directory = "";
            directory = path.TrimEnd(separator.ToCharArray());
            if (directory == null)
            {
                directory = "";
            }
            if (dir != separator)
            {
                directory += separator + dir + separator;
            }
            else
            {
                directory = separator;
            }
            return directory;
        }

        /// <summary>
        /// The filesystem that is currently in use
        /// </summary>
        public static MDFileSystem cFS = null;

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
                // If unable to detect a valid partition
                if (!GenerateFS())
                {
                    // Error - unable to create a new filesystem on specified partition
                }
                else
                {
                    fileSystems.Add(this);
                }
            }
            else
            {
                fileSystems.Add(this);
            }
        }

        /// <summary>
        /// Generates a new FS block structure on specified filesystem
        /// </summary>
        /// <param name="part"></param>
        /// <returns></returns>
        private bool GenerateFS(Partition part)
        {
            Refresh(10000);
            Byte[] data = part.NewBlockArray(1);
            fSignature.CopyTo(data, 0);
            for (int i = fSignature.Length; i < fSignature.Length; i++)
            {
                data[i] = fSignature[i];
            }
            part.WriteBlock(0, 1, data);
            return true;
        }

        /// <summary>
        /// Generates a new FS block structure on pre-set filesystem
        /// </summary>
        /// <param name="part"></param>
        /// <returns></returns>
        private bool GenerateFS()
        {
            Refresh(10000);
            Byte[] data = _partition.NewBlockArray(1);
            fSignature.CopyTo(data, 0);
            for (int i = fSignature.Length; i < fSignature.Length; i++)
            {
                data[i] = fSignature[i];
            }
            _partition.WriteBlock(0, 1, data);
            return true;
        }

        /// <summary>
        /// Tests to see if partition object (_partition) contains a valid MDFS filesystem block structure (does the partition signature match the ASCII string 'MedliDFS')
        /// </summary>
        /// <returns></returns>
        public bool IsValidFS()
        {
            Byte[] data = _partition.NewBlockArray(1);
            for (int i = 0; i < fSignature.Length; i++)
            {
                if (fSignature[i] != data[i])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Cleans a filesystem by a specified amount of blocks
        /// (default is BlockCount)
        /// </summary>
        /// <param name="sBlock"></param>
        public void Refresh(ulong sBlock = 0)
        {
            Byte[] data = _partition.NewBlockArray(1);
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = 0;
            }
            MDUtils.WriteLine("Proceeding to refresh the filesystem...");
            ulong lBlock = _partition.BlockCount;
            if (sBlock != 0)
            {
                lBlock = sBlock;
            }
            ulong rate = lBlock / 100;
            uint perc = 0;
            MDUtils.WriteOnLastLine(perc + "% refreshed. " + (uint) lBlock + " blocks remaining.");
            for (ulong i = 0; i < lBlock; i++)
            {
                Partition.WriteBlock(i, 1, data);
                if (i % rate == 0)
                {
                    perc++;
                }
                if (i % 32 == 0)
                {
                    MDUtils.WriteOnLastLine(perc + "% refreshed. " + ((uint) (lBlock - i)) + " blocks remaining.");
                }
            }
            MDUtils.WriteOnLastLine("Successfully refreshed filesystem.");
        }

        public static void Clean(MDBlock sBlock)
        {
            MDBlock block = sBlock;
            while (block.NextBlock != 0)
            {
                block = MDBlock.Read(block.Partition, block.NextBlock);
                block.Used = false;
                MDBlock.Write(cFS.Partition, block);
            }
        }
    }
}
