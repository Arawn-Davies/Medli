/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Core.Framework.dev
{
    public class TextScreen
    {
        public enum Color : byte
        {
            Black = 0x0,
            Blue = 0x1,
            Green = 0x2,
            Cyan = 0x3,
            Red = 0x4,
            Magenta = 0x5,
            Brown = 0x6,
            Lightgray = 0x7,
            Gray = 0x8,
            Lightblue = 0x9,
            Lightgreen = 0xA,
            Lightcyan = 0xB,
            Lightred = 0xC,
            Lightmagenta = 0xD,
            Yellow = 0xE,
            White = 0xF
        }
        public static Color Foreground, Background;
        public static int X, Y;
        public static unsafe void PrintChar(char chr, int x, int y)
        {
            //int* port = (int*)0xB8000;
            //port += (int)(((byte)color << 8) | chr);
            byte* address = (byte*)0xB8000;
            int position = (y * 80) + x;
            address[position] = (byte)chr;
            address[++position] = (byte)((uint)(Foreground) | ((uint)(Background) << 4));
            if (x < 80) { X = x; X++; }
            else { X = 0; Y = y; Y++; }
        }
    }
}
