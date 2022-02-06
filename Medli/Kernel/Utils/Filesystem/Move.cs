using System;
using System.Collections.Generic;
using System.Text;
using MedliSystem = Medli.System;

namespace Medli.Apps
{
    /// <summary>
    /// Class definition for the 'move' command
    /// </summary>
    /// <seealso cref="Medli.Apps.Command" />
    public class Move : Command
	{
        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public override string Name
		{
			get
			{
				return "move";
			}
		}

        /// <summary>
        /// Gets the summary for the command.
        /// </summary>
        public override string Summary
		{
			get
			{
				return "Moves the specified file to the specified directory\nmove [src] [dest]";
			}
		}

        /// <summary>
        /// Moves the specified parameter.
        /// </summary>
        /// <param name="param">The parameter.</param>
        public override void Execute(string param)
		{
			string[] args = param.Split(' ');
			MedliSystem.FS.mv(args[0], args[1]);
		}

	}
}