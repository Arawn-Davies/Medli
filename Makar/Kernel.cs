using Makar.Ring0;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace Makar
{
    public class Kernel : Sys.Kernel
    {

        protected override void BeforeRun()
        {
            Console.WriteLine("Cosmos booted successfully. Type a line of text to get it echoed back.");
            OSLvl0.PrintInfo();
        }

        protected override void Run()
        {
            Console.Write("Input: ");
            var input = Console.ReadLine();
            Console.Write("Text typed: ");
            Console.WriteLine(input);
        }
    }
}
