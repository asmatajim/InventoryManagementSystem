using KTMPOS.BAL.Services.Inventory.Categories;
using KTMPOS.BAL.Services.Inventory.Products;
using KTMPOS.BAL.Services.Inventory.SubCategories;
using KTMPOS.Common.Enumerations;
using KTMPOS.Common.Model.Common;
using KTMPOS.Common.Model.Inventory.Products;
using KTMPOS.DAL.Entities.Inventory;
using KTMPOS.Desktop.Utilities;

using Message = KTMPOS.Common.Constants.Message;

namespace KTMPOS.Desktop.Forms.Childs.Inventory
{
    public partial class ProductForm : Form
    {
        #region Initialization

        private int _id;
        private int _userId;
        private List<ProductRead> _products;
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IProductService _productService;

        #endregion Initialization

        #region Constructors

        public ProductForm(IProductService productService, ICategoryService categoryService,
                           ISubCategoryService subCategoryService)
        {
            InitializeComponent();
            InitializeFormComponent();
            _id = 0;
            _userId = 0;
            _products = [];
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
            _productService = productService;
        }

        #endregion Constructors

        #region Events

        private async void ProductForm_Load(object sender, EventArgs e)
        {
            if(MdiParent is POSMainForm posMain)
            {
                _userId = posMain.UserId;
            }

            await LoadCategoriesAsync();
            await LoadEmptySubCategoriesAsync();
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

        private async void ProductForm_KeyDown(object sender, KeyEventArgs e)
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
                dgvProduct.DataSource = _products;
            }
            else
            {
                var filteredRecords = _products
                                      .Where(x => x.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) || x.Category.Contains(searchText, StringComparison.OrdinalIgnoreCase) || x.SubCategory.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                                      .ToList();
                dgvProduct.DataSource = filteredRecords;
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

        private async void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _id = (int)dgvProduct.CurrentRow.Cells[nameof(ProductRead.Id)].Value;
            var result = await _productService.GetByIdAsync(_id);
            if(result.Status == Status.Failed)
            {
                DialogMessage.FailedAlert(result);
            }
            else
            {
                var record = result.Data.FirstOrDefault();
                if(record is not null)
                {
                    cboCategory.SelectedIndexChanged -= cboCategory_SelectedIndexChanged;
                    cboCategory.SelectedValue = record.CategoryId;
                    await LoadSubCategoriesAsync(record.CategoryId);
                    cboCategory.SelectedIndexChanged += cboCategory_SelectedIndexChanged;
                    cboSubCategory.SelectedValue = record.SubCategoryId;
                    txtProductName.Text = record.Name;
                    txtPurchasePrice.Text = record.PurchasePrice;
                    txtSellingPrice.Text = record.SellingPrice;
                }
            }
        }

        private async void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int categoryId = (int)cboCategory.SelectedValue;
            if(categoryId > 0)
            {
                await LoadSubCategoriesAsync(categoryId);
                return;
            }

            await LoadEmptySubCategoriesAsync();
        }

        #endregion Events

        #region Methods

        private void InitializeFormComponent()
        {
            KeyPreview = true;
            AcceptButton = btnSave;
            cboCategory.TabIndex = 0;
            cboSubCategory.TabIndex = 1;
            txtProductName.TabIndex = 2;
            txtPurchasePrice.TabIndex = 3;
            txtSellingPrice.TabIndex = 4;
            btnSave.TabIndex = 5;
            btnUpdate.TabIndex = 6;
            btnDelete.TabIndex = 7;
            btnCancel.TabIndex = 8;
            txtSearch.TabIndex = 9;
            btnExit.TabIndex = 10;
        }

