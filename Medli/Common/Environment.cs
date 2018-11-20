using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Medli.Common
{
    /// <summary>
    /// Will hold the environment methods which will be called by various components in Medli
    /// </summary>
    public class MEnvironment
    {
        public static string dir_ext = @"\";
        /// <summary>
        /// Small and simple method saves typing this method out over and over again - only has to be called once
        /// </summary>
        public static void PressAnyKey()
        {
            PressAnyKey("Press any key to continue...");
        }
        public static void PressAnyKey(string text)
        {
            Console.WriteLine(text);
            Console.ReadKey(true);
        }

    }
}
