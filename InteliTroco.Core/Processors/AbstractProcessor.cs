using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteliTroco.Core.Processors {

	public abstract class AbstractProcessor {

		public virtual IEnumerable<int> GetUnitList() {

			string key = "mu." + this.GetName().Replace("Processor", string.Empty).ToLower();
			string[] availableUnitList = ConfigurationManager.AppSettings[key].Split(',');

			foreach (string unit in availableUnitList) {
				yield return int.Parse(unit);
			}

		}

		public abstract Dictionary<int, long> Process(long amount);

		public virtual string GetName() {
			return this.GetType().Name;
		}

	}
}
