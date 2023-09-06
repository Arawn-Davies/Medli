using System;
using System.Collections.Generic;
using System.Text;
using Medli.Hardware;
using AR = Medli.System.Framework.AConsole.VideoRAM;

namespace Medli.System
{
	class Screen
	{
		public static void SaveBuffer()
		{
			AR.PushContents();
		}

		public static void RestoreBuffer()
		{
			AR.PopContents();
		}

		public static int CurrentScreen = 1;

		public static void ChangeScreen(int screen)
		{
			AR.Switch(CurrentScreen, screen);
			CurrentScreen = screen;
		}
	}
}
