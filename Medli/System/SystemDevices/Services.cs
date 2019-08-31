using System;
using System.Collections.Generic;
using System.Text;
using Medli.Common;

namespace Medli.System
{
    public class ServiceLogging
    {
        public static string PrintLog(LoggingService srv)
        {
            return srv.Log.stream;
        }
    }
}
