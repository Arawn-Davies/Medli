using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.Common
{
    public class TextLog
    {
		public string stream;

		public TextLog()
		{

		}
		public void Write(string text)
		{
			this.stream += text + "\n";
		}
    }
}
