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
        private static Cosmos.Debug.Kernel.Debugger mDebugger = new Cosmos.Debug.Kernel.Debugger("INSTALL");

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
            if (FSService.Active == false || Kernel._isLive == true)
            {
                Kernel.username = "recovery";
                Kernel.pcname = "recovery";
                mDebugger.Send("Installer - Skipping Installer due to live filesystem.");
                return false;
            }
			// Check the OS is not in live (read-only) mode.
			// Check for an active FS service is not applicable because the filesystem service calls the installer service directly.
            else if (Kernel._isLive == false)
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
						AConsole.Error.WriteLine("Medli encountered an exception during the pre-initialization stage.\nError: " + ex.Message);
						KernelExtensions.PressAnyKey();
					}

                }
				// If the user info file exists, read from it.
                if (File.Exists(Kernel.usrinfo))
                {
                    Console.Clear();
                    try
                    {
                        AccountAccess.Login();
						Kernel.SetColourScheme();
						Active = false;
						return true;

					}
                    catch (Exception ex)
                    {
						Console.WriteLine(ex.Message);
						AConsole.Error.WriteLine("Medli encountered an exception during the pre-initialization stage.\nError: " + ex.Message);
						KernelExtensions.PressAnyKey();
                    }
                }
                else
                {
                    Console.Clear();
                    Installer.ScreenSetup(is_setup: true);
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
				Kernel.SetColourScheme();
				return true;
            }
            else
            {
				Kernel.SetColourScheme();
				return false;
            }
		}
	}
}
