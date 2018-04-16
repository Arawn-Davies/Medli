using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Medli.Common;
using Medli.System;

namespace Medli.Kernel
{
    public class Kernel: Sys.Kernel
    {
        protected override void BeforeRun()
        {
			// Sys.Graphics.VGAScreen.SetTextMode(Sys.Graphics.VGAScreen.TextSize.Size80x50);
			try
			{
				SYSPBE.Init();
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Blue;
				KernelProperties.Running = true;
				Console.Clear();
				Console.Write(KernelVariables.logo);
				Console.WriteLine(KernelVariables.welcome);
			}
			catch (Exception ex)
			{
				FatalError.Crash(ex);
			}
        }
        
        protected override void Run()
        {
			try
			{
				while (KernelProperties.Running == true)
				{
					Console.Write("Prompt >");
					string cmd = Console.ReadLine();
					Shell.prompt(cmd);
				}
			}
			catch(Exception ex)
			{
				FatalError.Crash(ex);
			}
        }
	}
}
