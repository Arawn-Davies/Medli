using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Medli.Apps
{
    /// <summary>
    /// Class definition for the 'script' command
    /// </summary>
    /// <seealso cref="Medli.Apps.Command" />
    public class Script : Command
	{
        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public override string Name
		{
			get { return "run"; }
		}

        /// <summary>
        /// Gets the summary for the command.
        /// </summary>
        public override string Summary
		{
			get { return "Runs the specified script file. (ending in .mds)"; }
		}

        /// <summary>
        /// Executes the specified parameter.
        /// </summary>
        /// <param name="param">The parameter.</param>
        public override void Execute(string param)
		{
			try
			{
				if (param.EndsWith(".mds"))
				{
					string[] lines = File.ReadAllLines(param);
					foreach (string line in lines)
					{
						CommandConsole.Parse(line);
					}
					Console.WriteLine("");
				}
				else
				{
					Console.WriteLine("Not a valid Medli Shellscript file.");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
