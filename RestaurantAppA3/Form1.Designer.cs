﻿namespace RestaurantAppA3
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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(453, 57);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(156, 34);
			this.button1.TabIndex = 0;
			this.button1.Text = "SubmitOrder";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(205, 118);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(156, 34);
			this.button2.TabIndex = 1;
			this.button2.Text = "SendToCook";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(110, 31);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(42, 31);
			this.textBox1.TabIndex = 2;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(110, 83);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(42, 31);
			this.textBox2.TabIndex = 3;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(453, 119);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(156, 34);
			this.button3.TabIndex = 4;
			this.button3.Text = "PrepairFood";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(30, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 25);
			this.label1.TabIndex = 5;
			this.label1.Text = "Chicken";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(39, 81);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 25);
			this.label2.TabIndex = 6;
			this.label2.Text = "Egg";
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 25;
			this.listBox1.Location = new System.Drawing.Point(90, 159);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(623, 154);
			this.listBox1.TabIndex = 7;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(205, 59);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(182, 33);
			this.comboBox1.TabIndex = 8;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(804, 367);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Button button1;
		private Button button2;
		private TextBox textBox1;
		private TextBox textBox2;
		private Button button3;
		private Label label1;
		private Label label2;
		private ListBox listBox1;
		private ComboBox comboBox1;
	}
}