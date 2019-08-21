/*
* PROJECT:          Aura Operating System Development
* CONTENT:          Get multiboot info structure
* PROGRAMMERS:      Valentin Charbonnier <valentinbreiz@gmail.com>
*/

using IL2CPU.API.Attribs;
using XSharp.Assembler;

namespace Medli.Core
{

    public class GetMBI : AssemblerMethod
    {
        public override void AssembleNew(Assembler aAssembler, object aMethodInfo)
        {
            new XSharp.Assembler.x86.Push { DestinationRef = ElementReference.New("MultiBootInfo_Structure"), DestinationIsIndirect = true };
        }

        [PlugMethod(Assembler = typeof(GetMBI))]
        public static uint GetMBIAddress() { return 0; }
    }

}
