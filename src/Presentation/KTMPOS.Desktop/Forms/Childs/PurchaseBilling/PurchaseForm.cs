using KTMPOS.BAL.Services.Inventory.Products;
using KTMPOS.BAL.Services.PurchaseBilling;
using KTMPOS.Common.Enumerations;
using KTMPOS.Common.Model.Inventory.Products;
using KTMPOS.Common.Model.PurchaseBilling;
using KTMPOS.Desktop.Utilities;

using Message = KTMPOS.Common.Constants.Message;

namespace KTMPOS.Desktop.Forms.Childs.PurchaseBilling
{
    public partial class PurchaseForm : Form
    {
        #region Initialization

        private int _userId;
        private int _sn;
        private const string _action = "Action";
        private readonly IProductService _productService;
        private readonly ISupplierService _supplierService;
        private readonly IPurchaseService _purchaseService;
        private List<ProductRead> _products;
        private List<PurchaseGrid> _purchases;

        #endregion Initialization

        #region Constructors

        public PurchaseForm(IProductService productService, ISupplierService supplierService,
                            IPurchaseService purchaseService)
        {
            InitializeComponent();
            InitializeFormComponents();
            LoadPurchaseGridColumns();
            _userId = 0;
            _sn = 0;
            _products = [];
            _purchases = [];
            _productService = productService;
            _supplierService = supplierService;
            _purchaseService = purchaseService;
        }

        #endregion Constructors

        #region Events

        private async void PurchaseForm_Load(object sender, EventArgs e)
        {
            if(MdiParent is POSMainForm mainForm)
            {
                _userId = mainForm.UserId;
            }

            await LoadProductAsync();
            await LoadSuppliersAsync();
        }

        private void txtProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string product = txtProduct.Text;
                bool isValid = IsValidProduct(product);
                if(isValid)
                {
                    txtQty.Focus();
                    return;
                }

                DialogMessage.FailedAlert(Message.EmptyProduct);
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            // IsControl for Backspace, Enter, Tab, Escape, Delete, etc
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string product = txtProduct.Text;
                if(!IsValidProduct(product))
                {
                    DialogMessage.FailedAlert(Message.EmptyProduct);
                    return;
                }

                int.TryParse(txtQty.Text, out int qty);
                if(qty == 0)
                {
                    qty = 1;
                }

                (int productId, decimal unitPrice) = GetProductDetailsByProductName(product);
                decimal subTotal = unitPrice * qty;

                if(_sn > 0)
                {
                    PurchaseGrid purchase = _purchases
                                            .FirstOrDefault(p => p.SN == _sn);
                    purchase.Product = product;
                    purchase.ProductId = productId;
                    purchase.Qty = qty;
                    purchase.UnitPrice = unitPrice;
                    purchase.SubTotal = subTotal;
                }
                else
                {
                    if(CheckProductExistsInGrid(product))
                    {
                        DialogMessage.FailedAlert($"Product {product} already exist, please update the grid.");
                        ResetControls();
                        return;
                    }

                    _purchases.Add(new PurchaseGrid
                    {
                        SN = _purchases.Count + 1,
                        ProductId = productId,
                        Product = product,
                        Qty = qty,
                        UnitPrice = unitPrice,
                        SubTotal = subTotal
                    });
                }

