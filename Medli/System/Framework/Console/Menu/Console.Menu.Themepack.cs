/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;

namespace AIC.Main
{
    public static partial class AConsole
    {
        public partial class Menu
        {
            public class Themepack
            {
                private ConsoleColor[] colors;
                public Themepack(ConsoleColor fill, ConsoleColor box, ConsoleColor text, ConsoleColor highlighted, ConsoleColor arrow)
                {
                    colors = new ConsoleColor[5];
                    colors[0] = fill;
                    colors[1] = box;
                    colors[2] = text;
                    colors[3] = highlighted;
                    colors[4] = arrow;
                }
                public void Apply()
                {
                    Menu.ApplyThemePack(colors);
                }
            }
        }
    }
}
