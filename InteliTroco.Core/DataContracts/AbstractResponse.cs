using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteliTroco.Core.DataContracts {
	public abstract class AbstractResponse {
		
		public AbstractResponse() {
			ReportList = new List<Report>();
		}

		public bool Success { get; set; }
		
		public List<Report> ReportList { get; set; }

	}
}
