FormjQueryAjaxPost = (form, callback,DataTableId) => {
    try {
        
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (data) {
                if (data.success) {
                    swal.fire(data.message, 'Your Data has been  ' + data.message, 'success')

                    if (data.table) {
                        var tables = data.table.split(",");
                    }

                    $.each(tables, function (index, item) {
                        $(item).DataTable().ajax.reload();
                    })
                    if (data.reset == false) {
                        return;
                    }
                    $(form).find('.kt-select2').val(null).trigger('change');
                    $(form).find('.select2').val(null).trigger('change');

                    $('#AjaxForm input[type="text"]').val('');
                    $(".ddl").val('1').change();
                    $(form).find("[name=Id]").val("")
                    $(form).find("textarea").empty()
                    $(form).find('button[type="reset"]').trigger("click");
                    $(form).trigger("reset");
                    $('[type="radio"]').prop('checked', false);
                    $('input:checkbox').removeAttr('checked');

                    setTimeout(function () {
                        location.reload();
                    }, 3000);

                } else if (data.success == false) {
                    let modelStatiesMessages = '';
                    if (data.errors != null && data.errors != undefined && data.errors != "") {
                        data.errors.forEach((error) => {
                            modelStatiesMessages += `<li style="margin: .5rem 0">${error}</li>`;
                        });
                        toastr.options.timeOut = 7000;
                        toastr.warning(`<ul style='padding:1rem; font-size: 1.1rem;'>${modelStatiesMessages}</ul>`);
                    }
                    else {
                        swal.fire('Cancelled', 'Your Data Not Updated  :(  <br/> ' + data.message, 'error')
                    }
                } else if (callback) {
                    callback(data);
                    if (DataTableId) {
                        $(DataTableId).DataTable().ajax.reload();
                    }

                }
                else {
                    swal.fire('Cancelled', 'Your Data Not Updated  :(  <br/> ' + data.message, 'error')

                }

            }
        })
        return false;

    } catch (ex) {
        console.log(ex)
    }
}


