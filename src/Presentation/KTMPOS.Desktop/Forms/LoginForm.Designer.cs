namespace KTMPOS.Desktop.Forms
{
    partial class LoginForm
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
            txtUserName = new TextBox();
            lblUserName = new Label();
            lblHeader = new Label();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnCancel = new Button();
            btnSave = new Button();
            SuspendLayout();
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(229, 97);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(404, 47);
            txtUserName.TabIndex = 5;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(29, 103);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(164, 41);
            lblUserName.TabIndex = 4;
            lblUserName.Text = "UserName:";
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Location = new Point(832, 26);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(92, 41);
            lblHeader.TabIndex = 3;
            lblHeader.Text = "Login";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(29, 183);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(150, 41);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(229, 177);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(404, 47);
            txtPassword.TabIndex = 5;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(537, 264);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(285, 78);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel (F3)";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(228, 264);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(285, 78);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save (F2)";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1892, 762);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtPassword);
            Controls.Add(txtUserName);
            Controls.Add(lblPassword);
            Controls.Add(lblUserName);
            Controls.Add(lblHeader);
            Name = "LoginForm";
            Text = "LoginForm";
            KeyDown += LoginForm_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUserName;
        private Label lblUserName;
        private Label lblHeader;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnCancel;
        private Button btnSave;
    }
}