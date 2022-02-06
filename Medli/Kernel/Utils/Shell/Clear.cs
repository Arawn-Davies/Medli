using System;
namespace Medli.Apps
{
    /// <summary>
    /// Class definition for the 'clear' command
    /// </summary>
    /// <seealso cref="Medli.Apps.Command" />
    public class Clear : Command
	{
        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public override string Name
		{
			get { return "cls"; }
		}

        /// <summary>
        /// Gets the summary for the command.
        /// </summary>
        public override string Summary
		{
			get { return "Clears the screen."; }
		}

        /// <summary>
        /// Executes the command
        /// </summary>
        /// <param name="param">The parameter.</param>
        public override void Execute(string param)
		{
			Console.Clear();
		}

	}
}