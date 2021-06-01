using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Cosmos.Debug;
using Medli.System;
using Medli.Common;
using AIC.Main;

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
                Accounts.InitNewUser();
                Console.ForegroundColor = ConsoleColor.Green; WriteLine("\nDone!"); Console.ForegroundColor = ConsoleColor.White;
                
                Write("Enter the root password: ");
                MEnvironment.rootpass = ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                WriteLine("Writing root password...");
                MEnvironment.WriteRootPass();
                Console.ForegroundColor = ConsoleColor.Green; WriteLine("\nDone!"); Console.ForegroundColor = ConsoleColor.White;

                //File.WriteAllText(MEnvironment.rpf, AIC.Main.Crypto.MD5.hash(MEnvironment.rootpass));
            }
            catch (Exception ex)
            {
                Bluescreen.Init(ex, true);
                Console.ReadKey(true);
            }

            PressAnyKey("All set! Press any key to continue...");
            Console.Clear();

            ScreenSetup();
            WriteLine("Please enter a machine name:");
            Kernel.pcname = ReadLine();

            try
            {
                Console.ForegroundColor = ConsoleColor.White; Write("Creating machineinfo file...  "); File.Create(Kernel.pcinfo).Dispose(); Console.ForegroundColor = ConsoleColor.Green; WriteLine("Done!");
                Console.ForegroundColor = ConsoleColor.White; Write("Writing machineinfo to file..."); File.WriteAllText(Kernel.pcinfo, Kernel.pcname); Console.ForegroundColor = ConsoleColor.Green; WriteLine("Done!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch
            {
                Console.ReadKey(true);
                ErrorHandler.BlueScreen.Init(5, @"The Installer was unable to create the user directory and other files. 
This may be due to an unformatted hard drive or some other error", "FAT Error");
            }

            WriteLine("Awesome - you're all set!");
            PressAnyKey("Press any key to start Medli!");
            Console.Clear();
        }
    }
}
