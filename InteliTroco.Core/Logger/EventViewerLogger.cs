using Dlp.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InteliTroco.Core.Logger {
	class EventViewerLogger : ILogger {

		public void Log(LevelType level, CategoryType category, object data) {
			using (EventLog eventLog = new EventLog("Application")) {
				eventLog.Source = Assembly.GetEntryAssembly().GetName().Name;
				eventLog.WriteEntry(category + " " + Serializer.JsonSerialize(data), GetEventLogEntryType(level));
			}
		}

		private EventLogEntryType GetEventLogEntryType(LevelType level){
			switch (level) {
				case LevelType.info:
					return EventLogEntryType.Information;
				case LevelType.error:
					return EventLogEntryType.Error;
				case LevelType.debug:
					return EventLogEntryType.SuccessAudit;
				case LevelType.warn:
					return EventLogEntryType.Warning;	
				default:
					return EventLogEntryType.Information;
			}
			
		}
	}
}
