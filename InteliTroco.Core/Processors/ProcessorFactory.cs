using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteliTroco.Core.Processors {
	public static class ProcessorFactory {

		public static AbstractProcessor Create(string processorName) {

			AbstractProcessor[] processorList = {
				new BillProcessor(),
				new CoinProcessor(),
				new SilverProcessor(),
				new CandyProcessor()
				//Adicione novos processadores acima desta linha
			};

			return processorList.FirstOrDefault(x => x.GetName().ToLower().StartsWith(processorName));

		}

	}
}
