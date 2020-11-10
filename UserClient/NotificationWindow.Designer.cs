namespace UserClient
{
    partial class NotificationWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationWindow));
            this.buttonOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelText = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.paidtextboxsum = new System.Windows.Forms.TextBox();
            this.labelsum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.buttonOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOK.FlatAppearance.BorderSize = 0;
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOK.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.buttonOK.Location = new System.Drawing.Point(93, 308);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(117, 35);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "ОК";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ваш займ:";
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.BackColor = System.Drawing.Color.Transparent;
            this.labelText.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelText.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelText.Location = new System.Drawing.Point(12, 82);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(13, 17);
            this.labelText.TabIndex = 1;
            this.labelText.Text = "-";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkRed;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(216, 308);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Отмена";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // paidtextboxsum
            // 
            this.paidtextboxsum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paidtextboxsum.Location = new System.Drawing.Point(286, 240);
            this.paidtextboxsum.MaxLength = 5;
            this.paidtextboxsum.Name = "paidtextboxsum";
            this.paidtextboxsum.Size = new System.Drawing.Size(100, 25);
            this.paidtextboxsum.TabIndex = 3;
            this.paidtextboxsum.Visible = false;
            this.paidtextboxsum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.paidtextboxsum_KeyPress);
            // 
            // labelsum
            // 
            this.labelsum.AutoSize = true;
            this.labelsum.BackColor = System.Drawing.Color.Transparent;
            this.labelsum.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelsum.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelsum.Location = new System.Drawing.Point(171, 225);
            this.labelsum.Name = "labelsum";
            this.labelsum.Size = new System.Drawing.Size(109, 40);
            this.labelsum.TabIndex = 1;
            this.labelsum.Text = "сумма оплаты\r\nруб.";
            this.labelsum.Visible = false;
            // 
            // NotificationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(449, 355);
            this.Controls.Add(this.paidtextboxsum);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelsum);
            this.Controls.Add(this.labelText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOK);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "NotificationWindow";
            this.Text = "Ваш займ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelsum;
        public System.Windows.Forms.TextBox paidtextboxsum;
    }
}