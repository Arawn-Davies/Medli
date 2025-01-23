using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace Medli
{
    public partial class Kernel
    {
        /// <summary>
        /// The kernel version
        /// </summary>
        public static string KernelVersion = "0.3.6";

        /// <summary>
        /// Boolean if the system is running live or not
        /// </summary>
        public static bool _isLive;

        /// <summary>
        /// Boolean if the system is in normal execution mode
        /// </summary>
        public static bool _isRunning;

		public static bool _isLoggedIn = false;

        /// <summary>
        /// The system hostname
        /// </summary>
        public static string Hostname;

        /// <summary>
        /// ASCII logo
        /// </summary>
        public static string Logo = @"
   __    _                             
   /|   / |            |  |  o       //\\
  / |  /  |  ___    ___|  |  |      //__\\
 /  | /   | |___|  |   |  |  |     //\++/\\
/   |/    | |___   |___|  |_ |    //__\/__\\
                                  ~~~~~~~~~~          
The C# free and open source Operating System
";
        /// <summary>
        /// The Welcome message
        /// </summary>
        public static string Welcome = @"
Welcome to Medli version: " + KernelVersion + ", build: " +  BuildNumber + @"
Developed by Siaranite Solutions & Arawn Davies
Copyright (C) 2023 Arawn Davies, Siaranite Solutions, All Rights Reserved
Released under the BSD-3 Clause Clear license
";

        /// <summary>
        /// The license
        /// </summary>
        public static string License = @"MIT License

Copyright (c) 2023 Arawn Davies, Siaranite Solutions

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the ""Software""), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.";


        /// <summary>
        /// See 'Installer.username' - same string and value
        /// - Redefined for global usage in Medli
        /// </summary>
        public static string username;

        /// <summary>
        /// Defines where the PC information is stored as a file
        /// with it's location stored as a string
        /// </summary>
        public static string pcinfo = Common.Paths.System + MEnvironment.dir_ext + "pcinfo.sys";

        /// <summary>
        /// Defines where the user information is stored as a file,
        /// with it's location stored as a string
        /// </summary>
        public static string usrinfo = Common.Paths.System + MEnvironment.dir_ext + "usrinfo.sys";

        /// <summary>
        /// See 'Installer.MInit' for first declaration, shares the same value
        /// - Redefined for global usage in Medli
        /// </summary>
        public static string pcname;

    }
}
