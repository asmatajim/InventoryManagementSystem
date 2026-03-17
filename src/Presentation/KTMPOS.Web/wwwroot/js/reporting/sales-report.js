$(function () {
    const baseUrl = ' https://localhost:7147/api';
    loadReportTypes();

    $('#ddlFilter').on('change', function () {
        const selectedReportType = $(this).val();
        $.ajax({
            url: `${baseUrl}/report/Get/Report/Sales/${selectedReportType}`,
            type: 'GET',
            success: function (response) {
                if (response.status === 1) {
                    const element = response.data[0];
                    const html = `<tr>
                                  <td>1</td>
                                  <td>${element.totalGrossAmount}</td>
                                  <td>${element.totalDiscountAmount}</td>
                                  <td>${element.totalNetAmount}</td>
                                  <td>${element.totalRecords}</td>
                                  </tr>`;
                    $('#salesReportTableBody').html(html);
                }
                else {
                    alert(response.message);
                }
            },
            error: function (xhr, status, error) {
                alert(error);
            }
        });
    });

    function loadReportTypes() {
        $.ajax({
            url: `${baseUrl}/report/Get/ReportType`,
            type: 'GET',
            success: function (response) {
                if (response.status === 1) {
                    let html = '';
                    for (let i = 0; i < response.data.length; i++) {
                        const element = response.data[i];
                        html += `<option value="${element}">${element}</option>`;
                    }
                    $('#ddlFilter').html(html);
                    $("#ddlFilter").trigger('change');
                }
                else {
                    alert(response.message);
                }
            },
            error: function (xhr, status, error) {
                alert(error);
            }
        });
    }
});