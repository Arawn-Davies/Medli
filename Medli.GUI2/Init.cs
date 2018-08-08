using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using System.Drawing;
using Medli;
using System.Threading;

namespace Medli.GUI
{
    public class MUI
    {

        public static Canvas canvas;
		private static Pen pen = new Pen(Color.Black);
		private static Pen mousePen = new Pen(Color.Gray);
		private static Pen objPen = new Pen(Color.LightBlue);
        public static void Init()
        {
            Console.WriteLine("Medli GUI booted successfully. Let's go in Graphic Mode");
            Console.Clear();
            canvas = FullScreenCanvas.GetFullScreenCanvas();
			canvas.Clear(Color.White);
			while (true)
			{
				Main();
			}
        }
        public static void Main()
        {
            DrawMouse(mousePen, Sys.MouseManager.X, Sys.MouseManager.Y);
			Thread.Sleep(50);
			DrawMouse(new Pen(Color.White), Sys.MouseManager.X, Sys.MouseManager.Y);
        }

        public static void DrawMouse(Pen pen, uint x, uint y)
        {
            canvas.DrawPoint(pen, x, y);
            canvas.DrawPoint(pen, x + 1, y + 1);
            canvas.DrawPoint(pen, x + 1, y);
            canvas.DrawPoint(pen, x, y + 1);
            canvas.DrawPoint(pen, x +2 , y + 1);
            canvas.DrawPoint(pen, x + 1, y + 2);
            canvas.DrawPoint(pen, x + 2, y + 2);
            canvas.DrawPoint(pen, x + 3, y + 3);
            canvas.DrawPoint(pen, x + 4, y + 4);
        }
    }
}
