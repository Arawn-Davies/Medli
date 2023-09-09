using System;
using System.Collections.Generic;
using System.Text;
using Medli.Common;
using Medli.System;
using Sys = Cosmos.System;

namespace Medli.Apps
{
    /// <summary>
    /// Class definition for the 'reboot' command
    /// </summary>
    /// <seealso cref="Medli.Apps.Command" />
    public class Reboot : Command
	{
        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public override string Name
		{
			get { return "reboot"; }
		}

        /// <summary>
        /// Gets the summary for the command.
        /// </summary>
        public override string Summary
		{
			get { return "Closes applications and reboots the system."; }
		}


        /// <summary>
        /// Reboots the Medli oeprating system, accepting optional flags (none implemented)
        /// </summary>
        /// <param name="param">The parameter.</param>
        public override void Execute(string param)
		{
			EnvironmentVariables.SaveVars();
            System.Framework.Power.Reboot();
		}
	}
}