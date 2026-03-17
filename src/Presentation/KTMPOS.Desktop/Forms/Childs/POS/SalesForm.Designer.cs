namespace KTMPOS.Desktop.Forms.Childs.POS
{
    partial class SalesForm
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
            lblSalesHeader = new Label();
            dgvSales = new DataGridView();
            txtProduct = new TextBox();
            lblProductName = new Label();
            lblQty = new Label();
            txtQty = new TextBox();
            lblGrandTotal = new Label();
            lblGrandTotalOutput = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            lblDiscount = new Label();
            txtDiscount = new TextBox();
            lblNetTotal = new Label();
            lblNetTotalOutput = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSales).BeginInit();
            SuspendLayout();
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.Location = new Point(2828, 10);
            btnExit.Margin = new Padding(6);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(257, 80);
            btnExit.TabIndex = 6;
            btnExit.Text = "Exit (F10)";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // lblSalesHeader
            // 
            lblSalesHeader.Anchor = AnchorStyles.Top;
            lblSalesHeader.AutoSize = true;
            lblSalesHeader.Location = new Point(1394, 18);
            lblSalesHeader.Margin = new Padding(6, 0, 6, 0);
            lblSalesHeader.Name = "lblSalesHeader";
            lblSalesHeader.Size = new Size(270, 41);
            lblSalesHeader.TabIndex = 5;
            lblSalesHeader.Text = "Sales Management";
            // 
            // dgvSales
            // 
            dgvSales.AllowUserToAddRows = false;
            dgvSales.AllowUserToDeleteRows = false;
            dgvSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSales.Location = new Point(26, 141);
            dgvSales.Margin = new Padding(6);
            dgvSales.Name = "dgvSales";
            dgvSales.ReadOnly = true;
            dgvSales.RowHeadersWidth = 51;
            dgvSales.Size = new Size(1813, 711);
            dgvSales.TabIndex = 7;
            dgvSales.CellClick += dgvSales_CellClick;
            dgvSales.CellDoubleClick += dgvSales_CellDoubleClick;
            // 
            // txtProduct
            // 
            txtProduct.Location = new Point(221, 900);
            txtProduct.Margin = new Padding(6);
            txtProduct.Name = "txtProduct";
            txtProduct.Size = new Size(416, 47);
            txtProduct.TabIndex = 10;
            txtProduct.KeyDown += txtProduct_KeyDown;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(40, 906);
            lblProductName.Margin = new Padding(6, 0, 6, 0);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(129, 41);
            lblProductName.TabIndex = 9;
            lblProductName.Text = "Product:";
            // 
            // lblQty
            // 
            lblQty.AutoSize = true;
            lblQty.Location = new Point(45, 1007);
            lblQty.Margin = new Padding(6, 0, 6, 0);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(73, 41);
            lblQty.TabIndex = 8;
            lblQty.Text = "Qty:";
            // 
            // txtQty
            // 
            txtQty.Location = new Point(221, 1000);
            txtQty.Margin = new Padding(6);
            txtQty.Name = "txtQty";
            txtQty.Size = new Size(416, 47);
            txtQty.TabIndex = 10;
            txtQty.KeyDown += txtQty_KeyDown;
            txtQty.KeyPress += txtQty_KeyPress;
            // 
            // lblGrandTotal
            // 
            lblGrandTotal.AutoSize = true;
            lblGrandTotal.Location = new Point(801, 892);
            lblGrandTotal.Margin = new Padding(6, 0, 6, 0);
            lblGrandTotal.Name = "lblGrandTotal";
            lblGrandTotal.Size = new Size(177, 41);
            lblGrandTotal.TabIndex = 8;
            lblGrandTotal.Text = "Grand Total:";
            // 
            // lblGrandTotalOutput
            // 
            lblGrandTotalOutput.AutoSize = true;
            lblGrandTotalOutput.Location = new Point(1022, 892);
            lblGrandTotalOutput.Margin = new Padding(6, 0, 6, 0);
            lblGrandTotalOutput.Name = "lblGrandTotalOutput";
            lblGrandTotalOutput.Size = new Size(34, 41);
            lblGrandTotalOutput.TabIndex = 8;
            lblGrandTotalOutput.Text = "0";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(1549, 873);
            btnSave.Margin = new Padding(6);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(289, 80);
            btnSave.TabIndex = 12;
            btnSave.Text = "Save (F2)";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(1549, 980);
            btnCancel.Margin = new Padding(6);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(289, 80);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel (F3)";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblDiscount
            // 
            lblDiscount.AutoSize = true;
            lblDiscount.Location = new Point(801, 959);
            lblDiscount.Margin = new Padding(6, 0, 6, 0);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(142, 41);
            lblDiscount.TabIndex = 8;
            lblDiscount.Text = "Discount:";
            // 
            // txtDiscount
            // 
            txtDiscount.Location = new Point(1022, 959);
            txtDiscount.Margin = new Padding(6);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(416, 47);
            txtDiscount.TabIndex = 10;
            txtDiscount.KeyDown += txtDiscount_KeyDown;
            txtDiscount.KeyPress += txtDiscount_KeyPress;
            // 
            // lblNetTotal
            // 
            lblNetTotal.AutoSize = true;
            lblNetTotal.Location = new Point(801, 1060);
            lblNetTotal.Margin = new Padding(6, 0, 6, 0);
            lblNetTotal.Name = "lblNetTotal";
            lblNetTotal.Size = new Size(144, 41);
            lblNetTotal.TabIndex = 8;
            lblNetTotal.Text = "Net Total:";
            // 
            // lblNetTotalOutput
            // 
            lblNetTotalOutput.AutoSize = true;
            lblNetTotalOutput.Location = new Point(1022, 1060);
            lblNetTotalOutput.Margin = new Padding(6, 0, 6, 0);
            lblNetTotalOutput.Name = "lblNetTotalOutput";
            lblNetTotalOutput.Size = new Size(34, 41);
            lblNetTotalOutput.TabIndex = 8;
            lblNetTotalOutput.Text = "0";
            // 
            // SalesForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(3098, 1425);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtDiscount);
            Controls.Add(txtQty);
            Controls.Add(txtProduct);
            Controls.Add(lblNetTotalOutput);
            Controls.Add(lblGrandTotalOutput);
            Controls.Add(lblNetTotal);
            Controls.Add(lblGrandTotal);
            Controls.Add(lblDiscount);
            Controls.Add(lblQty);
            Controls.Add(lblProductName);
            Controls.Add(dgvSales);
            Controls.Add(lblSalesHeader);
            Controls.Add(btnExit);
            Margin = new Padding(6);
            Name = "SalesForm";
            Text = "Sales";
            Load += SalesForm_Load;
            KeyDown += SalesForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dgvSales).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblSalesHeader;
        private DataGridView dgvSales;
        private TextBox txtProduct;
        private Label lblProductName;
        private Label lblQty;
        private TextBox txtQty;
        private Label lblGrandTotal;
        private Label lblGrandTotalOutput;
        private Button btnSave;
        private Button btnCancel;
        private Button btnExit;

        #endregion

        private Label lblDiscount;
        private TextBox txtDiscount;
        private Label lblNetTotal;
        private Label lblNetTotalOutput;
    }
}