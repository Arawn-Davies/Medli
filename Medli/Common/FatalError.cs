using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace Medli.Common
{
    public class FatalError
    {
        public const string ErrorSplash = @"A fatal error has occurred and Medli was shutdown to protect your computer
from further damage. If this is the first time you have seen this error, press
any key to restart your computer. This error may have occurred due to newly
installed or older failing hardware. 

Error information can be found below:";

        public static void Crash(string error = "Something went wrong!", string description = "Unknown exception", bool critical = false)
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Clear();
            Console.CursorTop += 1;
            Console.WriteLine(ErrorSplash);
            Console.CursorTop += 1;
            // Print exception information
            Console.WriteLine("Kernel version: " + Kernel.KernelVersion);
            Console.WriteLine("Errpr: " + error);
            Console.WriteLine("Description: " + description);
            Console.WriteLine("Exception description: " + description);
            Console.CursorTop = 24;
            Console.WriteLine("Press any key to restart...");
            Console.ReadKey(true);
            Sys.Power.Reboot();
        }
        public static void Crash(string exception, string description, string lastknownaddress, string ctxinterrupt)
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Clear();

            Console.CursorTop += 1;
            Console.WriteLine(ErrorSplash);
            Console.CursorTop += 1;
            // Print exception information
            Console.WriteLine("Kernel version: " + Kernel.KernelVersion);
            Console.WriteLine("CPU Exception: " + ctxinterrupt);
            Console.WriteLine("Exception: " + exception);
            Console.WriteLine("Exception description: " + description);
            if (lastknownaddress != "")
            {
                Console.WriteLine("Last known address: " + lastknownaddress);
            }
            Console.CursorTop = 24;
            Console.WriteLine("Press any key to restart...");
            Console.ReadKey(true);
            Sys.Power.Reboot();
        }
        public static void Crash(Exception ex)
        {
            string exMsg = ex.Message;
            string exIntMsg = "";

            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.Clear();

            Console.CursorTop += 1;
            Console.WriteLine(ErrorSplash);
            Console.CursorTop += 1;
            // Print exception information
            Console.WriteLine("Kernel version: " + Kernel.KernelVersion);
            Console.WriteLine("Exception message: " + exMsg);
            if (ex.InnerException.Message != null)
            {
                exIntMsg = ex.InnerException.Message;
                Console.WriteLine("Internal exception: " + exIntMsg);
            }
            Console.CursorTop = 24;
            Console.WriteLine("Press any key to restart...");
            Console.ReadKey(true);
            Sys.Power.Reboot();
        }

        public static void Panic(Cosmos.Core.INTs.IRQContext aContext)
        {

        }
    }
    public class ErrorHandler
    {
        public class BlueScreen
        {
            /// <summary>
            /// BSoD equivalent message, when users see this, then they know it truly is an 'O shit' situation
            /// </summary>
            public static string Msg = @"

                '||            ||    
                 ||      ''    ||    
.|''|,    (''''  ||''|,  ||  ''||''  
||  ||     `'')  ||  ||  ||    ||    
`|..|'    `...' .||  || .||.   `|..'

What's happened now?! ";
            /// <summary>
            /// Initializes the BSoD equivalent, getting the error level, 
            /// error description and the error itself
            /// </summary>
            /// <param name="errlvl"></param>
            /// <param name="errdsc"></param>
            /// <param name="err"></param>
            public static void Init(int errlvl, string errdsc, string err)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.WriteLine(Msg + err);
                Console.WriteLine("This means that: "); Console.WriteLine(errdsc);
                Console.WriteLine("Press any key to restart.");
                Console.ReadKey(true);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Sys.Power.Reboot();
            }
        }
        /// <summary>
        /// Initializes the error reporter,
        /// works as an error handler for exceptions inside applications
        /// </summary>
        /// <param name="errlvl"></param>
        /// <param name="errdsc"></param>
        /// <param name="critical"></param>
        /// <param name="err"></param>
        public static void Init(int errlvl, string errdsc, bool critical, string err)
        {
            if (critical == true)
            {
                BlueScreen.Init(errlvl, errdsc, err);
            }
            else if (critical == false)
            {
                if (errlvl == 5)
                    Console.BackgroundColor = ConsoleColor.Blue;
                Console.Clear();
                Apps.Cowsay.Cow("Whoops!");
                Console.WriteLine("You've encountered an error. This means that: "); Console.WriteLine(errdsc);
                Console.WriteLine("Press any key to return to shell.");
                Console.ReadKey(true);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
            }
        }

    }
}
