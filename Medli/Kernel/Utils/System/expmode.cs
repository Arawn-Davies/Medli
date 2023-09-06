using System;
using System.Collections.Generic;
using System.Text;
using Medli.Common;
using Medli.System;
using Sys = Cosmos.System;
using AC = Medli.System.Framework.AConsole;

namespace Medli.Apps
{
    /// <summary>
    /// Class definition for the experimental mode
    /// </summary>
    /// <seealso cref="Medli.Apps.Command" />
    public class ExperimentalMode : Command
	{
        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public override string Name
		{
			get { return "expmode"; }
		}

        /// <summary>
        /// Gets the summary for the command.
        /// </summary>
        public override string Summary
		{
			get { return "Switches the kernel's experimental features on/off"; }
		}

        /// <summary>
        /// Executes the specified parameter.
        /// </summary>
        /// <param name="param">The parameter.</param>
        public override void Execute(string param)
		{
			if (param.ToLower().Contains("on"))
            {
                Kernel.ExperimentalMode = true;
            }
            else if (param.ToLower().Contains("off"))
            {
                Kernel.ExperimentalMode = false;
            }
            else
            {
                AC.Error.WriteLine("Use either On/Off. Keeping experimental features disabled.");
            }
		}
	}
}