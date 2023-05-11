namespace ShopApp.Framework
{
    partial class Dropdown
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ShowDropdownButton = new System.Windows.Forms.Button();
            this.DropdownInputMaskedEdit = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // ShowDropdownButton
            // 
            this.ShowDropdownButton.Location = new System.Drawing.Point(-1, -1);
            this.ShowDropdownButton.Name = "ShowDropdownButton";
            this.ShowDropdownButton.Size = new System.Drawing.Size(47, 23);
            this.ShowDropdownButton.TabIndex = 0;
            this.ShowDropdownButton.Text = "▼";
            this.ShowDropdownButton.UseVisualStyleBackColor = true;
            this.ShowDropdownButton.Click += new System.EventHandler(this.ShowDropdownButton_Click);
            // 
            // DropdownInputMaskedEdit
            // 
            this.DropdownInputMaskedEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DropdownInputMaskedEdit.Location = new System.Drawing.Point(44, 0);
            this.DropdownInputMaskedEdit.Name = "DropdownInputMaskedEdit";
            this.DropdownInputMaskedEdit.Size = new System.Drawing.Size(337, 20);
            this.DropdownInputMaskedEdit.TabIndex = 1;
            // 
            // Dropdown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DropdownInputMaskedEdit);
            this.Controls.Add(this.ShowDropdownButton);
            this.Name = "Dropdown";
            this.Size = new System.Drawing.Size(381, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ShowDropdownButton;
        private System.Windows.Forms.MaskedTextBox DropdownInputMaskedEdit;
    }
}
