using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteliTroco.Core.Processors {

	internal static class ProcessorFactory {

		//private static AbstractProcessor[] _processorList;
		//private static AbstractProcessor[] ProcessorList {
		//	get {
		//		if (_processorList == null) {
		//			AbstractProcessor[] pl = {
		//				new BillProcessor(),
		//				new CoinProcessor(),
		//				new CandyProcessor(),
		//				new SilverProcessor()
		//				//Adicione novos processadores acima desta linha.
		//			};
		//			_processorList = pl;
		//		}
		//		return _processorList;
		//	}
		//}

		private static Type[] _processorList;
		private static Type[] ProcessorList {
			get {
				if (_processorList == null) {
					Type[] pl = {
						typeof(BillProcessor),
						typeof(CoinProcessor),
						typeof(CandyProcessor),
						typeof(SilverProcessor)
						//Adicione novos processadores acima desta linha.
					};
					_processorList = pl;
				}
				return _processorList;
			}
		}
		
		internal static AbstractProcessor Create(string processorName) {
			//return ProcessorList.FirstOrDefault(x => x.GetName().ToLower().StartsWith(processorName));

			Type processorType = ProcessorList.FirstOrDefault(x => x.Name.ToLower().StartsWith(processorName));

			AbstractProcessor processor = Activator.CreateInstance(processorType) as AbstractProcessor;

			return processor;
		}
	}
}
