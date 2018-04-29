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
			//var xCtx = new Cosmos.Core.INTs.IRQContext();
			//Core.INTs.HandleInterrupt_00(ref xCtx);
			int a = 10 / 2;
			int b = a / 0;
			Console.WriteLine("This shouldn't print!");
		}
	}
}