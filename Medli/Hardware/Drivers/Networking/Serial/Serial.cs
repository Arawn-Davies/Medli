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
		int serial_received();
		char read_serial();
		int serial_empty();
	}
}
