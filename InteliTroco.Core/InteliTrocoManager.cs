using InteliTroco.Core.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InteliTroco.Core.Processors;
using InteliTroco.Core.Logger;
using Dlp.Framework.Container;
using InteliTroco.Core.Interceptors;
using System.Configuration;

namespace InteliTroco.Core {
	public class InteliTrocoManager {

		/// <summary>
		/// Base constructor.
		/// </summary>
		public InteliTrocoManager() {

			IocFactory.Register(
				Component.For<ILogger>().Interceptor<LogInterceptor>().
					ImplementedBy<FileLogger>("file").IsSingleton().
					ImplementedBy<EventViewerLogger>("event").IsSingleton()

				//Component.FromThisAssembly("InteliTroco.Core.Logger").IsSingleton<EventViewerLogger>()
				);
		}

		public CalculateResponse Calculate(CalculateRequest request) {

			CalculateResponse calculateResponse = new CalculateResponse();

			Log.Save(LevelType.info, CategoryType.request, request);

			try {
				// Verifica se todos os parâmetros recebidos são válidos.
				if (request.IsValid == false) {
					calculateResponse.ReportList = request.ValidationReportList;
					//goto Exit;
					return calculateResponse;
				}

				long changeAmount = request.PaymentAmount - request.ProductAmount;
				Dictionary<string, Dictionary<int, long>> monetaryUnities = CountMonetaryUnities(changeAmount);

				long actualChangeAmount = monetaryUnities.Sum(n => n.Value.Sum(x => x.Key * x.Value));
				long remainingChangeAmount = changeAmount - actualChangeAmount;

				if (remainingChangeAmount > 0) {
					calculateResponse.Success = false;
					calculateResponse.ReportList.Add(new Report { Code = -300, Message = "O troco não pode ser calculado, pois não há unidades monetárias disponíveis." });
				}
				else {
					calculateResponse.Success = true;
					calculateResponse.ChangeAmount = changeAmount;
					calculateResponse.CoinDictionary = monetaryUnities;
				}
			}
			catch (Exception ex) {
				calculateResponse.Success = false;
				calculateResponse.ReportList.Add(new Report { Code = -500, Message = "O troco não pode ser calculado, tente de novo" });
				Log.Save(LevelType.error, CategoryType.exception, ex.ToString());
			}
			finally {
				//Exit:
				Log.Save(LevelType.info, CategoryType.response, calculateResponse);
			}

			return calculateResponse;
		}

		public Dictionary<string, Dictionary<int, long>> CountMonetaryUnities(long amount) {

			Dictionary<string, Dictionary<int, long>> result = new Dictionary<string, Dictionary<int, long>>();
			ConfigurationUtility configurationUtility = new ConfigurationUtility();

			string[] priorityList = configurationUtility.MonetaryPriorityList;

			foreach (string priorityItem in priorityList) {

				AbstractProcessor processor = ProcessorFactory.Create(priorityItem);

				if (processor == null) {
					//Fazer alguma coisa
					break;
				}

				Dictionary<int, long> processResult = processor.Process(amount);
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