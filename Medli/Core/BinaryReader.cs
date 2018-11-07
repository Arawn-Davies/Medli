using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Core
{
	public class BinaryReader
	{
		public ioStream BaseStream;

		public BinaryReader(ioStream stream)
		{
			stream.Position = 0;
			this.BaseStream = stream;
		}

		public byte ReadByte()
		{
			++this.BaseStream.Position;
			return this.BaseStream.Data[this.BaseStream.Position - 1];
		}

		public int ReadInt32()
		{
			int int32 = BitConverter.ToInt32(this.BaseStream.Data, this.BaseStream.Position);
			this.BaseStream.Position += 4;
			return int32;
		}

		public uint ReadUInt32()
		{
			uint uint32 = BitConverter.ToUInt32(this.BaseStream.Data, this.BaseStream.Position);
			this.BaseStream.Position += 4;
			return uint32;
		}

		public string ReadAllText()
		{
			string str = "";
			while (this.BaseStream.Position < this.BaseStream.Data.Length)
				str += ((char)this.BaseStream.Read()).ToString();
			return str;
		}

		public void Close()
		{
			this.BaseStream.Close();
		}

		public string ReadString()
		{
			byte num = this.BaseStream.Read();
			string str = "";
			for (int index = 0; index < (int)num; ++index)
				str += ((char)this.BaseStream.Read()).ToString();
			return str;
		}
	}
}
