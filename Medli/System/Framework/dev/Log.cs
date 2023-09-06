/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using System.Collections.Generic;
using Medli.System.Framework;
using AB = Medli.System.Framework.AConsole.VideoRAM;

namespace Medli.System.Framework.dev
{
    public static class Log
    {
        /// <summary>
        /// Is the Log list initialized?
        /// </summary>
        private static bool initialized = false;

        /// <summary>
        /// Lists declaration of the calling class, category and description
        /// </summary>
        private static List<string> cc, cg, ds;
        /// <summary>
        /// Please use the following formatting for callingclass:
        /// dewitcher.[namespace/s].[class].[method/function]
        /// For example: dewitcher.dev.testclass.amethod
        /// </summary>
        /// <param name="callingclass">For example: dewitcher.dev.testclass.amethod</param>
        /// <param name="category">The category, for example WitchFS</param>
        /// <param name="description">The event description</param>
        public static void AddEntry(string callingclass, string category, string description)
        {
            if (!initialized) init();
            cc.Add(callingclass);
            cg.Add(category);
            ds.Add(description);
        }

#warning TODO: Work on implementation if needed
        /// <summary>
        /// Get the entries of the calling class
        /// </summary>
        /// <param name="category"></param>
        public static void GetEntries(string category)
        {
            if (!initialized) init();
            // Save current console state
            AB.PushContents();
            // Write the entries
            int max = Console.WindowHeight - 4;
            int found = 0;
            bool finished = false;
            while (!finished)
            {
                if (found < cc.Count)
                {
                    for (int i = found; i < cc.Count; i++)
                    {
                        if (category == category[i].ToString())
                        {
                            AConsole.WriteLine(ds[i].ToString());
                        }
                    }
                }
            }
            AConsole.WriteLine("Press any key to continue...");
            AConsole.ReadKey(true);
            AB.PopContents();
        }
        public static void Test()
        {
            AddEntry("aic.dev.Log.foo", "foo", "that's some foobar");
            AddEntry("aic.dev.Log.foo", "foo", "that's some foobar too");
            AddEntry("aic.dev.Log.foo", "foo", "foobar fighters");
            AddEntry("aic.dev.Log.foo", "foo", "that's some foobar fighter");
            AddEntry("aic.dev.Log.foo", "foo", "everybody loves foobar fighting");
            GetEntries("foo");
        }
        private static void init()
        {
            cc = new List<string>();
            cg = new List<string>();
            ds = new List<string>();
            initialized = true;
        }
    }
}
