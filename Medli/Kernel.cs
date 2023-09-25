using Medli.System;
using System.Collections.Generic;
using Sys = Cosmos.System;
using Medli.Common;
using Medli.Common.Drivers;
using IL2CPU.API.Attribs;
using System.Drawing;

namespace Medli
{
    public static partial class Kernel
    {

        [ManifestResourceStream(ResourceName = "Medli.Logo.bmp")]
        public static byte[] logoImage;

        /// <summary>
        /// List of kernel services (filesystem, logging etc.)
        /// </summary>
		public static List<Daemon> Daemons = new List<Daemon>();

        /// <summary>
        /// 
        /// </summary>
        public static List<Driver> Drivers = new List<Driver>();

        /// <summary>
        /// Custom console implementation object
        /// </summary>
        //public static System.Framework.AConsole AConsole;

        /// <summary>
        /// 
        /// </summary>
        public static string Consolemode = "VGATextmode";

        /// <summary>
        /// Bitmap Logo
        /// </summary>
        public static Sys.Graphics.Bitmap BitmapLogo;

		/// <summary>
		/// Draws the Medli logo onto the console
		/// </summary>
		public static void DrawLogo()
		{
			//
		}
	}
}
