using KTMPOS.BAL.Services.PurchaseBilling;
using KTMPOS.Common.Enumerations;
using KTMPOS.Common.Model.Common;
using KTMPOS.Common.Model.Inventory.Categories;
using KTMPOS.Common.Model.PurchaseBilling;
using KTMPOS.DAL.Entities.PurchaseBilling;
using KTMPOS.Desktop.Utilities;

using System.Data;

using Message = KTMPOS.Common.Constants.Message;

namespace KTMPOS.Desktop.Forms.Childs.PurchaseBilling
{
    public partial class SupplierForm : Form
    {
        #region Initialization

        private int _id;
        private int _userId;
        private List<SupplierRead> _suppliers;
        private readonly ISupplierService _supplierService;

        #endregion Initialization

        #region Constructors

        public SupplierForm(ISupplierService supplierService)
        {
            InitializeComponent();
            InitializeFormComponent();
            _id = 0;
            _userId = 0;
            _suppliers = [];
            _supplierService = supplierService;
        }

        #endregion Constructors

        #region Events

        private async void SupplierForm_Load(object sender, EventArgs e)
        {
            if(MdiParent is POSMainForm posMain)
            {
                _userId = posMain.UserId;
            }

            await LoadGridAsync();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await UpsertAsync();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetControls();
        }

        private async void SupplierForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F2)
            {
                await UpsertAsync();
            }
            else if(e.KeyCode == Keys.F3)
            {
                await UpdateAsync();
            }
            else if(e.KeyCode == Keys.F4)
            {
                await DeleteAsync();
            }
            else if(e.KeyCode == Keys.F5)
            {
                ResetControls();
            }
            else if(e.KeyCode == Keys.F10)
            {
                Close();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text;
            if(String.IsNullOrWhiteSpace(searchText))
            {
                dgvSupplier.DataSource = _suppliers;
            }
            else
            {
                var filteredRecords = _suppliers
                                      .Where(x => x.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) || x.ContactPerson.Contains(searchText, StringComparison.OrdinalIgnoreCase) || x.EmailAddress.Contains(searchText, StringComparison.OrdinalIgnoreCase) || x.PhoneNumber.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                                      .ToList();
                dgvSupplier.DataSource = filteredRecords;
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            await UpdateAsync();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            await DeleteAsync();
        }

        private async void dgvSupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _id = (int)dgvSupplier.CurrentRow.Cells[nameof(SupplierRead.Id)].Value;
            var result = await _supplierService.GetByIdAsync(_id);
            if(result.Status == Status.Failed)
            {
                DialogMessage.FailedAlert(result);
            }
            else
            {
                var record = result.Data.FirstOrDefault();
                if(record is not null)
                {
                    txtSupplierName.Text = record.Name;
                    txtContactPerson.Text = record.ContactPerson;
                    txtEmailAddress.Text = record.EmailAddress;
                    txtPhoneNumber.Text = record.PhoneNumber;
                    txtAddress.Text = record.Address;
                }
            }
        }

        #endregion Events

        #region Methods

        private void InitializeFormComponent()
        {
            KeyPreview = true;
            this.AcceptButton = btnSave;
            txtSupplierName.TabIndex = 0;
            txtContactPerson.TabIndex = 1;
            txtPhoneNumber.TabIndex = 2;
            txtEmailAddress.TabIndex = 3;
            txtAddress.TabIndex = 4;
            btnSave.TabIndex = 5;
            btnUpdate.TabIndex = 6;
            btnDelete.TabIndex = 7;
        }

