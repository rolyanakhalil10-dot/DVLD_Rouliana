using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsLoggerEventDAL
    {
        private static string _sourceName = "DVLDR";

        public static void LogEvent(string Message, EventLogEntryType entryType = EventLogEntryType.Error)
        {

            if (!EventLog.SourceExists(_sourceName))
            {
                EventLog.CreateEventSource(_sourceName, "Application");
            }

            EventLog.WriteEntry(_sourceName, Message, entryType);


        }

    }
}
