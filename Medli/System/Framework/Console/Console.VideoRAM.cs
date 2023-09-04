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
    public unsafe static partial class AConsole
    {
        public static class VideoRAM
        {
            /// <summary>
            /// Location of the VGA Video Memory buffer (0xB8000)
            /// </summary>
            private static byte* vram;

            public class VideoBuffer
            {
                public int id;
                public byte[] data;
                public int X, Y;
            }
            private static Stack<VideoBuffer> vbufferStack = new Stack<VideoBuffer>();
            private static List<VideoBuffer> vbufferList = new List<VideoBuffer>();

            /// <summary>
            /// Pushes what is in video RAM onto a stack
            /// </summary>
            public static void PushContents()
            {
                VideoBuffer vb = new VideoBuffer();
                vram = (byte*)0xB8000;
                vb.data = new byte[4250];
                for (int i = 0; i < 4250; i++)
                {
                    byte b = vram[i];
                    vb.data[i] = b;
                }
                vb.X = Console.CursorLeft;
                vb.Y = Console.CursorTop;
                vbufferStack.Push(vb);
            }


            /// <summary>
            /// Pops the content of the stack into Video RAM
            /// </summary>
            public static void PopContents()
            {
                if (vbufferStack.Count > 0)
                {
                    VideoBuffer vb = vbufferStack.Pop();
                    vram = (byte*)0xB8000;

                    for (int i = 0; i < 4250; i++)
                    {
                        vram[i] = vb.data[i];

                    }
                    Console.CursorLeft = vb.X;
                    Console.CursorTop = vb.Y;
                }
                else
                {
                    Error.WriteLine("MultiScreen stack empty - nothing to restore from!");
                }
            }

            /// <summary>
            /// Saves the Console content
            /// </summary>
            /// <param name="num"></param>
            /// <returns></returns>
            public static bool SaveContent(int id)
            {
                bool found = false;
                for (int i = 0; i < vbufferList.Count; i++)
                {
                    if (vbufferList[i].id == id)
                    {
                        found = true;
                        // Set new content
                        vram = (byte*)0xB8000;
                        vbufferList[i].data = new byte[4250];
                        vbufferList[i].id = id;
                        for (int j = 0; j < 4250; j++)
                        {
                            byte b = vram[j];
                            vbufferList[i].data[j] = b;
                        }
                        vbufferList[i].X = Console.CursorLeft;
                        vbufferList[i].Y = Console.CursorTop;
                        return true;
                    }
                }
                if (!found)
                {
                    VideoBuffer vb = new VideoBuffer();
                    vram = (byte*)0xB8000;
                    vb.data = new byte[4250];
                    vb.id = id;
                    for (int i = 0; i < 4250; i++)
                    {
                        byte b = vram[i];
                        vb.data[i] = b;
                    }
                    vb.X = Console.CursorLeft;
                    vb.Y = Console.CursorTop;
                    vbufferList.Add(vb);
                    return true;
                }
                return false;
            }

            /// <summary>
            /// Restores the Console content
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            public static bool RetContent(int id)
            {
                for (int i = 0; i < vbufferList.Count; i++)
                {
                    if (vbufferList[i].id == id)
                    {
                        // restore content
                        vram = (byte*)0xB8000;
                        for (int j = 0; j < 4250; j++)
                        {
                            vram[j] = vbufferList[i].data[j];
                        }
                        Console.CursorLeft = vbufferList[i].X;
                        Console.CursorTop = vbufferList[i].Y;
                        return true;
                    }
                }
                return false;
            }

            public static bool Switch(int cs, int id)
            {
                SaveContent(cs);
                foreach (VideoBuffer vb in vbufferList)
                {
                    if (id == vb.id)
                    {
                        return RetContent(id);
                    }
                    else
                    {
                        return SaveContent(id);
                    }
                }
                return false;

            }
        }
    }
}
