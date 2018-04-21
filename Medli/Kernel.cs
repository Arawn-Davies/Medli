using System;
using System.Collections.Generic;
using Sys = Cosmos.System;
using Medli.Common;
using Medli.System;

namespace Medli.Kernel
{

	public class Global
	{
		public static bool NumLock
		{
			get { return KeyboardManager.NumLock; }
			set { KeyboardManager.NumLock = value; }
		}

		public static bool CapsLock
		{
			get { return KeyboardManager.CapsLock; }
			set { KeyboardManager.CapsLock = value; }
		}

		public static bool ScrollLock
		{
			get { return KeyboardManager.ScrollLock; }
			set { KeyboardManager.ScrollLock = value; }
		}

		public static Hardware.TextScreenBase GetTextScreen() { return null; }
	}


    public class Kernel: Sys.Kernel
    {
		protected override void BeforeRun()
        {
			// Sys.Graphics.VGAScreen.SetTextMode(Sys.Graphics.VGAScreen.TextSize.Size80x50);
			try
			{
			
				KernelVariables.Hostname = "M_INIT";
				SYSPBE.Init(Global.GetTextScreen());

				//SetKeyboardScanMap(new Sys.ScanMaps.US_Standard());
				SysConsole.set_ForegroundColor(ConsoleColor.White);
				SysConsole.set_BackgroundColor(ConsoleColor.Blue);
				KernelVariables.Running = true;
				Extensions.MConsole.Clear();

				Console.Write(KernelVariables.logo);
				SysConsole.WriteLine(KernelVariables.welcome);
				SysConsole.WriteLine(" ");
				SysConsole.WriteLine("Current system date and time:");
				MedliTime.printDate();
				MedliTime.printTime();
				CoreInfo.PrintInfo();
			}
			catch (Exception ex)
			{
				FatalError.Crash(ex);
			}
        }

		public static ScanMapBase ChangeLayout()
		{
			bool selected = false;
			while (selected == false)
			{
				SysConsole.WriteLine("Select a keyboard layout:");
				SysConsole.WriteLine("1) United Kingdom");
				SysConsole.WriteLine("2) United States");
				SysConsole.WriteLine("3) Denmark");
				SysConsole.WriteLine("4) France");
				int mode;
				bool success = Int32.TryParse(SysConsole.ReadLine(), out mode);
				if (mode == 1)
				{
					return new System.ScanMaps.UK_Standard();
				}
				else if (mode == 2)
				{
					return new System.ScanMaps.US_Standard();
				}
				else if (mode == 3)
				{
					return new System.ScanMaps.DE_Standard();
				}
				else if (mode == 4)
				{
					return new System.ScanMaps.FR_Standard();
				}
				else if (success == false)
				{
					SysConsole.WriteLine("Not a valid option! Using UK Layout...");
					return new System.ScanMaps.UK_Standard();
				}
				else
				{
					SysConsole.WriteLine("That option doesn't exist. Using UK Layout...");
					return new System.ScanMaps.UK_Standard();
				}
			}
			return new System.ScanMaps.UK_Standard();
		}


        protected override void Run()
        {
			try
			{
				//Apps.Applications.Init();
				while (KernelVariables.Running == true)
				{
					SysConsole.Write(KernelVariables.Hostname + " Prompt >");
					string cmd = SysConsole.ReadLine();
					Shell.prompt(cmd);
				}
			}
			catch(Exception ex)
			{
				FatalError.Crash(ex);
			}
        }
	}
}
