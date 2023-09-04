using System;
using System.Collections.Generic;
using System.Text;
using AIC.Main;
using AIC.Main.Extensions;
using Console = AIC.Main.AConsole;
using menu = AIC.Main.AConsole.Menu;

namespace AICTest
{
    public class ShutdownEntry : menu.Entry
    {
        public ShutdownEntry() { this.text = "Shutdown"; }
        public override void Execute()
        {
            userACPI.Shutdown();
        }
    }
    public class RebootEntry : menu.Entry
    {
        public RebootEntry() { this.text = "Reboot"; }
        public override void Execute()
        {
            userACPI.Reboot();
        }
    }
    public class Entry1 : menu.Entry
    {
        public Entry1() { this.text = "Apollo Test Entry"; }
        public override void Execute()
        {
            Console.Clear();
            Console.WriteLine("Apollo Test Entry");
            KernelExtensions.PressAnyKey();
            // Place the code that should be executed here
        }
    }

    // A hello world entry
    public class Entry2 : menu.Entry
    {
        public Entry2() { this.text = "Hello, world! Test Entry"; }
        public override void Execute()
        {
            Console.Clear();
            Console.WriteLine("Hello World!");
            KernelExtensions.PressAnyKey();
            // Place the code that should be executed here
        }
    }

    public class Bluescreen : menu.Entry
    {
        public static int breakme()
        {
            int num = 0;
            int val = 0;
            int number = (((val / num) / val) / num);
            return number;
        }
        public Bluescreen() { this.text = "Bluescreen test"; }
        public override void Execute()
        {
            Console.Clear();
            KernelExtensions.PressAnyKey("Press any key to start a test Stop Error");
            Console.WriteLine(breakme().ToString());
        }
    }

    public class CryptoSHA256 : menu.Entry
    {
        public CryptoSHA256() { this.text = "SHA256 Test"; }

        public override void Execute()
        {
            Console.WriteLine("Enter string to be hashed using SHA256");
            string hash = StringExtensions.SHA256(Console.ReadLine());
            Console.WriteLine(hash);
            KernelExtensions.PressAnyKey();
        }
    }

    public class Boot_SFT : menu.Entry
    {
        public Boot_SFT() { this.text = "Slide From Top"; }

        public override void Execute()
        {
            Bootscreen.Show("AIC Demo!", Bootscreen.Effect.SlideFromTop, ConsoleColor.Green, 1);
            Console.Clear();
        }
    }

    public class Boot_SFR : menu.Entry
    {
        public Boot_SFR() { this.text = "Slide From Right"; }

        public override void Execute()
        {
            Bootscreen.Show("AIC Demo!", Bootscreen.Effect.SlideFromRight, ConsoleColor.Green, 1);
            Console.Clear();
        }
    }

    public class Boot_SFB : menu.Entry
    {
        public Boot_SFB() { this.text = "Slide From Bottom"; }

        public override void Execute()
        {
            Bootscreen.Show("AIC Demo!", Bootscreen.Effect.SlideFromBottom, ConsoleColor.Green, 1);
            Console.Clear();
        }
    }

    public class Boot_SFL : menu.Entry
    {
        public Boot_SFL() { this.text = "Slide From Left";  }

        public override void Execute()
        {
            Bootscreen.Show("AIC Demo!", Bootscreen.Effect.SlideFromLeft, ConsoleColor.Green, 1);
            Console.Clear();
        }
    }



    public class Boot_TWR : menu.Entry
    {
        public Boot_TWR() { this.text = "Typewriter"; }

        public override void Execute()
        {
            Bootscreen.Show("AIC Demo!", Bootscreen.Effect.Typewriter, ConsoleColor.Green, 2);
            Console.Clear();
        }
    }

    public class Boot_Matrix : menu.Entry
    {
        public Boot_Matrix() { this.text = "Matrix"; }

        public override void Execute()
        {
            Bootscreen.Show("AIC Demo!", Bootscreen.Effect.Matrix, ConsoleColor.Green, 2);
            Console.Clear();
        }
    }
}
