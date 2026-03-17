namespace KTMPOS.Desktop.Forms.Childs.Reporting
{
    partial class SalesReportForm
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
            if(disposing && (components != null))
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
            btnExit = new Button();
            lblSalesReportHeader = new Label();
            dgvSalesReport = new DataGridView();
            lblReportFilter = new Label();
            cboFilter = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvSalesReport).BeginInit();
            SuspendLayout();
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.Location = new Point(1613, 10);
            btnExit.Margin = new Padding(6);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(257, 80);
            btnExit.TabIndex = 8;
            btnExit.Text = "Exit (F10)";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // lblSalesReportHeader
            // 
            lblSalesReportHeader.Anchor = AnchorStyles.Top;
            lblSalesReportHeader.AutoSize = true;
            lblSalesReportHeader.Location = new Point(703, 29);
            lblSalesReportHeader.Margin = new Padding(6, 0, 6, 0);
            lblSalesReportHeader.Name = "lblSalesReportHeader";
            lblSalesReportHeader.Size = new Size(182, 41);
            lblSalesReportHeader.TabIndex = 7;
            lblSalesReportHeader.Text = "Sales Report";
            // 
            // dgvSalesReport
            // 
            dgvSalesReport.AllowUserToAddRows = false;
            dgvSalesReport.AllowUserToDeleteRows = false;
            dgvSalesReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSalesReport.Location = new Point(26, 289);
            dgvSalesReport.Margin = new Padding(6);
            dgvSalesReport.Name = "dgvSalesReport";
            dgvSalesReport.ReadOnly = true;
            dgvSalesReport.RowHeadersWidth = 51;
            dgvSalesReport.Size = new Size(1749, 711);
            dgvSalesReport.TabIndex = 9;
            // 
            // lblReportFilter
            // 
            lblReportFilter.AutoSize = true;
            lblReportFilter.Location = new Point(26, 135);
            lblReportFilter.Margin = new Padding(6, 0, 6, 0);
            lblReportFilter.Name = "lblReportFilter";
            lblReportFilter.Size = new Size(98, 41);
            lblReportFilter.TabIndex = 10;
            lblReportFilter.Text = "Filter: ";
            // 
            // cboFilter
            // 
            cboFilter.FormattingEnabled = true;
            cboFilter.Location = new Point(151, 127);
            cboFilter.Margin = new Padding(6);
            cboFilter.Name = "cboFilter";
            cboFilter.Size = new Size(399, 49);
            cboFilter.TabIndex = 11;
            cboFilter.SelectedIndexChanged += cboFilter_SelectedIndexChanged;
            // 
            // SalesReportForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1874, 1046);
            Controls.Add(cboFilter);
            Controls.Add(lblReportFilter);
            Controls.Add(dgvSalesReport);
            Controls.Add(btnExit);
            Controls.Add(lblSalesReportHeader);
            Margin = new Padding(6);
            Name = "SalesReportForm";
            Text = "SalesReportForm";
            Load += SalesReportForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSalesReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnExit;
        private Label lblSalesReportHeader;
        private DataGridView dgvSalesReport;
        private Label lblReportFilter;
        private ComboBox cboFilter;
    }
}