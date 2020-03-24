namespace MparWinForm07.Mvc.View
{
    partial class Blog2View
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.newButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.firstButton = new System.Windows.Forms.Button();
            this.previousButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.lastButton = new System.Windows.Forms.Button();
            this.XRecordsPerPage = new System.Windows.Forms.NumericUpDown();
            this.XCurrentPage = new System.Windows.Forms.NumericUpDown();
            this.txtBlogId = new System.Windows.Forms.TextBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.XRecordsPerPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XCurrentPage)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 464);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1496, 464);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "BlogId";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Url";
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(1216, 16);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(192, 48);
            this.newButton.TabIndex = 3;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(1216, 88);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(192, 48);
            this.RemoveButton.TabIndex = 4;
            this.RemoveButton.Text = "Delete";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(1216, 160);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(192, 48);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // firstButton
            // 
            this.firstButton.Location = new System.Drawing.Point(408, 424);
            this.firstButton.Name = "firstButton";
            this.firstButton.Size = new System.Drawing.Size(75, 40);
            this.firstButton.TabIndex = 6;
            this.firstButton.Text = "button4";
            this.firstButton.UseVisualStyleBackColor = true;
            this.firstButton.Click += new System.EventHandler(this.firstButton_Click);
            // 
            // previousButton
            // 
            this.previousButton.Location = new System.Drawing.Point(496, 424);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(75, 40);
            this.previousButton.TabIndex = 7;
            this.previousButton.Text = "button5";
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(624, 424);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(75, 40);
            this.NextButton.TabIndex = 8;
            this.NextButton.Text = "button6";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // lastButton
            // 
            this.lastButton.Location = new System.Drawing.Point(712, 424);
            this.lastButton.Name = "lastButton";
            this.lastButton.Size = new System.Drawing.Size(75, 40);
            this.lastButton.TabIndex = 9;
            this.lastButton.Text = "button7";
            this.lastButton.UseVisualStyleBackColor = true;
            this.lastButton.Click += new System.EventHandler(this.lastButton_Click);
            // 
            // XRecordsPerPage
            // 
            this.XRecordsPerPage.Location = new System.Drawing.Point(48, 432);
            this.XRecordsPerPage.Name = "XRecordsPerPage";
            this.XRecordsPerPage.Size = new System.Drawing.Size(120, 29);
            this.XRecordsPerPage.TabIndex = 10;
            // 
            // XCurrentPage
            // 
            this.XCurrentPage.Location = new System.Drawing.Point(216, 432);
            this.XCurrentPage.Name = "XCurrentPage";
            this.XCurrentPage.Size = new System.Drawing.Size(120, 29);
            this.XCurrentPage.TabIndex = 11;
            // 
            // txtBlogId
            // 
            this.txtBlogId.Location = new System.Drawing.Point(280, 40);
            this.txtBlogId.Name = "txtBlogId";
            this.txtBlogId.Size = new System.Drawing.Size(100, 29);
            this.txtBlogId.TabIndex = 12;
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(280, 112);
            this.txtUrl.Multiline = true;
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(440, 40);
            this.txtUrl.TabIndex = 13;
            // 
            // Blog2View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1487, 925);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.txtBlogId);
            this.Controls.Add(this.XCurrentPage);
            this.Controls.Add(this.XRecordsPerPage);
            this.Controls.Add(this.lastButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.firstButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Name = "Blog2View";
            this.Text = "Blog2View";
            ((System.ComponentModel.ISupportInitialize)(this.XRecordsPerPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XCurrentPage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button firstButton;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button lastButton;
        private System.Windows.Forms.NumericUpDown XRecordsPerPage;
        private System.Windows.Forms.NumericUpDown XCurrentPage;
        private System.Windows.Forms.TextBox txtBlogId;
        private System.Windows.Forms.TextBox txtUrl;
    }
}