using System;
using System.Collections.Generic;
using System.Text;
using MDFS;
using MDFS.Physical;
using Cosmos.HAL.BlockDevice;

namespace Medli.System.MDFS
{
    public class MDFile : MDEntry
    {
        /// <summary>
        /// The full path (path + filename) of the current file
        /// </summary>
        public String Filename
        {
            get
            {
                return MDFileSystem.ConcatDirectory(_path, Name);
            }
        }

        /// <summary>
        /// Writes the specified byte array into the file
        /// </summary>
        /// <param name="Data"></param>
        public void WriteAllBytes(Byte[] Data)
        {
            if (sBlock.NextBlock != 0)
            {
                MDFileSystem.Clean(sBlock);
                sBlock.NextBlock = 0;
                MDBlock.Write(MDFileSystem.cFS.Partition, sBlock);
            }
            int index = 0;
            MDBlock edge = MDBlock.GetFreeBlock(MDFileSystem.cFS.Partition);
            sBlock.NextBlock = edge.BlockNumber;
            MDBlock.Write(_partition, sBlock);
            do
            {
                Byte[] arr = new byte[MDBlock.MaxBlockContentSize];
                index = Utilities.CopyByteToByte(Data, index, arr, 0, arr.Length);
                edge.Used = true;
                edge.Content = arr;
                if (index != Data.Length)
                {
                    MDBlock fB = MDBlock.GetFreeBlock(MDFileSystem.cFS.Partition);
                    edge.NextBlock = fB.BlockNumber;
                    edge.ContentSize = (uint)arr.Length;
                    MDBlock.Write(MDFileSystem.cFS.Partition, edge);
                    edge = fB;
                }
                else
                {
                    edge.ContentSize = (uint)(Data.Length % arr.Length);
                    MDBlock.Write(MDFileSystem.cFS.Partition, edge);
                }
            }
            while (index != Data.Length);
            EditAttributes(EntryAttribute.DtM, DateTime.Now.UNIXTimeStamp);
            EditAttributes(EntryAttribute.DtA, DateTime.Now.UNIXTimeStamp);
        }

        /// <summary>
        /// Converts the specified text into a byte[] array, and writes the bytes to the file entry (WriteAllBytes())
        /// </summary>
        /// <param name="txt"></param>
        public void WriteAllText(String txt)
        {
            Byte[] tB = new byte[txt.Length];
            Utilities.CopyCharToByte(txt.ToCharArray(), 0, tB, 0, txt.Length);
            WriteAllBytes(tB);
        }

        /// <summary>
        /// Returns the bytes stored in the file entry
        /// </summary>
        /// <returns></returns>
        public Byte[] ReadAllBytes()
        {
            if (sBlock.NextBlock == 0)
            {
                return new byte[0];
            }
            MDBlock b = sBlock;
            List<Byte> bL = new List<Byte>();
            while (b.NextBlock != 0)
            {
                b = MDBlock.Read(b.Partition, b.NextBlock);
                for (int i = 0; i < b.ContentSize; i++)
                {
                    bL.Add(b.Content[i]);
                }
            }
            EditAttributes(EntryAttribute.DtA, DateTime.Now.UNIXTimeStamp);
            return bL.ToArray();
        }

        /// <summary>
        /// Converts the file entry's bytes into a string, and returns it
        /// </summary>
        /// <returns></returns>
        public string ReadAllText()
        {
            Byte[] b = ReadAllBytes();
            Char[] txt = new char[b.Length];
            Utilities.CopyByteToChar(b, 0, txt, 0, b.Length);
            return Utilities.CharToString(txt);
        }

        /// <summary>
        /// MDFS File object constructor
        /// </summary>
        /// <param name="part"></param>
        /// <param name="blockNumber"></param>
        /// <param name="path"></param>
        public MDFile(Partition part, ulong blockNumber, String path)
        {
            _path = path;
            _partition = part;
            sBlock = MDBlock.Read(part, blockNumber);
            if (!sBlock.Used)
            {
                sBlock.Used = true;
                String name = "New File";
                CreateEntry(_partition, sBlock, name);
            }
        }
    }
}
