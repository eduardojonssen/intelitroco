using InteliTroco.Core.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InteliTroco.Core.Processors;

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

			string[] priorityList = configurationUtility.MonetaryPriorityList;

			foreach (string priorityItem in priorityList) {

				AbstractProcessor processor = ProcessorFactory.Create(priorityItem);

				if (processor == null) {
					//Fazer alguma coisa
					break;
				}

				Dictionary<int,long> processResult = processor.Process(amount);
				result.Add(priorityItem, processResult);

				amount -= processResult.Sum(n => n.Key * n.Value);

				if (amount <= 0) {
					break;
				}

			}

			return result;
		}

	}
}