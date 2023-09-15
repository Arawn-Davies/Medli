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
    public class Logout : Command
	{
        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public override string Name
		{
			get { return "logout"; }
		}

        /// <summary>
        /// Gets the summary for the command.
        /// </summary>
        public override string Summary
		{
			get { return "Closes applications and logs out of the system."; }
		}


        /// <summary>
        /// Reboots the Medli oeprating system, accepting optional flags (none implemented)
        /// </summary>
        /// <param name="param">The parameter.</param>
        public override void Execute(string param)
		{
			Kernel._isLoggedIn = false;
		}
	}
}