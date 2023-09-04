/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using System.Collections.Generic;

namespace AIC.Main
{
    public static partial class AConsole
    {
        public partial class Menu
        {
            internal class Back : Entry
            {
                public Back() { this.text = "Back to Main Menu"; }
                public override void Execute()
                {
                    Menu.menu = 3;
                }
            }
        }
    }
}
