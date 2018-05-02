using System;
using System.Collections.Generic;
using System.Text;

namespace Medli.System
{
    public abstract class Service
    {
		public abstract bool Init();
		public string ServiceName;
		public AccessPriority Priority;
    }

	public enum AccessPriority
	{
		HIGH = 1,
		AMID = 2,
		MID = 3,
		LMID = 4,
		LOW = 5
	}
}
