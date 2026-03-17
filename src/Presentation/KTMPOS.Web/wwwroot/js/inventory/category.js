$(function () {
    $('.categoryDelete').each(function () {
        const $this = $(this);
        $this.bootstrap_confirm_delete({
            heading: 'Delete',
            message: 'Are you sure you want to delete ?',
            callback: function (e) {
                const categoryId = $this.data('category-id');
                $.ajax({
                    url: `/Inventory/Category/Delete/${categoryId}`,
                    type: 'DELETE',
                    dataType: 'json',
                    success: function (response) {
                        location.href = '/Inventory/Category/Get';
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        console.log(textStatus, errorThrown);
                        $('#bootstrap-confirm-dialog').modal('hide');
                    }
                });
            },
            cancel_callback: function (e) {
                $('#bootstrap-confirm-dialog').modal('hide');
            }
        });
    });

    $(document).on('click', '#bootstrap-confirm-dialog .close', function () {
        $('#bootstrap-confirm-dialog').modal('hide');
    });
});