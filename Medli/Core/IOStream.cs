using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Core
{
	public abstract class IOStream
	{
		private bool a = true;
		public int Position;
		public byte[] Data;

		public virtual void Write(byte i)
		{
			if (this.Data.Length + 1 < this.Position)
			{
				byte[] numArray = new byte[this.Data.Length + 1000];
				for (int index = 0; index < this.Data.Length; ++index)
					numArray[index] = i;
				this.Data = numArray;
			}
			this.Data[this.Position] = i;
			++this.Position;
		}

		public virtual byte Read()
		{
			++this.Position;
			return this.Data[this.Position - 1];
		}

		public virtual void Flush()
		{
			this.Data = (byte[])null;
			this.Position = 0;
		}

		public virtual void Close()
		{
		}

		public void init(int size)
		{
			this.a = false;
			this.Data = new byte[size];
		}
	}
}
