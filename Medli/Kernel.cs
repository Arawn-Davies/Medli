﻿using System;
using System.Collections.Generic;
using Sys = Cosmos.System;
using Medli.Common;
using Medli.Common.Drivers;
using Medli.System;
using IL2CPU.API.Attribs;

namespace Medli
{
    public static partial class Kernel
    {
        [ManifestResourceStream(ResourceName = "Medli.Logo.bmp")]
        public static byte[] logoImage;

        /// <summary>
        /// List of kernel services (filesystem, logging etc.)
        /// </summary>
		public static List<Service> Services = new List<Service>();

        /// <summary>
        /// 
        /// </summary>
        public static List<Driver> Drivers = new List<Driver>();

        /// <summary>
        /// 
        /// </summary>
        public static System.AConsole.Console AConsole;

        public static bool ExperimentalMode = false;

        /// <summary>
        /// 
        /// </summary>
        public static string Consolemode = "VGATextmode";

        /// <summary>
        /// 
        /// </summary>
        public static Cosmos.HAL.PCSpeaker speaker = new Cosmos.HAL.PCSpeaker();

        /// <summary>
        /// 
        /// </summary>
        public static Cosmos.System.Graphics.Bitmap Logo;

        /// <summary>
        /// 
        /// </summary>
        public static void DrawLogo()
        {
            AConsole.DrawImage(0, 0, 90, 37, System.Graphics.Imaging.Image.Load(logoImage));
        }
    }
}
