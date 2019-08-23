using System;
using System.Collections.Generic;
using System.Text;
using IL2CPU.API.Attribs;
using Cosmos.HAL;
using Medli;

namespace MedliPlugs.System
{
    [Plug(Target = typeof(Cosmos.System.Global))]
    public static class Global
    {
        public static void Init(TextScreenBase textScreen)
        {
            //Kernel.AConsole = new Medli.System.AConsole.VGA.VGAConsole(textScreen);
            Kernel.AConsole = new Medli.System.AConsole.VESAVBE.VESAVBEConsole();
            Cosmos.HAL.Global.Init(textScreen);
            Cosmos.System.Global.NumLock = false;
            Cosmos.System.Global.CapsLock = false;
            Cosmos.System.Global.ScrollLock = false;
            //Network.NetworkStack.Init();
        }
    }
}
