using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Medli.Common;
using Medli.System;

namespace Medli
{
    public class Kernel: Sys.Kernel
    {
		public string logo = $@"                                    
    /|    //| |                              
   //|   // | |     ___      ___   / // ( )  Welcome to Medli version: { KernelProperties.KernelVersion } 
  // |  //  | |   //___) ) //   ) / // / /   Developed by Siaranite Solutions and Arawn Davies
 //  | //   | |  //       //   / / // / /    Copyright © Siaranite Solutions 2018, All Rights Reserved
//   |//    | | ((____   ((___/ / // / /     Released under the BSD-3 Clause Clear licence
";
        protected override void BeforeRun()
        {
			try
			{
				SYSPBE.Init();
				KernelProperties.Running = true;
				Console.Write(logo);
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
					Shell.prompt(Console.ReadLine());
				}
			}
			catch(Exception ex)
			{
				FatalError.Crash(ex);
			}
        }
	}
}
