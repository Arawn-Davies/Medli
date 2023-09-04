using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Cosmos.Debug;
using Medli.System;
using Medli.Common;
using Medli.System.Framework;

namespace Medli.System
{
    /// <summary>
    /// Class for the Medli installer
    /// </summary>
    public partial class Installer
    {
        /// <summary>
        /// Main installer method, choose colour of installer, choose desired username and reports if a FAT error occurs
        /// </summary>
        public static void Main()
        {
            ScreenSetup();
            WriteLine("Welcome to the Medli installer.");
            PressAnyKey();

            try
            {
                
                Accounts.InitNewUser(); Done();
                
                WriteLine("Enter the root password: "); 
                MEnvironment.rootpass = ReadLine();

                WritePrefix("Writing root password...");
                MEnvironment.WriteRootPass(); Done();

            }
            catch (Exception ex)
            {
                Bluescreen.Init(ex, true);
                Console.ReadKey(true);
            }

            WriteLine("Please enter a machine name:");
            Kernel.pcname = ReadLine();

            try
            {
                WritePrefix("Creating machineinfo file...    "); File.Create(Kernel.pcinfo).Dispose(); Done();
                WritePrefix("Writing machineinfo to file...  "); File.WriteAllText(Kernel.pcinfo, Kernel.pcname); Done();
            }
            catch
            {
                WriteLine("OOOPS!");
                PressAnyKey("Press any key to view the stop error: ");
                ErrorHandler.BlueScreen.Init(5, @"The Installer was unable to create the user directory and other files. 
This may be due to a failing hard drive or other internal error", "FAT Error");
            }

            WriteLine("Awesome - you're all set!");
            PressAnyKey("Press any key to start Medli!");
            Console.Clear();
        }

        private static void Done()
        {
            Console.ForegroundColor = ConsoleColor.Green; 
            WriteSuffix("\tDone!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
