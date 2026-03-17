namespace KTMPOS.Desktop.Forms.Childs.Inventory
{
    partial class ProductForm
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
            cboCategory = new ComboBox();
            btnCancel = new Button();
            btnDelete = new Button();
            txtSearch = new TextBox();
            dgvProduct = new DataGridView();
            btnExit = new Button();
            btnUpdate = new Button();
            btnSave = new Button();
            txtProductName = new TextBox();
            lblSearch = new Label();
            lblCategory = new Label();
            lblProductName = new Label();
            lblProductHeader = new Label();
            lblSubCategory = new Label();
            cboSubCategory = new ComboBox();
            lblPurchasePrice = new Label();
            txtPurchasePrice = new TextBox();
            lblSellingPrice = new Label();
            txtSellingPrice = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvProduct).BeginInit();
            SuspendLayout();
            // 
            // cboCategory
            // 
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(287, 123);
            cboCategory.Margin = new Padding(6);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(416, 49);
            cboCategory.TabIndex = 22;
            cboCategory.SelectedIndexChanged += cboCategory_SelectedIndexChanged;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(869, 572);
            btnCancel.Margin = new Padding(6);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(257, 80);
            btnCancel.TabIndex = 20;
            btnCancel.Text = "Cancel (F5)";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(599, 572);
            btnDelete.Margin = new Padding(6);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(257, 80);
            btnDelete.TabIndex = 21;
            btnDelete.Text = "Delete (F4)";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(2380, 601);
            txtSearch.Margin = new Padding(6);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(314, 47);
            txtSearch.TabIndex = 19;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // dgvProduct
            // 
            dgvProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProduct.Location = new Point(42, 674);
            dgvProduct.Margin = new Padding(6);
            dgvProduct.Name = "dgvProduct";
            dgvProduct.RowHeadersWidth = 51;
            dgvProduct.Size = new Size(2654, 791);
            dgvProduct.TabIndex = 18;
            dgvProduct.CellDoubleClick += dgvProduct_CellDoubleClick;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.Location = new Point(2429, 14);
            btnExit.Margin = new Padding(6);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(257, 80);
            btnExit.TabIndex = 17;
            btnExit.Text = "Exit (F10)";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(325, 572);
            btnUpdate.Margin = new Padding(6);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(257, 80);
            btnUpdate.TabIndex = 15;
            btnUpdate.Text = "Update (F3)";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(49, 572);
            btnSave.Margin = new Padding(6);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(257, 80);
            btnSave.TabIndex = 16;
            btnSave.Text = "Save (F2)";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(287, 299);
            txtProductName.Margin = new Padding(6);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(416, 47);
            txtProductName.TabIndex = 14;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(2248, 607);
            lblSearch.Margin = new Padding(6, 0, 6, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(113, 41);
            lblSearch.TabIndex = 11;
            lblSearch.Text = "Search:";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(42, 129);
            lblCategory.Margin = new Padding(6, 0, 6, 0);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(146, 41);
            lblCategory.TabIndex = 12;
            lblCategory.Text = "Category:";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(49, 314);
            lblProductName.Margin = new Padding(6, 0, 6, 0);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(104, 41);
            lblProductName.TabIndex = 13;
            lblProductName.Text = "Name:";
            // 
            // lblProductHeader
            // 
            lblProductHeader.Anchor = AnchorStyles.Top;
            lblProductHeader.AutoSize = true;
            lblProductHeader.Location = new Point(1103, 14);
            lblProductHeader.Margin = new Padding(6, 0, 6, 0);
            lblProductHeader.Name = "lblProductHeader";
            lblProductHeader.Size = new Size(307, 41);
            lblProductHeader.TabIndex = 10;
            lblProductHeader.Text = "Product Management";
            // 
            // lblSubCategory
            // 
            lblSubCategory.AutoSize = true;
            lblSubCategory.Location = new Point(42, 217);
            lblSubCategory.Margin = new Padding(6, 0, 6, 0);
            lblSubCategory.Name = "lblSubCategory";
            lblSubCategory.Size = new Size(205, 41);
            lblSubCategory.TabIndex = 12;
            lblSubCategory.Text = "Sub Category:";
            // 
            // cboSubCategory
            // 
            cboSubCategory.FormattingEnabled = true;
            cboSubCategory.Location = new Point(287, 211);
            cboSubCategory.Margin = new Padding(6);
            cboSubCategory.Name = "cboSubCategory";
            cboSubCategory.Size = new Size(416, 49);
            cboSubCategory.TabIndex = 22;
            // 
            // lblPurchasePrice
            // 
            lblPurchasePrice.AutoSize = true;
            lblPurchasePrice.Location = new Point(49, 404);
            lblPurchasePrice.Margin = new Padding(6, 0, 6, 0);
            lblPurchasePrice.Name = "lblPurchasePrice";
            lblPurchasePrice.Size = new Size(216, 41);
            lblPurchasePrice.TabIndex = 13;
            lblPurchasePrice.Text = "Purchase Price:";
            // 
            // txtPurchasePrice
            // 
            txtPurchasePrice.Location = new Point(289, 392);
            txtPurchasePrice.Margin = new Padding(6);
            txtPurchasePrice.Name = "txtPurchasePrice";
            txtPurchasePrice.Size = new Size(416, 47);
            txtPurchasePrice.TabIndex = 14;
            // 
            // lblSellingPrice
            // 
            lblSellingPrice.AutoSize = true;
            lblSellingPrice.Location = new Point(49, 494);
            lblSellingPrice.Margin = new Padding(6, 0, 6, 0);
            lblSellingPrice.Name = "lblSellingPrice";
            lblSellingPrice.Size = new Size(185, 41);
            lblSellingPrice.TabIndex = 13;
            lblSellingPrice.Text = "Selling Price:";
            // 
            // txtSellingPrice
            // 
            txtSellingPrice.Location = new Point(295, 482);
            txtSellingPrice.Margin = new Padding(6);
            txtSellingPrice.Name = "txtSellingPrice";
            txtSellingPrice.Size = new Size(416, 47);
            txtSellingPrice.TabIndex = 14;
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2712, 1490);
            Controls.Add(cboSubCategory);
            Controls.Add(cboCategory);
            Controls.Add(btnCancel);
            Controls.Add(btnDelete);
            Controls.Add(txtSearch);
            Controls.Add(dgvProduct);
            Controls.Add(btnExit);
            Controls.Add(btnUpdate);
            Controls.Add(btnSave);
            Controls.Add(txtSellingPrice);
            Controls.Add(txtPurchasePrice);
            Controls.Add(txtProductName);
            Controls.Add(lblSubCategory);
            Controls.Add(lblSellingPrice);
            Controls.Add(lblSearch);
            Controls.Add(lblPurchasePrice);
            Controls.Add(lblCategory);
            Controls.Add(lblProductName);
            Controls.Add(lblProductHeader);
            Margin = new Padding(6);
            Name = "ProductForm";
            Text = "Product";
            Load += ProductForm_Load;
            KeyDown += ProductForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dgvProduct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboCategory;
        private Button btnCancel;
        private Button btnDelete;
        private TextBox txtSearch;
        private DataGridView dgvProduct;
        private Button btnExit;
        private Button btnUpdate;
        private Button btnSave;
        private TextBox txtProductName;
        private Label lblSearch;
        private Label lblCategory;
        private Label lblProductName;
        private Label lblProductHeader;
        private Label lblSubCategory;
        private ComboBox cboSubCategory;
        private Label lblPurchasePrice;
        private TextBox txtPurchasePrice;
        private Label lblSellingPrice;
        private TextBox txtSellingPrice;

    }
}