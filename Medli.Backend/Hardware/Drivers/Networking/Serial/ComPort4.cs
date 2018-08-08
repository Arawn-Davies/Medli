using System;
using System.Collections.Generic;
using System.Text;
using Medli.Core;

namespace Medli.Hardware.Drivers
{
	public class SerialPort4 : BusIO, SerialPort
	{
		public const ushort COM4 = 0x3F8;

		public void Initialize()
		{
			Write8(COM4 + 1, 0x00);    // Disable all interrupts
			Write8(COM4 + 3, 0x80);    // Enable DLAB (set baud rate divisor)
			Write8(COM4 + 0, 0x03);    // Set divisor to 3 (lo byte) 38400 baud
			Write8(COM4 + 1, 0x00);    //                  (hi byte)
			Write8(COM4 + 3, 0x03);    // 8 bits, no parity, one stop bit
			Write8(COM4 + 2, 0xC7);    // Enable FIFO, clear them, with 14-byte threshold
			Write8(COM4 + 4, 0x0B);
		}
		public byte Received()
		{
			while (SerialReceived() == 0) ;
			return Read8(COM4);
		}

		public byte[] ReceivedBytes()
		{
			byte[] serialbytes = new byte[] { 0x00 };
			while (SerialReceived() == 0)
			{
				serialbytes = Common.Extensions.AddToArray(serialbytes, Received());
			}
			return serialbytes;
		}
		public char ReadChar()
		{
			while (SerialReceived() == 0) ;

			return (char)Read8(COM4);
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
			return Read8(COM4 + 5) & 0x20;
		}

		public int SerialReceived()
		{
			return Read8(COM4 + 5) & 1;
		}

		public void Write(char c)
		{
			while (SerialEmpty() == 0) ;

			Write8(COM4, (byte)c);
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

		public void Send(byte b)
		{
			while (SerialEmpty() == 0) ;
			Write8(COM4, b);
		}

		public void Send(byte[] bytes)
		{
			foreach (byte b in bytes)
			{
				Send(b);
			}
		}
	}
}