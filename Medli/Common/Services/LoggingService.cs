using System;
using System.Collections.Generic;
using System.Text;
using Medli.System;
using System.IO;

namespace Medli.Common
{
    public class LoggingService
    {
		public string LogFile;
		public readonly TextLog log = new TextLog();

		public bool Init()
		{
			if (!File.Exists(LogFile))
			{
				File.Create(LogFile);
			}
			return true;
		}

		public void Record(string logtext)
		{
			string datetime = SysClock.Month() + ":" + SysClock.DayOfTheMonth() + ":" + SysClock.Hour() + ":" + SysClock.Minute() + ":" + SysClock.Second();
			log.Write(datetime + "\t" + logtext);
		}

		public void Save()
		{
			File.WriteAllText(LogFile, log.stream);
		}

		public LoggingService(string logpath)
		{
			LogFile = logpath;
			Init();
		}
	}
}
