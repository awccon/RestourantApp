﻿namespace RestaurantApp3
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
			this.receiveBtn = new System.Windows.Forms.Button();
			this.sendBtn = new System.Windows.Forms.Button();
			this.resutlListBox = new System.Windows.Forms.ListBox();
			this.serveBtn = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.chickentxt = new System.Windows.Forms.TextBox();
			this.eggtxt = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// receiveBtn
			// 
			this.receiveBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.receiveBtn.Location = new System.Drawing.Point(91, 208);
			this.receiveBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.receiveBtn.Name = "receiveBtn";
			this.receiveBtn.Size = new System.Drawing.Size(477, 61);
			this.receiveBtn.TabIndex = 0;
			this.receiveBtn.Text = "Submit customer orders";
			this.receiveBtn.UseVisualStyleBackColor = true;
			this.receiveBtn.Click += new System.EventHandler(this.receiveBtn_Click);
			// 
			// sendBtn
			// 
			this.sendBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.sendBtn.Location = new System.Drawing.Point(135, 328);
			this.sendBtn.Name = "sendBtn";
			this.sendBtn.Size = new System.Drawing.Size(477, 60);
			this.sendBtn.TabIndex = 1;
			this.sendBtn.Text = "Send to Cook";
			this.sendBtn.UseVisualStyleBackColor = true;
			this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
			// 
			// resutlListBox
			// 
			this.resutlListBox.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.resutlListBox.FormattingEnabled = true;
			this.resutlListBox.ItemHeight = 32;
			this.resutlListBox.Location = new System.Drawing.Point(22, 548);
			this.resutlListBox.Name = "resutlListBox";
			this.resutlListBox.Size = new System.Drawing.Size(713, 324);
			this.resutlListBox.TabIndex = 2;
			// 
			// serveBtn
			// 
			this.serveBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.serveBtn.Location = new System.Drawing.Point(135, 422);
			this.serveBtn.Name = "serveBtn";
			this.serveBtn.Size = new System.Drawing.Size(477, 60);
			this.serveBtn.TabIndex = 3;
			this.serveBtn.Text = "Serve the customers";
			this.serveBtn.UseVisualStyleBackColor = true;
			this.serveBtn.Click += new System.EventHandler(this.serveBtn_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(446, 76);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(198, 40);
			this.comboBox1.TabIndex = 4;
			// 
			// chickentxt
			// 
			this.chickentxt.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.chickentxt.Location = new System.Drawing.Point(154, 46);
			this.chickentxt.Name = "chickentxt";
			this.chickentxt.Size = new System.Drawing.Size(44, 39);
			this.chickentxt.TabIndex = 5;
			// 
			// eggtxt
			// 
			this.eggtxt.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.eggtxt.Location = new System.Drawing.Point(154, 118);
			this.eggtxt.Name = "eggtxt";
			this.eggtxt.Size = new System.Drawing.Size(44, 39);
			this.eggtxt.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label1.Location = new System.Drawing.Point(44, 49);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(106, 32);
			this.label1.TabIndex = 7;
			this.label1.Text = "Chicken:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label2.Location = new System.Drawing.Point(91, 121);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 32);
			this.label2.TabIndex = 8;
			this.label2.Text = "Egg:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.receiveBtn);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.chickentxt);
			this.groupBox1.Controls.Add(this.eggtxt);
			this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.groupBox1.Location = new System.Drawing.Point(44, 25);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(677, 286);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Menu Items";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(352, 79);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(89, 32);
			this.label3.TabIndex = 9;
			this.label3.Text = "Drinks:";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(757, 893);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.serveBtn);
			this.Controls.Add(this.resutlListBox);
			this.Controls.Add(this.sendBtn);
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "Form1";
			this.Text = "Form1";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private Button receiveBtn;
		private Button sendBtn;
		private ListBox resutlListBox;
		private Button serveBtn;
		private ComboBox comboBox1;
		private TextBox chickentxt;
		private TextBox eggtxt;
		private Label label1;
		private Label label2;
		private GroupBox groupBox1;
		private Label label3;
	}
}