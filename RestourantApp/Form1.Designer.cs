namespace RestourantApp
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
            this.submitButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioEgg = new System.Windows.Forms.RadioButton();
            this.radioChicken = new System.Windows.Forms.RadioButton();
            this.textQuantity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.copyButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEggQuality = new System.Windows.Forms.Label();
            this.prepareButton = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.submitButton.Location = new System.Drawing.Point(324, 190);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(307, 42);
            this.submitButton.TabIndex = 2;
            this.submitButton.Text = "Submit new request";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioEgg);
            this.groupBox1.Controls.Add(this.radioChicken);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(49, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 112);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menu";
            // 
            // radioEgg
            // 
            this.radioEgg.AutoSize = true;
            this.radioEgg.Location = new System.Drawing.Point(180, 45);
            this.radioEgg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioEgg.Name = "radioEgg";
            this.radioEgg.Size = new System.Drawing.Size(75, 34);
            this.radioEgg.TabIndex = 13;
            this.radioEgg.Text = "Egg";
            this.radioEgg.UseVisualStyleBackColor = true;
            // 
            // radioChicken
            // 
            this.radioChicken.AutoSize = true;
            this.radioChicken.Checked = true;
            this.radioChicken.Location = new System.Drawing.Point(13, 45);
            this.radioChicken.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioChicken.Name = "radioChicken";
            this.radioChicken.Size = new System.Drawing.Size(114, 34);
            this.radioChicken.TabIndex = 12;
            this.radioChicken.TabStop = true;
            this.radioChicken.Text = "Chicken";
            this.radioChicken.UseVisualStyleBackColor = true;
            // 
            // textQuantity
            // 
            this.textQuantity.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textQuantity.Location = new System.Drawing.Point(159, 193);
            this.textQuantity.Name = "textQuantity";
            this.textQuantity.Size = new System.Drawing.Size(144, 37);
            this.textQuantity.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(61, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "Quantity";
            
            // 
            // copyButton
            // 
            this.copyButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.copyButton.Location = new System.Drawing.Point(61, 260);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(511, 45);
            this.copyButton.TabIndex = 6;
            this.copyButton.Text = "Copy the previous request";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(61, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 30);
            this.label2.TabIndex = 7;
            this.label2.Text = "Egg Quality:";
            // 
            // lblEggQuality
            // 
            this.lblEggQuality.AutoSize = true;
            this.lblEggQuality.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEggQuality.Location = new System.Drawing.Point(191, 348);
            this.lblEggQuality.Name = "lblEggQuality";
            this.lblEggQuality.Size = new System.Drawing.Size(25, 30);
            this.lblEggQuality.TabIndex = 8;
            this.lblEggQuality.Text = "0";
            // 
            // prepareButton
            // 
            this.prepareButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.prepareButton.Location = new System.Drawing.Point(61, 407);
            this.prepareButton.Name = "prepareButton";
            this.prepareButton.Size = new System.Drawing.Size(511, 43);
            this.prepareButton.TabIndex = 9;
            this.prepareButton.Text = "Prepare Food";
            this.prepareButton.UseVisualStyleBackColor = true;
            this.prepareButton.Click += new System.EventHandler(this.prepareButton_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(61, 523);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(513, 252);
            this.txtResult.TabIndex = 10;
            this.txtResult.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(61, 487);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 30);
            this.label4.TabIndex = 11;
            this.label4.Text = "Results";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 817);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.prepareButton);
            this.Controls.Add(this.lblEggQuality);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textQuantity);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.submitButton);
            this.Name = "Form1";
            this.Text = "TajGrill";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button submitButton;
        private GroupBox groupBox1;
        private TextBox textQuantity;
        private Label label1;
        private Button copyButton;
        private Label label2;
        private Label lblEggQuality;
        private Button prepareButton;
        private RichTextBox txtResult;
        private Label label4;
        private RadioButton radioChicken;
        private RadioButton radioEgg;
    }
}