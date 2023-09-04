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
            public class Category
            {
                public string Name;
                public List<Entry> entries;
                public Category(string name)
                {
                    this.entries = new List<Entry>();
                    this.entries.Add(new Back());
                    this.Name = name;
                }
                public void AddEntry(Entry entry) { this.entries.Add(entry); }
                public void AddEntries(Entry[] entries)
                {
                    for (int i = 0; i < entries.Length; i++) { this.entries.Add(entries[i]); }
                }
            }
        }
    }
}
