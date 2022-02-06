using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Apps
{
    /// <summary>
    /// Class definition for the 'echo' command
    /// </summary>
    /// <seealso cref="Medli.Apps.Command" />
    public class Echo : Command
	{
        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public override string Name
		{
			get { return "echo"; }
		}

        /// <summary>
        /// Gets the summary for the command.
        /// </summary>
        public override string Summary
		{
			get
			{
				return @"Duplicates text you enter to the console.
echo $[arg] : Returns the contents of the speciied variable";
			}
		}

        /// <summary>
        /// Executes the specified parameter.
        /// </summary>
        /// <param name="param">The parameter.</param>
        public override void Execute(string param)
		{
			if (param.StartsWith("$"))
			{
				Console.WriteLine(EnvironmentVariables.Retrieve(param.Substring(1)));
			}
			else
			{
				Console.WriteLine(param);
			}
		}
	}
}
