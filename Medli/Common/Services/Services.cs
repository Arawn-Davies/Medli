using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Medli.Common
{
    public class Service
    {
		public Service()
		{
			ServicePath = Paths.SystemData + Path.DirectorySeparatorChar + ServiceName.ToLower() + Path.DirectorySeparatorChar + "log.sys";
			ServiceLogger = new LoggingService(ServicePath);
		}

		public string ServicePath;

		public LoggingService ServiceLogger;
		public virtual bool Init()
		{
			ServiceLogger.Init();
			ServiceLogger.Record("Service logger created!");
			return true;
		}
		public string ServiceName;
		public AccessPriority Priority;

		public bool Active;
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
