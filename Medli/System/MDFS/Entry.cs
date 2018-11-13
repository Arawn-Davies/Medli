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
    }
}
