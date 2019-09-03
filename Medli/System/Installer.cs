using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Cosmos.Debug;
using Medli.System;
using Medli.Common;
using AIC_Framework;

namespace Medli
{
    /// <summary>
    /// Class for the Medli installer
    /// </summary>
    class Installer
    {

        /// <summary>
        /// 
        /// </summary>
        private static Cosmos.Debug.Kernel.Debugger mDebugger;

        /// <summary>
        /// Initializes the Medli installer console screen by 
        /// setting the default colour, the title and cursor position
        /// </summary>
        /// <param name="color"></param>
        private static void ScreenSetup()
        {
            Console.BackgroundColor = defaultcol;
            Console.Clear();
            //TODO
            Console.CursorTop = 0;
            Console.CursorLeft = 0;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Medli Installer ");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorTop = 7;
            Console.CursorLeft = 7;
        }

        /// <summary>
        /// Custom Write method for the installer console, sets the cursor position
        /// </summary>
        /// <param name="text"></param>
        private static void Write(string text)
        {
            Console.CursorLeft = 7;
            Console.Write(text);
            Console.CursorLeft = 0;
        }

        /// <summary>
        /// Custom WriteLine method for the installer console, sets the cursor position
        /// </summary>
        /// <param name="text"></param>
        private static void WriteLine(string text)
        {
            Console.CursorLeft = 7;
            Console.WriteLine(text);
            Console.CursorLeft = 0;
        }


        /// <summary>
        /// The default colour for the installation console
        /// </summary>
        private static ConsoleColor defaultcol = ConsoleColor.Blue;

        /// <summary>
        /// Initializes the installer and allows the user to choose a machine name
        /// Sets the machine name as a variable and writes it to the disk
        /// </summary>
        public static void Setup()
        {
            if (Kernel.IsLive == true)
            {
                Kernel.username = "test";
                Kernel.pcname = "testing";
            }
            else if (Kernel.IsLive == false)
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
                if (File.Exists(Kernel.usrinfo))
                {
                    Console.Clear();
                    try
                    {
                        Accounts.UserLogin();
                        AConsole.Fill(ConsoleColor.Blue);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Welcome back, " + Kernel.username + @"!");
                        MEnvironment.PressAnyKey();
                    }
                    catch (Exception ex)
                    {
                        AConsole.Error.WriteLine("Medli encountered an exception during the pre-initialization stage.\nError: " + ex.Message);
                    }
                }
                else
                {
                    Console.Clear();
                    ScreenSetup();
                    WriteLine("Medli was unable to find any info regarding your PC.");
                    WriteLine("The Medli installer will now run.");
                    Console.CursorLeft = 7;
                    MEnvironment.PressAnyKey();
                    Console.CursorLeft = 0;
                    Console.Clear();
                    Main();
                }
            }           
        }
        
        /// <summary>
        /// Main installer method, choose colour of installer, choose desired username and reports if a FAT error occurs
        /// </summary>
        private static void Main()
        {
            ScreenSetup();
            WriteLine("Welcome to the Medli installer.");
            Console.CursorLeft = 7;
            MEnvironment.PressAnyKey();
            Console.CursorLeft = 0;

            Write("Enter new account name: ");
            string usrname = Console.ReadLine();
            Kernel.username = usrname;

            Write("Enter the new account password: ");
            string pass = Console.ReadLine();
            MEnvironment.usrpass = pass;

            Write("Enter the new account type (guest, normal, root): ");
            string user_type = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White; WriteLine("Creating user account...");

            try
            {
                Accounts.CreateUser(usrname, pass, user_type);
                Console.ForegroundColor = ConsoleColor.Green; Console.Write("\t\tDone!"); Console.ForegroundColor = ConsoleColor.White;
                
                Write("Enter the root password: ");
                MEnvironment.rootpass = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                WriteLine("Writing root password...");
                MEnvironment.WriteRootPass();
                Console.ForegroundColor = ConsoleColor.Green; Console.Write("\t\tDone!"); Console.ForegroundColor = ConsoleColor.White;

                //File.WriteAllText(MEnvironment.rpf, AIC_Framework.Crypto.MD5.hash(MEnvironment.rootpass));
            }
            catch (Exception ex)
            {
                Bluescreen.Init(ex, true);
                Console.ReadKey(true);
            }
            Console.CursorLeft = 7;
            MEnvironment.PressAnyKey("All set! Press any key to continue...");
            Console.CursorLeft = 0;

            Kernel.username = usrname;
            Console.Clear();

            ScreenSetup();
            WriteLine("Please enter a machine name:");
            Kernel.pcname = Console.ReadLine();

            try
            {
                Console.ForegroundColor = ConsoleColor.White; Write("Creating machineinfo file...  "); File.Create(Kernel.pcinfo).Dispose(); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\t\tDone!");
                Console.ForegroundColor = ConsoleColor.White; Write("Writing machineinfo to file..."); File.WriteAllText(Kernel.pcinfo, Kernel.pcname); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("\t\tDone!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch
            {
                Console.ReadKey(true);
                ErrorHandler.BlueScreen.Init(5, @"The Installer was unable to create the user directory and other files. 
This may be due to an unformatted hard drive or some other error", "FAT Error");
            }

            //Console.WriteLine("Excellent! Please enter who this copy of Medli is registered to:");
            //KernelVariables.regname = Console.ReadLine();
            //File.Create(Kernel.current_dir + "reginfo.sys");
            //File.WriteAllText(Kernel.current_dir + "reginfo.sys", KernelVariables.regname);

            WriteLine("Awesome - you're all set!");
            Console.CursorLeft = 7;
            MEnvironment.PressAnyKey("Press any key to start Medli!");
            Console.CursorLeft = 0;
            Console.Clear();
        }
    }
}
