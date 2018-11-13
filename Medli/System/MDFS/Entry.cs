using System;
using System.Collections.Generic;
using System.Text;
using MDFS;
using MDFS.Physical;
using Cosmos.HAL.BlockDevice;

namespace Medli.System.MDFS
{
    /// <summary>
    /// Modifiable attributes of filesystem entries
    /// </summary>
    public enum EntryAttribute
    {
        /// <summary>
        /// Date/Time Created
        /// </summary>
        DtC = 0x00,

        /// <summary>
        /// Date/Time Modified
        /// </summary>
        DtM = 0x08,

        /// <summary>
        /// Date/Time Last Accessed
        /// </summary>
        DtA = 0x10,

        /// <summary>
        /// Owner
        /// </summary>
        OwR = 0x18,

        /// <summary>
        /// Group
        /// </summary>
        GoP = 0x20,

        /// <summary>
        /// Visisibility
        /// </summary>
        HdN = 0x28,

        /// <summary>
        /// Read/Write Permissions
        /// </summary>
        ReW = 0x29,

        /// <summary>
        /// Owner Permissions
        /// </summary>
        OwP = 0x30,

        /// <summary>
        /// Group Permissions
        /// </summary>
        GrP = 0x3a,

        /// <summary>
        /// Global Permissions
        /// </summary>
        GlP = 0x3b
    }

    public class MDEntry
    {
        /// <summary>
        /// Char[] array of characters that are invalid for use in files/directories
        /// </summary>
        protected static Char[] UnacceptableChars = new char[] { '/', '?', '*' };

        /// <summary>
        /// The starting block of this FileSystem entry
        /// </summary>
        protected MDBlock sBlock;

        /// <summary>
        /// The filesystem path of the entry
        /// </summary>
        protected String _path;
        
        /// <summary>
        /// The partition upon which the entry resides
        /// </summary>
        protected Partition _partition;

        /// <summary>
        /// The maximum length a filename can be
        /// </summary>
        private static int MaxFNL = 255;

        /// <summary>
        /// Path of the FS entry
        /// </summary>
        public String Path
        {
            get
            {
                return _path;
            }
        }

        /// <summary>
        /// Returns the FileSystem entryname
        /// </summary>
        public String Name
        {
            get
            {
                Byte[] arr = sBlock.Content;
                String ret = "";
                for (int i = 0; i < MaxFNL; i++)
                {
                    if (arr[i] == 0)
                    {
                        break;
                    }
                    ret += ((Char) arr[i]).ToString();
                }
                return ret;
            }
        }

        /// <summary>
        /// Sets the entry's attributes to the specified
        /// </summary>
        /// <param name="Entry"></param>
        /// <param name="value"></param>
        public void EditAttributes(EntryAttribute Attrib, long value)
        {
            if (Attrib < EntryAttribute.HdN)
            {
                Utilities.CopyByteToByte(BitConverter.GetBytes(value), 0, sBlock.Content, MaxFNL + (int)Attrib, 8, false);
            }
            else
            {
                Utilities.CopyByteToByte(BitConverter.GetBytes(value), 0, sBlock.Content, MaxFNL + (int)Attrib, 1, false);
            }
        }

        /// <summary>
        /// Creates a new FS entry at the specified partititon block
        /// </summary>
        /// <param name="_part"></param>
        /// <param name="block"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        protected static MDBlock CreateEntry(Partition _part, MDBlock block, String name)
        {
            if (block != null && ((!Utilities.StringContains(name, UnacceptableChars)) || block.BlockNumber == 0))
            {
                block.Used = true;
                block.NextBlock = 0;
                block.TotalSize = 0;
                char[] nm = name.ToCharArray();
                for (int i = 0; i < nm.Length; i++)
                {
                    block.Content[i] = (byte)nm[i];
                }
                if (block.BlockNumber != 0)
                {
                    Utilities.CopyByteToByte(BitConverter.GetBytes(DateTime.Now.UNIXTimeStamp), 0, block.Content, MaxFNL + (int)EntryAttribute.DtC, 8, false);
                }
                block.Content[nm.Length] = 0;
                block.ContentSize = (uint)nm.Length;
                MDBlock.Write(_part, block);
                return block;
            }
            return null;
        }

        /// <summary>
        /// Creates a new FS entry at the next available partition block
        /// </summary>
        /// <param name="_part"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        protected static MDBlock CreateEntry(Partition _part, String name)
        {
            return CreateEntry(_part, MDBlock.GetFreeBlock(_part), name);
        }
    }
}
