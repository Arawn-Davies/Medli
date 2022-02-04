using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Apps
{
    /// <summary>
    /// Class definition for the 'time' command
    /// </summary>
    /// <seealso cref="Medli.Apps.Command" />
    public class Time : Command
	{
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public override string Name
		{
			get { return "time"; }
		}

        /// <summary>
        /// Gets the summary for the command.
        /// </summary>
        public override string Summary
		{
			get { return "Displays the current time."; }
		}

        /// <summary>
        /// Executes the specified parameter.
        /// </summary>
        /// <param name="param">The parameter.</param>
        public override void Execute(string param)
		{
			Medli.Time.printTime();
		}
	}
}