namespace MicroLoan
{
    partial class OperatorClient
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.WorkSpaceTable = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDeleateOLD = new System.Windows.Forms.Button();
            this.listBoxSearchType = new System.Windows.Forms.ListBox();
            this.SearchtextBox = new System.Windows.Forms.TextBox();
            this.buttonSendUpdate = new System.Windows.Forms.Button();
            this.buttonShowNew = new System.Windows.Forms.Button();
            this.listBoxTypeVision = new System.Windows.Forms.ListBox();
            this.buttonShowAll = new System.Windows.Forms.Button();
            this.shadow = new System.Windows.Forms.Panel();
            this.Menu = new System.Windows.Forms.Panel();
            this.buttonClaim = new System.Windows.Forms.Button();
            this.buttonTable = new System.Windows.Forms.Button();
            this.WorkSpaceClaim = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.WorkSpaceTable.SuspendLayout();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(31, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(707, 351);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Text = "dataGridView1";
            // 
            // WorkSpaceTable
            // 
            this.WorkSpaceTable.BackColor = System.Drawing.SystemColors.Control;
            this.WorkSpaceTable.Controls.Add(this.label1);
            this.WorkSpaceTable.Controls.Add(this.buttonDeleateOLD);
            this.WorkSpaceTable.Controls.Add(this.listBoxSearchType);
            this.WorkSpaceTable.Controls.Add(this.SearchtextBox);
            this.WorkSpaceTable.Controls.Add(this.buttonSendUpdate);
            this.WorkSpaceTable.Controls.Add(this.buttonShowNew);
            this.WorkSpaceTable.Controls.Add(this.listBoxTypeVision);
            this.WorkSpaceTable.Controls.Add(this.buttonShowAll);
            this.WorkSpaceTable.Controls.Add(this.shadow);
            this.WorkSpaceTable.Controls.Add(this.dataGridView1);
            this.WorkSpaceTable.Location = new System.Drawing.Point(194, 0);
            this.WorkSpaceTable.Name = "WorkSpaceTable";
            this.WorkSpaceTable.Size = new System.Drawing.Size(910, 569);
            this.WorkSpaceTable.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(8, 502);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 36);
            this.label1.TabIndex = 9;
            this.label1.Text = "Удалить все старые завяки,\r\nотклоненные более 7 дней назад.\r\n\r\n";
            // 
            // buttonDeleateOLD
            // 
            this.buttonDeleateOLD.Location = new System.Drawing.Point(216, 502);
            this.buttonDeleateOLD.Name = "buttonDeleateOLD";
            this.buttonDeleateOLD.Size = new System.Drawing.Size(143, 55);
            this.buttonDeleateOLD.TabIndex = 8;
            this.buttonDeleateOLD.Text = "Удалить";
            this.buttonDeleateOLD.UseVisualStyleBackColor = true;
            // 
            // listBoxSearchType
            // 
            this.listBoxSearchType.FormattingEnabled = true;
            this.listBoxSearchType.ItemHeight = 12;
            this.listBoxSearchType.Items.AddRange(new object[] {
            "По фамилии",
            "По номеру"});
            this.listBoxSearchType.Location = new System.Drawing.Point(216, 381);
            this.listBoxSearchType.Name = "listBoxSearchType";
            this.listBoxSearchType.Size = new System.Drawing.Size(120, 28);
            this.listBoxSearchType.TabIndex = 7;
            // 
            // SearchtextBox
            // 
            this.SearchtextBox.Location = new System.Drawing.Point(53, 381);
            this.SearchtextBox.Name = "SearchtextBox";
            this.SearchtextBox.Size = new System.Drawing.Size(145, 23);
            this.SearchtextBox.TabIndex = 6;
            // 
            // buttonSendUpdate
            // 
            this.buttonSendUpdate.Location = new System.Drawing.Point(744, 323);
            this.buttonSendUpdate.Name = "buttonSendUpdate";
            this.buttonSendUpdate.Size = new System.Drawing.Size(143, 52);
            this.buttonSendUpdate.TabIndex = 5;
            this.buttonSendUpdate.Text = "Отправить и обновить";
            this.buttonSendUpdate.UseVisualStyleBackColor = true;
            // 
            // buttonShowNew
            // 
            this.buttonShowNew.Location = new System.Drawing.Point(744, 66);
            this.buttonShowNew.Name = "buttonShowNew";
            this.buttonShowNew.Size = new System.Drawing.Size(86, 37);
            this.buttonShowNew.TabIndex = 4;
            this.buttonShowNew.Text = "Новые заявки";
            this.buttonShowNew.UseVisualStyleBackColor = true;
            // 
            // listBoxTypeVision
            // 
            this.listBoxTypeVision.FormattingEnabled = true;
            this.listBoxTypeVision.ItemHeight = 12;
            this.listBoxTypeVision.Items.AddRange(new object[] {
            "Заявки",
            "Клиенты"});
            this.listBoxTypeVision.Location = new System.Drawing.Point(836, 24);
            this.listBoxTypeVision.Name = "listBoxTypeVision";
            this.listBoxTypeVision.Size = new System.Drawing.Size(74, 40);
            this.listBoxTypeVision.TabIndex = 3;
            // 
            // buttonShowAll
            // 
            this.buttonShowAll.Location = new System.Drawing.Point(744, 24);
            this.buttonShowAll.Name = "buttonShowAll";
            this.buttonShowAll.Size = new System.Drawing.Size(86, 36);
            this.buttonShowAll.TabIndex = 2;
            this.buttonShowAll.Text = "Отобразить все";
            this.buttonShowAll.UseVisualStyleBackColor = true;
            // 
            // shadow
            // 
            this.shadow.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.shadow.Location = new System.Drawing.Point(0, 0);
            this.shadow.Name = "shadow";
            this.shadow.Size = new System.Drawing.Size(3, 569);
            this.shadow.TabIndex = 1;
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Menu.Controls.Add(this.buttonClaim);
            this.Menu.Controls.Add(this.buttonTable);
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(196, 569);
            this.Menu.TabIndex = 2;
            this.Menu.Paint += new System.Windows.Forms.PaintEventHandler(this.Meunu_Paint);
            // 
            // buttonClaim
            // 
            this.buttonClaim.BackColor = System.Drawing.Color.Transparent;
            this.buttonClaim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClaim.FlatAppearance.BorderSize = 0;
            this.buttonClaim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClaim.Location = new System.Drawing.Point(0, 149);
            this.buttonClaim.Name = "buttonClaim";
            this.buttonClaim.Size = new System.Drawing.Size(196, 93);
            this.buttonClaim.TabIndex = 1;
            this.buttonClaim.Text = "Заявка";
            this.buttonClaim.UseVisualStyleBackColor = false;
            this.buttonClaim.Click += new System.EventHandler(this.buttonClaim_Click);
            // 
            // buttonTable
            // 
            this.buttonTable.BackColor = System.Drawing.Color.Transparent;
            this.buttonTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTable.FlatAppearance.BorderSize = 0;
            this.buttonTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTable.Location = new System.Drawing.Point(0, 40);
            this.buttonTable.Name = "buttonTable";
            this.buttonTable.Size = new System.Drawing.Size(197, 90);
            this.buttonTable.TabIndex = 0;
            this.buttonTable.Text = "Таблица";
            this.buttonTable.UseVisualStyleBackColor = false;
            this.buttonTable.Click += new System.EventHandler(this.buttonTable_Click);
            // 
            // WorkSpaceClaim
            // 
            this.WorkSpaceClaim.BackColor = System.Drawing.SystemColors.Control;
            this.WorkSpaceClaim.Location = new System.Drawing.Point(194, 0);
            this.WorkSpaceClaim.Name = "WorkSpaceClaim";
            this.WorkSpaceClaim.Size = new System.Drawing.Size(910, 569);
            this.WorkSpaceClaim.TabIndex = 3;
            this.WorkSpaceClaim.Visible = false;
            // 
            // OperatorClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1104, 569);
            this.Controls.Add(this.Menu);
            this.Controls.Add(this.WorkSpaceTable);
            this.Controls.Add(this.WorkSpaceClaim);
            this.MaximizeBox = false;
            this.Name = "OperatorClient";
            this.Text = " ";
            this.Load += new System.EventHandler(this.OperatorClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.WorkSpaceTable.ResumeLayout(false);
            this.WorkSpaceTable.PerformLayout();
            this.Menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel WorkSpaceTable;
        private System.Windows.Forms.Panel Menu;
        private System.Windows.Forms.Panel shadow;
        private System.Windows.Forms.Button buttonShowAll;
        private System.Windows.Forms.ListBox listBoxTypeVision;
        private System.Windows.Forms.Panel WorkSpaceClaim;
        private System.Windows.Forms.TextBox SearchtextBox;
        private System.Windows.Forms.Button buttonSendUpdate;
        private System.Windows.Forms.Button buttonShowNew;
        private System.Windows.Forms.ListBox listBoxSearchType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDeleateOLD;
        private System.Windows.Forms.Button buttonClaim;
        private System.Windows.Forms.Button buttonTable;
    }
}

