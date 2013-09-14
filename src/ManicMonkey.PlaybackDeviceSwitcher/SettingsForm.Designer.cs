namespace ManicMonkey.PlaybackDeviceSwitcher
{
    partial class SettingsForm
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
            this.saveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.resetSettingsButton = new System.Windows.Forms.Button();
            this.activeEndpointsGrid = new System.Windows.Forms.DataGridView();
            this.aegName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aegAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aegVisible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.activeEndpointsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(392, 310);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(103, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save changes";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(512, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "You can set the visiblility and alias for any of the playback devices in the syst" +
    "em by updating the grid below.\r\n";
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(500, 310);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "Cancel";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // resetSettingsButton
            // 
            this.resetSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resetSettingsButton.Location = new System.Drawing.Point(11, 309);
            this.resetSettingsButton.Name = "resetSettingsButton";
            this.resetSettingsButton.Size = new System.Drawing.Size(103, 23);
            this.resetSettingsButton.TabIndex = 5;
            this.resetSettingsButton.Text = "Reset Settings";
            this.resetSettingsButton.UseVisualStyleBackColor = true;
            this.resetSettingsButton.Click += new System.EventHandler(this.resetSettingsButton_Click);
            // 
            // activeEndpointsGrid
            // 
            this.activeEndpointsGrid.AllowUserToAddRows = false;
            this.activeEndpointsGrid.AllowUserToDeleteRows = false;
            this.activeEndpointsGrid.AllowUserToResizeColumns = false;
            this.activeEndpointsGrid.AllowUserToResizeRows = false;
            this.activeEndpointsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.activeEndpointsGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.activeEndpointsGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.activeEndpointsGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.activeEndpointsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.activeEndpointsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aegName,
            this.aegAlias,
            this.aegVisible});
            this.activeEndpointsGrid.Location = new System.Drawing.Point(11, 33);
            this.activeEndpointsGrid.Name = "activeEndpointsGrid";
            this.activeEndpointsGrid.RowHeadersVisible = false;
            this.activeEndpointsGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.activeEndpointsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.activeEndpointsGrid.Size = new System.Drawing.Size(564, 267);
            this.activeEndpointsGrid.TabIndex = 6;
            // 
            // aegName
            // 
            this.aegName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.aegName.DataPropertyName = "Name";
            this.aegName.HeaderText = "System name";
            this.aegName.Name = "aegName";
            this.aegName.ReadOnly = true;
            // 
            // aegAlias
            // 
            this.aegAlias.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.aegAlias.DataPropertyName = "Alias";
            this.aegAlias.HeaderText = "Alias";
            this.aegAlias.Name = "aegAlias";
            // 
            // aegVisible
            // 
            this.aegVisible.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.aegVisible.DataPropertyName = "Hidden";
            this.aegVisible.HeaderText = "Hidden";
            this.aegVisible.Name = "aegVisible";
            this.aegVisible.Width = 47;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 342);
            this.Controls.Add(this.activeEndpointsGrid);
            this.Controls.Add(this.resetSettingsButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveButton);
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Playback Device Switcher settings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.activeEndpointsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button resetSettingsButton;
        private System.Windows.Forms.DataGridView activeEndpointsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn aegName;
        private System.Windows.Forms.DataGridViewTextBoxColumn aegAlias;
        private System.Windows.Forms.DataGridViewCheckBoxColumn aegVisible;
    }
}