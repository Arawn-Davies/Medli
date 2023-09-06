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

namespace Medli.System.Framework
{
    public static partial class AConsole
    {
        public partial class Menu
        {
            public static bool recovery = false;
            public static int menu = 0;
            public static List<Category> cat;
            public static ConsoleColor fill;
            public static ConsoleColor background;
            public static ConsoleColor normal;
            public static ConsoleColor highlighted;
            public static ConsoleColor arrow;
            internal static int item = 0;
            internal static int itemcat = 0;
            public static void Reset()
            {
                cat = new List<Category>();
                fill = ConsoleColor.Cyan;
                background = ConsoleColor.Green;
                normal = ConsoleColor.Black;
                highlighted = ConsoleColor.White;
                arrow = ConsoleColor.Yellow;
            }

            public static void ApplyThemePack(ConsoleColor[] colors)
            {
                if (colors.Length == 5)
                {
                    fill = colors[0];
                    background = colors[1];
                    normal = colors[2];
                    highlighted = colors[3];
                    arrow = colors[4];
                }
                else if (colors.Length < 5)
                    Bluescreen.Init("INVALID_THEME_EXCEPTION",
                    "Looks like your ConsoleColor-Array contains less than 5 entries");
                else if (colors.Length > 5)
                    Bluescreen.Init("INVALID_THEME_EXCEPTION",
                    "Looks like your ConsoleColor-Array contains more than 5 entries");
            }
            public static void AddCategory(Category category) { cat.Add(category); }
            public static void Show()
            {
                Console.Clear();
                
                fill = ConsoleColor.Cyan;
                background = ConsoleColor.Green;
                normal = ConsoleColor.Black;
                highlighted = ConsoleColor.White;
                arrow = ConsoleColor.Yellow;
                Fill(fill);

                while (true)
                {
                    if (recovery == true) break;
                    if (menu == 0) ShowCategoryMenu();
                    else if (menu == 1) { Fill(fill); menu++; }
                    else if (menu == 2) ShowEntryMenu();
                    else if (menu == 3) { Fill(fill); menu = 0; }
                }
            }
            private static void ShowCategoryMenu()
            {
                for (int i = 10 - (cat.Count / 2); i < 11 + cat.Count; i++)
                {
                    string buffer = "";
                    AConsole.CursorTop = i;
                    for (int j = 10; j <= 70; j++)
                    {
                        buffer += " ";
                    }
                    CursorLeft = 10;
                    WriteEx(buffer, background, background);
                }
                CursorTop = 11 - (cat.Count / 2);
                for (int i = 0; i < cat.Count; i++)
                {
                    if (i == item)
                    {
                        WriteEx(cat[i].Name, highlighted, background, true);
                        CursorLeft = 69;
                        WriteLineEx(">", arrow, background);
                    }
                    else WriteLineEx(cat[i].Name, normal, background, true);
                }
                while (true)
                {
                    ConsoleKey key = ReadKey().Key;
                    if (key == ConsoleKey.UpArrow)
                    {
                        if (item > 0) item--;
                        else item = cat.Count - 1;
                        break;
                    }
                    else if (key == ConsoleKey.DownArrow)
                    {
                        if (item < cat.Count - 1) item++;
                        else item = 0;
                        break;
                    }
                    else if (key == ConsoleKey.Enter || key == ConsoleKey.RightArrow)
                    {
                        itemcat = item;
                        item = 0;
                        menu = 1;
                        break;
                    }
                }
            }
            private static void ShowEntryMenu()
            {
                for (int i = 10 - (cat[itemcat].entries.Count / 2); i < 11 + cat.Count; i++)
                {
                    string buffer = "";
                    AConsole.CursorTop = i;
                    for (int j = 10; j <= 70; j++)
                    {
                        buffer += " ";
                    }
                    AConsole.CursorLeft = 10;
                    AConsole.WriteEx(buffer, background, background);
                }
                AConsole.CursorTop = 11 - (cat[itemcat].entries.Count / 2);
                for (int i = 0; i < cat[itemcat].entries.Count; i++)
                {
                    if (i == item)
                    {
                        WriteEx(cat[itemcat].entries[i].text, highlighted, background, true);
                        CursorLeft = 69;
                        WriteLineEx(">", arrow, background);
                    }
                    else WriteLineEx(cat[itemcat].entries[i].text, normal, background, true);
                }
                while (true)
                {
                    ConsoleKey key = AConsole.ReadKey().Key;
                    if (key == ConsoleKey.UpArrow)
                    {
                        if (item > 0) item--;
                        else item = cat[itemcat].entries.Count - 1;
                        break;
                    }
                    else if (key == ConsoleKey.DownArrow)
                    {
                        if (item < cat[itemcat].entries.Count - 1) item++;
                        else item = 0;
                        break;
                    }
                    else if (key == ConsoleKey.Enter || key == ConsoleKey.RightArrow)
                    {
                        cat[itemcat].entries[item].Execute();
                        break;
                    }
                }
            }
        }
    }
}
