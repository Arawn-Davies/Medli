using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.System.Utils
{
    /// <summary>
    /// Class definition for BinaryReader
    /// </summary>
    public class BinaryReader
    {
        /// <summary>
        /// The position
        /// </summary>
        private int _pos = 0;
        /// <summary>
        /// The data
        /// </summary>
        private byte[] _data;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryReader"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        public BinaryReader(byte[] data)
        {
            _data = data;
        }

        /// <summary>
        /// Seeks the specified position.
        /// </summary>
        /// <param name="pos">The position.</param>
        /// <returns></returns>
        public int Seek(int pos)
        {
            var oldPos = _pos;
            _pos = pos;
            return oldPos;
        }

        /// <summary>
        /// Tells this instance.
        /// </summary>
        /// <returns></returns>
        public int Tell()
        {
            return _pos;
        }

        /// <summary>
        /// Returns the data stored at location in uint8.
        /// </summary>
        /// <returns></returns>
        public byte GetUint8()
        {
            return _data[_pos++];
        }

        /// <summary>
        /// Returns the data stored at location in uint16.
        /// </summary>
        /// <returns></returns>
        public ushort GetUint16()
        {
            return (ushort)(((GetUint8() << 8) | GetUint8()) >> 0);
        }

        /// <summary>
        /// Returns the data stored at location in uint32.
        /// </summary>
        /// <returns></returns>
        public uint GetUint32()
        {
            return (uint)GetInt32();
        }

        /// <summary>
        /// Returns the data stored at location in int16.
        /// </summary>
        /// <returns></returns>
        public short GetInt16()
        {
            //            var result = GetUint16();
            //             if ((result & 0x8000) == 1)
            //             {
            //                 result -= (1 << 16);
            //             }
            //             return result;

            return (short)GetUint16();
        }

        /// <summary>
        /// Returns the data stored at location in int32.
        /// </summary>
        /// <returns></returns>
        public int GetInt32()
        {
            return ((GetUint8() << 24) |
                    (GetUint8() << 16) |
                    (GetUint8() << 8) |
                    (GetUint8()));
        }

        /// <summary>
        /// Returns string at specifiec length.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        public string GetString(int length)
        {
            var result = "";
            for (var i = 0; i < length; i++)
            {
                result += (char)GetUint8();
            }
            return result;
        }

        /// <summary>
        /// Gets the date.
        /// </summary>
        #warning TODO Restore functionality using DateTime
        public void GetDate()
        {
            GetUint32();
            GetUint32();
            /* var macTime = GetUint32() * 0x100000000 + GetUint32();
            return new DateTime(macTime, DateTimeKind.Utc);*/
        }

        /// <summary>
        /// Returns the character.
        /// </summary>
        /// <returns></returns>
        public char GetChar()
        {
            return (char)GetUint8();
        }
    }
}
