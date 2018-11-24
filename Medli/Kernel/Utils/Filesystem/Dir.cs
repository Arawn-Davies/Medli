using Medli.System;

namespace Medli.Apps
{
	public class Dir : Command
	{
		public override string Name
		{
			get
			{
				return "dir";
			}
		}

		public override string Summary
		{
			get
			{
				return "Lists the files in the current directory.";
			}
		}

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