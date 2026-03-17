namespace KTMPOS.Desktop.Forms.Childs.PurchaseBilling
{
    partial class SupplierForm
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
            lblSupplierName = new Label();
            txtSupplierName = new TextBox();
            lblContactPerson = new Label();
            txtContactPerson = new TextBox();
            lblPhoneNumber = new Label();
            txtPhoneNumber = new TextBox();
            lblEmailAddress = new Label();
            txtEmailAddress = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            btnExit = new Button();
            lblProductHeader = new Label();
            btnCancel = new Button();
            btnDelete = new Button();
            txtSearch = new TextBox();
            dgvSupplier = new DataGridView();
            btnUpdate = new Button();
            btnSave = new Button();
            lblSearch = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSupplier).BeginInit();
            SuspendLayout();
            // 
            // lblSupplierName
            // 
            lblSupplierName.AutoSize = true;
            lblSupplierName.Location = new Point(26, 199);
            lblSupplierName.Margin = new Padding(6, 0, 6, 0);
            lblSupplierName.Name = "lblSupplierName";
            lblSupplierName.Size = new Size(221, 41);
            lblSupplierName.TabIndex = 0;
            lblSupplierName.Text = "Supplier Name:";
            // 
            // txtSupplierName
            // 
            txtSupplierName.Location = new Point(293, 199);
            txtSupplierName.Margin = new Padding(6);
            txtSupplierName.Name = "txtSupplierName";
            txtSupplierName.Size = new Size(420, 47);
            txtSupplierName.TabIndex = 1;
            // 
            // lblContactPerson
            // 
            lblContactPerson.AutoSize = true;
            lblContactPerson.Location = new Point(26, 271);
            lblContactPerson.Margin = new Padding(6, 0, 6, 0);
            lblContactPerson.Name = "lblContactPerson";
            lblContactPerson.Size = new Size(226, 41);
            lblContactPerson.TabIndex = 2;
            lblContactPerson.Text = "Contact Person:";
            // 
            // txtContactPerson
            // 
            txtContactPerson.Location = new Point(293, 271);
            txtContactPerson.Margin = new Padding(6);
            txtContactPerson.Name = "txtContactPerson";
            txtContactPerson.Size = new Size(420, 47);
            txtContactPerson.TabIndex = 3;
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Location = new Point(26, 342);
            lblPhoneNumber.Margin = new Padding(6, 0, 6, 0);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(227, 41);
            lblPhoneNumber.TabIndex = 4;
            lblPhoneNumber.Text = "Phone Number:";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(293, 342);
            txtPhoneNumber.Margin = new Padding(6);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(420, 47);
            txtPhoneNumber.TabIndex = 5;
            // 
            // lblEmailAddress
            // 
            lblEmailAddress.AutoSize = true;
            lblEmailAddress.Location = new Point(26, 414);
            lblEmailAddress.Margin = new Padding(6, 0, 6, 0);
            lblEmailAddress.Name = "lblEmailAddress";
            lblEmailAddress.Size = new Size(210, 41);
            lblEmailAddress.TabIndex = 6;
            lblEmailAddress.Text = "Email Address:";
            // 
            // txtEmailAddress
            // 
            txtEmailAddress.Location = new Point(293, 414);
            txtEmailAddress.Margin = new Padding(6);
            txtEmailAddress.Name = "txtEmailAddress";
            txtEmailAddress.Size = new Size(420, 47);
            txtEmailAddress.TabIndex = 7;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(26, 486);
            lblAddress.Margin = new Padding(6, 0, 6, 0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(132, 41);
            lblAddress.TabIndex = 8;
            lblAddress.Text = "Address:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(293, 486);
            txtAddress.Margin = new Padding(6);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(420, 47);
            txtAddress.TabIndex = 9;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.Location = new Point(1910, 8);
            btnExit.Margin = new Padding(6);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(257, 80);
            btnExit.TabIndex = 19;
            btnExit.Text = "Exit (F10)";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // lblProductHeader
            // 
            lblProductHeader.Anchor = AnchorStyles.Top;
            lblProductHeader.AutoSize = true;
            lblProductHeader.Location = new Point(827, 27);
            lblProductHeader.Margin = new Padding(6, 0, 6, 0);
            lblProductHeader.Name = "lblProductHeader";
            lblProductHeader.Size = new Size(312, 41);
            lblProductHeader.TabIndex = 18;
            lblProductHeader.Text = "Supplier Management";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(858, 576);
            btnCancel.Margin = new Padding(6);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(257, 80);
            btnCancel.TabIndex = 27;
            btnCancel.Text = "Cancel (F5)";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(589, 576);
            btnDelete.Margin = new Padding(6);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(257, 80);
            btnDelete.TabIndex = 28;
            btnDelete.Text = "Delete (F4)";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(1817, 662);
            txtSearch.Margin = new Padding(6);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(314, 47);
            txtSearch.TabIndex = 26;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // dgvSupplier
            // 
            dgvSupplier.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSupplier.Location = new Point(38, 738);
            dgvSupplier.Margin = new Padding(6);
            dgvSupplier.Name = "dgvSupplier";
            dgvSupplier.RowHeadersWidth = 51;
            dgvSupplier.Size = new Size(2095, 800);
            dgvSupplier.TabIndex = 25;
            dgvSupplier.CellDoubleClick += dgvSupplier_CellDoubleClick;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(314, 576);
            btnUpdate.Margin = new Padding(6);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(257, 80);
            btnUpdate.TabIndex = 23;
            btnUpdate.Text = "Update (F3)";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(38, 576);
            btnSave.Margin = new Padding(6);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(257, 80);
            btnSave.TabIndex = 24;
            btnSave.Text = "Save (F2)";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(1685, 668);
            lblSearch.Margin = new Padding(6, 0, 6, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(113, 41);
            lblSearch.TabIndex = 22;
            lblSearch.Text = "Search:";
            // 
            // SupplierForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2178, 1517);
            Controls.Add(btnCancel);
            Controls.Add(btnDelete);
            Controls.Add(txtSearch);
            Controls.Add(dgvSupplier);
            Controls.Add(btnUpdate);
            Controls.Add(btnSave);
            Controls.Add(lblSearch);
            Controls.Add(btnExit);
            Controls.Add(lblProductHeader);
            Controls.Add(lblSupplierName);
            Controls.Add(txtSupplierName);
            Controls.Add(lblContactPerson);
            Controls.Add(txtContactPerson);
            Controls.Add(lblPhoneNumber);
            Controls.Add(txtPhoneNumber);
            Controls.Add(lblEmailAddress);
            Controls.Add(txtEmailAddress);
            Controls.Add(lblAddress);
            Controls.Add(txtAddress);
            Margin = new Padding(6);
            Name = "SupplierForm";
            Text = "Supplier";
            Load += SupplierForm_Load;
            KeyDown += SupplierForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dgvSupplier).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblSupplierName;
        private TextBox txtSupplierName;
        private Label lblContactPerson;
        private TextBox txtContactPerson;
        private Label lblPhoneNumber;
        private TextBox txtPhoneNumber;
        private Label lblEmailAddress;
        private TextBox txtEmailAddress;
        private Label lblAddress;
        private TextBox txtAddress;

        #endregion

        private Button btnExit;
        private Label lblProductHeader;
        private Button btnCancel;
        private Button btnDelete;
        private TextBox txtSearch;
        private DataGridView dgvSupplier;
        private Button btnUpdate;
        private Button btnSave;
        private Label lblSearch;
    }
}