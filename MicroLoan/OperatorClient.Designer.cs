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
            this.listBoxTypeVision = new System.Windows.Forms.ListBox();
            this.buttonShowAll = new System.Windows.Forms.Button();
            this.shadow = new System.Windows.Forms.Panel();
            this.Meunu = new System.Windows.Forms.Panel();
            this.ClaimLable = new System.Windows.Forms.Label();
            this.TableLable = new System.Windows.Forms.Label();
            this.WorkSpaceClaim = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.WorkSpaceTable.SuspendLayout();
            this.Meunu.SuspendLayout();
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
            this.WorkSpaceTable.Controls.Add(this.listBoxTypeVision);
            this.WorkSpaceTable.Controls.Add(this.buttonShowAll);
            this.WorkSpaceTable.Controls.Add(this.shadow);
            this.WorkSpaceTable.Controls.Add(this.dataGridView1);
            this.WorkSpaceTable.Location = new System.Drawing.Point(194, 0);
            this.WorkSpaceTable.Name = "WorkSpaceTable";
            this.WorkSpaceTable.Size = new System.Drawing.Size(910, 569);
            this.WorkSpaceTable.TabIndex = 1;
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
            this.buttonShowAll.Click += new System.EventHandler(this.button1_Click);
            // 
            // shadow
            // 
            this.shadow.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.shadow.Location = new System.Drawing.Point(0, 0);
            this.shadow.Name = "shadow";
            this.shadow.Size = new System.Drawing.Size(3, 569);
            this.shadow.TabIndex = 1;
            // 
            // Meunu
            // 
            this.Meunu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Meunu.Controls.Add(this.ClaimLable);
            this.Meunu.Controls.Add(this.TableLable);
            this.Meunu.Location = new System.Drawing.Point(0, 0);
            this.Meunu.Name = "Meunu";
            this.Meunu.Size = new System.Drawing.Size(196, 569);
            this.Meunu.TabIndex = 2;
            this.Meunu.Paint += new System.Windows.Forms.PaintEventHandler(this.Meunu_Paint);
            // 
            // ClaimLable
            // 
            this.ClaimLable.AutoSize = true;
            this.ClaimLable.BackColor = System.Drawing.Color.Transparent;
            this.ClaimLable.Location = new System.Drawing.Point(68, 124);
            this.ClaimLable.Name = "ClaimLable";
            this.ClaimLable.Size = new System.Drawing.Size(47, 12);
            this.ClaimLable.TabIndex = 1;
            this.ClaimLable.Text = "Заявка";
            this.ClaimLable.Click += new System.EventHandler(this.ClaimLable_Click);
            // 
            // TableLable
            // 
            this.TableLable.AutoSize = true;
            this.TableLable.BackColor = System.Drawing.Color.Transparent;
            this.TableLable.Location = new System.Drawing.Point(68, 48);
            this.TableLable.Name = "TableLable";
            this.TableLable.Size = new System.Drawing.Size(56, 12);
            this.TableLable.TabIndex = 0;
            this.TableLable.Text = "Таблица";
            this.TableLable.Click += new System.EventHandler(this.TableLable_Click);
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
            this.Controls.Add(this.Meunu);
            this.Controls.Add(this.WorkSpaceTable);
            this.Controls.Add(this.WorkSpaceClaim);
            this.MaximizeBox = false;
            this.Name = "OperatorClient";
            this.Text = " ";
            this.Load += new System.EventHandler(this.OperatorClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.WorkSpaceTable.ResumeLayout(false);
            this.Meunu.ResumeLayout(false);
            this.Meunu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel WorkSpaceTable;
        private System.Windows.Forms.Panel Meunu;
        private System.Windows.Forms.Panel shadow;
        private System.Windows.Forms.Button buttonShowAll;
        private System.Windows.Forms.Label TableLable;
        private System.Windows.Forms.ListBox listBoxTypeVision;
        private System.Windows.Forms.Label ClaimLable;
        private System.Windows.Forms.Panel WorkSpaceClaim;
    }
}

