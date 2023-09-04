/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2019, Siaranite Solutions
Copyright (c) 2019, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIC.Main
{
    public static partial class AConsole
    {
        public class ProgressBar
        {
            /// <summary>
            /// CursorTop
            /// </summary>
            int CT = AConsole.CursorTop;

            /// <summary>
            /// CursorLeft
            /// </summary>
            int CL = AConsole.CursorLeft;

            /// <summary>
            /// The value of the progress bar
            /// </summary>
            private int value = 0;

            /// <summary>
            /// 
            /// </summary>
            public int Value
            {
                get { return value; }
                set
                {
                    if (value >= 0 && value <= 20)
                    {
                        this.value = value;
                    }
                }
            }

            /// <summary>
            /// Initialize a new ProgressBar
            /// </summary>
            /// <param name="startValue">Value</param>
            /// <param name="Flicker">true = Very cool effect =)</param>
            public ProgressBar(int startValue)
            {
                Value = startValue;
                Refresh();
            }

            /// <summary>
            /// Increment the status of the progress bar
            /// </summary>
            public void Increment()
            {
                Value++;
                //Refresh();
            }

            /// <summary>
            /// Decrement the status of the progress bar
            /// </summary>
            public void Decrement()
            {
                Value--;
                Refresh();
            }

            /// <summary>
            /// INFO: MaxValue is 100 and MinValue is 0.
            /// </summary>
            public void Draw()
            {
                AConsole.WriteLine();
                string buffer = "[          ]";
                AConsole.Write(buffer);
                AConsole.CursorLeft = CL + 1;

                string __buffer = "";

                for (int i = 0; i < this.value; i++)
                {
                    __buffer += "=";
                }

                AConsole.Write(__buffer);

                AConsole.CursorLeft = CL + 14;
                AConsole.Write(this.value.ToString() + "0%");
                AConsole.CursorTop = CT;
                AConsole.CursorLeft = CL;
            }

            private void Refresh()
            {
                this.Draw();
            }
        }
    }
}
