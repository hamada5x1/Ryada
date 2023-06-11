// This Class Is General For CRUD Operations <<
class CRUD {

    static DeleteRecord(btn, url, dt) {
        $("body").on("click", btn, function (event) {

            function ajaxDeleteRecordFunction() {
                let id = $(event.target).closest('a').attr('data-id');
                if (id == null || id == undefined) {
                    const form = event.target.closest('form');
                    id = form.querySelector('input').value;
                }

                $.ajax({
                    url: url + id,
                    type: "delete",
                    success: function (result) {
                        if (result.success) {
                            $("form").trigger("reset");
                            swals.basicSuccess("Successfull", "The Delete Done Sucssesfully");
                            setTimeout(function () {
                                location.reload();
                            }, 2000);
                        }
                        else {
                            swals.errorAlert("Somthing Is Wrong", "Cann't Delete This Record");
                        }
                    },
                    error: function (err) {
                        swals.errorAlert("Somthing Is Faild", "Cann't Make The Delete Operation");
                    }
                });
            }
            swals.confirmBtton(ajaxDeleteRecordFunction, "Are You Sure To Delete ", "You won't be able to revert this!",);
        });
    }

    static SelectRecordCRUD(formId, ajaxUrl, modalId, callBackFunction) {

        let form = document.getElementById(formId);
        let rowData;
        $.ajax({
            url: ajaxUrl,
            type: "get",
            success: function (result) {
                if (result.success) {
                    rowData = result.data;
                    for (let key in rowData) {
                        let key2 = key.charAt(0).toUpperCase() + key.substring(1);
                        let input = form.elements[key2];
                        if (input) {
                            if (input.type == "date") {
                                let dateValue = new Date(rowData[key]);
                                input.value = dateValue.getFullYear() + "-" + ("0" + (dateValue.getMonth() + 1)).slice(-2) + "-" + ("0" + dateValue.getDate()).slice(-2);
                            }
                            else if (input.type == "time") {
                                let dateValue = new Date(rowData[key]);
                                input.value = dateValue.getHours().toString().padStart(2, "0") + ":" + dateValue.getMinutes().toString().padStart(2, "0");
                            }
                            else {
                                input.value = rowData[key];
                            }
                        }
                    }

                    if (callBackFunction)
                        callBackFunction(result);


                    $(modalId).modal('hide');
                }
            },
            error: function (err) {
            }
        });
    }
    static SelectRecordBFAMS(btn, formId, ajaxUrl, modalId, callBackFunction) {
        $("body").on("click", btn, function (event) {
            let id = $(event.target).closest('a').attr('data-id');
            let form = document.getElementById(formId);
            let rowData;
            $.ajax({
                url: ajaxUrl + id,
                type: "get",
                success: function (result) {
                    console.log(result);
                    if (result.success) {
                        rowData = result.data;
                        for (let key in rowData) {
                            let key2 = key.charAt(0).toUpperCase() + key.substring(1);
                            let input = form.elements[key2];
                            if (input) {
                                if (input.type == "date") {
                                    let dateValue = new Date(rowData[key]);
                                    input.value = dateValue.getFullYear() + "-" + ("0" + (dateValue.getMonth() + 1)).slice(-2) + "-" + ("0" + dateValue.getDate()).slice(-2);
                                }
                                else if (input.type == "time") {
                                    let dateValue = new Date(rowData[key]);
                                    input.value = dateValue.getHours().toString().padStart(2, "0") + ":" + dateValue.getMinutes().toString().padStart(2, "0");
                                }
                                else if (input.type == "checkbox") {
                                    input.checked = (rowData[key] === true);
                                }
                                else {
                                    input.value = rowData[key];
                                }
                            }
                        }

                        if (callBackFunction)
                            callBackFunction(result);


                        $(modalId).modal('hide');
                    }
                    else {
                        swals.errorAlert("Somthing Is Wrong", "Cann't Select This Record");
                    }
                },
                error: function (err) {
                    swals.errorAlert("Somthing Is Faild", "Cann't Make The Select Operation");
                }
            });
        });
    }
}

// This Class Is General For Swals Fires 
class swals {

    static basicSuccess(basicTitle, subtitle) {
        Swal.fire(
            basicTitle,
            subtitle,
            'success'
        )
    }

    static errorAlert(basicTitle = "Oops...", subtitle = "Something went wrong!", typeIcon = "error") {
        Swal.fire({
            type: typeIcon,
            title: basicTitle,
            text: subtitle,
            //    footer: '<a href="">Why do I have this issue?</a>'
        })
    }


    static confirmBtton(ajaxFunction, title, text, typeIcon = "warning") {
        Swal.fire({
            title: title,
            text: text,
            type: typeIcon,
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes'
        }).then((result) => {
            if (result.value) {
                ajaxFunction();
                if (result.success) {
                    Swal.fire(
                        'Succeeded!',
                        'Operation Completed Successfully',
                        'success'
                    );
                }
            }

        });
    }

}

// This Class Is General For ( Date - DateTime - Time ) Manpulation
class DateTimeSettings {
    static dateTimeToDate(datetime) {
        //var justDate = datetime.toString().substring(0, datetime.indexOf("T"))
        //return justDate;
        if (datetime && datetime !== undefined && datetime != null && datetime != "0001-01-01T00:00:00") {
            var date = new Date(datetime);
            if (!isNaN(date.getDay())) {
                return moment(date).format('DD/MM/YYYY');
            }
        }
        return '';

    }

    static dateTimeToTime(datetime) {
        //return datetime.toString().substring(1, datetime.indexOf("T"));

        if (datetime && datetime !== undefined && datetime != null && datetime != "0001-01-01T00:00:00") {
            var date = new Date(datetime);
            if (!isNaN(date.getDay())) {
                return moment(date).format('hh:mm A');
            }
        }
        return '';
    }
    static DateTimeFormated(datetime) {
        if (datetime && datetime !== undefined && datetime != null && datetime != "0001-01-01T00:00:00") {
            var date = new Date(datetime);
            if (!isNaN(date.getDay())) {
                return moment(date).format('DD/MM/YYYY hh:mm A');
            }
        }
        return '';
    }
}




var AppendSelectedOption = (selector, text, value) => {
    if ($(selector).find(`option[value=${value}]`).length > 0) {
        $(selector).find(`option[value=${value}]`).prop('selected', true);
        $(selector).trigger('change');
        return;
    }

    $(selector).append($("<option selected></option>").val(value).html(text));
}

var AppendSelectedOption = (selector, text, value) => {
    if ($(selector).find(`option[value=${value}]`).length > 0) {
        return;
    }

    $(selector).append($("<option selected></option>").val(value).html(text));
}



// Self Envoke Reset function
(function () {
    let resetBtns = document.querySelectorAll('button[type=reset]');

    let allSelectLists = document.querySelectorAll("select");
    let allOptents = document.querySelectorAll("option");
    let event = new Event("change");

    resetBtns.forEach((ele) => {
        ele.onclick = () => {
            $('.kt-empty-start-select2').select2({placeholder:'Select'})
            allSelectLists.forEach((ele) => {
                ele.value = " ";
                ele.dispatchEvent(event);

            })
        }
    });

})();






var ErrorMessage = (msg, header) => {
    toastr.error(msg, header);
}
var SuccessMessage = (msg, header) => {
    toastr.success(msg, header);
}

toastr.options = {
    "closeButton": true,
    "debug": true,
    "newestOnTop": true,
    "progressBar": true,
    "positionClass": "toast-bottom-right",
    "preventDuplicates": false,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "hide",
    "font-size": "bold",
};

