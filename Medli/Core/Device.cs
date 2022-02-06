using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Core
{
    /// <summary>
    /// Class definition for Medli-Core Device
    /// </summary>
    /// <seealso cref="Medli.Core.BusIO" />
    public class Device : BusIO
    {
        /// <summary>
        /// Reads the block located at the lba
        /// </summary>
        /// <param name="LBA">The lba.</param>
        /// <returns></returns>
        public virtual ushort[] ReadBlock(uint LBA)
		{
			return new ushort[2];
		}

        /// <summary>
        /// Writes the block at 'LBA' using 'Data'.
        /// </summary>
        /// <param name="LBA">The lba.</param>
        /// <param name="Data">The data.</param>
        public virtual void WriteBlock(uint LBA, UInt16[] Data)
		{

		}
	}
}
