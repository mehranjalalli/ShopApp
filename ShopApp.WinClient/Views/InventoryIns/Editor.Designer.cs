namespace ShopApp.WinClient.Views.InventoryIns
{
    partial class Editor
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ControlsContainer = new System.Windows.Forms.Panel();
            this.DescriptionsTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DateDropdown = new ShopApp.Framework.Dropdown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.InsTypeComboBox = new System.Windows.Forms.ComboBox();
            this.InventoriesComboBox = new System.Windows.Forms.ComboBox();
            this.GridContainerPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.ControlsContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.GridContainerPanel);
            this.panel1.Controls.Add(this.ControlsContainer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(995, 686);
            this.panel1.TabIndex = 1;
            // 
            // ControlsContainer
            // 
            this.ControlsContainer.Controls.Add(this.DescriptionsTextBox);
            this.ControlsContainer.Controls.Add(this.label5);
            this.ControlsContainer.Controls.Add(this.TitleTextBox);
            this.ControlsContainer.Controls.Add(this.label4);
            this.ControlsContainer.Controls.Add(this.label3);
            this.ControlsContainer.Controls.Add(this.DateDropdown);
            this.ControlsContainer.Controls.Add(this.label2);
            this.ControlsContainer.Controls.Add(this.label1);
            this.ControlsContainer.Controls.Add(this.InsTypeComboBox);
            this.ControlsContainer.Controls.Add(this.InventoriesComboBox);
            this.ControlsContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControlsContainer.Location = new System.Drawing.Point(0, 0);
            this.ControlsContainer.Name = "ControlsContainer";
            this.ControlsContainer.Size = new System.Drawing.Size(995, 159);
            this.ControlsContainer.TabIndex = 4;
            // 
            // DescriptionsTextBox
            // 
            this.DescriptionsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionsTextBox.Location = new System.Drawing.Point(22, 67);
            this.DescriptionsTextBox.Multiline = true;
            this.DescriptionsTextBox.Name = "DescriptionsTextBox";
            this.DescriptionsTextBox.Size = new System.Drawing.Size(887, 81);
            this.DescriptionsTextBox.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(915, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "توضیحات";
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleTextBox.Location = new System.Drawing.Point(22, 41);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(887, 20);
            this.TitleTextBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(915, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "عنوان رسید";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(409, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "تاریخ";
            // 
            // DateDropdown
            // 
            this.DateDropdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateDropdown.InputMask = "";
            this.DateDropdown.Location = new System.Drawing.Point(22, 14);
            this.DateDropdown.Name = "DateDropdown";
            this.DateDropdown.Size = new System.Drawing.Size(381, 21);
            this.DateDropdown.TabIndex = 2;
            this.DateDropdown.Value = "";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(653, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "نوع رسید";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(915, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "انتخاب انبار";
            // 
            // InsTypeComboBox
            // 
            this.InsTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InsTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InsTypeComboBox.FormattingEnabled = true;
            this.InsTypeComboBox.Location = new System.Drawing.Point(447, 14);
            this.InsTypeComboBox.Name = "InsTypeComboBox";
            this.InsTypeComboBox.Size = new System.Drawing.Size(200, 21);
            this.InsTypeComboBox.TabIndex = 0;
            // 
            // InventoriesComboBox
            // 
            this.InventoriesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InventoriesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InventoriesComboBox.FormattingEnabled = true;
            this.InventoriesComboBox.Location = new System.Drawing.Point(709, 14);
            this.InventoriesComboBox.Name = "InventoriesComboBox";
            this.InventoriesComboBox.Size = new System.Drawing.Size(200, 21);
            this.InventoriesComboBox.TabIndex = 0;
            // 
            // GridContainerPanel
            // 
            this.GridContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridContainerPanel.Location = new System.Drawing.Point(0, 159);
            this.GridContainerPanel.Name = "GridContainerPanel";
            this.GridContainerPanel.Size = new System.Drawing.Size(995, 527);
            this.GridContainerPanel.TabIndex = 3;
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "Editor";
            this.Size = new System.Drawing.Size(995, 725);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.ControlsContainer.ResumeLayout(false);
            this.ControlsContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel GridContainerPanel;
        private System.Windows.Forms.Panel ControlsContainer;
        private System.Windows.Forms.TextBox DescriptionsTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Framework.Dropdown DateDropdown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox InsTypeComboBox;
        private System.Windows.Forms.ComboBox InventoriesComboBox;
    }
}
