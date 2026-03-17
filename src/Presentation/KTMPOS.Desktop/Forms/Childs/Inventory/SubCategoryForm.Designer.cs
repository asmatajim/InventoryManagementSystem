namespace KTMPOS.Desktop.Forms.Childs.Inventory
{
    partial class SubCategoryForm
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
            lblSubCategoryHeader = new Label();
            lblCategoryName = new Label();
            txtSubCategoryName = new TextBox();
            btnSave = new Button();
            btnExit = new Button();
            dgvSubCategory = new DataGridView();
            btnUpdate = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            btnDelete = new Button();
            btnCancel = new Button();
            lblCategory = new Label();
            cboCategory = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvSubCategory).BeginInit();
            SuspendLayout();
            // 
            // lblSubCategoryHeader
            // 
            lblSubCategoryHeader.Anchor = AnchorStyles.Top;
            lblSubCategoryHeader.AutoSize = true;
            lblSubCategoryHeader.Location = new Point(1218, 18);
            lblSubCategoryHeader.Margin = new Padding(6, 0, 6, 0);
            lblSubCategoryHeader.Name = "lblSubCategoryHeader";
            lblSubCategoryHeader.Size = new Size(383, 41);
            lblSubCategoryHeader.TabIndex = 0;
            lblSubCategoryHeader.Text = "Sub Category Management";
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Location = new Point(62, 242);
            lblCategoryName.Margin = new Padding(6, 0, 6, 0);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(104, 41);
            lblCategoryName.TabIndex = 1;
            lblCategoryName.Text = "Name:";
            // 
            // txtSubCategoryName
            // 
            txtSubCategoryName.Location = new Point(232, 236);
            txtSubCategoryName.Margin = new Padding(6);
            txtSubCategoryName.Name = "txtSubCategoryName";
            txtSubCategoryName.Size = new Size(416, 47);
            txtSubCategoryName.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(72, 344);
            btnSave.Margin = new Padding(6);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(257, 80);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save (F2)";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.Location = new Point(2622, 10);
            btnExit.Margin = new Padding(6);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(257, 80);
            btnExit.TabIndex = 4;
            btnExit.Text = "Exit (F10)";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // dgvSubCategory
            // 
            dgvSubCategory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSubCategory.Location = new Point(66, 558);
            dgvSubCategory.Margin = new Padding(6);
            dgvSubCategory.Name = "dgvSubCategory";
            dgvSubCategory.RowHeadersWidth = 51;
            dgvSubCategory.Size = new Size(2769, 711);
            dgvSubCategory.TabIndex = 5;
            dgvSubCategory.CellDoubleClick += dgvSubCategory_CellDoubleClick;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(348, 344);
            btnUpdate.Margin = new Padding(6);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(257, 80);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Update (F3)";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(2516, 484);
            txtSearch.Margin = new Padding(6);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(314, 47);
            txtSearch.TabIndex = 6;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(2388, 490);
            lblSearch.Margin = new Padding(6, 0, 6, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(113, 41);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Search:";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(623, 344);
            btnDelete.Margin = new Padding(6);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(257, 80);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete (F4)";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(892, 344);
            btnCancel.Margin = new Padding(6);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(257, 80);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel (F5)";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(66, 133);
            lblCategory.Margin = new Padding(6, 0, 6, 0);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(146, 41);
            lblCategory.TabIndex = 1;
            lblCategory.Text = "Category:";
            // 
            // cboCategory
            // 
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(232, 127);
            cboCategory.Margin = new Padding(6);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(416, 49);
            cboCategory.TabIndex = 9;
            // 
            // SubCategoryForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2896, 1273);
            Controls.Add(cboCategory);
            Controls.Add(btnCancel);
            Controls.Add(btnDelete);
            Controls.Add(txtSearch);
            Controls.Add(dgvSubCategory);
            Controls.Add(btnExit);
            Controls.Add(btnUpdate);
            Controls.Add(btnSave);
            Controls.Add(txtSubCategoryName);
            Controls.Add(lblSearch);
            Controls.Add(lblCategory);
            Controls.Add(lblCategoryName);
            Controls.Add(lblSubCategoryHeader);
            Margin = new Padding(6);
            Name = "SubCategoryForm";
            Text = "Sub Category";
            Load += SubCategoryForm_Load;
            KeyDown += SubCategoryForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dgvSubCategory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSubCategoryHeader;
        private Label lblCategoryName;
        private TextBox txtSubCategoryName;
        private Button btnSave;
        private Button btnExit;
        private DataGridView dgvSubCategory;
        private Button btnUpdate;
        private TextBox txtSearch;
        private Label lblSearch;
        private Button btnDelete;
        private Button btnCancel;
        private Label lblCategory;
        private ComboBox cboCategory;

    }
}