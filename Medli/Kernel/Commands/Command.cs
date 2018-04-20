using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Apps
{
    public abstract class Command
    {
		public abstract string Name
		{
			get;
		}

		/// <summary>
		/// Gets the summary for the command.
		/// </summary>
		public abstract string Summary
		{
			get;
		}

		public abstract void Execute(string param);

		public virtual void Help()
		{
			Console.WriteLine(Name);
			Console.WriteLine(" " + Summary);
		}

	}
}
