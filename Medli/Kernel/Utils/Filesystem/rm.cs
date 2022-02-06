using System;
using System.Collections.Generic;
using System.Text;
using MedliSystem = Medli.System;
using System.IO;
using Medli.System;

namespace Medli.Apps
{
    /// <summary>
    /// Class definition for the 'rm' command
    /// </summary>
    /// <seealso cref="Medli.Apps.Command" />
    public class rm : Command
	{
        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public override string Name
		{
			get
			{
				return "rm";
			}
		}

        /// <summary>
        /// Gets the summary for the command.
        /// </summary>
        public override string Summary
		{
			get
			{
				return @"Removes the specified file/directory
Directory: rm -r [arg]
File:      rm [arg]";
			}
		}

        /// <summary>
        /// Executes the specified parameter.
        /// </summary>
        /// <param name="param">The parameter.</param>
        public override void Execute(string param)
		{
			string[] args = param.Split(' ');
			if (args[0] == "-r")
			{
				FS.del(args[1], true);
			}
			else
			{
				FS.del(args[0], false);
			}
		}

	}
}