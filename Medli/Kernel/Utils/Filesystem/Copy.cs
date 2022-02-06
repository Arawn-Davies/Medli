using System;
using System.Collections.Generic;
using System.Text;
using MSys = Medli.System;
using System.IO;
using Medli.Common;

namespace Medli.Apps
{
    /// <summary>
    /// Class definition for the 'copy' command
    /// </summary>
    /// <seealso cref="Medli.Apps.Command" />
    public class Copy : Command
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
				return "copy";
			}
		}

        /// <summary>
        /// Gets the summary for the command.
        /// </summary>
        public override string Summary
		{
			get
			{
				return "Copies the specified file to the specified destination";
			}
		}

        /// <summary>
        /// Executes the specified parameter.
        /// </summary>
        /// <param name="param">The parameter.</param>
        public override void Execute(string param)
		{
			string[] args = param.Split(' ');
			if (File.Exists(args[0]))
			{
				MSys.FS.Copy(Paths.CurrentDirectory + args[0], args[1]);
			}
			else
			{
				Console.WriteLine("File does not exist");
			}
		}

	}
}