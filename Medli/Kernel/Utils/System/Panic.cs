using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Apps
{
    /// <summary>
    /// Class definition for the 'panic' command
    /// </summary>
    /// <seealso cref="Medli.Apps.Command" />
    public class Panic : Command
	{
        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public override string Name
		{
			get { return "panic"; }
		}

        /// <summary>
        /// Gets the summary for the command.
        /// </summary>
        public override string Summary
		{
			get { return "Causes a kernel panic."; }
		}

        /// <summary>
        /// Executes the specified parameter.
        /// </summary>
        /// <param name="param">The parameter.</param>
        public override void Execute(string param)
		{
            // Manually initiates a kernel panic
            var xCtx = new Cosmos.Core.INTs.IRQContext();
            Cosmos.Core.INTs.HandleInterrupt_00(ref xCtx);
			//Console.WriteLine("This shouldn't print!");
		}
	}
}