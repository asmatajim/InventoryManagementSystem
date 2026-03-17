using KTMPOS.BAL.Services.Inventory.Categories;
using KTMPOS.BAL.Services.Inventory.SubCategories;
using KTMPOS.Common.Enumerations;
using KTMPOS.Common.Model.Common;
using KTMPOS.Common.Model.Inventory.SubCategories;
using KTMPOS.Desktop.Utilities;

using Message = KTMPOS.Common.Constants.Message;

namespace KTMPOS.Desktop.Forms.Childs.Inventory
{
    public partial class SubCategoryForm : Form
    {
        #region Initialization

        private int _id;
        private int _userId;
        private List<SubCategoryRead> _subCategories;
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;

        #endregion Initialization

        #region Constructors

        public SubCategoryForm(ICategoryService categoryService, ISubCategoryService subCategoryService)
        {
            InitializeComponent();
            InitializeFormComponent();
            _id = 0;
            _userId = 0;
            _subCategories = [];
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
        }

        #endregion Constructors

        #region Events

        private async void SubCategoryForm_Load(object sender, EventArgs e)
        {
            if(MdiParent is POSMainForm posMain)
            {
                _userId = posMain.UserId;
            }

            await LoadCategoriesAsync();
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

        private async void SubCategoryForm_KeyDown(object sender, KeyEventArgs e)
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
                dgvSubCategory.DataSource = _subCategories;
            }
            else
            {
                var filteredRecords = _subCategories
                                      .Where(x => x.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) || x.Category.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                                      .ToList();
                dgvSubCategory.DataSource = filteredRecords;
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

        private async void dgvSubCategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _id = (int)dgvSubCategory.CurrentRow.Cells[nameof(SubCategoryRead.Id)].Value;
            var result = await _subCategoryService.GetByIdAsync(_id);
            if(result.Status == Status.Failed)
            {
                DialogMessage.FailedAlert(result);
            }
            else
            {
                var record = result.Data.FirstOrDefault();
                if(record is not null)
                {
                    cboCategory.SelectedValue = record.CategoryId;
                    txtSubCategoryName.Text = record.Name;
                }
            }
        }

        #endregion Events

        #region Methods

        private void InitializeFormComponent()
        {
            KeyPreview = true;
            AcceptButton = btnSave;
            cboCategory.TabIndex = 0;
            txtSubCategoryName.TabIndex = 1;
            btnSave.TabIndex = 2;
            btnUpdate.TabIndex = 3;
            btnDelete.TabIndex = 4;
            btnCancel.TabIndex = 5;
            txtSearch.TabIndex = 6;
            btnExit.TabIndex = 7;
        }

        private async Task LoadGridAsync()
        {
            dgvSubCategory.RowHeadersVisible = false;
            dgvSubCategory.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SubCategoryRead.SN),
                HeaderText = "S.N.",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SubCategoryRead.SN)
            });
            dgvSubCategory.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SubCategoryRead.Id),
                HeaderText = "Id",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SubCategoryRead.Id)
            });
            dgvSubCategory.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SubCategoryRead.Name),
                HeaderText = "Name",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SubCategoryRead.Name)
            });
            dgvSubCategory.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SubCategoryRead.Category),
                HeaderText = "Category",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SubCategoryRead.Category)
            });
            dgvSubCategory.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SubCategoryRead.CreatedBy),
                HeaderText = "Created By",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SubCategoryRead.CreatedBy)
            });
            dgvSubCategory.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SubCategoryRead.CreatedDate),
                HeaderText = "Created Date",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SubCategoryRead.CreatedDate)
            });
            dgvSubCategory.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SubCategoryRead.ModifiedBy),
                HeaderText = "Modified By",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SubCategoryRead.ModifiedBy)
            });
            dgvSubCategory.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SubCategoryRead.ModifiedDate),
                HeaderText = "Modified Date",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SubCategoryRead.ModifiedDate)
            });
            await LoadSubCategoriesAsync();
        }

        private async Task LoadSubCategoriesAsync()
        {
            var result = await _subCategoryService.GetAllAsync();
            if(result.Status == Status.Success)
            {
                _subCategories = result.Data;
                dgvSubCategory.DataSource = _subCategories;
            }
        }

        private async Task UpsertAsync(int id = 0)
        {
            _id = id;
            try
            {
                int categoryId = (int)cboCategory.SelectedValue;
                string name = txtSubCategoryName.Text;
                Output result = null;
                if(_id > 0)
                {
                    SubCategoryUpdate request = new()
                    {
                        Id = _id,
                        Name = name,
                        CategoryId = categoryId,
                        CreatedBy = _userId
                    };
                    result = await _subCategoryService.UpdateAsync(request);
                }
                else
                {
                    SubCategoryCreate request = new()
                    {
                        Name = name,
                        CategoryId = categoryId,
                        CreatedBy = _userId
                    };
                    result = await _subCategoryService.SaveAsync(request);
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
                await LoadSubCategoriesAsync();
                DialogMessage.SuccessAlert(result.Message);
            }
            else
            {
                DialogMessage.FailedAlert(result);
            }
        }

        private void ResetControls()
        {
            cboCategory.SelectedIndex = 0;
            txtSubCategoryName.Clear();
            cboCategory.Focus();
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
                    Output result = await _subCategoryService.DeleteAsync(_id);
                    await OnSuccessAsync(result);
                    return;
                }

                DialogMessage.FailedAlert(Message.EmptyRecord);
                return;
            }

            ResetControls();
        }

        private async Task LoadCategoriesAsync()
        {
            var result = await _categoryService.FetchAllAsync();
            List<Dropdown> categories = [];
            if(result.Status == Status.Success)
            {
                categories = result.Data;
            }

            categories.Insert(0, new()
            {
                Id = 0,
                Name = "Please select a category"
            });
            cboCategory.DisplayMember = nameof(Dropdown.Name);
            cboCategory.ValueMember = nameof(Dropdown.Id);
            cboCategory.DataSource = categories;
            cboCategory.SelectedIndex = 0;
        }

        #endregion Methods
    }
}