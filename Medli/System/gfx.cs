using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using Cosmos.System.Graphics;

namespace Medli.System
{
	public class gfx
	{
		public static void GoGraphical()
		{
			Mode mode = new Mode(1024, 768, ColorDepth.ColorDepth32);
			Kernel.canvas = FullScreenCanvas.GetFullScreenCanvas(mode);
			Pen pen = new Pen(Color.White);
			Kernel.canvas.DrawString("Welcome to Medli", Cosmos.System.Graphics.Fonts.PCScreenFont.Default, pen, new Cosmos.System.Graphics.Point(0,0));
			Kernel.canvas.DrawString("Press any key to continue", Cosmos.System.Graphics.Fonts.PCScreenFont.Default, pen, new Cosmos.System.Graphics.Point(0, 20));
			Console.ReadKey(true);
			Kernel.canvas.Disable();
			Console.Clear();
			Console.WriteLine("Exited graphical mode.");

		}
	}
}
