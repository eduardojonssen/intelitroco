namespace InteliTroco {
	partial class UxFrmInteliTroco {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.UxTxtPaymentAmount = new System.Windows.Forms.NumericUpDown();
			this.UxTxtProductAmount = new System.Windows.Forms.NumericUpDown();
			this.UxBtnCalculate = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.UxTxtResult = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.UxTxtPaymentAmount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.UxTxtProductAmount)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.UxTxtPaymentAmount);
			this.groupBox1.Controls.Add(this.UxTxtProductAmount);
			this.groupBox1.Controls.Add(this.UxBtnCalculate);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(351, 200);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			// 
			// UxTxtPaymentAmount
			// 
			this.UxTxtPaymentAmount.Location = new System.Drawing.Point(167, 86);
			this.UxTxtPaymentAmount.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
			this.UxTxtPaymentAmount.Name = "UxTxtPaymentAmount";
			this.UxTxtPaymentAmount.Size = new System.Drawing.Size(153, 26);
			this.UxTxtPaymentAmount.TabIndex = 2;
			// 
			// UxTxtProductAmount
			// 
			this.UxTxtProductAmount.Location = new System.Drawing.Point(167, 41);
			this.UxTxtProductAmount.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
			this.UxTxtProductAmount.Name = "UxTxtProductAmount";
			this.UxTxtProductAmount.Size = new System.Drawing.Size(153, 26);
			this.UxTxtProductAmount.TabIndex = 1;
			// 
			// UxBtnCalculate
			// 
			this.UxBtnCalculate.Location = new System.Drawing.Point(167, 133);
			this.UxBtnCalculate.Name = "UxBtnCalculate";
			this.UxBtnCalculate.Size = new System.Drawing.Size(153, 38);
			this.UxBtnCalculate.TabIndex = 3;
			this.UxBtnCalculate.Text = "Calcular";
			this.UxBtnCalculate.UseVisualStyleBackColor = true;
			this.UxBtnCalculate.Click += new System.EventHandler(this.UxBtnCalculate_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(4, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(157, 20);
			this.label2.TabIndex = 9;
			this.label2.Text = "Valor do pagamento:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(30, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(131, 20);
			this.label1.TabIndex = 7;
			this.label1.Text = "Valor do produto:";
			// 
			// UxTxtResult
			// 
			this.UxTxtResult.Location = new System.Drawing.Point(12, 218);
			this.UxTxtResult.Multiline = true;
			this.UxTxtResult.Name = "UxTxtResult";
			this.UxTxtResult.ReadOnly = true;
			this.UxTxtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.UxTxtResult.Size = new System.Drawing.Size(351, 223);
			this.UxTxtResult.TabIndex = 7;
			// 
			// UxFrmInteliTroco
			// 
			this.AcceptButton = this.UxBtnCalculate;
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(375, 453);
			this.Controls.Add(this.UxTxtResult);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "UxFrmInteliTroco";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "InteliTroco";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.UxTxtPaymentAmount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.UxTxtProductAmount)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button UxBtnCalculate;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox UxTxtResult;
		private System.Windows.Forms.NumericUpDown UxTxtPaymentAmount;
		private System.Windows.Forms.NumericUpDown UxTxtProductAmount;

	}
}

