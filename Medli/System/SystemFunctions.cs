using System;
using System.Collections.Generic;
using System.Text;
using Medli.Hardware;
using MDFS;
using MDFS.Physical;

namespace Medli.System
{
	public class SystemFunctions
	{
		private static IDE[] IDEs = IDE.Devices.ToArray();
		public static int CurrentScreen = 1;
		public static void ChangeScreen(int screen)
		{
			//MultiScreen.PushContents();
			Console.Clear();
			//Console.WriteLine("Test, this is a test...");
			//Common.Extensions.PAKTC();
			//Console.Clear();
			//MultiScreen.PopContents();
			if (MultiScreen.SetContent(CurrentScreen) == true)
			{
				if (MultiScreen.RetContent(screen) == true)
				{
					Console.WriteLine("successfully restored screen");
					CurrentScreen = screen;
				}
				else
				{
					Console.WriteLine("Saved screen, failed to restore specified screen");
				}
			}
			else
			{
				Console.WriteLine("Failed to save screen!");
			}
			//Console.Clear();
			//new Kernel.CommandConsole();
		}

		public static void PrintUsedRAM()
		{
			MemoryMonitoring.PrintUsed();
		}
		public static void PrintTotalRAM()
		{
			MemoryMonitoring.PrintTotal();
		}
		public static void PrintFreeRAM()
		{
			MemoryMonitoring.PrintFree();
		}
		public static void PrintInfo()
		{
			MemoryMonitoring.PrintInfo();
		}
		public static void lspci()
		{
			HAL.ListPCIDevices();
		}
		public static void FDISKRun()
		{
			Hardware.DiskUtil.Main(IDEs);
		}
	}
}
