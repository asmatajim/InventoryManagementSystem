using KTMPOS.BAL.Services.Reporting;
using KTMPOS.Common.Enumerations;
using KTMPOS.Common.Model.Common;
using KTMPOS.Common.Model.Reporting;

using System.Net.Http.Json;

namespace KTMPOS.Desktop.Forms.Childs.Reporting
{
    public partial class SalesReportForm : Form
    {
        #region Initialization

        private readonly ISalesReportService _salesReportService;

        #endregion Initialization

        #region Constructors

        public SalesReportForm(ISalesReportService salesReportService)
        {
            _salesReportService = salesReportService;
            InitializeComponent();
            LoadSalesReportGrid();
        }

        #endregion Constructors

        #region Events

        private async void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cboFilter.Text;
            var result = await GetSalesReportAsync(selectedValue);
            if(result.Status == Status.Success)
            {
                dgvSalesReport.DataSource = null;
                dgvSalesReport.DataSource = result.Data;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion Events

        #region Methods

        private void LoadSalesReportGrid()
        {
            dgvSalesReport.AutoGenerateColumns = false;
            dgvSalesReport.ReadOnly = true;
            dgvSalesReport.RowHeadersVisible = false;

            dgvSalesReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SN",
                HeaderText = "S.N.",
                DataPropertyName = nameof(SalesReport.SN),
                Width = 100,
            });
            dgvSalesReport.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SalesReport.TotalGrossAmount),
                HeaderText = "Total Gross Amount",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SalesReport.TotalGrossAmount),
                Width = 300
            });
            dgvSalesReport.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SalesReport.TotalDiscountAmount),
                HeaderText = "Total Discount Amount",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SalesReport.TotalDiscountAmount),
                Width = 300
            });
            dgvSalesReport.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SalesReport.TotalNetAmount),
                HeaderText = "Total Net Amount",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SalesReport.TotalNetAmount),
                Width = 300
            });
            dgvSalesReport.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SalesReport.TotalRecords),
                HeaderText = "Total Records",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SalesReport.TotalRecords),
                Width = 300
            });
        }

        private async Task LoadSalesReportTypesAsync()
        {
            var result = await GetSalesReportTypeAsync();
            if(result.Status == Status.Success)
            {
                cboFilter.DataSource = result.Data;
                cboFilter.SelectedIndex = 0;
            }
        }

        private async Task<Output<string>> GetSalesReportTypeAsync()
        {
            HttpClient client = new();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7147/api/report/Get/ReportType");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<Output<string>>();
            return result;
        }

        private async Task<Output<SalesReport>> GetSalesReportAsync(string reportType)
        {
            HttpClient client = new();
            HttpResponseMessage response = await client.GetAsync($"https://localhost:7147/api/report/Get/Report/Sales/{reportType}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<Output<SalesReport>>();
            return result;
        }

        #endregion Methods

        private async void SalesReportForm_Load(object sender, EventArgs e)
        {
            await LoadSalesReportTypesAsync();
        }
    }
}