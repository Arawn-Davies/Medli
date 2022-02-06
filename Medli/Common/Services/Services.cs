using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Medli.Common
{
    /// <summary>
    /// class definition for kernel daemons
    /// </summary>
    public class Daemon
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Daemon"/> class.
        /// </summary>
        public Daemon()
		{
			ServicePath = Paths.SystemData + Path.DirectorySeparatorChar + ServiceName.ToLower() + Path.DirectorySeparatorChar + "log.sys";
			ServiceLogger = new LoggingService(ServicePath);
		}

        /// <summary>
        /// The service path
        /// </summary>
        public string ServicePath;

        /// <summary>
        /// The service logging tool
        /// </summary>
        public LoggingService ServiceLogger;

        /// <summary>
        /// Initializes this daemon.
        /// </summary>
        /// <returns></returns>
        public virtual bool Init()
		{
			ServiceLogger.Init();
			ServiceLogger.Record("Service logger created!");
			return true;
		}
        /// <summary>
        /// The name of the daemon running
        /// </summary>
        public string ServiceName;

        /// <summary>
        /// The priority of the daemon, whether some should be allocated more access and usage privileges over others
        /// </summary>
        public AccessPriority Priority;

        /// <summary>
        /// Boolean for the daemon activity status
        /// </summary>
        public bool Active;
    }

    /// <summary>
    /// Class definition for access priorities, etc. core system daemons would have higher priority than others
    /// </summary>
    public enum AccessPriority
	{
        /// <summary>
        /// The highest level
        /// </summary>
        HIGH = 1,
        /// <summary>
        /// The medium level
        /// </summary>
        MID = 3,
        /// <summary>
        /// The lowest level
        /// </summary>
        LOW = 5
	}
}
