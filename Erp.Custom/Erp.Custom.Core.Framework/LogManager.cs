using System;
using System.Diagnostics;

namespace Erp.Custom.Core.Framework
{
    public static class LogManager
    {
        private static readonly string logname = "GOSHU Epicor external application log.";

        public static void WriteEntry(Exception er)
        {
            if (!EventLog.SourceExists(logname))
            {
                EventLog.CreateEventSource(logname, logname);
            }

            EventLog.WriteEntry(logname,
                                er.Message + Environment.NewLine
                                + "------------------------------------------------------------" + Environment.NewLine
                                + er.StackTrace,
                                System.Diagnostics.EventLogEntryType.Error);
        }
    }
}
