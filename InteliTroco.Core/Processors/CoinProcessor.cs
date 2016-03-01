using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteliTroco.Core.Processors {
	class CoinProcessor : AbstractProcessor{

		public override Dictionary<int, long> Process(long amount) {

			IEnumerable<int> availableMonetaryUnitList = this.GetUnitList();

			Dictionary<int, long> result = new Dictionary<int, long>();
			foreach (int unit in availableMonetaryUnitList.OrderByDescending(we => we)) {

				long unitQuantity = amount / unit;

				if (unitQuantity <= 0) {
					continue;
				}

				result.Add(unit, unitQuantity);
				amount = amount - (unitQuantity * unit);
			}

			return result;
		}
	}
}
