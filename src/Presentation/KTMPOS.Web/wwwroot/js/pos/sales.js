$(function () {
    let _sn = 0;
    let _products = [];
    let _sales = [];
    let _discountPercent = 0;
    let _discountAmount = 0;
    const _maxDiscount = 5;
    const _emptyProduct = "Please select a valid product first.";
    const _pattern = /^\d+(%)?$/;

    loadProducts();

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
                const sales = _sales.find(p => p.sn === _sn);
                if (sales) {
                    sales.product = product;
                    sales.productId = productId;
                    sales.qty = qty;
                    sales.unitPrice = unitPrice;
                    sales.subTotal = subTotal;
                }
            } else {
                if (checkProductExistsInGrid(productId)) {
                    alert(`Product '${product}' already exist, please update the grid.`);
                    resetControls();
                    return;
                }

                _sales.push({
                    sn: _sales.length + 1,
                    productId: productId,
                    product: product,
                    qty: qty,
                    unitPrice: unitPrice,
                    subTotal: subTotal
                });
            }

            loadSalesTable();
        }
    });

    $("#txtDiscount").on("keypress", function (e) {
        const isDigit = /^[0-9]$/.test(e.key);
        const isControlKey = e.key.length > 1;

        if (!isDigit && !isControlKey && e.key !== "%") {
            e.preventDefault();
        }
    });

    $("#txtDiscount").on("keydown", function (e) {
        if (e.key === 'Enter') {
            let discount = $(this).val().trim();
            const grandTotal = parseFloat($('#hdGrandTotal').text());
            let netTotal = 0;

            if (!discount) {
                netTotal = grandTotal;
                $('#hdNetTotal').text(netTotal);
                return;
            }

            if (!_pattern.test(discount)) {
                alert('Please enter a valid discount in the format (10%).');
                resetDiscount();
                return;
            }

            if (discount.endsWith('%')) {
                discount = discount.replace(/%+$/, '');
                _discountPercent = parseFloat(discount);

                if (_discountPercent > _maxDiscount) {
                    alert(`Maximum discount allowed is ${_maxDiscount}%.`);
                    resetDiscount();
                    return;
                }

                _discountAmount = (grandTotal * _discountPercent) / 100;
            } else {
                const maxDiscountAmount = (grandTotal * _maxDiscount) / 100;
                _discountPercent = 0;
                _discountAmount = parseFloat(discount);

                if (_discountAmount > maxDiscountAmount) {
                    alert(`Maximum discount allowed is ${_maxDiscount}%.`);
                    resetDiscount();
                    return;
                }
            }

            netTotal = grandTotal - _discountAmount;
            $('#hdNetTotal').text(netTotal);
            $(this).val('');
            $('#ddlProductName').focus();
        }
    });

    $('#tblSalesBody').on('click', '.btnItemEdit', function () {
        const productId = $(this).data('product-id');
        const sales = _sales.find(x => x.productId === productId);
        if (sales) {
            $('#ddlProductName').val(productId);
            $('#txtQuantity').val(sales.qty);
            _sn = sales.sn;
        }
    });

    $('#tblSalesBody').on('click', '.btnItemDelete', function () {
        const productId = $(this).data('product-id');
        const productToRemoveIndex = _sales.findIndex(a => a.productId === productId)
        _sales.splice(productToRemoveIndex, 1);
        loadSalesTable();
    });

    $('#btnSalesSave').on('click', function () {
        if (_sales.length <= 0) {
            alert('Please add at least one product to the sales list.');
            return;
        }

        const request = {
            discountPercent: _discountPercent,
            discountAmount: _discountAmount,
            salesDetails: _sales
        };
        $.ajax({
            url: '/Pos/Save',
            type: 'POST',
            data: request,
            dataType: 'json',
            success: function (response) {
                location.href = '/Pos';
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus, errorThrown);
            }
        });
    });

    function loadSalesTable() {
        let html = '';
        for (let i = 0; i < _sales.length; i++) {
            const sales = _sales[i];
            html += `<tr>
                    <td>${i + 1}</td>
                    <td>${sales.product}</td>
                    <td>${sales.unitPrice}</td>
                    <td>${sales.qty}</td>
                    <td>${sales.unitPrice * sales.qty}</td>
                     <td>
                    <a data-product-id="${sales.productId}" class="btn btn-warning btn-sm btnItemEdit">Edit</a>
                    <a data-product-id="${sales.productId}" href="#" class="btn btn-danger btn-sm btnItemDelete">Delete</a>
                </td>
                </tr>`;
        }
        $('#tblSalesBody').html(html);
        resetControls();
        calculateGrandTotal();
    }

    function calculateGrandTotal() {
        const grandTotal = _sales.reduce((n, { qty, unitPrice }) => n + (qty * unitPrice), 0)
        $('#hdGrandTotal').html(grandTotal);
        $('#hdNetTotal').html(grandTotal);
    }

    function resetControls() {
        $("#ddlProductName").prop("selectedIndex", 0);
        $('#txtQuantity').val('');
        $("#ddlProductName").focus();
        _sn = 0;
    }

    function checkProductExistsInGrid(productId) {
        const exists = _sales.some(p => p.productId == productId);
        return exists;
    }

    function getProductDetailsByProductName(productId) {
        const detail = _products.find(p => p.id === productId);
        return { productId: detail.id, productName: detail.name, unitPrice: detail.sellingPrice };
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
            url: '/Pos/Product/Get',
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

    function resetDiscount() {
        $('#txtDiscount').val('');
        $('#txtDiscount').focus();
    }
});