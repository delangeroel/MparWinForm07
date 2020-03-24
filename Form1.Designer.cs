namespace MparWinForm07
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ActionButton = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.CountryButton = new System.Windows.Forms.Button();
            this.CustomerButton = new System.Windows.Forms.Button();
            this.LoanButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ActionButton
            // 
            this.ActionButton.Location = new System.Drawing.Point(68, 144);
            this.ActionButton.Margin = new System.Windows.Forms.Padding(4);
            this.ActionButton.Name = "ActionButton";
            this.ActionButton.Size = new System.Drawing.Size(196, 48);
            this.ActionButton.TabIndex = 0;
            this.ActionButton.Text = "Action";
            this.ActionButton.UseVisualStyleBackColor = true;
            this.ActionButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(1027, 211);
            this.maskedTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.maskedTextBox1.Mask = "#,###,###,##0.00";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.maskedTextBox1.Size = new System.Drawing.Size(273, 29);
            this.maskedTextBox1.TabIndex = 2;
            // 
            // CountryButton
            // 
            this.CountryButton.Location = new System.Drawing.Point(72, 216);
            this.CountryButton.Margin = new System.Windows.Forms.Padding(4);
            this.CountryButton.Name = "CountryButton";
            this.CountryButton.Size = new System.Drawing.Size(196, 48);
            this.CountryButton.TabIndex = 3;
            this.CountryButton.Text = "Country";
            this.CountryButton.UseVisualStyleBackColor = true;
            this.CountryButton.Click += new System.EventHandler(this.CountryButton_Click);
            // 
            // CustomerButton
            // 
            this.CustomerButton.Location = new System.Drawing.Point(72, 288);
            this.CustomerButton.Margin = new System.Windows.Forms.Padding(4);
            this.CustomerButton.Name = "CustomerButton";
            this.CustomerButton.Size = new System.Drawing.Size(196, 48);
            this.CustomerButton.TabIndex = 4;
            this.CustomerButton.Text = "Customer";
            this.CustomerButton.UseVisualStyleBackColor = true;
            this.CustomerButton.Click += new System.EventHandler(this.CustomerButton_Click);
            // 
            // LoanButton
            // 
            this.LoanButton.Location = new System.Drawing.Point(72, 360);
            this.LoanButton.Margin = new System.Windows.Forms.Padding(4);
            this.LoanButton.Name = "LoanButton";
            this.LoanButton.Size = new System.Drawing.Size(196, 48);
            this.LoanButton.TabIndex = 5;
            this.LoanButton.Text = "Loan";
            this.LoanButton.UseVisualStyleBackColor = true;
            this.LoanButton.Click += new System.EventHandler(this.LoanButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(72, 440);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 48);
            this.button1.TabIndex = 6;
            this.button1.Text = "Blog";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(304, 440);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(196, 48);
            this.button2.TabIndex = 7;
            this.button2.Text = "Blog";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2928, 1110);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LoanButton);
            this.Controls.Add(this.CustomerButton);
            this.Controls.Add(this.CountryButton);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.ActionButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ActionButton;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Button CountryButton;
        private System.Windows.Forms.Button CustomerButton;
        private System.Windows.Forms.Button LoanButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

