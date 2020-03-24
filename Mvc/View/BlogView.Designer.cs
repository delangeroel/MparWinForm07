namespace MparWinForm07.Mvc.View
{
    partial class BlogView
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
            this.newButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBlogId = new System.Windows.Forms.TextBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.firstButton = new System.Windows.Forms.Button();
            this.previousButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.lastButton = new System.Windows.Forms.Button();
            this.XRecordsPerPage = new System.Windows.Forms.NumericUpDown();
            this.XCurrentPage = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.XRecordsPerPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XCurrentPage)).BeginInit();
            this.SuspendLayout();
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(1120, 56);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(144, 48);
            this.newButton.TabIndex = 0;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(1120, 120);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(144, 48);
            this.RemoveButton.TabIndex = 1;
            this.RemoveButton.Text = "Delete";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(1120, 184);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(144, 48);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "BlogId";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Url";
            // 
            // txtBlogId
            // 
            this.txtBlogId.Location = new System.Drawing.Point(360, 32);
            this.txtBlogId.Name = "txtBlogId";
            this.txtBlogId.Size = new System.Drawing.Size(100, 29);
            this.txtBlogId.TabIndex = 5;
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(360, 96);
            this.txtUrl.Multiline = true;
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(448, 40);
            this.txtUrl.TabIndex = 6;
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 440);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1344, 576);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // firstButton
            // 
            this.firstButton.Location = new System.Drawing.Point(336, 384);
            this.firstButton.Name = "firstButton";
            this.firstButton.Size = new System.Drawing.Size(104, 48);
            this.firstButton.TabIndex = 8;
            this.firstButton.Text = "<<";
            this.firstButton.UseVisualStyleBackColor = true;
            this.firstButton.Click += new System.EventHandler(this.firstButton_Click_1);
            // 
            // previousButton
            // 
            this.previousButton.Location = new System.Drawing.Point(464, 384);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(104, 48);
            this.previousButton.TabIndex = 9;
            this.previousButton.Text = "<";
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click_1);
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(608, 384);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(104, 48);
            this.NextButton.TabIndex = 10;
            this.NextButton.Text = ">";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // lastButton
            // 
            this.lastButton.Location = new System.Drawing.Point(720, 384);
            this.lastButton.Name = "lastButton";
            this.lastButton.Size = new System.Drawing.Size(104, 48);
            this.lastButton.TabIndex = 11;
            this.lastButton.Text = ">>";
            this.lastButton.UseVisualStyleBackColor = true;
            this.lastButton.Click += new System.EventHandler(this.lastButton_Click);
            // 
            // XRecordsPerPage
            // 
            this.XRecordsPerPage.Location = new System.Drawing.Point(128, 328);
            this.XRecordsPerPage.Name = "XRecordsPerPage";
            this.XRecordsPerPage.Size = new System.Drawing.Size(120, 29);
            this.XRecordsPerPage.TabIndex = 12;
            // 
            // XCurrentPage
            // 
            this.XCurrentPage.Location = new System.Drawing.Point(320, 320);
            this.XCurrentPage.Name = "XCurrentPage";
            this.XCurrentPage.Size = new System.Drawing.Size(120, 29);
            this.XCurrentPage.TabIndex = 13;
            // 
            // BlogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1340, 1013);
            this.Controls.Add(this.XCurrentPage);
            this.Controls.Add(this.XRecordsPerPage);
            this.Controls.Add(this.lastButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.firstButton);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.txtBlogId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.newButton);
            this.Name = "BlogView";
            this.Text = "BlogView";
            ((System.ComponentModel.ISupportInitialize)(this.XRecordsPerPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XCurrentPage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBlogId;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button firstButton;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button lastButton;
        private System.Windows.Forms.NumericUpDown XRecordsPerPage;
        private System.Windows.Forms.NumericUpDown XCurrentPage;
    }
}