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
   //|   // | |     ___      ___   / // ( )  Welcome to Bourne-Again Medli version { KernelProperties.KernelVersion } 
  // |  //  | |   //___) ) //   ) / // / /   Developed by Siaranite Solutions and Arawn Davies
 //  | //   | |  //       //   / / // / /    Copyright © Siaranite Solutions 2018, All Rights Reserved
//   |//    | | ((____   ((___/ / // / /     Released under the BSD-3 Clause Clear licence
";
        protected override void BeforeRun()
        {
			SYSPBE.Init();
			KernelProperties.Running = true;
			Console.Write(logo);
        }
        
        protected override void Run()
        {
			CoreInfo.PrintInfo();
			while (KernelProperties.Running == true)
			{
				Shell.prompt(Console.ReadLine());
			}
        }
	}
}
