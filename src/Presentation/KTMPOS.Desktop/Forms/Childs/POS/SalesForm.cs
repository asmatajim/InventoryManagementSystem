using KTMPOS.BAL.Services.Inventory.Products;
using KTMPOS.BAL.Services.POS;
using KTMPOS.Common.Enumerations;
using KTMPOS.Common.Model.Inventory.Products;
using KTMPOS.Common.Model.POS;
using KTMPOS.Desktop.Utilities;

using System.Data;
using System.Text.RegularExpressions;

using Message = KTMPOS.Common.Constants.Message;

namespace KTMPOS.Desktop.Forms.Childs.POS
{
    public partial class SalesForm : Form
    {
        #region Initialization

        private int _userId;
        private int _sn;
        private decimal _discountPercent, _discountAmount;
        private const string _action = "Action";
        private const int _maxDiscount = 5;
        private readonly IProductService _productService;
        private readonly ISalesService _salesService;
        private List<ProductRead> _products;
        private List<SalesGrid> _sales;

        /// <summary>
        /// ^ Represents start of string.
        /// \d+ matches one or more digits.
        /// The ? means zero or one of the preceding token (in this case, the % sign)
        /// $ (End of the string)
        /// </summary>
        private string _pattern = @"^\d+(%?)$";

        #endregion Initialization

        #region Constructors

        public SalesForm(IProductService productService, ISalesService salesService)
        {
            InitializeComponent();
            InitializeFormComponents();
            LoadSalesGridColumns();
            _userId = 0;
            _sn = 0;
            _discountPercent = 0;
            _discountAmount = 0;
            _products = [];
            _sales = [];
            _productService = productService;
            _salesService = salesService;
        }

        #endregion Constructors

        #region Events

        private async void SalesForm_Load(object sender, EventArgs e)
        {
            if(MdiParent is POSMainForm mainForm)
            {
                _userId = mainForm.UserId;
            }

            await LoadProductAsync();
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
                    SalesGrid sales = _sales
                                      .FirstOrDefault(p => p.SN == _sn);
                    sales.Product = product;
                    sales.ProductId = productId;
                    sales.Qty = qty;
                    sales.UnitPrice = unitPrice;
                    sales.SubTotal = subTotal;
                }
                else
                {
                    if(CheckProductExistsInGrid(product))
                    {
                        DialogMessage.FailedAlert($"Product {product} already exist, please update the grid.");
                        ResetControls();
                        return;
                    }

                    _sales.Add(new SalesGrid
                    {
                        SN = _sales.Count + 1,
                        ProductId = productId,
                        Product = product,
                        Qty = qty,
                        UnitPrice = unitPrice,
                        SubTotal = subTotal
                    });
                }

