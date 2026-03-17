$(function () {
    let _sn = 0;
    let _products = [];
    let _purchases = [];
    const _emptyProduct = "Please select a valid product first.";

    loadProducts();
    loadSuppliers();

    $('#ddlProductName').on('change', function () {
        const productId = parseInt($(this).val());
        const isValid = isValidProduct(productId);
        if (isValid) {
            $('#txtQuantity').focus();
            return;
        }

        alert(_emptyProduct);
    });

    $('#txtQuantity').on('keypress', function () {
        // Allow control keys like Backspace, Enter, Tab, Escape, Delete, etc.
        if (!/\d/.test(event.key) && !event.ctrlKey && !event.metaKey && !event.altKey && event.key.length === 1) {
            event.preventDefault();
        }
    });

    $('#txtQuantity').on('keydown', function () {
        if (event.key === "Enter") {
            const productId = parseInt($('#ddlProductName').val());
            if (!isValidProduct(productId)) {
                alert(_emptyProduct);
                return;
            }

            let qty = parseInt($(this).val());
            if (isNaN(qty) || qty === 0) {
                qty = 1;
            }

            const productDetails = getProductDetailsByProductName(productId);
            const product = productDetails.productName;
            const unitPrice = productDetails.unitPrice;
            const subTotal = unitPrice * qty;

            if (_sn > 0) {
                const purchase = _purchases.find(p => p.sn === _sn);
                if (purchase) {
                    purchase.product = product;
                    purchase.productId = productId;
                    purchase.qty = qty;
                    purchase.unitPrice = unitPrice;
                    purchase.subTotal = subTotal;
                }
            } else {
                if (checkProductExistsInGrid(productId)) {
                    alert(`Product '${product}' already exist, please update the grid.`);
                    resetControls();
                    return;
                }

                _purchases.push({
                    sn: _purchases.length + 1,
                    productId: productId,
                    product: product,
                    qty: qty,
                    unitPrice: unitPrice,
                    subTotal: subTotal
                });
            }

            loadPurchaseTable();
        }
    });

    $('#tblPurchaseBody').on('click', '.btnItemEdit', function () {
        const productId = $(this).data('product-id');
        const purchase = _purchases.find(x => x.productId === productId);
        if (purchase) {
            $('#ddlProductName').val(productId);
            $('#txtQuantity').val(purchase.qty);
            _sn = purchase.sn;
        }
    });

    $('#tblPurchaseBody').on('click', '.btnItemDelete', function () {
        const productId = $(this).data('product-id');
        const productToRemoveIndex = _purchases.findIndex(a => a.productId === productId)
        _purchases.splice(productToRemoveIndex, 1);
        loadPurchaseTable();
    });

    $('#btnPurchaseSave').on('click', function () {
        debugger;
        const supplierId = parseInt($('#ddlSupplierId').val());
        if (supplierId <= 0) {
            $('#supplierIdErrorMsg').removeClass('d-none');
            return;
        } else {
            $('#supplierIdErrorMsg').addClass('d-none');
        }

        if (_purchases.length <= 0) {
            alert('Please add at least one product to the purchase list.');
            return;
        }

        const request = {
            supplierId: supplierId,
            purchaseDetails: _purchases
        };
        $.ajax({
            url: '/Purchase/Save',
            type: 'POST',
            data: request,
            dataType: 'json',
            success: function (response) {
                location.href = '/Purchase';
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus, errorThrown);
            }
        });
    });

    function loadPurchaseTable() {
        let html = '';
        for (let i = 0; i < _purchases.length; i++) {
            const purchase = _purchases[i];
            html += `<tr>
                    <td>${i + 1}</td>
                    <td>${purchase.product}</td>
                    <td>${purchase.unitPrice}</td>
                    <td>${purchase.qty}</td>
                    <td>${purchase.unitPrice * purchase.qty}</td>
                     <td>
                    <a data-product-id="${purchase.productId}" class="btn btn-warning btn-sm btnItemEdit">Edit</a>
                    <a data-product-id="${purchase.productId}" href="#" class="btn btn-danger btn-sm btnItemDelete">Delete</a>
                </td>
                </tr>`;
        }
        $('#tblPurchaseBody').html(html);
        resetControls();
        calculateGrandTotal();
    }

    function calculateGrandTotal() {
        const grandTotal = _purchases.reduce((n, { qty, unitPrice }) => n + (qty * unitPrice), 0)
        $('#hdGrandTotal').html(grandTotal);
    }

    function resetControls() {
        $("#ddlProductName").prop("selectedIndex", 0);
        $('#txtQuantity').val('');
        $("#ddlProductName").focus();
        _sn = 0;
    }

    function checkProductExistsInGrid(productId) {
        const exists = _purchases.some(p => p.productId == productId);
        return exists;
    }

    function getProductDetailsByProductName(productId) {
        const detail = _products.find(p => p.id === productId);
        return { productId: detail.id, productName: detail.name, unitPrice: detail.purchasePrice };
    }

    function isValidProduct(productId) {
        if (isNaN(productId)) {
            return false;
        }

        if (productId > 0) {
            const validProduct = _products.some(x => x.id === productId);
            return validProduct;
        }

        return false;
    }

    function loadProducts() {
        $.ajax({
            url: '/Purchase/Product/Get',
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                let html = '<option value="0">Please select a product</option>';
                if (response.status == 1) {
                    _products = response.data;
                    for (let i = 0; i < response.data.length; i++) {
                        const product = response.data[i];
                        html += `<option value="${product.id}">${product.name}</option>`;
                    }
                } else {
                    alert(response.error);
                }

                $('#ddlProductName').html(html);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus, errorThrown);
            }
        });
    }
    function loadSuppliers() {
        $.ajax({
            url: '/Purchase/SupplierList/Get',
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                let html = '<option value="0">Please select a supplier</option>';
                if (response.status == 1) {
                    for (let i = 0; i < response.data.length; i++) {
                        const supplier = response.data[i];
                        html += `<option value="${supplier.id}">${supplier.name}</option>`;
                    }
                } else {
                    alert(response.error);
                }

                $('#ddlSupplierId').html(html);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus, errorThrown);
            }
        });
    }
});