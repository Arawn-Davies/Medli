using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.HAL;
using IL2CPU.API.Attribs;

namespace MedliPlugs.System
{
	[Plug(Target = typeof(Cosmos.System.Global))]
    public static class Global
    {
		public static void Init(TextScreenBase textScreen)
		{
			HAL.Global.Init(textScreen);
			Sys.Global.NumLock = false;
			Sys.Global.CapsLock = false;
			Sys.Global.ScrollLock = false;
		}
    }
}
