using Medli.System;
using System;

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
            if (param == "quick")
            {
                try
                {
                    Common.Services.FSService.Format();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Screen.SaveBuffer();
                FS.MFSU();
                Screen.RestoreBuffer();
            }
        }
	}
}
