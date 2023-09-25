using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Medli.Common;
using Medli.System;
using Medli.Core;
using System.IO;
using Medli.Main;
using System.Linq;
using Medli.Hardware;
using Medli.System.Framework;
using Cosmos.System.Graphics;

namespace Medli
{
    /// <summary>
    /// Initial boot class definition including init methods
    /// </summary>
    /// <seealso cref="Cosmos.System.Kernel" />
    public class Boot
    {
        /// <summary>
        /// Initialise filesystem and system services
        /// </summary>
		public static void BeforeRun()
		{
            Console.Clear();
			Kernel.backgroundColour = ConsoleColor.Blue;
			Kernel.foregroundColour = ConsoleColor.White;
			Kernel.SetColourScheme();
            Console.Clear();
            try
			{
				Console.Clear();
				
				Kernel._isLive = false;

				if (Kernel._isLive == true )
				{
					Kernel.Hostname = "MedliLive";
				}

				Ring0.Init();
				HAL.Init();
				Level3.Init();

				/*
				for (int i = 0; i < SystemFunctions.IDEs.Length; i++)
				{
					//new MDFS.DiskListing(i, SystemFunctions.IDEs[i]);
				}
				Extensions.PressAnyKey();
				*/





				
				Kernel._isRunning = true;
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
        public static void Run()
		{

			try
			{
				while (Kernel._isLoggedIn == true)
				{
					CommandConsole Shell = new CommandConsole();
					Shell.Initialize();
					Console.WriteLine("Logged in: " + Kernel._isLoggedIn);
					if (Kernel._isLoggedIn == false)
					{
						break;
					}
				}
				if (Common.Services.FSService.Active && Kernel._isLive == false)
				{
					Console.WriteLine("Logged in: " + Kernel._isLoggedIn);
					AccountAccess.Logout();
					AccountAccess.Login();
				}
				else
				{
					Kernel.username = "recovery";
					Kernel.pcname = "recovery";
				}
			}
			catch (Exception ex)
			{
				FatalError.Crash(ex);
			}
		}
	}
}