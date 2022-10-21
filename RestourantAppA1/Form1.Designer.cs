namespace RestourantAppA1
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.resultBox = new System.Windows.Forms.ListBox();
			this.submitOrder = new System.Windows.Forms.Button();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ChickenRadio = new System.Windows.Forms.RadioButton();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.quantityOfOrder = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.eggQualityResult = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// resultBox
			// 
			this.resultBox.FormattingEnabled = true;
			this.resultBox.ItemHeight = 15;
			this.resultBox.Location = new System.Drawing.Point(12, 248);
			this.resultBox.Name = "resultBox";
			this.resultBox.Size = new System.Drawing.Size(421, 184);
			this.resultBox.TabIndex = 0;
			// 
			// submitOrder
			// 
			this.submitOrder.Location = new System.Drawing.Point(228, 62);
			this.submitOrder.Name = "submitOrder";
			this.submitOrder.Size = new System.Drawing.Size(205, 23);
			this.submitOrder.TabIndex = 1;
			this.submitOrder.Text = "Submit new order";
			this.submitOrder.UseVisualStyleBackColor = true;
			this.submitOrder.Click += new System.EventHandler(this.SubmitOrder_Click);
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(6, 32);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(45, 19);
			this.radioButton1.TabIndex = 2;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Egg";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ChickenRadio);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(93, 87);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "MenuItem";
			// 
			// ChickenRadio
			// 
			this.ChickenRadio.AutoSize = true;
			this.ChickenRadio.Location = new System.Drawing.Point(6, 57);
			this.ChickenRadio.Name = "ChickenRadio";
			this.ChickenRadio.Size = new System.Drawing.Size(68, 19);
			this.ChickenRadio.TabIndex = 3;
			this.ChickenRadio.Text = "Chicken";
			this.ChickenRadio.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(78, 123);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(278, 25);
			this.button1.TabIndex = 7;
			this.button1.Text = "CopyPreviousOrder";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.CopyPreviousOrder_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(78, 207);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(278, 25);
			this.button2.TabIndex = 8;
			this.button2.Text = "PrepareFood";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.PrepareFood_Click);
			// 
			// quantityOfOrder
			// 
			this.quantityOfOrder.Location = new System.Drawing.Point(111, 63);
			this.quantityOfOrder.Name = "quantityOfOrder";
			this.quantityOfOrder.Size = new System.Drawing.Size(100, 23);
			this.quantityOfOrder.TabIndex = 9;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(111, 44);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 15);
			this.label1.TabIndex = 10;
			this.label1.Text = "QuantityOfOrder";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(18, 169);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(81, 15);
			this.label2.TabIndex = 11;
			this.label2.Text = "QualityOfEgg:";
			// 
			// eggQualityResult
			// 
			this.eggQualityResult.AutoSize = true;
			this.eggQualityResult.Location = new System.Drawing.Point(105, 169);
			this.eggQualityResult.Name = "eggQualityResult";
			this.eggQualityResult.Size = new System.Drawing.Size(19, 15);
			this.eggQualityResult.TabIndex = 12;
			this.eggQualityResult.Text = "65";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(445, 443);
			this.Controls.Add(this.eggQualityResult);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.quantityOfOrder);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.submitOrder);
			this.Controls.Add(this.resultBox);
			this.Name = "Form1";
			this.Text = "Form1";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ListBox resultBox;
		private Button submitOrder;
		private RadioButton radioButton1;
		private GroupBox groupBox1;
		private RadioButton ChickenRadio;
		private Button button1;
		private Button button2;
		private TextBox quantityOfOrder;
		private Label label1;
		private Label label2;
		private Label eggQualityResult;
	}
}