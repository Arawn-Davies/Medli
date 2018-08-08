using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Medli.Common;
using Medli.System;
using Medli;
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
				KernelVariables.Hostname = "M_INIT";
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Blue;
				KernelVariables.Running = true;
				Console.Clear();
				//Hardware.AddDisks.Detect();
				Console.Write(KernelVariables.logo);
				Console.WriteLine(KernelVariables.welcome);
				Console.WriteLine("");
				Console.WriteLine("Current system date and time:");
				Time.printDate();
				Time.printTime();
				SystemFunctions.PrintInfo();
			}
			catch (Exception ex)
			{
				KernelVariables.Running = false;
				FatalError.Crash(ex);
				Console.ReadKey(true);
			}
		}

		protected override void Run()
		{
			try
			{
				//Apps.Applications.Init();
				while (KernelVariables.Running == true)
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
