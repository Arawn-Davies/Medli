using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IL2CPU.API.Attribs;
using Cosmos.HAL;

namespace MedliPlugs.System
{
	[Plug(Target = typeof(Cosmos.System.Global))]
	public static class Global
	{
		public static void Init(TextScreenBase textScreen, bool initScrollWheel = true, bool initPS2 = true, bool initNetwork = true, bool ideInit = true)
		{
			Cosmos.HAL.Global.Init(textScreen, initScrollWheel, initPS2, initNetwork, ideInit);
			Cosmos.System.Global.NumLock = false;
			Cosmos.System.Global.CapsLock = false;
			Cosmos.System.Global.ScrollLock = false;
			//Network.NetworkStack.Init();
		}
	}
}
