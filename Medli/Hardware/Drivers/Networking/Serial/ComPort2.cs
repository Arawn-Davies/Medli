using System;
using System.Collections.Generic;
using System.Text;
using Medli.Core;

namespace Medli.Hardware.Drivers
{
    public class SerialPort2 : BusIO, SerialPort
	{
		public const ushort COM2 = 0x3F8;

		public void Initialize()
		{
			Write8(COM2 + 1, 0x00);    // Disable all interrupts
			Write8(COM2 + 3, 0x80);    // Enable DLAB (set baud rate divisor)
			Write8(COM2 + 0, 0x03);    // Set divisor to 3 (lo byte) 38400 baud
			Write8(COM2 + 1, 0x00);    //                  (hi byte)
			Write8(COM2 + 3, 0x03);    // 8 bits, no parity, one stop bit
			Write8(COM2 + 2, 0xC7);    // Enable FIFO, clear them, with 14-byte threshold
			Write8(COM2 + 4, 0x0B);
		}

		public char read_serial()
		{
			while (serial_received() == 0) ;

			return (char)Read8(COM2);
		}

		public int serial_empty()
		{
			return Read8(COM2 + 5) & 0x20;
		}

		public int serial_received()
		{
			return Read8(COM2 + 5) & 1;
		}

		public void Write(char c)
		{
			while (serial_empty() == 0) ;

			Write8(COM2, (byte)c);
		}
	}
}
