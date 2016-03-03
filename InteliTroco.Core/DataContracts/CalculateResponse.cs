using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteliTroco.Core.DataContracts {
	public class CalculateResponse : AbstractResponse {

		public CalculateResponse()
			: base() {

		}

		public Dictionary<string, Dictionary<int, long>> CoinDictionary { get; set; }

		public Nullable<long> ChangeAmount { get; set; }

	}
}
