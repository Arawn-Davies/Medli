using System.Diagnostics.Metrics;
using MedliX;
namespace Aryll
{
    internal class Program
    {
        static void Main(string[] args)
        {
			// Aryll is a translation layer for MedliX which allows it to run the Medli system on top of the .NET Core runtime.
			// MedliX runs on bare metal hardware, so Aryll is a compatibility layer that redirects drives and devices, and provides a virtualized environment for software development 

			// For example, file system paths such as 0:\\ and 1:\\ are redirected to a folder residing on the host machine, with IO methods being redirected to that folder.
			// Aryll will also allow mounting of a virtual disk image with the MedliX file system, and redirecting the IO methods to that disk image.

			Console.WriteLine("");
		}
	}
}