                LoadSalesGrid();
                CalculateGrandTotal();
            }
        }

        private void dgvSales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex != dgvSales.CurrentRow.Cells[_action].ColumnIndex)
            {
                _sn = (int)dgvSales.CurrentRow.Cells[nameof(SalesGrid.SN)].Value;
                txtProduct.Text = dgvSales.CurrentRow.Cells[nameof(SalesGrid.Product)].Value.ToString();
                txtQty.Text = dgvSales.CurrentRow.Cells[nameof(SalesGrid.Qty)].Value.ToString();
                txtProduct.Focus();
            }
            else
            {
                ResetControls();
            }
        }

        private void dgvSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex == dgvSales.CurrentRow.Cells[_action].ColumnIndex)
            {
                DeleteSalesEntry();
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

        private async void SalesForm_KeyDown(object sender, KeyEventArgs e)
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

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // IsControl for Backspace, Enter, Tab, Escape, Delete, etc
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '%')
            {
                e.Handled = true;
            }
        }

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string discount = txtDiscount.Text.Trim();
                decimal grandTotal = decimal.Parse(lblGrandTotalOutput.Text);
                decimal netTotal = 0;
                if(String.IsNullOrWhiteSpace(discount))
                {
                    netTotal = grandTotal;
                    lblNetTotalOutput.Text = netTotal.ToString();
                    return;
                }

                if(!Regex.IsMatch(discount, _pattern))
                {
                    DialogMessage.FailedAlert("Please enter a valid discount in the format (10%).");
                    txtDiscount.Clear();
                    txtDiscount.Focus();
                    return;
                }

                if(discount.EndsWith('%'))
                {
                    discount = discount.TrimEnd('%');
                    _discountPercent = decimal.Parse(discount);
                    if(_discountPercent > _maxDiscount)
                    {
                        DialogMessage.FailedAlert($"Maximum discount allowed is {_maxDiscount}%.");
                        txtDiscount.Clear();
                        txtDiscount.Focus();
                        return;
                    }

                    _discountAmount = (grandTotal * _discountPercent) / 100;
                }
                else
                {
                    decimal maxDiscountAmount = (grandTotal * _maxDiscount) / 100;
                    _discountAmount = decimal.Parse(discount);
                    if(_discountAmount > maxDiscountAmount)
                    {
                        DialogMessage.FailedAlert($"Maximum discount allowed is {_maxDiscount}%.");
                        txtDiscount.Clear();
                        txtDiscount.Focus();
                        return;
                    }
                }

                netTotal = grandTotal - _discountAmount;
                lblNetTotalOutput.Text = netTotal.ToString();
                txtDiscount.Clear();
                txtProduct.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion Events

        #region Methods

        private void LoadSalesGridColumns()
        {
            dgvSales.AutoGenerateColumns = false;
            dgvSales.ReadOnly = true;
            dgvSales.RowHeadersVisible = false;

            dgvSales.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(SalesGrid.SN),
                CellTemplate = new DataGridViewTextBoxCell(),
                HeaderText = "S.N.",
                DataPropertyName = nameof(SalesGrid.SN),
            });
            dgvSales.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(SalesGrid.Product),
                CellTemplate = new DataGridViewTextBoxCell(),
                HeaderText = "Item",
                Width = 200,
                DataPropertyName = nameof(SalesGrid.Product),
            });
            dgvSales.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(SalesGrid.UnitPrice),
                CellTemplate = new DataGridViewTextBoxCell(),
                HeaderText = "Price",
                DataPropertyName = nameof(SalesGrid.UnitPrice),
            });
            dgvSales.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(SalesGrid.Qty),
                CellTemplate = new DataGridViewTextBoxCell(),
                HeaderText = "Qty",
                DataPropertyName = nameof(SalesGrid.Qty),
            });
            dgvSales.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(SalesGrid.SubTotal),
                CellTemplate = new DataGridViewTextBoxCell(),
                HeaderText = "Sub Total",
                DataPropertyName = nameof(SalesGrid.SubTotal),
            });
            dgvSales.Columns.Add(new DataGridViewButtonColumn
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
            txtDiscount.TabIndex = 2;
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

        private void LoadSalesGrid()
        {
            dgvSales.DataSource = null;
            dgvSales.DataSource = _sales;
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
            return (detail.Id, detail.SellingPrice);
        }

        private void CalculateGrandTotal()
        {
            decimal grandTotal = _sales
                                 .Sum(p => p.SubTotal);
            lblGrandTotalOutput.Text = grandTotal.ToString();
            lblNetTotalOutput.Text = grandTotal.ToString();
        }

        private bool CheckProductExistsInGrid(string product)
        {
            bool exists = _sales
                          .Any(p => p.Product == product);
            return exists;
        }

        private void DeleteSalesEntry()
        {
            int sn = (int)dgvSales.CurrentRow.Cells[nameof(SalesGrid.SN)].Value;
            SalesGrid Sales = _sales
                              .FirstOrDefault(p => p.SN == sn);
            _sales.Remove(Sales);
            UpdateSerialNumbers();
            LoadSalesGrid();
            CalculateGrandTotal();
        }

        private void UpdateSerialNumbers()
        {
            int sn = 1;
            foreach(var Sales in _sales)
            {
                Sales.SN = sn;
                sn++;
            }
        }

        private async Task SaveAsync()
        {
            SalesCreate request = new()
            {
                CreatedBy = _userId,
                DiscountPercent = _discountPercent,
                DiscountAmount = _discountAmount,
                SalesDetails = _sales
                               .Select(x => new SalesDetailCreate
                               {
                                   ProductId = x.ProductId,
                                   Qty = x.Qty,
                               })
                               .ToList()
            };
            var result = await _salesService.SaveAsync(request);
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
            lblNetTotalOutput.Text = "0";
            _sales.Clear();
            LoadSalesGrid();
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

        #endregion Methods
    }
}