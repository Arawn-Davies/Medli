using System;
using System.Collections.Generic;
using System.Text;
using Medli.Common;

namespace Medli.Core
{
    class FatalError
    {
		public static void Crash(string exception, string description, string lastknownaddress, string ctxinterrupt)
		{
			Console.BackgroundColor = ConsoleColor.DarkMagenta;
			Console.Clear();

			Console.CursorTop += 1;
			Console.WriteLine("A fatal processor exception occurred and Medli was shutdown to protect your computer from further damage.");
			Console.WriteLine("If this is the first time you have seen this error, press any key to restart your computer.");
			Console.WriteLine("This error may have occurred due to newly installed or older failing hardware. Error information can be found below:");
			Console.CursorTop += 1;
			// Print exception information
			Console.WriteLine("Kernel version: " + KernelProperties.KernelVersion);
			Console.WriteLine("CPU Exception: " + ctxinterrupt);
			Console.WriteLine("Exception: " + exception);
			Console.WriteLine("Exception description: " + description);
			if (lastknownaddress != "")
			{
				Console.WriteLine("Last known address: " + lastknownaddress);
			}
			Console.CursorTop = 24;
			Console.WriteLine("Press any key to restart...");
			Console.ReadKey(true);
			KernelProperties.Running = false;
		}
		public static void Crash(Exception ex)
		{
			string exMsg = ex.Message;
			string exIntMsg = "";

			Console.BackgroundColor = ConsoleColor.DarkMagenta;
			Console.Clear();

			Console.CursorTop += 1;
			Console.WriteLine("A fatal exception occurred and Medli was shutdown to protect your computer from further damage.");
			Console.WriteLine("If this is the first time you have seen this error, press any key to restart your computer.");
			Console.WriteLine("This error may have occurred due to newly installed or older failing hardware. Error information can be found below:");
			Console.CursorTop += 1;
			// Print exception information
			Console.WriteLine("Kernel version: " + KernelProperties.KernelVersion);
			Console.WriteLine("Exception: " + ex);
			Console.WriteLine("Exception message: " + exMsg);
			if (ex.InnerException.Message != null)
			{
				exIntMsg = ex.InnerException.Message;
				Console.WriteLine("Internal exception: " + exIntMsg);
			}
			Console.CursorTop = 24;
			Console.WriteLine("Press any key to restart...");
			Console.ReadKey(true);
			KernelProperties.Running = false;
		}
    }
}
