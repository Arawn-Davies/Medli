using IL2CPU.API.Attribs;
using XSharp.Assembler;
using XSharp;

namespace Medli.Core.Executables
{
    public unsafe class COM
    {
        private byte[] code;
        public COM(string file)
        {
            code = System.FS.ReadContents(file);
        }
        public COM(byte[] file)
        {
            code = file;
        }
        public void Execute()
        {
            /* This might be overwritting something, but since we do not have paging working
             * there is really no 'better' alternative. I have test this though and I have
             * not noticed any bad side effects so I will assume this is somewhat safe...
             */
            byte* ptr = (byte*)0x100;
            for (int i = 0; i < code.Length; i++)
            {
                ptr[i] = code[i];
            }
            Caller c = new Caller();
            c.CallCode(0x100); // Jump!!!!!
        }
    }
    // G-DOS license ends here........
    // This is by Aurora01, a better alternative than the hacks that Grunty OS uses
    // I could have just wrote this by my self, but I was to lazy......
    // NoobBinaryLoader. (C) NoobOS 2013. Licensed under the GNU GPL where applicable.
    public class Caller
    {
        [PlugMethod(Assembler = typeof(CallerPlug))]
        public void CallCode(uint address) { }
    }
    [Plug(Target = typeof(Caller))]
    public class CallerPlug : AssemblerMethod
    {
        public override void AssembleNew(Assembler aAssembler, object aMethodInfo)
        {
            new XSharp.Assembler.x86.Mov{ SourceReg = XSRegisters.EBP, SourceDisplacement = 8, SourceIsIndirect = true, DestinationReg = XSRegisters.EAX };
            new XSharp.Assembler.x86.Call{ DestinationReg = XSRegisters.EAX };
        }
    }
}
