using System;
using System.Collections.Generic;
using System.Text;
using Medli.Core.IOGroups;

namespace Medli.Core
{
    public class CoreDevices
    {
		public static readonly PS2Controller PS2Controller = new PS2Controller();
		public static readonly PCSpeaker PCSpeaker = new PCSpeaker();
		public static readonly PIT PIT = new PIT();
		public static readonly TextScreen TextScreen = new TextScreen();
		public static readonly ATA ATA1 = new ATA(false);
		public static readonly ATA ATA2 = new ATA(true);
		public static readonly RTC RTC = new RTC();
		public static readonly VBE VBE = new VBE();
		public static MemoryManager MemMon;
	}
}
