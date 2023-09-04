/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIC.Main.dev
{
    public partial class TextScreen
    {
        // Constructor
        public TextScreen()
        {
            Foreground = Color.White;
            Background = Color.Black;
            X = 0;
            Y = 0;
            UpdateCursor(X, Y);
        }
    }
}
