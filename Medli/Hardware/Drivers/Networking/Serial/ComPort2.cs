using System;
using System.Collections.Generic;
using System.Text;
using Medli.Core;
using Medli.System.Framework;

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
		public byte Received()
		{
			while (SerialReceived() == 0) ;
			return Read8(COM2);
		}

		public byte[] ReceivedBytes()
		{
			byte[] serialbytes = new byte[] { 0x00 };
			while (SerialReceived() == 0)
			{
				serialbytes = StringExtensions.AddToArray(serialbytes, Received());
			}
			return serialbytes;
		}
		public char ReadChar()
		{
			while (SerialReceived() == 0) ;

			return (char)Read8(COM2);
		}
		public string Read()
		{
			while (SerialReceived() == 0) ;
			string text = "";
			text += ReadChar();
			return text;
		}

		public string ReadLine()
		{
			return Read() + Environment.NewLine;
		}

		public int SerialEmpty()
		{
			return Read8(COM2 + 5) & 0x20;
		}

		public int SerialReceived()
		{
			return Read8(COM2 + 5) & 1;
		}

		public void Send(byte b)
		{
			while (SerialEmpty() == 0) ;
			Write8(COM2, b);
		}

		public void Send(byte[] bytes)
		{
			foreach (byte b in bytes)
			{
				Send(b);
			}
		}

		public void Write(char c)
		{
			while (SerialEmpty() == 0) ;

			Write8(COM2, (byte)c);
		}

		public void Write(string text)
		{
			foreach (char c in text)
			{
				Write(c);
			}
		}

		public void WriteLine(string text)
		{
			Write(text + Environment.NewLine);
		}
	}
}