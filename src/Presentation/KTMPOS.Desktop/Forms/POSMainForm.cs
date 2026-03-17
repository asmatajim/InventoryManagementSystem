using KTMPOS.Desktop.Forms.Childs.Inventory;
using KTMPOS.Desktop.Forms.Childs.POS;
using KTMPOS.Desktop.Forms.Childs.PurchaseBilling;
using KTMPOS.Desktop.Forms.Childs.Reporting;

using Microsoft.Extensions.DependencyInjection;

namespace KTMPOS.Desktop.Forms
{
    public partial class POSMainForm : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public POSMainForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            this.WindowState = FormWindowState.Maximized;
        }

        public int UserId { get; set; }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm<CategoryForm>();
        }

        private void subCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm<SubCategoryForm>();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm<ProductForm>();
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm<SupplierForm>();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm<PurchaseForm>();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm<SalesForm>();
        }

        private void salesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenChildForm<SalesReportForm>();
        }

        private void OpenChildForm<T>() where T : Form
        {
            var existingForm = MdiChildren.FirstOrDefault(x => x is T);
            if(existingForm is not null)
            {
                existingForm.BringToFront();
                return;
            }

            Form form = _serviceProvider.GetRequiredService<T>() as Form;
            form.MdiParent = this;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            form.ControlBox = false;
            form.Show();
        }
    }
}