namespace RestaurantApp4
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtChickenCount = new System.Windows.Forms.TextBox();
			this.txtEggCount = new System.Windows.Forms.TextBox();
			this.txtClientName = new System.Windows.Forms.TextBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 28;
			this.listBox1.Location = new System.Drawing.Point(13, 531);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(838, 340);
			this.listBox1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(228, 164);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(319, 38);
			this.button1.TabIndex = 1;
			this.button1.Text = "Receive this request from: ";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(210, 280);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(403, 38);
			this.button2.TabIndex = 2;
			this.button2.Text = "Send all Customer requests to the Cook";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(210, 400);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(403, 38);
			this.button3.TabIndex = 3;
			this.button3.Text = "Serve prepared food to the Customers";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Controls.Add(this.txtClientName);
			this.groupBox1.Controls.Add(this.txtEggCount);
			this.groupBox1.Controls.Add(this.txtChickenCount);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Location = new System.Drawing.Point(36, 26);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(801, 222);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Menu";
			// 
			// txtChickenCount
			// 
			this.txtChickenCount.Location = new System.Drawing.Point(257, 30);
			this.txtChickenCount.Name = "txtChickenCount";
			this.txtChickenCount.Size = new System.Drawing.Size(47, 34);
			this.txtChickenCount.TabIndex = 2;
			// 
			// txtEggCount
			// 
			this.txtEggCount.Location = new System.Drawing.Point(257, 88);
			this.txtEggCount.Name = "txtEggCount";
			this.txtEggCount.Size = new System.Drawing.Size(47, 34);
			this.txtEggCount.TabIndex = 3;
			// 
			// txtClientName
			// 
			this.txtClientName.Location = new System.Drawing.Point(576, 164);
			this.txtClientName.Name = "txtClientName";
			this.txtClientName.Size = new System.Drawing.Size(182, 34);
			this.txtClientName.TabIndex = 4;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(576, 47);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(182, 36);
			this.comboBox1.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(45, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(194, 28);
			this.label1.TabIndex = 6;
			this.label1.Text = "How many chicken?";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(45, 86);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(160, 28);
			this.label2.TabIndex = 7;
			this.label2.Text = "How many egg?";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(865, 876);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.listBox1);
			this.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.Name = "Form1";
			this.Text = "Form1";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private ListBox listBox1;
		private Button button1;
		private Button button2;
		private Button button3;
		private GroupBox groupBox1;
		private ComboBox comboBox1;
		private TextBox txtClientName;
		private TextBox txtEggCount;
		private TextBox txtChickenCount;
		private Label label2;
		private Label label1;
	}
}