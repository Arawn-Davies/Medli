using System;
using System.Collections.Generic;
using System.Text;
using static Cosmos.Core.INTs;
using Medli.Common;
using Medli.Core.Executables;

namespace Medli.Common.Drivers
{
    public class SystemCalls : Driver
    {
        public override bool Init()
        {
            this.Name = "API";
            SetIntHandler(0x48, SWI); //ints.setinthandler
            return true;
        }

        public static int x = Console.CursorLeft;
        public static int y = Console.CursorTop;

        public unsafe static void SWI(ref IRQContext aContext)
        {
            if (aContext.Interrupt == 0x7F)
            {
                if (aContext.EAX == 0x01) //Print function.
                {
                    uint ptr = aContext.ESI;
                    byte* dat = (byte*)(ptr + MEF.ProgramAddress);
                    for (int i = 0; dat[i] != 0; i++)
                    {
                        if ((char)dat[i] == 0x0A)
                            Console.WriteLine("\n");
                        else
                            Console.Write((char)dat[i]);
                    }
                }
                else if (aContext.EAX == 0x02) //Readline function.
                {
                    uint ptr = aContext.ESI;
                    byte* dat = (byte*)(ptr + MEF.ProgramAddress);

                    string input = "";

                    for (int i = 0; dat[i] != 0; i++)
                    {
                        input = input + (char)dat[i];
                    }

                    Console.Write(input);
                    string output = Console.ReadLine();

                    uint ptr2 = aContext.EDI;
                    byte* dat2 = (byte*)(ptr2 + MEF.ProgramAddress);

                    List<byte> list = new List<byte>();

                    foreach (char charr in output)
                    {
                        list.Add(Utils.StringToByte(charr));
                    }

                    byte[] test = list.ToArray();

                    for (int i = 0; i < test.Length; i++)
                    {
                        dat2[i] = test[i];
                    }

                    aContext.EDI = (uint)dat2 - MEF.ProgramAddress;

                }
            }
        }
    }
}
