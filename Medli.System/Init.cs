using System;
using System.Collections.Generic;
using System.Text;
using Medli.Hardware;

namespace Medli.System
{
    public class SYSPBE
    {
		public static void Init()
		{
			HALPBE.Init();
		}
    }
}
