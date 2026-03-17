namespace KTMPOS.Desktop.Forms
{
    partial class POSMainForm
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
            menuStrip1 = new MenuStrip();
            inventoryToolStripMenuItem = new ToolStripMenuItem();
            categoryToolStripMenuItem = new ToolStripMenuItem();
            subCategoryToolStripMenuItem = new ToolStripMenuItem();
            productToolStripMenuItem = new ToolStripMenuItem();
            purchaseBillingToolStripMenuItem = new ToolStripMenuItem();
            supplierToolStripMenuItem = new ToolStripMenuItem();
            purchaseToolStripMenuItem = new ToolStripMenuItem();
            pOSToolStripMenuItem = new ToolStripMenuItem();
            salesToolStripMenuItem = new ToolStripMenuItem();
            reportingToolStripMenuItem = new ToolStripMenuItem();
            salesToolStripMenuItem1 = new ToolStripMenuItem();
            revenueToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(40, 40);
            menuStrip1.Items.AddRange(new ToolStripItem[] { inventoryToolStripMenuItem, purchaseBillingToolStripMenuItem, pOSToolStripMenuItem, reportingToolStripMenuItem, exitToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1791, 52);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // inventoryToolStripMenuItem
            // 
            inventoryToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { categoryToolStripMenuItem, subCategoryToolStripMenuItem, productToolStripMenuItem });
            inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            inventoryToolStripMenuItem.Size = new Size(167, 48);
            inventoryToolStripMenuItem.Text = "Inventory";
            // 
            // categoryToolStripMenuItem
            // 
            categoryToolStripMenuItem.Name = "categoryToolStripMenuItem";
            categoryToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D1;
            categoryToolStripMenuItem.Size = new Size(465, 54);
            categoryToolStripMenuItem.Text = "Category";
            categoryToolStripMenuItem.Click += categoryToolStripMenuItem_Click;
            // 
            // subCategoryToolStripMenuItem
            // 
            subCategoryToolStripMenuItem.Name = "subCategoryToolStripMenuItem";
            subCategoryToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D2;
            subCategoryToolStripMenuItem.Size = new Size(465, 54);
            subCategoryToolStripMenuItem.Text = "Sub Category";
            subCategoryToolStripMenuItem.Click += subCategoryToolStripMenuItem_Click;
            // 
            // productToolStripMenuItem
            // 
            productToolStripMenuItem.Name = "productToolStripMenuItem";
            productToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D3;
            productToolStripMenuItem.Size = new Size(465, 54);
            productToolStripMenuItem.Text = "Product";
            productToolStripMenuItem.Click += productToolStripMenuItem_Click;
            // 
            // purchaseBillingToolStripMenuItem
            // 
            purchaseBillingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { supplierToolStripMenuItem, purchaseToolStripMenuItem });
            purchaseBillingToolStripMenuItem.Name = "purchaseBillingToolStripMenuItem";
            purchaseBillingToolStripMenuItem.Size = new Size(249, 48);
            purchaseBillingToolStripMenuItem.Text = "Purchase Billing";
            // 
            // supplierToolStripMenuItem
            // 
            supplierToolStripMenuItem.Name = "supplierToolStripMenuItem";
            supplierToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D4;
            supplierToolStripMenuItem.Size = new Size(404, 54);
            supplierToolStripMenuItem.Text = "Supplier";
            supplierToolStripMenuItem.Click += supplierToolStripMenuItem_Click;
            // 
            // purchaseToolStripMenuItem
            // 
            purchaseToolStripMenuItem.Name = "purchaseToolStripMenuItem";
            purchaseToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D5;
            purchaseToolStripMenuItem.Size = new Size(404, 54);
            purchaseToolStripMenuItem.Text = "Purchase";
            purchaseToolStripMenuItem.Click += purchaseToolStripMenuItem_Click;
            // 
            // pOSToolStripMenuItem
            // 
            pOSToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { salesToolStripMenuItem });
            pOSToolStripMenuItem.Name = "pOSToolStripMenuItem";
            pOSToolStripMenuItem.Size = new Size(98, 48);
            pOSToolStripMenuItem.Text = "POS";
            // 
            // salesToolStripMenuItem
            // 
            salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            salesToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D6;
            salesToolStripMenuItem.Size = new Size(352, 54);
            salesToolStripMenuItem.Text = "Sales";
            salesToolStripMenuItem.Click += salesToolStripMenuItem_Click;
            // 
            // reportingToolStripMenuItem
            // 
            reportingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { salesToolStripMenuItem1, revenueToolStripMenuItem });
            reportingToolStripMenuItem.Name = "reportingToolStripMenuItem";
            reportingToolStripMenuItem.Size = new Size(173, 48);
            reportingToolStripMenuItem.Text = "Reporting";
            // 
            // salesToolStripMenuItem1
            // 
            salesToolStripMenuItem1.Name = "salesToolStripMenuItem1";
            salesToolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.D7;
            salesToolStripMenuItem1.Size = new Size(448, 54);
            salesToolStripMenuItem1.Text = "Sales";
            salesToolStripMenuItem1.Click += salesToolStripMenuItem1_Click;
            // 
            // revenueToolStripMenuItem
            // 
            revenueToolStripMenuItem.Name = "revenueToolStripMenuItem";
            revenueToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D8;
            revenueToolStripMenuItem.Size = new Size(448, 54);
            revenueToolStripMenuItem.Text = "Revenue";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D9;
            exitToolStripMenuItem.Size = new Size(88, 48);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // POSMainForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1791, 1429);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(8, 9, 8, 9);
            Name = "POSMainForm";
            Text = "POSMainForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem inventoryToolStripMenuItem;
        private ToolStripMenuItem categoryToolStripMenuItem;
        private ToolStripMenuItem subCategoryToolStripMenuItem;
        private ToolStripMenuItem productToolStripMenuItem;
        private ToolStripMenuItem purchaseBillingToolStripMenuItem;
        private ToolStripMenuItem supplierToolStripMenuItem;
        private ToolStripMenuItem purchaseToolStripMenuItem;
        private ToolStripMenuItem pOSToolStripMenuItem;
        private ToolStripMenuItem salesToolStripMenuItem;
        private ToolStripMenuItem reportingToolStripMenuItem;
        private ToolStripMenuItem salesToolStripMenuItem1;
        private ToolStripMenuItem revenueToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}



