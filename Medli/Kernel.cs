using System;
using System.Collections.Generic;
using Sys = Cosmos.System;
using Medli.Common;
using Medli.System;
using IL2CPU.API.Attribs;

namespace Medli
{
    public static partial class Kernel
    {
        [ManifestResourceStream(ResourceName = "Medli.Logo.bmp")]
        public static byte[] logoImage;

		public static List<Service> Services = new List<Service>();
        public static System.AConsole.Console AConsole;
        public static string Consolemode = "VGATextmode";
        public static Cosmos.HAL.PCSpeaker speaker = new Cosmos.HAL.PCSpeaker();

        public static Cosmos.System.Graphics.Bitmap Logo;

        public static void DrawLogo()
        {
            AConsole.DrawImage(0, 0, 90, 37, System.Graphics.Imaging.Image.Load(logoImage));
        }
    }
}
