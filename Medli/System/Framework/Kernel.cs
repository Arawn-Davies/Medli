using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using AIC.Main;
using AIC.Main.Extensions;
using Console = AIC.Main.AConsole;
using menu = AIC.Main.AConsole.Menu;

namespace AICTest
{
    
    public class Kernel: Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Console.Clear();
            Bootscreen.Show("AIC Demo!", Bootscreen.Effect.Matrix, ConsoleColor.Green, 3);
            Console.Clear();
            menu.Reset();
        }
        
        protected override void Run()
        {
            
            // Create a new category: catTest
            menu.Category catTest = new menu.Category("Category 1");
            catTest.AddEntry(new Entry1());
            catTest.AddEntry(new Entry2());
            // Create a new category: catAICTests
            // Contains methods for testing the AIC Framework.
            menu.Category catAICTests = new menu.Category("Tests menu");
            catAICTests.AddEntry(new ShutdownEntry());
            catAICTests.AddEntry(new RebootEntry());
            catAICTests.AddEntry(new Bluescreen());

            menu.Category BootScreens = new menu.Category("BootScreen demos");
            BootScreens.AddEntry(new Boot_SFT());
            BootScreens.AddEntry(new Boot_SFR());
            BootScreens.AddEntry(new Boot_SFB());
            BootScreens.AddEntry(new Boot_SFL());
            BootScreens.AddEntry(new Boot_TWR());
            BootScreens.AddEntry(new Boot_Matrix());

            // Add the categories to the menu
            menu.AddCategory(catTest);
            menu.AddCategory(catAICTests);
            menu.AddCategory(BootScreens);

            // Show the menu
            menu.Show();
            
        }
    }

}
