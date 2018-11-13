using System;
using System.Collections.Generic;
using System.Text;
using MDFS;
using MDFS.Physical;
using Cosmos.HAL.BlockDevice;

namespace Medli.System.MDFS
{
    public class MDBlock
    {
        public static uint MaxBlockContentSize = 491;

        private Partition _partition;

        private ulong _blockNo = 0;

        private bool _Used = false;
        private uint _cSize = 0;
        private ulong _tSize = 0;
        private ulong _nBlock = 0;

        /// <summary>
        /// The partition holding the block
        /// </summary>
        public Partition Partition
        {
            get
            {
                return _partition;
            }
        }

        /// <summary>
        /// The number of the current block
        /// </summary>
        public ulong BlockNumber
        {
            get
            {
                return _blockNo;
            }
        }

        /// <summary>
        /// Bool whether block used or not used
        /// </summary>
        public bool Used
        {
            get
            {
                return _Used;
            }
            set
            {
                _Used = value;
            }
        }

        /// <summary>
        /// The current content Size
        /// </summary>
        public uint ContentSize
        {
            get
            {
                return _cSize;
            }
            set
            {
                _cSize = value;
            }
        }

        /// <summary>
        /// Total size of the Entry (Not Used)
        /// </summary>
        public ulong TotalSize
        {
            get
            {
                return _tSize;
            }
            set
            {
                _tSize = value;
            }
        }

        /// <summary>
        /// The next block number to read al the content
        /// </summary>
        public ulong NextBlock
        {
            get
            {
                return _nBlock;
            }
            set
            {
                _nBlock = value;
            }
        }

        /// <summary>
        /// The Content Byte Array. TO-DO: code this better
        /// </summary>
        public Byte[] Content;

        /// <summary>
        /// Creates a new virtual Block.
        /// </summary>
        /// <param name="Data">The Byte data</param>
        /// <param name="p">The partition to use</param>
        /// <param name="bn">The block number</param>
        public MDBlock(Byte[] Data, Partition p, ulong bn)
        {
            _blockNo = bn;
            _partition = p;
            Content = new Byte[Data.Length - 21];
            if (Data[0] == 0x00)
            {
                _Used = false;
                for (int i = 0; i < Content.Length; i++)
                {
                    Content[i] = 0;
                }
            }
            else
            {
                _Used = true;
                _cSize = BitConverter.ToUInt32(Data, 1);
                _tSize = BitConverter.ToUInt64(Data, 5);
                _nBlock = BitConverter.ToUInt64(Data, 13);
                for (int i = 21; i < Data.Length; i++)
                {
                    Content[i - 21] = Data[i];
                }
            }
        }

        /// <summary>
        /// The
        /// </summary>
        /// <param name="p">The partition to read</param>
        /// <param name="bn">The blocknumber to read</param>
        public static MDBlock Read(Partition p, ulong bn)
        {
            Byte[] data = p.NewBlockArray(1);
            p.ReadBlock(bn, 1, data);
            return new MDBlock(data, p, bn);
        }

        /// <summary>
        /// Writes a block into a specific partition
        /// </summary>
        /// <param name="p">The partition to write to</param>
        /// <param name="b">The block to write</param>
        public static void Write(Partition p, MDBlock b)
        {
            Byte[] data = new Byte[p.BlockSize];
            int index = 0;
            if (b.Used)
            {
                data[index++] = 0x01;
            }
            else
            {
                data[index++] = 0x00;
            }
            Byte[] x = BitConverter.GetBytes(b.ContentSize);
            for (int i = 0; i < x.Length; i++)
            {
                data[index++] = x[i];
            }
            x = BitConverter.GetBytes(b.TotalSize);
            for (int i = 0; i < x.Length; i++)
            {
                data[index++] = x[i];
            }
            x = BitConverter.GetBytes(b.NextBlock);
            for (int i = 0; i < x.Length; i++)
            {
                data[index++] = x[i];
            }
            x = b.Content;
            for (int i = 0; i < x.Length; i++)
            {
                data[index++] = x[i];
            }
            p.WriteBlock(b.BlockNumber, 1, data);
        }

        /// <summary>
        /// Get the next free block from the selected partition (TO-DO: Implement something that runs faster)
        /// </summary>
        /// <param name="p">The partition to get the block from</param>
        public static MDBlock GetFreeBlock(Partition p)
        {
            for (ulong i = 1; i < p.BlockCount; i++)
            {
                MDBlock b = Read(p, i);
                if (!b.Used)
                {
                    return b;
                }
            }
            return null;
        }
    }
}
