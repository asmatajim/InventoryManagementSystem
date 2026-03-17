namespace KTMPOS.Desktop.Forms.Childs.PurchaseBilling
{
    partial class PurchaseForm
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
            lblPurchaseHeader = new Label();
            dgvPurchase = new DataGridView();
            txtProduct = new TextBox();
            lblCategory = new Label();
            lblProductName = new Label();
            cboSupplier = new ComboBox();
            lblQty = new Label();
            txtQty = new TextBox();
            lblGrandTotal = new Label();
            lblGrandTotalOutput = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPurchase).BeginInit();
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
            // lblPurchaseHeader
            // 
            lblPurchaseHeader.Anchor = AnchorStyles.Top;
            lblPurchaseHeader.AutoSize = true;
            lblPurchaseHeader.Location = new Point(1394, 18);
            lblPurchaseHeader.Margin = new Padding(6, 0, 6, 0);
            lblPurchaseHeader.Name = "lblPurchaseHeader";
            lblPurchaseHeader.Size = new Size(322, 41);
            lblPurchaseHeader.TabIndex = 5;
            lblPurchaseHeader.Text = "Purchase Management";
            // 
            // dgvPurchase
            // 
            dgvPurchase.AllowUserToAddRows = false;
            dgvPurchase.AllowUserToDeleteRows = false;
            dgvPurchase.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPurchase.Location = new Point(26, 141);
            dgvPurchase.Margin = new Padding(6);
            dgvPurchase.Name = "dgvPurchase";
            dgvPurchase.ReadOnly = true;
            dgvPurchase.RowHeadersWidth = 51;
            dgvPurchase.Size = new Size(1813, 711);
            dgvPurchase.TabIndex = 7;
            dgvPurchase.CellClick += dgvPurchase_CellClick;
            dgvPurchase.CellDoubleClick += dgvPurchase_CellDoubleClick;
            // 
            // txtProduct
            // 
            txtProduct.Location = new Point(246, 906);
            txtProduct.Margin = new Padding(6);
            txtProduct.Name = "txtProduct";
            txtProduct.Size = new Size(416, 47);
            txtProduct.TabIndex = 10;
            txtProduct.KeyDown += txtProduct_KeyDown;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(733, 1007);
            lblCategory.Margin = new Padding(6, 0, 6, 0);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(134, 41);
            lblCategory.TabIndex = 8;
            lblCategory.Text = "Supplier:";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(21, 920);
            lblProductName.Margin = new Padding(6, 0, 6, 0);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(129, 41);
            lblProductName.TabIndex = 9;
            lblProductName.Text = "Product:";
            // 
            // cboSupplier
            // 
            cboSupplier.FormattingEnabled = true;
            cboSupplier.Location = new Point(954, 1000);
            cboSupplier.Margin = new Padding(6);
            cboSupplier.Name = "cboSupplier";
            cboSupplier.Size = new Size(416, 49);
            cboSupplier.TabIndex = 11;
            // 
            // lblQty
            // 
            lblQty.AutoSize = true;
            lblQty.Location = new Point(26, 1021);
            lblQty.Margin = new Padding(6, 0, 6, 0);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(73, 41);
            lblQty.TabIndex = 8;
            lblQty.Text = "Qty:";
            // 
            // txtQty
            // 
            txtQty.Location = new Point(246, 1007);
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
            lblGrandTotal.Location = new Point(733, 900);
            lblGrandTotal.Margin = new Padding(6, 0, 6, 0);
            lblGrandTotal.Name = "lblGrandTotal";
            lblGrandTotal.Size = new Size(177, 41);
            lblGrandTotal.TabIndex = 8;
            lblGrandTotal.Text = "Grand Total:";
            // 
            // lblGrandTotalOutput
            // 
            lblGrandTotalOutput.AutoSize = true;
            lblGrandTotalOutput.Location = new Point(954, 900);
            lblGrandTotalOutput.Margin = new Padding(6, 0, 6, 0);
            lblGrandTotalOutput.Name = "lblGrandTotalOutput";
            lblGrandTotalOutput.Size = new Size(34, 41);
            lblGrandTotalOutput.TabIndex = 8;
            lblGrandTotalOutput.Text = "0";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(1443, 882);
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
            btnCancel.Location = new Point(1443, 998);
            btnCancel.Margin = new Padding(6);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(289, 80);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel (F3)";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // PurchaseForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(3098, 1285);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cboSupplier);
            Controls.Add(txtQty);
            Controls.Add(txtProduct);
            Controls.Add(lblGrandTotalOutput);
            Controls.Add(lblGrandTotal);
            Controls.Add(lblQty);
            Controls.Add(lblCategory);
            Controls.Add(lblProductName);
            Controls.Add(dgvPurchase);
            Controls.Add(btnExit);
            Controls.Add(lblPurchaseHeader);
            Margin = new Padding(6);
            Name = "PurchaseForm";
            Text = "Purchase";
            Load += PurchaseForm_Load;
            KeyDown += PurchaseForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dgvPurchase).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        private Button btnExit;
        private Label lblPurchaseHeader;
        private DataGridView dgvPurchase;
        private TextBox txtProduct;
        private Label lblCategory;
        private Label lblProductName;
        private ComboBox cboSupplier;
        private Label lblQty;
        private TextBox txtQty;
        private Label lblGrandTotal;
        private Label lblGrandTotalOutput;
        private Button btnSave;
        private Button btnCancel;

        #endregion
    }
}