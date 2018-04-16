using System;
using System.Collections.Generic;
using System.Text;
using Medli.Core;

namespace Medli.Hardware.Drivers
{
    public class SerialPort1 : BusIO, SerialPort
    {
		public const ushort COM1 = 0x3F8;

		public void Initialize()
		{
			Write8(COM1 + 1, 0x00);    // Disable all interrupts
			Write8(COM1 + 3, 0x80);    // Enable DLAB (set baud rate divisor)
			Write8(COM1 + 0, 0x03);    // Set divisor to 3 (lo byte) 38400 baud
			Write8(COM1 + 1, 0x00);    //                  (hi byte)
			Write8(COM1 + 3, 0x03);    // 8 bits, no parity, one stop bit
			Write8(COM1 + 2, 0xC7);    // Enable FIFO, clear them, with 14-byte threshold
			Write8(COM1 + 4, 0x0B);
		}

		public char read_serial()
		{
			while (serial_received() == 0) ;

			return (char)Read8(COM1);
		}

		public int serial_empty()
		{
			return Read8(COM1 + 5) & 0x20;
		}

		public int serial_received()
		{
			return Read8(COM1 + 5) & 1;
		}

		public void Write(char c)
		{
			while (serial_empty() == 0) ;

			Write8(COM1, (byte)c);
		}
	}
}
