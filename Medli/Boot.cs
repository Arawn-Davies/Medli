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
                SystemFunctions.IDEs = MDFS.Physical.IDE.Devices.ToArray();
                for (int i = 0; i < SystemFunctions.IDEs.Length; i++)
                {
                    new MDFS.DiskListing(i, SystemFunctions.IDEs[i]);
                }
                //KernelVariables.IsLive = true;
                Runtime.Level3Init();
                Kernel.Hostname = "M_INIT";
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Blue;
                Kernel.Running = true;
				Console.Clear();
                Hardware.AddDisks.Detect();
                Console.Write(Kernel.logo);
                Console.WriteLine(Kernel.welcome);
				Console.WriteLine("");
				Console.WriteLine("Current system date and time:");
				Date.printDate();
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
				CommandConsole Shell = new CommandConsole();
				Shell.Initialize();
			}
			catch (Exception ex)
			{
				FatalError.Crash(ex);
			}
		}
	}
}


////Apps.Applications.Init();
//while (Kernel.Running == true)
//{
//                Console.Write(Directory.GetCurrentDirectory() + " >");
//	//KernelVariables.Hostname
//	string cmd = Console.ReadLine();
//                Shell.Prompt(cmd);
//}