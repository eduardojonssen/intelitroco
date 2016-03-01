using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteliTroco.Core.DataContracts {
	public sealed class CalculateRequest : AbstractRequest {

		public CalculateRequest() { }

		public long ProductAmount { get; set; }

		public long PaymentAmount { get; set; }

		protected override void Validate() {

			if (this.ProductAmount < 0) {
				this.AddError(-1, "ProductAmount", "Product amount must be positive integer");
			}

			if (this.PaymentAmount < 0) {
				this.AddError(-2, "PaymentAmount", "Payment amount must be positive integer");
			}

			if (this.PaymentAmount < this.ProductAmount) {
				this.AddError(-3, "PaymentAmount", "Payment amount cannot be less than product amount");
			}
		}
	}
}
