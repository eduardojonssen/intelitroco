using Dlp.Framework.Container;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteliTroco.Core.Logger {
	public static class Log {

		private static string LoggerType {
			get {
				return ConfigurationManager.AppSettings["logDefault"];
			}
		}

		private static string LoggerValue {
			get {
				return ConfigurationManager.AppSettings[LoggerType];
			}
		}

		internal static void Save(LevelType levelType, CategoryType categoryType, object data) {

			ILogger logger = IocFactory.ResolveByName<ILogger>(LoggerType, LoggerValue ?? string.Empty);
						
			logger.Log(levelType, categoryType, data);
		}

	}
}
