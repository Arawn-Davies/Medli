using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.System.Graphics;
using Sys = Cosmos.System;

namespace Medli
{
    public partial class Kernel
    {
		public enum GFXDriver
		{
			VMWareSVGA,
			VBE,
			VGA
		}
		public static GFXDriver graphicsDriver;
		public enum Hypervisor
		{
			VirtualBox,
			VMWare, 
			Bochs,
			QEMU,
			VirtualPC,
			BareMetal
		}
		public static Hypervisor VM;

		public static string Host;
		public static bool IsVirtualised;

		public static Canvas canvas;

		public static ConsoleColor backgroundColour = ConsoleColor.Black;
		public static ConsoleColor foregroundColour = ConsoleColor.White;

		public static void SetColourScheme()
		{
			Console.BackgroundColor = backgroundColour;
			Console.ForegroundColor = foregroundColour;
		}
		public static void SaveColourScheme()
		{
			backgroundColour = Console.BackgroundColor;
			foregroundColour = Console.ForegroundColor;
			SetColourScheme();
		}
	}
}
