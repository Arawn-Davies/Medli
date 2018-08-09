using System;
using System.Collections.Generic;
using System.Text;
using Medli.Core;

namespace Medli.Hardware.Drivers
{
    public interface SerialPort
    {
		void Initialize();
		void Write(char c);
		int SerialReceived();
		byte Received();
		byte[] ReceivedBytes();
		char ReadChar();
		string Read();
		string ReadLine();
		int SerialEmpty();
		void WriteLine(string text);
		void Write(string text);
	}
}
