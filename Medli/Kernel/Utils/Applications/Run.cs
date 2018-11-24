﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Medli.Common;

namespace Medli.Apps
{
    /// <summary>
    /// Class for Medliscript (mdscript),
    /// a simple scripting interface for the Medli command line shell
    /// </summary>
    class Mdscript : Command
    {
		public override string Name
		{
			get
			{
				return "run";
			}
		}

		public override string Summary
		{
			get
			{
				return "Executes the specified script";
			}
		}

		/// <summary>
		/// Executes a script passed to the application,
		/// parsing the commands listed in a valid text file
		/// that has the extension '.mds'
		/// </summary>
		/// <param name="scriptname"></param>
		public override void Execute(string param)
        {
            try
            {
                if (param != "" && param != null && param.Length < 5 && param.EndsWith(".mds"))
                {
					if (File.Exists(Paths.CurrentDirectory + Paths.Separator + param))
					{
						string[] lines = File.ReadAllLines(param);
						foreach (string line in lines)
						{
							CommandConsole.Parse(line);
							//Console.WriteLine("");
						}
					}
					else
					{
						Shell.InvalidCommand(param, 2);
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
