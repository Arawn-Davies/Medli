using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace Medli.GUI
{
    public class Kernel: Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Console.WriteLine("Bypassing Medli console, booting to MUI");
        }
        
        protected override void Run()
        {
            MUI.Init();
            Console.Clear();
            Console.WriteLine("Finished? Press any key to shutdown...");
            Cosmos.Core.ACPI.Shutdown();
        }
    }
}
