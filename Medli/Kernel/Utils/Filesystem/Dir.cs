using Medli.System;

namespace Medli.Apps
{
    /// <summary>
    /// Class definition for the 'dir' command
    /// </summary>
    /// <seealso cref="Medli.Apps.Command" />
    public class Dir : Command
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
				return "dir";
			}
		}

        /// <summary>
        /// Gets the summary for the command.
        /// </summary>
        public override string Summary
		{
			get
			{
				return "Lists the files in the current directory.";
			}
		}

        /// <summary>
        /// Executes the specified parameter.
        /// </summary>
        /// <param name="param">The parameter.</param>
        public override void Execute(string param)
		{
			if (param != "")
			{
				FS.Dir(param);
			}
			else
			{
				FS.Dir();
			}
		}

	}
}