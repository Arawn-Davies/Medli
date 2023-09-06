using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Medli.Main;
using Medli.Main.Extensions;
using Console = Medli.Main.AConsole;
using menu = Medli.Main.AConsole.Menu;

namespace MedliTest
{
    
    public class Kernel: Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Console.Clear();
            Bootscreen.Show("Medli Demo!", Bootscreen.Effect.Matrix, ConsoleColor.Green, 3);
            Console.Clear();
            menu.Reset();
        }
        
        protected override void Run()
        {
            
            // Create a new category: catTest
            menu.Category catTest = new menu.Category("Category 1");
            catTest.AddEntry(new Entry1());
            catTest.AddEntry(new Entry2());
            // Create a new category: catMedliTests
            // Contains methods for testing the Medli Framework.
            menu.Category catMedliTests = new menu.Category("Tests menu");
            catMedliTests.AddEntry(new ShutdownEntry());
            catMedliTests.AddEntry(new RebootEntry());
            catMedliTests.AddEntry(new Bluescreen());

            menu.Category BootScreens = new menu.Category("BootScreen demos");
            BootScreens.AddEntry(new Boot_SFT());
            BootScreens.AddEntry(new Boot_SFR());
            BootScreens.AddEntry(new Boot_SFB());
            BootScreens.AddEntry(new Boot_SFL());
            BootScreens.AddEntry(new Boot_TWR());
            BootScreens.AddEntry(new Boot_Matrix());

            // Add the categories to the menu
            menu.AddCategory(catTest);
            menu.AddCategory(catMedliTests);
            menu.AddCategory(BootScreens);

            // Show the menu
            menu.Show();
            
        }
    }

}
