using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Medli.Common;
using Medli.System;
using Medli.System.Framework;
using static System.Net.Mime.MediaTypeNames;
using Medli.Common.Services;

namespace Medli.Apps
{
	class VICS : Command
	{
		public override string Name
		{
			get
			{
				return "vics";
			}
		}
		public override string Summary
		{
			get
			{
				return @"Launches the VICS text editor
No file : vics
Optional: vics [arg]";
			}
		}
		public override void Execute(string param)
		{
			if (FSService.Active == true)
			{
				Screen.SaveBuffer();
				Console.Clear();
				if (param != "")
				{
					vics.StartVICS(param);
				}
				else
				{
					vics.StartVICS();
				}
				Screen.RestoreBuffer();
			}
			else
			{
				Console.WriteLine("The filesystem service is currently inactive. Please make sure the OS is not in live or recovery mode.");
				KernelExtensions.PressAnyKey();
			}
		}
	}
}