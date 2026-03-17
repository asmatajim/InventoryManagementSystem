namespace KTMPOS.Desktop.Forms.Childs.Inventory
{
    partial class CategoryForm
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

        private void InitializeComponent()
        {
            lblCategoryHeader = new Label();
            lblCategoryName = new Label();
            txtCategoryName = new TextBox();
            btnSave = new Button();
            btnExit = new Button();
            dgvCategory = new DataGridView();
            btnUpdate = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            btnDelete = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCategory).BeginInit();
            SuspendLayout();
            // 
            // lblCategoryHeader
            // 
            lblCategoryHeader.Anchor = AnchorStyles.Top;
            lblCategoryHeader.AutoSize = true;
            lblCategoryHeader.Location = new Point(1003, 18);
            lblCategoryHeader.Margin = new Padding(6, 0, 6, 0);
            lblCategoryHeader.Name = "lblCategoryHeader";
            lblCategoryHeader.Size = new Size(324, 41);
            lblCategoryHeader.TabIndex = 0;
            lblCategoryHeader.Text = "Category Management";
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Location = new Point(60, 105);
            lblCategoryName.Margin = new Padding(6, 0, 6, 0);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(104, 41);
            lblCategoryName.TabIndex = 1;
            lblCategoryName.Text = "Name:";
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(183, 100);
            txtCategoryName.Margin = new Padding(6);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(416, 47);
            txtCategoryName.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(70, 207);
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
            btnExit.Location = new Point(2191, 10);
            btnExit.Margin = new Padding(6);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(257, 80);
            btnExit.TabIndex = 4;
            btnExit.Text = "Exit (F10)";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // dgvCategory
            // 
            dgvCategory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategory.Location = new Point(70, 375);
            dgvCategory.Margin = new Padding(6);
            dgvCategory.Name = "dgvCategory";
            dgvCategory.RowHeadersWidth = 51;
            dgvCategory.Size = new Size(2344, 625);
            dgvCategory.TabIndex = 5;
            dgvCategory.CellDoubleClick += dgvCategory_CellDoubleClick;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(346, 207);
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
            txtSearch.Location = new Point(2091, 308);
            txtSearch.Margin = new Padding(6);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(314, 47);
            txtSearch.TabIndex = 6;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(1966, 314);
            lblSearch.Margin = new Padding(6, 0, 6, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(113, 41);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Search:";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(620, 207);
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
            btnCancel.Location = new Point(890, 207);
            btnCancel.Margin = new Padding(6);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(257, 80);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel (F5)";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // CategoryForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2465, 1009);
            Controls.Add(btnCancel);
            Controls.Add(btnDelete);
            Controls.Add(txtSearch);
            Controls.Add(dgvCategory);
            Controls.Add(btnExit);
            Controls.Add(btnUpdate);
            Controls.Add(btnSave);
            Controls.Add(txtCategoryName);
            Controls.Add(lblSearch);
            Controls.Add(lblCategoryName);
            Controls.Add(lblCategoryHeader);
            Margin = new Padding(6);
            Name = "CategoryForm";
            Text = "Category";
            Load += CategoryForm_Load;
            KeyDown += CategoryForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dgvCategory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCategoryHeader;
        private Label lblCategoryName;
        private TextBox txtCategoryName;
        private Button btnSave;
        private Button btnExit;
        private DataGridView dgvCategory;
        private Button btnUpdate;
        private TextBox txtSearch;
        private Label lblSearch;
        private Button btnDelete;
        private Button btnCancel;

    }
}