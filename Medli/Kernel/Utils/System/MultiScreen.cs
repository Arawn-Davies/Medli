using System;
using System.Collections.Generic;
using System.Text;
using Medli.System;

namespace Medli.Apps
{
	class Multiscreen : Command
	{
		public override string Name
		{
			get
			{
				return "screen";
			}
		}

		public override string Summary
		{
			get
			{
				return "Switches the current terminal to a new multiscreen terminal";
			}
		}

		public void Switch(int screen)
		{
			if (screen != Screen.CurrentScreen)
			{
				Screen.ChangeScreen(screen);
			}
			else
			{

			}
		}

		public override void Execute(string param)
		{
			if (param == "get")
			{
				Console.WriteLine(Screen.CurrentScreen);
			}
			else if (param == "new")
			{
				try
				{
					Screen.ChangeScreen(Screen.CurrentScreen);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			else if (param == "save")
			{
				Screen.SaveBuffer();
			}
			else if (param == "restore")
			{
				Screen.RestoreBuffer();
			}
			else
			{
				try
				{
					int screen = Int32.Parse(param);
					if (screen != Screen.CurrentScreen)
					{
						Switch(screen);
					}
					else
					{

					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					Console.WriteLine("Invalid option!");
				}

			}
		}
		public override void Help()
		{
			Console.WriteLine("screen [option]");
			Console.WriteLine(Summary);
			Console.WriteLine("[get] returns the current screen");
			Console.WriteLine("[number from 1-4] switches to the specified screen");
		}
	}
}
