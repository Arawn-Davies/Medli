using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Medli.Common;
using Medli.System;
using System.IO;
using AIC.Main;

namespace Medli
{
    public class Boot : Sys.Kernel
    {
        /// <summary>
        /// Initialise filesystem and system services
        /// </summary>
		protected override void BeforeRun()
		{
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            try
			{
                /*
                
                SystemFunctions.IDEs = MDFS.Physical.IDE.Devices.ToArray();
                for (int i = 0; i < SystemFunctions.IDEs.Length; i++)
                {
                    new MDFS.DiskListing(i, SystemFunctions.IDEs[i]);
                }
                */
                Kernel.IsLive = false;
                
                
                Level3.Init();

                //Kernel.Hostname = "MedliLive";
                Kernel.Running = true;
				Console.Clear();
                //Hardware.AddDisks.Detect();
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
                Console.ReadKey();
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