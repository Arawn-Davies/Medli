using System;
using System.Collections.Generic;
using System.Text;
using Medli.Common;

namespace Medli.Apps
{
    /// <summary>
    /// Class definition of command 'version'
    /// </summary>
    /// <seealso cref="Medli.Apps.Command" />
    public class Version : Command
	{
        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public override string Name
		{
			get { return "version"; }
		}

        /// <summary>
        /// Gets the summary for the command.
        /// </summary>
        public override string Summary
		{
			get { return "Displays version information about Medli."; }
		}

        /// <summary>
        /// Executes the specified parameter.
        /// </summary>
        /// <param name="param">The parameter.</param>
        public override void Execute(string param)
		{
			if (param.CompareTo("") == 0 || param.CompareTo("ver") == 0)
			{
				DisplayVersion();
			}
			else
			{
				Help();
			}
		}
        /// <summary>
        /// Displays the version.
        /// </summary>
        private void DisplayVersion()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Medli Copyright 2022 Siaranite Solutions");
			Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("Medli v");
			Console.WriteLine(Kernel.KernelVersion);
			Console.WriteLine();
		}

        /// <summary>
        /// Prints help information about this command.
        /// </summary>
        public override void Help()
		{
			Console.WriteLine("version [ver|dev]");
			Console.Write("  "); Console.WriteLine(Summary);
			Console.WriteLine();
			Console.WriteLine("  ver: Displays the version information.");
			Console.WriteLine("  dev: Displays information about the developers.");
		}
	}
}