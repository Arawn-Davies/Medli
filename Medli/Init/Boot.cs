using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Medli.Common;
using Medli.System;
using System.IO;
using Medli.Main;
using System.Linq;
using Medli.Hardware;
using Medli.Core;
using Medli.System.Framework;

namespace Medli
{
    /// <summary>
    /// Initial boot class definition including init methods
    /// </summary>
    /// <seealso cref="Cosmos.System.Kernel" />
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
				Kernel.IsLive = true;

				Level1.Init();
				Level2.Init();
				Level3.Init();

				/*
				for (int i = 0; i < SystemFunctions.IDEs.Length; i++)
				{
					//new MDFS.DiskListing(i, SystemFunctions.IDEs[i]);
				}
				Extensions.PressAnyKey();
				*/





				//Kernel.Hostname = "MedliLive";
				Kernel.Running = true;
				Console.Clear();
                //Hardware.AddDisks.Detect();
                Console.Write(Kernel.Logo);
                Console.WriteLine(Kernel.Welcome);
				Console.WriteLine("");
				Console.WriteLine("Current system date and time:");
				Date.printDate();
				Time.printTime();
				SystemFunctions.PrintInfo();
				Console.WriteLine("Welcome back, " + Kernel.username + @"!");
			}
			catch (Exception ex)
			{
                Console.ReadKey();
				FatalError.Crash(ex);
			}
		}

        /// <summary>
        /// Main kernel loop
        /// </summary>
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