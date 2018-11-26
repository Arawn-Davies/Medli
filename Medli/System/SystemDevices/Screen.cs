using System;
using System.Collections.Generic;
using System.Text;
using Medli.Hardware;

namespace Medli.System
{
	class Screen
	{
		public static void SaveBuffer()
		{
			MultiScreen.PushContents();
		}

		public static void RestoreBuffer()
		{
			MultiScreen.PopContents();
		}

		public static int CurrentScreen = 1;

		public static void ChangeScreen(int screen)
		{
			MultiScreen.Switch(CurrentScreen, screen);
			CurrentScreen = screen;
		}
	}
}
