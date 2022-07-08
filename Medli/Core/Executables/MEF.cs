using XSharp;
using IL2CPU.API.Attribs;
using XSharp.Assembler;

namespace Medli.Core.Executables
{
    public unsafe class MEF
    {
        public static uint ProgramAddress;

        public static void LoadProgram(byte[] code)
        {
            byte* data = (byte*)Cosmos.Core.Memory.Heap.Alloc((uint)code.Length);
            ProgramAddress = (uint)&data[0];
            for (int i = 0; i < code.Length; i++)
            {
                data[i] = code[i];
            }
            Caller call = new Caller();
            call.CallCode((uint)&data[0]);
        }

        public class Caller
        {
            [PlugMethod(Assembler = typeof(CallerPlug))]
            public void CallCode(uint address) { }
        }
        [Plug(Target = typeof(Caller))]
        public class CallerPlug : AssemblerMethod// : PlugMethod // : Method
        {
            public override void AssembleNew(Assembler aAssembler, object aMethodInfo)
            {//I asked jp2masa
                XS.Set(XSRegisters.EAX, XSRegisters.EBP, sourceDisplacement: 8);
                XS.Call(XSRegisters.EAX);
            }
        }
    }
}
