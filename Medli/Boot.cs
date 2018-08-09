using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Medli.Common;
using Medli.System;
using System.IO;

namespace Medli
{
    public class Boot : Sys.Kernel
    {
		protected override void BeforeRun()
		{
			try
			{
                //KernelVariables.IsLive = true;
                SystemBootEnvironment.Init();
                Kernel.Hostname = "M_INIT";
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Blue;
                Kernel.Running = true;
				Console.Clear();
                //Hardware.AddDisks.Detect();
                Console.Write(Kernel.logo);
                Console.WriteLine(Kernel.welcome);
				Console.WriteLine("");
				Console.WriteLine("Current system date and time:");
				Time.printDate();
				Time.printTime();
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
				while (Kernel.Running == true)
				{
                    Console.Write(Directory.GetCurrentDirectory() + " >");
					//KernelVariables.Hostname
					string cmd = Console.ReadLine();
                    Shell.Prompt(cmd);
				}
			}
			catch (Exception ex)
			{
				FatalError.Crash(ex);
			}
		}
	}
}
