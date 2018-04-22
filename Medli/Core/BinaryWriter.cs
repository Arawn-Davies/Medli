using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Core
{
	public class BinaryWriter
	{
		public ioStream BaseStream;

		public void Write(byte data)
		{
			this.BaseStream.Write(data);
		}

		public void Write(char data)
		{
			this.BaseStream.Write((byte)data);
		}

		public void WriteBytes(string str)
		{
			for (int index = 0; index < str.Length; ++index)
				this.Write((byte)str[index]);
		}

		public void Write(int data)
		{
			foreach (byte i in BitConverter.GetBytes(data))
				this.BaseStream.Write(i);
		}

		public void Write(uint data)
		{
			foreach (byte i in BitConverter.GetBytes(data))
				this.BaseStream.Write(i);
		}

		public void Write(short data)
		{
			foreach (byte i in BitConverter.GetBytes(data))
				this.BaseStream.Write(i);
		}

		public void Write(ushort data)
		{
			foreach (byte i in BitConverter.GetBytes(data))
				this.BaseStream.Write(i);
		}

		public void Write(byte[] data)
		{
			foreach (byte i in data)
				this.BaseStream.Write(i);
		}

		public void Write(string data)
		{
			this.BaseStream.Write((byte)data.Length);
			foreach (byte i in data)
				this.BaseStream.Write(i);
		}

		public BinaryWriter(ioStream file)
		{
			this.BaseStream = file;
		}
	}
}
