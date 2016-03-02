using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using Dlp.Framework;

namespace InteliTroco.Core.Logger {			

	class Logger : ILogger{

		public string LogFilePath { get; set; }

		public Logger( string logFilePath ) {
			this.LogFilePath = logFilePath;
		}

		public void Log( LevelType level, CategoryType category, object data ) {

			string logDirectory = Path.GetDirectoryName(this.LogFilePath);

			if (Directory.Exists(logDirectory) == false) {
				Directory.CreateDirectory(logDirectory);
			}

			using (FileStream fs = new FileStream(LogFilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)) {
				using (StreamWriter sw = new StreamWriter(fs)) {
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.AppendFormat("{0} Level:{1} Application:[{2}] Category:{3} {4}", DateTime.UtcNow, level, Assembly.GetEntryAssembly().GetName().Name, category, Serializer.JsonSerialize(data));
					sw.WriteLine(stringBuilder.ToString());
				}
			}

		}

	}
}
