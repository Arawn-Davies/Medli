using System;
using System.Collections.Generic;
using Sys = Cosmos.System;
using Medli.Common;
using Medli.System;

namespace Medli.Kernel
{
    public class Kernel: Sys.Kernel
    {
		protected override void BeforeRun()
        {
			//Sys.Graphics.VGAScreen.SetTextMode(Sys.Graphics.VGAScreen.TextSize.Size80x50);
			try
			{
				SYSPBE.Init();
				KernelVariables.Hostname = "M_INIT";
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Blue;
				KernelVariables.Running = true;
				Console.Clear();
				Hardware.AddDisks.Detect();
				Console.Write(KernelVariables.logo);
				Console.WriteLine(KernelVariables.welcome);
				Console.WriteLine(" ");
				Console.WriteLine("Current system date and time:");
				MedliTime.printDate();
				MedliTime.printTime();
				SystemFunctions.PrintInfo();
			}
			catch (Exception ex)
			{
				FatalError.Crash(ex);
			}
        }

		protected override void Run()
        {
			try
			{
				//Apps.Applications.Init();
				while (KernelVariables.Running == true)
				{
					Console.Write("Prompt >");
					//KernelVariables.Hostname
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
