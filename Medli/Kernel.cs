using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace Medli
{
    public class Kernel: Sys.Kernel
    {
		public const string logo = @"
   ▄▄▄▄███▄▄▄▄      ▄████████ ████████▄   ▄█        ▄█  
 ▄██▀▀▀███▀▀▀██▄   ███    ███ ███   ▀███ ███       ███  
 ███   ███   ███   ███    █▀  ███    ███ ███       ███▌ 
 ███   ███   ███  ▄███▄▄▄     ███    ███ ███       ███▌ 
 ███   ███   ███ ▀▀███▀▀▀     ███    ███ ███       ███▌ 
 ███   ███   ███   ███    █▄  ███    ███ ███       ███  
 ███   ███   ███   ███    ███ ███   ▄███ ███▌    ▄ ███  
  ▀█   ███   █▀    ██████████ ████████▀  █████▄▄██ █▀   
                                         ▀             
";
        protected override void BeforeRun()
        {
			Console.Write(logo);
            Console.WriteLine("Cosmos booted successfully. Type a line of text to get it echoed back.");
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
