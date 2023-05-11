namespace ShopApp.WinClient.Views.SystemForms
{
    partial class FinancialYearEditorForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.CancelButton = new System.Windows.Forms.Button();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.StartDateMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.FinishDateMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.FinishDateLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.CancelButton);
            this.panel1.Controls.Add(this.AcceptButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 219);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 36);
            this.panel1.TabIndex = 8;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(92, 6);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "صرفنظر";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(11, 6);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptButton.TabIndex = 0;
            this.AcceptButton.Text = "تائید";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(12, 12);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(419, 21);
            this.TitleTextBox.TabIndex = 1;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(437, 15);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(83, 13);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "عنوان سال مالی";
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(12, 39);
            this.DescriptionTextBox.Multiline = true;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(419, 103);
            this.DescriptionTextBox.TabIndex = 3;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(437, 42);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(47, 13);
            this.DescriptionLabel.TabIndex = 2;
            this.DescriptionLabel.Text = "توضیحات";
            // 
            // StartDateMaskedTextBox
            // 
            this.StartDateMaskedTextBox.Location = new System.Drawing.Point(12, 148);
            this.StartDateMaskedTextBox.Mask = "0000/00/00";
            this.StartDateMaskedTextBox.Name = "StartDateMaskedTextBox";
            this.StartDateMaskedTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartDateMaskedTextBox.Size = new System.Drawing.Size(419, 21);
            this.StartDateMaskedTextBox.TabIndex = 5;
            // 
            // FinishDateMaskedTextBox
            // 
            this.FinishDateMaskedTextBox.Location = new System.Drawing.Point(12, 175);
            this.FinishDateMaskedTextBox.Mask = "0000/00/00";
            this.FinishDateMaskedTextBox.Name = "FinishDateMaskedTextBox";
            this.FinishDateMaskedTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FinishDateMaskedTextBox.Size = new System.Drawing.Size(419, 21);
            this.FinishDateMaskedTextBox.TabIndex = 7;
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Location = new System.Drawing.Point(437, 151);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(59, 13);
            this.StartDateLabel.TabIndex = 4;
            this.StartDateLabel.Text = "تاریخ شروع";
            // 
            // FinishDateLabel
            // 
            this.FinishDateLabel.AutoSize = true;
            this.FinishDateLabel.Location = new System.Drawing.Point(437, 178);
            this.FinishDateLabel.Name = "FinishDateLabel";
            this.FinishDateLabel.Size = new System.Drawing.Size(50, 13);
            this.FinishDateLabel.TabIndex = 6;
            this.FinishDateLabel.Text = "تاریخ پایان";
            // 
            // FinancialYearEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(532, 255);
            this.Controls.Add(this.FinishDateMaskedTextBox);
            this.Controls.Add(this.StartDateMaskedTextBox);
            this.Controls.Add(this.FinishDateLabel);
            this.Controls.Add(this.StartDateLabel);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FinancialYearEditorForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FinancialYearEditor";
            this.Load += new System.EventHandler(this.FinancialYearEditorForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.MaskedTextBox StartDateMaskedTextBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.MaskedTextBox FinishDateMaskedTextBox;
        private System.Windows.Forms.Label StartDateLabel;
        private System.Windows.Forms.Label FinishDateLabel;
    }
}