using System;
using System.Collections.Generic;
using System.Text;
using Medli.Common;
using Medli.System;
using Sys = Cosmos.System;

namespace Medli.Apps
{
    /// <summary>
    /// Class definition for the 'shutdown' command
    /// </summary>
    /// <seealso cref="Medli.Apps.Command" />
    public class Shutdown : Command
	{
        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public override string Name
		{
			get { return "shutdown"; }
		}

        /// <summary>
        /// Gets the summary for the command.
        /// </summary>
        public override string Summary
		{
			get { return "Closes applications and powers down the system."; }
  		}

        /// <summary>
        /// Shuts down the operating system, optional flags could be added (emergency shutdown etc.)
        /// </summary>
        public override void Execute(string param)
        {
            EnvironmentVariables.SaveVars();
            System.Framework.Power.Shutdown();
        }
    }
}