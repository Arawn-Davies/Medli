using System;
using System.Collections.Generic;
using System.Text;
using Medli;

namespace Medli.Apps
{
    /// <summary>
    /// Class definition for the 'date' command
    /// </summary>
    /// <seealso cref="Medli.Apps.Command" />
    public class Date : Command
	{
        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public override string Name
		{
			get { return "date"; }
		}

        /// <summary>
        /// Gets the summary for the command.
        /// </summary>
        public override string Summary
		{
			get { return "Displays the current date."; }
		}

        /// <summary>
        /// Executes the specified parameter.
        /// </summary>
        /// <param name="param">The parameter.</param>
        public override void Execute(string param)
		{
			Medli.Date.printDate();
		}
	}
}