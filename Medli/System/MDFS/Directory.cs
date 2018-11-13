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
        /// The full path (path+Name) of the current Directory
        /// </summary>
        public String DirectoryName
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
        /// <param name="blockNumber">The block number we want to use</param>
        /// <param name="path">The path of the new directory</param>
        public MDDirectory(Partition partition, ulong blockNumber, String path)
        {
            _path = path;
            _partition = partition;
            sBlock = MDBlock.Read(partition, blockNumber);
            if (blockNumber == 1 && path == "/" && sBlock.Content[0] != '/')
            {
                Char[] nm = "/".ToCharArray();
                for (int i = 0; i < nm.Length; i++)
                {
                    sBlock.Content[i] = (byte)nm[i];
                }
                sBlock.Used = true;
                sBlock.NextBlock = 0;
                MDBlock.Write(partition, sBlock);
            }
            if (!sBlock.Used)
            {
                sBlock.Used = true;
                String n = "New Directory";
                if (path == MDFileSystem.separator)
                {
                    _path = "";
                    n = path;
                }
                CreateEntry(partition, sBlock, n);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MDDirectory[] RetrieveDirectories()
        {
            MDBlock curb = sBlock;
            List<MDDirectory> d = new List<MDDirectory>();
            while (curb.NextBlock != 0)
            {
                int index = 0;
                curb = MDBlock.Read(sBlock.Partition, sBlock.NextBlock);
                while (index < curb.ContentSize)
                {
                    ulong a = BitConverter.ToUInt64(curb.Content, index);
                    index += 8;
                    uint sep = BitConverter.ToUInt32(curb.Content, index);
                    index += 4;
                    if (sep == 1)
                    {
                        d.Add(new MDDirectory(_partition, a, MDFileSystem.ConcatDirectory(_path, Name)));
                    }
                }
            }
            return d.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MDFile[] RetrieveFiles()
        {
            MDBlock curb = sBlock;
            List<MDFile> d = new List<MDFile>();
            while (curb.NextBlock != 0)
            {
                int index = 0;
                curb = MDBlock.Read(sBlock.Partition, sBlock.NextBlock);
                while (index < curb.ContentSize)
                {
                    ulong a = BitConverter.ToUInt64(curb.Content, index);
                    index += 8;
                    uint sep = BitConverter.ToUInt32(curb.Content, index);
                    index += 4;
                    if (sep == 1)
                    {
                        d.Add(new MDFile(_partition, a, MDFileSystem.ConcatDirectory(_path, Name)));
                    }
                }
            }
            return d.ToArray();
        }

        /// <summary>
        /// Retrieves the entries stored in the directory
        /// </summary>
        /// <returns></returns>
        public MDEntry[] RetrieveEntries()
        {
            MDBlock edge = sBlock;
            List<MDEntry> entries = new List<MDEntry>();
            while (edge.NextBlock != 0)
            {
                int index = 0;
                edge = MDBlock.Read(sBlock.Partition, sBlock.NextBlock);
                while (index < edge.ContentSize)
                {
                    ulong a = BitConverter.ToUInt64(edge.Content, index);
                    index += 8;
                    uint sep = BitConverter.ToUInt32(edge.Content, index);
                    index += 4;
                    if (sep == 1)
                    {
                        entries.Add(new MDDirectory(_partition, a, MDFileSystem.ConcatDirectory(_path, Name)));
                    }
                    else if (sep == 2)
                    {
                        entries.Add(new MDFile(_partition, a, MDFileSystem.ConcatDirectory(_path, Name)));
                    }
                }
            }
            return entries.ToArray();
        }

        public void AddDirectory(String Name)
        {
            MDEntry[] directories = RetrieveEntries();
            for (int i = 0; i < directories.Length; i++)
            {
                if (directories[i].Name == Name)
                {
                    throw new Exception("The directory already exists!");
                    return;
                }
            }
            MDBlock edge = EditBlock();
            MDBlock nDirB = CreateEntry(_partition, Name);
            BitConverter.GetBytes(nDirB.BlockNumber).CopyTo(edge.Content, edge.ContentSize);
            BitConverter.GetBytes((uint)1).CopyTo(edge.Content, edge.ContentSize + 8);
            edge.ContentSize += 12;
            MDBlock.Write(_partition, edge);
            EditAttributes(EntryAttribute.DtM, DateTime.Now.UNIXTimeStamp);
            EditAttributes(EntryAttribute.DtA, DateTime.Now.UNIXTimeStamp);
        }


        /// <summary>
        /// Gets the last NoobFSBlock of the directory
        /// </summary>
        private MDBlock EditBlock()
        {
            MDBlock ret = sBlock;
            while (ret.NextBlock != 0)
            {
                ret = MDBlock.Read(sBlock.Partition, sBlock.NextBlock);
            }
            if (ret.BlockNumber == sBlock.BlockNumber)
            {
                ret = MDBlock.GetFreeBlock(_partition);
                ret.Used = true;
                ret.ContentSize = 0;
                ret.NextBlock = 0;
                sBlock.NextBlock = ret.BlockNumber;
                MDBlock.Write(_partition, sBlock);
                MDBlock.Write(_partition, ret);
            }
            if (_partition.NewBlockArray(1).Length - ret.ContentSize < 12)
            {
                MDBlock block = MDBlock.GetFreeBlock(_partition);
                if (block == null)
                {
                    return null;
                }
                ret.NextBlock = block.BlockNumber;
                MDBlock.Write(_partition, ret);
                block.Used = true;
                ret = block;
            }
            return ret;
        }

        /// <summary>
        /// Get the directory specified by the Fullname passed
        /// </summary>
        /// <param name="fn">The fullname of the directory</param>
        public static MDDirectory GetDirectoryByFullName(String fn)
        {
            MDDirectory dir = MDFileSystem.cFS.Root;
            if (fn == dir.Name)
            {
                return dir;
            }
            if (fn == null || fn == "")
            {
                return null;
            }
            String[] names = fn.Split('/');
            if (names[0] != "")
            {
                return null;
            }
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] != null && names[i] != "")
                {
                    dir = dir.GetDirectoryByName(names[i]);
                    if (dir == null)
                    {
                        break;
                    }
                }
            }
            return dir;
        }

        /// <summary>
        /// Get the directory specified by the Name passed
        /// </summary>
        /// <param name="n">The name of the child directory</param>
        public MDDirectory GetDirectoryByName(String n)
        {
            MDDirectory[] dirs = RetrieveDirectories();
            for (int i = 0; i < dirs.Length; i++)
            {
                if (dirs[i].Name == n)
                {
                    return dirs[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Overrides the ToString Method.
        /// </summary>
        public override String ToString()
        {
            return this.Name;
        }

        /// <summary>
        /// Get the directory specified by the Fullname passed
        /// </summary>
        /// <param name="fn">The fullname of the directory</param>
        public static MDFile GetFileByFullName(String fn)
        {
            MDDirectory dir = new MDDirectory(MDFileSystem.cFS.Partition, 1, MDFileSystem.separator);
            if (fn == null || fn == "")
            {
                return null;
            }
            String[] names = fn.Split('/');
            for (int i = 0; i < names.Length - 1; i++)
            {
                if (names[i] != "")
                {
                    dir = dir.GetDirectoryByName(names[i]);
                    if (dir == null)
                    {
                        break;
                    }
                }
            }
            return dir.RetrieveFileByName(names[names.Length - 1]);
        }

        /// <summary>
        /// Get the file specified by the Name passed
        /// </summary>
        /// <param name="n">The name of the child file</param>
        public MDFile RetrieveFileByName(String n)
        {
            MDFile[] files = RetrieveFiles();
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Name == n)
                {
                    return files[i];
                }
            }
            return null;
        }
    }
}
