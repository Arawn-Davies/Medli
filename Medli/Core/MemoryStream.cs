using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Core
{
	public class MemoryStream : ioStream
	{
		private unsafe byte* a = (byte*)null;

		public override void Close()
		{
		}

		public override unsafe void Write(byte i)
		{
			if ((IntPtr)this.a == IntPtr.Zero)
			{
				base.Write(i);
			}
			else
			{
				this.a[this.Position] = i;
				++this.Position;
			}
		}

		public override unsafe byte Read()
		{
			if ((IntPtr)this.a == IntPtr.Zero)
				return base.Read();
			++this.Position;
			return this.a[this.Position - 1];
		}

		public unsafe MemoryStream(int size)
		{
			this.a = (byte*)null;
			this.init(size);
		}

		public unsafe MemoryStream(byte[] dat)
		{
			this.a = (byte*)null;
			this.Data = dat;
		}

		public unsafe MemoryStream(byte* ptr)
		{
			this.a = ptr;
		}
	}
}
