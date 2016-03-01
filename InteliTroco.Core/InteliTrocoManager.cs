using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteliTroco.Core {
	public class InteliTrocoManager {

		/// <summary>
		/// Base constructor.
		/// </summary>
		public InteliTrocoManager() {
		}

		public CalculateResponse Calculate(CalculateRequest request) {
			CalculateResponse calculateResponse = new CalculateResponse();
			try {
				// Verifica se todos os parâmetros recebidos são válidos.
				if (request.IsValid == false) {
					calculateResponse.ReportList = request.ValidationReportList;
					return calculateResponse;
				}

				calculateResponse.ChangeAmount = request.PaymentAmount - request.ProductAmount;
				calculateResponse.CoinDictionary = CountCoins(calculateResponse.ChangeAmount);
				calculateResponse.Success = true;

			}
			catch (Exception ex) {
				calculateResponse.ReportList.Add(new Report { Code = -500, Message = "O troco não pode ser calculado, tente de novo" });
			}
			return calculateResponse;
		}

		public Dictionary<string,Dictionary<int,long>> CountCoins(long amount) {

			Dictionary<string, Dictionary<int, long>> result = new Dictionary<string, Dictionary<int, long>>();
			ConfigurationUtility configurationUtility = new ConfigurationUtility();
			List<MonetaryUnit> availableMonetaryUnitList = configurationUtility.AvailableMonetaryUnitList;

			string[] priorityList = configurationUtility.MonetaryPriorityList;

			foreach (string priorityItem in priorityList) {

				Dictionary<int, long> monetaryUnities = new Dictionary<int, long>();
				foreach (MonetaryUnit monetaryUnit in configurationUtility.AvailableMonetaryUnitList.Where(x => x.Type == priorityItem).OrderByDescending(we => we.AmountInCents)) {					

					long coinQuantity = amount / monetaryUnit.AmountInCents;

					if (coinQuantity <= 0) {
						continue;
					}

					monetaryUnities.Add(monetaryUnit.AmountInCents,coinQuantity);
					amount = amount - (coinQuantity * monetaryUnit.AmountInCents);
				}

				result.Add(priorityItem, monetaryUnities);
			}

			return result;
		}

	}
}