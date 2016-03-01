using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteliTroco.Core {

	public abstract class AbstractRequest {

		public AbstractRequest() {
			this._validationReportList = new List<Report>();
		}

		internal bool IsValid {
			get {
				this._validationReportList.Clear();
				this.Validate();
				return (this._validationReportList.Any() == false);
			}
		}

		private List<Report> _validationReportList;

		internal List<Report> ValidationReportList { get { return this._validationReportList.ToList(); } }

		protected void AddError(int code, string field, string message) {

			Report report = new Report();

			report.Code = code;
			report.Field = string.Format("{0}.{1}", this.GetType().Name, field);
			report.Message = message;

			this._validationReportList.Add(report);
		}

		protected abstract void Validate();
	}
}
