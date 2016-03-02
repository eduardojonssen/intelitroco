using InteliTroco.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Dlp.Framework;
using InteliTroco.Core.DataContracts;
using System.Threading;
using System.Globalization;

namespace InteliTroco {
	public partial class UxFrmInteliTroco : Form {
		public UxFrmInteliTroco() {
			InitializeComponent();

			//Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
			//Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
		}

		private void UxBtnCalculate_Click(object sender, EventArgs e) {
			UxTxtResult.Text = Calculate(UxTxtProductAmount.Text, UxTxtPaymentAmount.Text);
		}

		private string Calculate(string productAmount, string paymentAmount) {
			long longProductAmount = 0;
			long longPaymentAmount = 0;

			string errorMessage = string.Empty;

			if (long.TryParse(productAmount, out longProductAmount) == false) {
				errorMessage += "Product amount must be positive value in cents\r\n";
			}
			if (long.TryParse(paymentAmount, out longPaymentAmount) == false) {
				errorMessage += "Payment amount must be positive value in cents\r\n";
			}

			if (longPaymentAmount < longProductAmount) {
				errorMessage += "Payment amount can't be less than product amount\r\n";
			}

			//if (string.IsNullOrEmpty(errorMessage) == false) {
			//	return errorMessage;
			//}

			InteliTrocoManager manager = new InteliTrocoManager();

			CalculateRequest request = new CalculateRequest();

			request.PaymentAmount = longPaymentAmount;
			request.ProductAmount = longProductAmount;

			CalculateResponse result = manager.Calculate(request);

			StringBuilder resultString = new StringBuilder();

			if (result.Success == false) {
				resultString.AppendLine("Ocorreu um ou mais erros listados abaixo:");

				foreach (Report resultErrorMessage in result.ReportList) {
					resultString.AppendLine(string.Format("Campo: {0} [{1}] Mensagem: {2}", resultErrorMessage.Field, resultErrorMessage.Code, resultErrorMessage.Message));
				}

				return resultString.ToString();
			}

			resultString.AppendLine(string.Format("Valor total do troco: {0:0.00}", ((decimal)result.ChangeAmount / 100).ToString("C", new CultureInfo("pt-BR"))));

			foreach (KeyValuePair<string, Dictionary<int, long>> item in result.CoinDictionary) {

				foreach (KeyValuePair<int, long> coins in item.Value) {

					resultString.AppendLine(string.Format("{0}: {1}, Quantidade: {2}", item.Key, coins.Key, coins.Value));
				}

			}

			return resultString.ToString();
		}
	}
}

