using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.System.FileSystem;
using System.IO;
using Medli.System;
using Medli.Main;
using Medli.System.Framework;

namespace Medli.Common.Services
{
    public class InstallService
	{

        /// <summary>
        /// Installation debugger
        /// </summary>
        private static Cosmos.Debug.Kernel.Debugger mDebugger = new Cosmos.Debug.Kernel.Debugger("Boot", "Installer");

        public static string ServiceName = "INSRV";

		public static AccessPriority Priority = AccessPriority.MID;

		public static bool Active = false;

		public static string ServicePath;

		public static LoggingService ServiceLogger;


        /// <summary>
        /// Initializes the installer service and allows the user to choose a machine name
        /// Sets the machine name as a variable and writes it to the disk
        /// </summary>
        /// <returns></returns>
        public static bool Init()
		{
            if (FSService.Active == false)
            {
                Kernel.username = "test";
                Kernel.pcname = "testing";
                mDebugger.Send("Installer - Skipping Installer due to live filesystem.");
                return false;
            }
            else if (Kernel.IsLive == true)
            {
                Kernel.username = "test";
                Kernel.pcname = "testing";
                mDebugger.Send("Installer - Skipping Installer due to live filesystem.");
                return false;
            }
            else if (FSService.Active == true && Kernel.IsLive == false)
            {
                if (File.Exists(Kernel.pcinfo))
                {
                    try
                    {
                        string[] pcnames = File.ReadAllLines(Kernel.pcinfo);
                        Kernel.pcname = pcnames[0];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                //Console.WriteLine("Does usrinfo exist?");
                //Console.WriteLine(File.Exists(Kernel.usrinfo));
                //KernelExtensions.PressAnyKey();
                if (File.Exists(Kernel.usrinfo))
                {
                    Console.Clear();
                    try
                    {
                        Accounts.UserLogin();
                        AConsole.Fill(ConsoleColor.Blue);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Welcome back, " + Kernel.username + @"!");
                        KernelExtensions.PressAnyKey();
                    }
                    catch (Exception ex)
                    {
                        AConsole.Error.WriteLine("Medli encountered an exception during the pre-initialization stage.\nError: " + ex.Message);
                        KernelExtensions.PressAnyKey();
                    }
                }
                else
                {
                    Console.Clear();
                    Installer.ScreenSetup();
                    Installer.WriteLine("Medli was unable to find any info regarding your PC.");
                    Installer.WriteLine("The Medli installer will now run.");
                    ServiceLogger = new LoggingService(Paths.SystemLogs + @"\ins.log");
                    ServiceLogger.Record("Installer Service logger initialized.");
                    ServiceLogger.Record("Installer Service running on " + Paths.Root);
                    mDebugger.Send("Running setup...");
                    Installer.PressAnyKey();
                    Console.Clear();
                    Active = true;
                    Installer.Main();
                }
                Active = false;
                return true;
            }
            else
            {
                return false;
            }
		}
	}
}