        private async Task LoadGridAsync()
        {
            dgvProduct.RowHeadersVisible = false;
            dgvProduct.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(ProductRead.SN),
                HeaderText = "S.N.",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(ProductRead.SN)
            });
            dgvProduct.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(ProductRead.Id),
                HeaderText = "Id",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(ProductRead.Id)
            });
            dgvProduct.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(ProductRead.Name),
                HeaderText = "Name",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(ProductRead.Name)
            });
            dgvProduct.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(ProductRead.Category),
                HeaderText = "Category",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(ProductRead.Category)
            });
            dgvProduct.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(ProductRead.SubCategory),
                HeaderText = "Sub Category",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(ProductRead.SubCategory)
            });
            dgvProduct.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(ProductRead.Stock),
                HeaderText = "Stock",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(ProductRead.Stock)
            });
            dgvProduct.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(ProductRead.PurchasePrice),
                HeaderText = "Purchase Price",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(ProductRead.PurchasePrice)
            });
            dgvProduct.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(ProductRead.SellingPrice),
                HeaderText = "Selling Price",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(ProductRead.SellingPrice)
            });
            dgvProduct.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(ProductRead.CreatedBy),
                HeaderText = "Created By",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(ProductRead.CreatedBy)
            });
            dgvProduct.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(ProductRead.CreatedDate),
                HeaderText = "Created Date",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(ProductRead.CreatedDate)
            });
            dgvProduct.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(ProductRead.ModifiedBy),
                HeaderText = "Modified By",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(ProductRead.ModifiedBy)
            });
            dgvProduct.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(ProductRead.ModifiedDate),
                HeaderText = "Modified Date",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(ProductRead.ModifiedDate)
            });
            await LoadProductsAsync();
        }

        private async Task LoadProductsAsync()
        {
            var result = await _productService.GetAllAsync();
            if(result.Status == Status.Success)
            {
                _products = result.Data;
                dgvProduct.DataSource = _products;
            }
        }

        private async Task UpsertAsync(int id = 0)
        {
            _id = id;
            try
            {
                int categoryId = (int)cboCategory.SelectedValue;
                int subCategoryId = (int)cboSubCategory.SelectedValue;
                string name = txtProductName.Text;
                decimal.TryParse(txtPurchasePrice.Text, out decimal purchasePrice);
                decimal.TryParse(txtSellingPrice.Text, out decimal sellingPrice);
                Output result = null;
                if(_id > 0)
                {
                    ProductUpdate request = new()
                    {
                        Id = _id,
                        Name = name,
                        CategoryId = categoryId,
                        SubCategoryId = subCategoryId,
                        PurchasePrice = purchasePrice,
                        SellingPrice = sellingPrice,
                        CreatedBy = _userId
                    };
                    result = await _productService.UpdateAsync(request);
                }
                else
                {
                    ProductCreate request = new()
                    {
                        Name = name,
                        CategoryId = categoryId,
                        SubCategoryId = subCategoryId,
                        PurchasePrice = purchasePrice,
                        SellingPrice = sellingPrice,
                        CreatedBy = _userId
                    };
                    result = await _productService.SaveAsync(request);
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
                await LoadProductsAsync();
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
            cboSubCategory.SelectedIndex = 0;
            txtProductName.Clear();
            txtPurchasePrice.Clear();
            txtSellingPrice.Clear();
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
                    Output result = await _productService.DeleteAsync(_id);
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

        private async Task LoadEmptySubCategoriesAsync()
        {
            List<Dropdown> subCategories = [new()
            {
                Id = 0,
                Name = "Please select a sub category"
            }];
            cboSubCategory.DisplayMember = nameof(Dropdown.Name);
            cboSubCategory.ValueMember = nameof(Dropdown.Id);
            cboSubCategory.DataSource = subCategories;
            cboSubCategory.SelectedIndex = 0;
        }

        private async Task LoadSubCategoriesAsync(int categoryId)
        {
            var result = await _subCategoryService.FetchByCategoryIdAsync(categoryId);
            List<Dropdown> subCategories = [];
            if(result.Status == Status.Success)
            {
                subCategories = result.Data;
            }

            subCategories.Insert(0, new()
            {
                Id = 0,
                Name = "Please select a sub category"
            });
            cboSubCategory.DisplayMember = nameof(Dropdown.Name);
            cboSubCategory.ValueMember = nameof(Dropdown.Id);
            cboSubCategory.DataSource = subCategories;
            cboSubCategory.SelectedIndex = 0;
        }

        #endregion Methods
    }
}