                LoadPurchaseGrid();
                CalculateGrandTotal();
            }
        }

        private void dgvPurchase_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex != dgvPurchase.CurrentRow.Cells[_action].ColumnIndex)
            {
                _sn = (int)dgvPurchase.CurrentRow.Cells[nameof(PurchaseGrid.SN)].Value;
                txtProduct.Text = dgvPurchase.CurrentRow.Cells[nameof(PurchaseGrid.Product)].Value.ToString();
                txtQty.Text = dgvPurchase.CurrentRow.Cells[nameof(PurchaseGrid.Qty)].Value.ToString();
                txtProduct.Focus();
            }
            else
            {
                ResetControls();
            }
        }

        private void dgvPurchase_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex == dgvPurchase.CurrentRow.Cells[_action].ColumnIndex)
            {
                DeletePurchaseEntry();
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await SaveAsync();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetAllControls();
        }

        private async void PurchaseForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F2)
            {
                await SaveAsync();
            }
            else if(e.KeyCode == Keys.F3)
            {
                ResetAllControls();
            }
            else if(e.KeyCode == Keys.F10)
            {
                Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion Events

        #region Methods

        private void LoadPurchaseGridColumns()
        {
            dgvPurchase.AutoGenerateColumns = false;
            dgvPurchase.ReadOnly = true;
            dgvPurchase.RowHeadersVisible = false;

            dgvPurchase.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(PurchaseGrid.SN),
                CellTemplate = new DataGridViewTextBoxCell(),
                HeaderText = "S.N.",
                DataPropertyName = nameof(PurchaseGrid.SN),
            });
            dgvPurchase.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(PurchaseGrid.Product),
                CellTemplate = new DataGridViewTextBoxCell(),
                HeaderText = "Item",
                Width = 200,
                DataPropertyName = nameof(PurchaseGrid.Product),
            });
            dgvPurchase.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(PurchaseGrid.UnitPrice),
                CellTemplate = new DataGridViewTextBoxCell(),
                HeaderText = "Price",
                DataPropertyName = nameof(PurchaseGrid.UnitPrice),
            });
            dgvPurchase.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(PurchaseGrid.Qty),
                CellTemplate = new DataGridViewTextBoxCell(),
                HeaderText = "Qty",
                DataPropertyName = nameof(PurchaseGrid.Qty),
            });
            dgvPurchase.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(PurchaseGrid.SubTotal),
                CellTemplate = new DataGridViewTextBoxCell(),
                HeaderText = "Sub Total",
                DataPropertyName = nameof(PurchaseGrid.SubTotal),
            });
            dgvPurchase.Columns.Add(new DataGridViewButtonColumn
            {
                Name = _action,
                CellTemplate = new DataGridViewButtonCell(),
                HeaderText = _action,
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                Width = 150
            });
        }

        private void InitializeFormComponents()
        {
            txtProduct.TabIndex = 0;
            txtQty.TabIndex = 1;
            cboSupplier.TabIndex = 2;
            btnSave.TabIndex = 3;
            btnCancel.TabIndex = 4;
            txtProduct.Focus();
            KeyPreview = true;
        }

        private bool IsValidProduct(string product)
        {
            if(String.IsNullOrWhiteSpace(product))
            {
                return false;
            }

            bool validProduct = _products
                                .Any(x => x.Name == product);
            return validProduct;
        }

        private void LoadPurchaseGrid()
        {
            dgvPurchase.DataSource = null;
            dgvPurchase.DataSource = _purchases;
            ResetControls();
        }

        private void ResetControls()
        {
            txtProduct.Clear();
            txtQty.Clear();
            txtProduct.Focus();
            _sn = 0;
        }

        private (int productId, decimal unitPrice) GetProductDetailsByProductName(string product)
        {
            var detail = _products
                         .FirstOrDefault(p => p.Name == product);
            return (detail.Id, detail.PurchasePrice);
        }

        private void CalculateGrandTotal()
        {
            decimal grandTotal = _purchases
                                 .Sum(p => p.SubTotal);
            lblGrandTotalOutput.Text = grandTotal.ToString();
        }

        private bool CheckProductExistsInGrid(string product)
        {
            bool exists = _purchases
                          .Any(p => p.Product == product);
            return exists;
        }

        private void DeletePurchaseEntry()
        {
            int sn = (int)dgvPurchase.CurrentRow.Cells[nameof(PurchaseGrid.SN)].Value;
            PurchaseGrid purchase = _purchases
                                    .FirstOrDefault(p => p.SN == sn);
            _purchases.Remove(purchase);
            UpdateSerialNumbers();
            LoadPurchaseGrid();
            CalculateGrandTotal();
        }

        private void UpdateSerialNumbers()
        {
            int sn = 1;
            foreach(var purchase in _purchases)
            {
                purchase.SN = sn;
                sn++;
            }
        }

        private async Task SaveAsync()
        {
            PurchaseCreate request = new()
            {
                SupplierId = (int)cboSupplier.SelectedValue,
                CreatedBy = _userId,
                PurchaseDetails = _purchases
                                  .Select(x => new PurchaseDetailCreate
                                  {
                                      ProductId = x.ProductId,
                                      Qty = x.Qty,
                                  })
                                  .ToList()
            };
            var result = await _purchaseService.SaveAsync(request);
            if(result.Status == Status.Success)
            {
                ResetAllControls();
                DialogMessage.SuccessAlert(result.Message);
            }
            else
            {
                DialogMessage.FailedAlert(result);
            }
        }

        private void ResetAllControls()
        {
            lblGrandTotalOutput.Text = "0";
            cboSupplier.SelectedIndex = 0;
            _purchases.Clear();
            LoadPurchaseGrid();
        }

        private async Task LoadProductAsync()
        {
            var result = await _productService.GetAllAsync();
            if(result.Status == Status.Success)
            {
                _products = result.Data;

                var productNames = _products
                                   .Select(p => p.Name)
                                   .ToArray();
                AutoCompleteStringCollection source = new();
                source.AddRange(productNames);

                txtProduct.AutoCompleteCustomSource = source;
                txtProduct.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtProduct.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }

        private async Task LoadSuppliersAsync()
        {
            var result = await _supplierService.GetAllAsync();
            var suppliers = result.Data;
            suppliers.Insert(0, new SupplierRead
            {
                Id = 0,
                Name = "Please select a supplier"
            });
            cboSupplier.DataSource = suppliers;
            cboSupplier.DisplayMember = nameof(SupplierRead.Name);
            cboSupplier.ValueMember = nameof(SupplierRead.Id);
            cboSupplier.SelectedIndex = 0;
        }

        #endregion Methods
    }
}