using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Apps
{
    /// <summary>
    /// Class definition for the 'exit' command
    /// </summary>
    /// <seealso cref="Medli.Apps.Command" />
    public class Exit : Command
	{
        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public override string Name
		{
			get { return "exit"; }
		}

        /// <summary>
        /// Gets the summary for the command.
        /// </summary>
        public override string Summary
		{
			get { return "Closes the console."; }
		}

        /// <summary>
        /// A delegate void method that exits an opened terminal
        /// </summary>
        public delegate void Delegate();

        /// <summary>
        /// The exit void method
        /// </summary>
        private Delegate _exit;

        /// <summary>
        /// Initializes a new instance of the <see cref="Exit"/> class.
        /// </summary>
        /// <param name="exit">The exit.</param>
        public Exit(Delegate exit)
		{
			_exit = exit;
		}

        /// <summary>
        /// Executes the specified parameter.
        /// </summary>
        /// <param name="param">The parameter.</param>
        public override void Execute(string param)
		{
			_exit();
		}

        /// <summary>
        /// Returns help information about this command.
        /// </summary>
        public override void Help()
		{
			Console.WriteLine("exit");
			Console.WriteLine(" Closes the console.");
		}

	}
}