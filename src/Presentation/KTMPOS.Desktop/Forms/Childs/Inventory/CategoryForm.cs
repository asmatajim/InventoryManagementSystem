using KTMPOS.BAL.Services.Inventory.Categories;
using KTMPOS.Common.Enumerations;
using KTMPOS.Common.Model.Common;
using KTMPOS.Common.Model.Inventory.Categories;
using KTMPOS.Desktop.Utilities;

using Message = KTMPOS.Common.Constants.Message;

namespace KTMPOS.Desktop.Forms.Childs.Inventory
{
    public partial class CategoryForm : Form
    {
        #region Initialization

        private int _id;
        private int _userId;
        private List<CategoryRead> _categories;
        private readonly ICategoryService _categoryService;

        #endregion Initialization

        #region Constructors

        public CategoryForm(ICategoryService categoryService)
        {
            InitializeComponent();
            InitializeFormComponent();
            _id = 0;
            _userId = 0;
            _categories = [];
            _categoryService = categoryService;
        }

        #endregion Constructors

        #region Events

        private async void CategoryForm_Load(object sender, EventArgs e)
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

        private async void CategoryForm_KeyDown(object sender, KeyEventArgs e)
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
                dgvCategory.DataSource = _categories;
            }
            else
            {
                var filteredRecords = _categories
                                       .Where(x => x.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                                       .ToList();
                dgvCategory.DataSource = filteredRecords;
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

        private async void dgvCategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _id = (int)dgvCategory.CurrentRow.Cells[nameof(CategoryRead.Id)].Value;
            var result = await _categoryService.GetByIdAsync(_id);
            if(result.Status == Status.Failed)
            {
                DialogMessage.FailedAlert(result);
            }
            else
            {
                var record = result.Data.FirstOrDefault();
                if(record is not null)
                {
                    txtCategoryName.Text = record.Name;
                }
            }
        }

        #endregion Events

        #region Methods

        private void InitializeFormComponent()
        {
            KeyPreview = true;
            AcceptButton = btnSave;
            txtCategoryName.TabIndex = 0;
            btnSave.TabIndex = 1;
            btnUpdate.TabIndex = 2;
            btnDelete.TabIndex = 3;
            btnCancel.TabIndex = 4;
            txtSearch.TabIndex = 5;
            btnExit.TabIndex = 6;
        }

        private async Task LoadGridAsync()
        {
            dgvCategory.RowHeadersVisible = false;
            dgvCategory.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(CategoryRead.SN),
                HeaderText = "S.N.",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(CategoryRead.SN)
            });
            dgvCategory.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(CategoryRead.Id),
                HeaderText = "Id",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(CategoryRead.Id)
            });
            dgvCategory.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(CategoryRead.Name),
                HeaderText = "Name",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(CategoryRead.Name)
            });
            dgvCategory.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(CategoryRead.CreatedBy),
                HeaderText = "Created By",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(CategoryRead.CreatedBy)
            });
            dgvCategory.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(CategoryRead.CreatedDate),
                HeaderText = "Created Date",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(CategoryRead.CreatedDate)
            });
            dgvCategory.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(CategoryRead.ModifiedBy),
                HeaderText = "Modified By",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(CategoryRead.ModifiedBy)
            });
            dgvCategory.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(CategoryRead.ModifiedDate),
                HeaderText = "Modified Date",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(CategoryRead.ModifiedDate)
            });
            await LoadCategoriesAsync();
        }

        private async Task LoadCategoriesAsync()
        {
            var result = await _categoryService.GetAllAsync();
            if(result.Status == Status.Success)
            {
                _categories = result.Data;
                dgvCategory.DataSource = _categories;
            }
        }

        private async Task UpsertAsync(int id = 0)
        {
            _id = id;
            try
            {
                string name = txtCategoryName.Text;
                Output result = null;
                if(_id > 0)
                {
                    CategoryUpdate request = new()
                    {
                        Id = _id,
                        Name = name,
                        CreatedBy = _userId
                    };
                    result = await _categoryService.UpdateAsync(request);
                }
                else
                {
                    CategoryCreate request = new()
                    {
                        Name = name,
                        CreatedBy = _userId
                    };
                    result = await _categoryService.SaveAsync(request);
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
                await LoadCategoriesAsync();
                DialogMessage.SuccessAlert(result.Message);
            }
            else
            {
                DialogMessage.FailedAlert(result);
            }
        }

        private void ResetControls()
        {
            txtCategoryName.Clear();
            txtCategoryName.Focus();
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
                    Output result = await _categoryService.DeleteAsync(_id);
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