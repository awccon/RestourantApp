namespace RestaurantApp2
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.submitBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.drinksComBox = new System.Windows.Forms.ComboBox();
            this.textBoxEgg = new System.Windows.Forms.TextBox();
            this.textBoxChicken = new System.Windows.Forms.TextBox();
            this.resultsListBox = new System.Windows.Forms.ListBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.eggQualityLb = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.submitBtn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.drinksComBox);
            this.groupBox1.Controls.Add(this.textBoxEgg);
            this.groupBox1.Controls.Add(this.textBoxChicken);
            this.groupBox1.Location = new System.Drawing.Point(39, 39);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(679, 211);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menu";
            // 
            // submitBtn
            // 
            this.submitBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.submitBtn.Location = new System.Drawing.Point(150, 150);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(404, 45);
            this.submitBtn.TabIndex = 7;
            this.submitBtn.Text = "Receive this request from a Customer";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "How many egg?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "How many chicken?";
            // 
            // drinksComBox
            // 
            this.drinksComBox.FormattingEnabled = true;
            this.drinksComBox.Location = new System.Drawing.Point(448, 68);
            this.drinksComBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.drinksComBox.Name = "drinksComBox";
            this.drinksComBox.Size = new System.Drawing.Size(188, 28);
            this.drinksComBox.TabIndex = 4;
            // 
            // textBoxEgg
            // 
            this.textBoxEgg.Location = new System.Drawing.Point(297, 91);
            this.textBoxEgg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxEgg.Name = "textBoxEgg";
            this.textBoxEgg.Size = new System.Drawing.Size(31, 27);
            this.textBoxEgg.TabIndex = 1;
            // 
            // textBoxChicken
            // 
            this.textBoxChicken.Location = new System.Drawing.Point(297, 46);
            this.textBoxChicken.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxChicken.Name = "textBoxChicken";
            this.textBoxChicken.Size = new System.Drawing.Size(31, 27);
            this.textBoxChicken.TabIndex = 0;
            // 
            // resultsListBox
            // 
            this.resultsListBox.FormattingEnabled = true;
            this.resultsListBox.ItemHeight = 20;
            this.resultsListBox.Location = new System.Drawing.Point(39, 488);
            this.resultsListBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.resultsListBox.Name = "resultsListBox";
            this.resultsListBox.Size = new System.Drawing.Size(679, 264);
            this.resultsListBox.TabIndex = 1;
            // 
            // sendBtn
            // 
            this.sendBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sendBtn.Location = new System.Drawing.Point(189, 270);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(404, 45);
            this.sendBtn.TabIndex = 8;
            this.sendBtn.Text = "Send all Customer requests to the Cook";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(189, 403);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(404, 45);
            this.button3.TabIndex = 9;
            this.button3.Text = "Serve prepared food to the Customers";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.serveBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 346);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Egg Quality:";
            // 
            // eggQualityLb
            // 
            this.eggQualityLb.AutoSize = true;
            this.eggQualityLb.Location = new System.Drawing.Point(197, 346);
            this.eggQualityLb.Name = "eggQualityLb";
            this.eggQualityLb.Size = new System.Drawing.Size(33, 20);
            this.eggQualityLb.TabIndex = 11;
            this.eggQualityLb.Text = "100";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 454);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Results";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 795);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.eggQualityLb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.resultsListBox);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private ListBox resultsListBox;
        private Label label2;
        private Label label1;
        private ComboBox drinksComBox;
        private TextBox textBoxEgg;
        private TextBox textBoxChicken;
        private Button submitBtn;
        private Button sendBtn;
        private Button button3;
        private Label label3;
        private Label eggQualityLb;
        private Label label5;
    }
}