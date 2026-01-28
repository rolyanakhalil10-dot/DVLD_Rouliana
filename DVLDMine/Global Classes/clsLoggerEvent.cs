using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DVLDMine
{
    public class clsLoggerEvent
    {
        private static string _sourceName = "DVLDMine";

        public static void LogEvent(string Message, EventLogEntryType entryType = EventLogEntryType.Error)
        {

           if(!EventLog.SourceExists(_sourceName))
           {
                EventLog.CreateEventSource(_sourceName, "Application");
           }

            EventLog.WriteEntry(_sourceName, Message, entryType);


        }

    }
}
