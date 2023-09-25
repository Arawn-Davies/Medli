using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.System.Graphics;
using Medli.System.Imaging;
using Medli.System.Framework;
using Sys = Cosmos.System;

namespace Medli
{
    public partial class Kernel
    {
		/// <summary>
		/// List of graphics drivers
		/// </summary>
		public enum GFXDriver
		{
			VMWareSVGA,
			VBE,
			VGA
		}

		/// <summary>
		/// Graphics driver currently in use
		/// </summary>
		public static GFXDriver graphicsDriver;
		
		/// <summary>
		/// List of hypervisors Medli may be running on
		/// </summary>
		public enum Hypervisor
		{
			VirtualBox,
			VMWare, 
			Bochs,
			QEMU,
			VirtualPC,
			BareMetal
		}

		/// <summary>
		/// If the operating system is running on virtualized hardware, which hypervisor?
		/// </summary>
		public static Hypervisor VM;

		/// <summary>
		/// If virtualized, hypervisor name
		/// </summary>
		public static string Host;

		/// <summary>
		/// Is the operating system running on virtualized hardware
		/// </summary>
		public static bool IsVirtualised;

		/// <summary>
		/// Graphical mode canvas
		/// </summary>
		public static Canvas canvas;

		/// <summary>
		/// Default console background colour
		/// </summary>
		public static ConsoleColor backgroundColour = ConsoleColor.Black;

		/// <summary>
		/// Default console foreground colour
		/// </summary>
		public static ConsoleColor foregroundColour = ConsoleColor.White;

		/// <summary>
		/// Sets the console colours back to their defaults.
		/// </summary>
		public static void SetColourScheme()
		{
			Console.BackgroundColor = backgroundColour;
			Console.ForegroundColor = foregroundColour;
		}

		/// <summary>
		/// Sets the default console colours to the current console colours
		/// </summary>
		public static void SaveColourScheme()
		{
			backgroundColour = Console.BackgroundColor;
			foregroundColour = Console.ForegroundColor;
		}
	}
}
