using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Core
{
    public class Device : BusIO
    {
		public virtual ushort[] ReadBlock(uint LBA)
		{
			return new ushort[2];
		}

		public virtual void WriteBlock(uint LBA, UInt16[] Data)
		{

		}
	}
}
