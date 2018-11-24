using Medli.System;

namespace Medli.Apps
{
	class fdisk : Command
	{
		public override string Name
		{
			get
			{
				return "fdisk";
			}
		}

		public override string Summary
		{
			get
			{
				return "Launches the disk utility";
			}
		}

		public override void Execute(string param)
		{
			FS.MFSU();
		}
	}
}
