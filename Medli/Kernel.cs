using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Medli.Common;
using Medli.System;

namespace Medli.Kernel
{
    public class Kernel: Sys.Kernel
    {
		/*
		public override void Start()
		{
			SYSPBE.Init();
			Sys.Global.Init(GetTextScreen());
			Sys.KeyboardManager.AddKeyboard(new Cosmos.HAL.PS2Keyboard());
		}
		*/
        protected override void BeforeRun()
        {
			// Sys.Graphics.VGAScreen.SetTextMode(Sys.Graphics.VGAScreen.TextSize.Size80x50);
			try
			{
			
				KernelVariables.Hostname = "M_INIT";
				SYSPBE.Init();

				//SetKeyboardScanMap(new Sys.ScanMaps.US_Standard());
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Blue;
				KernelVariables.Running = true;
				Console.Clear();

				Console.Write(KernelVariables.logo);
				Console.WriteLine(KernelVariables.welcome);
				Console.WriteLine(" ");
				Console.WriteLine("Current system date and time:");
				MedliTime.printDate();
				MedliTime.printTime();
			}
			catch (Exception ex)
			{
				FatalError.Crash(ex);
			}
        }

		public static Sys.ScanMapBase ChangeLayout()
		{
			bool selected = false;
			while (selected == false)
			{
				Console.WriteLine("Select a keyboard layout:");
				Console.WriteLine("1) United Kingdom");
				Console.WriteLine("2) United States");
				Console.WriteLine("3) Denmark");
				Console.WriteLine("4) France");
				int mode;
				bool success = Int32.TryParse(Console.ReadLine(), out mode);
				if (mode == 1)
				{
					return new UK_Standard();
				}
				else if (mode == 2)
				{
					return new Sys.ScanMaps.US_Standard();
				}
				else if (mode == 3)
				{
					return new Sys.ScanMaps.DE_Standard();
				}
				else if (mode == 4)
				{
					return new Sys.ScanMaps.FR_Standard();
				}
				else if (success == false)
				{
					Console.WriteLine("Not a valid option! Using UK Layout...");
					return new UK_Standard();
				}
				else
				{
					Console.WriteLine("That option doesn't exist. Using UK Layout...");
					return new UK_Standard();
				}
			}
			return new UK_Standard();
		}


        protected override void Run()
        {
			try
			{
				//Apps.Applications.Init();
				while (KernelVariables.Running == true)
				{
					Console.Write(KernelVariables.Hostname + " Prompt >");
					string cmd = Console.ReadLine();
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
