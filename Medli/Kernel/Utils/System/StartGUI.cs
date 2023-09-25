using System;
using System.Collections.Generic;
using System.Text;
using Medli.Common;
using Medli.System;
using Sys = Cosmos.System;

namespace Medli.Apps
{
	/// <summary>
	/// Class definition for the 'shutdown' command
	/// </summary>
	/// <seealso cref="Medli.Apps.Command" />
	public class StartGUI : Command
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
				return "startgui";
			}
		}

		/// <summary>
		/// Gets the summary for the command.
		/// </summary>
		public override string Summary
		{
			get
			{
				return "Starts the graphical user interface";
			}
		}

		/// <summary>
		/// Shuts down the operating system, optional flags could be added (emergency shutdown etc.)
		/// </summary>
		public override void Execute(string param)
		{
			gfx.GoGraphical();
		}
	}
}