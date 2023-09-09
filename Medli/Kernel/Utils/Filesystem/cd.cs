using System;
using System.Collections.Generic;
using System.Text;
using MedliSystem = Medli.System;
using System.IO;
using Medli.System;

namespace Medli.Apps
{
    /// <summary>
    /// Class definition for the 'cd' command
    /// </summary>
    /// <seealso cref="Medli.Apps.Command" />
    public class cd : Command
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
				return "cd";
			}
		}

        /// <summary>
        /// Gets the summary for the command.
        /// </summary>
        public override string Summary
		{
			get
			{
				return @"Changes to the specified directoy";
			}
		}

        /// <summary>
        /// Executes the specified parameter.
        /// </summary>
        /// <param name="param">The parameter.</param>
        public override void Execute(string param = "")
		{
			if (param == "..")
			{
				FS.cdp();
			}
			else
			{
				FS.cd(param);
			}
		}

	}
}