using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Medli.Applications
{
    /// <summary>
    /// Class for Medliscript (mdscript),
    /// a simple scripting language for the Medli command line shell
    /// </summary>
    class Mdscript
    {
        /// <summary>
        /// Executes a script passed to the application,
        /// parsing the commands listed in a valid text file
        /// that has the extension '.mds'
        /// </summary>
        /// <param name="scriptname"></param>
        public static void Execute(string scriptname)
        {
            try
            {
                if (scriptname.EndsWith(".mds"))
                {
                    string[] lines = File.ReadAllLines(scriptname);
                    foreach (string line in lines)
                    {
                        Shell.Prompt(line);
                        //Console.WriteLine("");
                    }
                }
                else
                {
                    Console.WriteLine("Not a valid Medliscript file.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