        private async Task LoadGridAsync()
        {
            dgvSupplier.AutoGenerateColumns = false;
            dgvSupplier.ReadOnly = true;
            dgvSupplier.RowHeadersVisible = false;

            dgvSupplier.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SupplierRead.SN),
                HeaderText = "S.N.",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SupplierRead.SN)
            });
            dgvSupplier.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SupplierRead.Id),
                HeaderText = "Id",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SupplierRead.Id)
            });
            dgvSupplier.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SupplierRead.Name),
                HeaderText = "Name",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SupplierRead.Name),
                Width = 200
            });
            dgvSupplier.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SupplierRead.ContactPerson),
                HeaderText = "Contact Person",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SupplierRead.ContactPerson),
                Width = 200
            });
            dgvSupplier.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SupplierRead.PhoneNumber),
                HeaderText = "Phone",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SupplierRead.PhoneNumber),
                Width = 200
            });
            dgvSupplier.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SupplierRead.EmailAddress),
                HeaderText = "Email",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SupplierRead.EmailAddress),
                Width = 200
            });
            dgvSupplier.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SupplierRead.Address),
                HeaderText = "Address",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SupplierRead.Address),
                Width = 200
            });
            dgvSupplier.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SupplierRead.CreatedBy),
                HeaderText = "Created By",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SupplierRead.CreatedBy)
            });
            dgvSupplier.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SupplierRead.CreatedDate),
                HeaderText = "Created Date",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SupplierRead.CreatedDate)
            });
            dgvSupplier.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SupplierRead.ModifiedBy),
                HeaderText = "Modified By",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SupplierRead.ModifiedBy),
                Width = 200
            });
            dgvSupplier.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SupplierRead.ModifiedDate),
                HeaderText = "Modified Date",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SupplierRead.ModifiedDate),
                Width = 200
            });
            await LoadSuppliersAsync();
        }

        private async Task LoadSuppliersAsync()
        {
            var result = await _supplierService.GetAllAsync();
            if(result.Status == Status.Success)
            {
                _suppliers = result.Data;
                dgvSupplier.DataSource = _suppliers;
            }
        }

        private async Task UpsertAsync(int id = 0)
        {
            _id = id;
            try
            {
                string name = txtSupplierName.Text;
                string contactPerson = txtContactPerson.Text;
                string emailAddress = txtEmailAddress.Text;
                string phoneNumber = txtPhoneNumber.Text;
                string address = txtAddress.Text;
                Output result = null;
                if(_id > 0)
                {
                    SupplierUpdate request = new()
                    {
                        Id = _id,
                        Name = name,
                        ContactPerson = contactPerson,
                        Address = address,
                        EmailAddress = emailAddress,
                        PhoneNumber = phoneNumber,
                        CreatedBy = _userId
                    };
                    result = await _supplierService.UpdateAsync(request);
                }
                else
                {
                    SupplierCreate request = new()
                    {
                        Name = name,
                        ContactPerson = contactPerson,
                        Address = address,
                        EmailAddress = emailAddress,
                        PhoneNumber = phoneNumber,
                        CreatedBy = _userId
                    };
                    result = await _supplierService.SaveAsync(request);
                }

                await OnSuccessAsync(result);
            }
            catch(Exception ex)
            {
                DialogMessage.FailedAlert(ex.Message);
            }
        }

        private async Task OnSuccessAsync(Output result)
        {
            if(result.Status == Status.Success)
            {
                ResetControls();
                await LoadSuppliersAsync();
                DialogMessage.SuccessAlert(result.Message);
            }
            else
            {
                DialogMessage.FailedAlert(result);
            }
        }

        private void ResetControls()
        {
            btnSave.Enabled = true;
            txtSupplierName.Clear();
            txtContactPerson.Clear();
            txtPhoneNumber.Clear();
            txtEmailAddress.Clear();
            txtAddress.Clear();
            txtSupplierName.Focus();
            _id = 0;
        }

        private async Task UpdateAsync()
        {
            if(_id > 0)
            {
                await UpsertAsync(_id);
                return;
            }

            DialogMessage.FailedAlert(Message.EmptyRecord);
        }

        private async Task DeleteAsync()
        {
            DialogResult confirmResult = DialogMessage.ConfirmAlert();
            if(confirmResult == DialogResult.Yes)
            {
                if(_id > 0)
                {
                    Output result = await _supplierService.DeleteAsync(_id);
                    await OnSuccessAsync(result);
                    return;
                }

                DialogMessage.FailedAlert(Message.EmptyRecord);
                return;
            }

            ResetControls();
        }

        #endregion Methods
    }
}