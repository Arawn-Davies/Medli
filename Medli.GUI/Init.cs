using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using System.Drawing;
using Medli;

namespace Medli.GUI
{
    public class MUI
    {

        public static Canvas canvas;
        public static void Init()
        {
            Console.WriteLine("Medli GUI booted successfully. Let's go in Graphic Mode");
            Console.Clear();
            canvas = FullScreenCanvas.GetFullScreenCanvas();
            Main();
            

        }
        public static void Main()
        {
			canvas.Clear(Color.Blue);
            Pen pen = new Pen(Color.Black);
            pen.Color = Color.Black;
            canvas.DrawFilledRectangle(pen, 0, 0, 600, 50);
            Pen mousePen = new Pen(Color.White);
            mousePen.Color = Color.White;
            DrawMouse(mousePen, 40, 25);
            Console.ReadKey(true);
        }
        public static void MouseDraw()
        {
            Pen pen = new Pen(Color.Red);
            canvas.DrawLine(pen, Sys.MouseManager.X, Sys.MouseManager.Y, Sys.MouseManager.X + 5, Sys.MouseManager.Y);
            canvas.DrawLine(pen, Sys.MouseManager.X, Sys.MouseManager.Y, Sys.MouseManager.X, Sys.MouseManager.Y - 5);
            canvas.DrawLine(pen, Sys.MouseManager.X, Sys.MouseManager.Y, Sys.MouseManager.X + 5, Sys.MouseManager.Y - 5);
        }
        public static void DrawMouse(Pen pen, int x, int y)
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
