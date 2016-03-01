using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace InteliTroco.Core {
	class ConfigurationUtility {
		public List<int> AvailableCoinList { get {

				List<int> availableCoinList = new List<int>();								
				string[] availableCoinArray = ConfigurationManager.AppSettings["AvailableCoinList"].Split(',');
				foreach (string coin in availableCoinArray) {
					availableCoinList.Add(int.Parse(coin));
				}
				return availableCoinList;
		} }

		public List<MonetaryUnit> AvailableMonetaryUnitList {
			get {

				List<MonetaryUnit> monetaryUnitList = new List<MonetaryUnit>();

				string[] keys = ConfigurationManager.AppSettings.AllKeys;
				foreach (string key in keys.Where(p => p.StartsWith("mu."))) {

					string[] availableMonetaryArray = ConfigurationManager.AppSettings[key].Split(',');
					
					foreach (string monetaryValue in availableMonetaryArray) {
						MonetaryUnit monetaryUnit = new MonetaryUnit { 
							AmountInCents = int.Parse(monetaryValue),
							Type = key							
						};
						monetaryUnitList.Add(monetaryUnit);
					}
				}

				return monetaryUnitList;
			}
		}

		public string[] MonetaryPriorityList { 
			get 
			{
				return ConfigurationManager.AppSettings["monetaryPriority"].Split(',');
			} 
		}
	}
}
