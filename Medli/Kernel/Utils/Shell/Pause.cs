using System;
using Medli.Common;
using Medli.System.Framework;

namespace Medli.Apps
{
    /// <summary>
    /// Class definition for the 'pause' command
    /// </summary>
    /// <seealso cref="Medli.Apps.Command" />
    public class Pause : Command
	{
        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public override string Name
		{
			get { return "pause"; }
		}

        /// <summary>
        /// Gets the summary for the command.
        /// </summary>
        public override string Summary
		{
			get { return "Prompts the user to press any key."; }
		}

        /// <summary>
        /// Executes the specified parameter.
        /// </summary>
        /// <param name="param">The parameter.</param>
        public override void Execute(string param)
		{
			if (param != null)
			{
				KernelExtensions.PressAnyKey(param);
			}
			else
			{
				KernelExtensions.PressAnyKey();
			}
		}

	}
}