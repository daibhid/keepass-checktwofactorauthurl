namespace CheckTwoFactorAuthURL
{
    partial class ResultsForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.EntryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.URL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupportsTwoFactor = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SupportsPhone = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SupportsSMS = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SupportsHardware = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SupportsSoftware = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EntryName,
            this.URL,
            this.SupportsTwoFactor,
            this.SupportsPhone,
            this.SupportsSMS,
            this.SupportsHardware,
            this.SupportsSoftware});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(800, 450);
            this.dataGridView1.TabIndex = 0;
            // 
            // EntryName
            // 
            this.EntryName.HeaderText = "EntryName";
            this.EntryName.Name = "EntryName";
            this.EntryName.ReadOnly = true;
            // 
            // URL
            // 
            this.URL.HeaderText = "URL";
            this.URL.Name = "URL";
            this.URL.ReadOnly = true;
            // 
            // SupportsTwoFactor
            // 
            this.SupportsTwoFactor.HeaderText = "SupportsTwoFactor";
            this.SupportsTwoFactor.Name = "SupportsTwoFactor";
            this.SupportsTwoFactor.ReadOnly = true;
            this.SupportsTwoFactor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SupportsTwoFactor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SupportsPhone
            // 
            this.SupportsPhone.HeaderText = "SupportsPhone";
            this.SupportsPhone.Name = "SupportsPhone";
            this.SupportsPhone.ReadOnly = true;
            this.SupportsPhone.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SupportsPhone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SupportsSMS
            // 
            this.SupportsSMS.HeaderText = "SupportsSMS";
            this.SupportsSMS.Name = "SupportsSMS";
            this.SupportsSMS.ReadOnly = true;
            this.SupportsSMS.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SupportsSMS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SupportsHardware
            // 
            this.SupportsHardware.HeaderText = "SupportsHardware";
            this.SupportsHardware.Name = "SupportsHardware";
            this.SupportsHardware.ReadOnly = true;
            this.SupportsHardware.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SupportsHardware.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SupportsSoftware
            // 
            this.SupportsSoftware.HeaderText = "SupportsSoftware";
            this.SupportsSoftware.Name = "SupportsSoftware";
            this.SupportsSoftware.ReadOnly = true;
            this.SupportsSoftware.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SupportsSoftware.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ResultsForm";
            this.Text = "ResultsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn URL;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SupportsTwoFactor;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SupportsPhone;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SupportsSMS;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SupportsHardware;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SupportsSoftware;
    }
}