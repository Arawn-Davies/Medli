using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Apps
{
	public class Panic : Command
	{
		public override string Name
		{
			get { return "panic"; }
		}

		public override string Summary
		{
			get { return "Causes a kernel panic."; }
		}

		public override void Execute(string param)
		{
            // Manually initiates a kernel panic
            var xCtx = new Cosmos.Core.INTs.IRQContext();
            Cosmos.Core.INTs.HandleInterrupt_00(ref xCtx);
			//Console.WriteLine("This shouldn't print!");
		}
	}
}