using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace Medli_Boot
{
	public class Kernel : Sys.Kernel
	{

		protected override void BeforeRun()
		{
			Medli.Boot.BeforeRun();
		}

		protected override void Run()
		{
			Medli.Boot.Run();
		}
	}
}
