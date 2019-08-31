using System;
using System.Collections.Generic;
using System.Text;
using Medli.Common;

namespace Medli.System.SystemDevices
{
    public class ServiceLogging
    {
        public static string PrintLog(Service srv)
        {
            return srv.ServiceLogger.log.stream;
        }
    }
}
