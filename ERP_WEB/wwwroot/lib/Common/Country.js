
function DeleteCountry(Id) {
    debugger
    $.ajax({
        url: "/Country/Delete?Id=" + Id,
        success: function (result) {
            if (result.isSuccess) {
                alert("Deleted Successfully")
                location.reload();
            }
        }
    });
}


function AddOrEditCountry(Id) {
    debugger
    AddGetModal("/Country/Edit?Id=" + Id, "Add new Bf", "lg", function () { });
}



$(document).ready(function () {
    /*$('#tblcountry').DataTable();*/



    $("body").on("click", "#btnAddCountry", function () {
        AddGetModal("/Country/Add", "Add new Country", "lg", function () { });
    });


    $("body").on("click", "#btnCancel", function () {
        $("#modal-common").modal('hide');
    });

    $(document).on("submit", "#formCategory", function (e) {
        debugger
        e.preventDefault();
        CountryValidation()
        var form = $(this);
        form.ajaxSubmit({
            beforeSubmit: function () {
                if (!form.valid()) {
                    return false;
                }
                else {
                    return true;
                }
            },
            success: function (res) {
                if (res && res.status) {
                    $("#modal-common").modal('hide');
                    toastr.success("Country Saved", 'Success');
                    $("#CityForm").resetForm();
                    RefreshDataTable('#tblcountry');
                } else {
                    toastr.error(res.message, 'Error');
                }
            },
            Errors: function () {
                toastr.error("Server get error response.", 'Error');
            }
        });
        return false;
    });

});



function CountryValidation() {
    debugger
    $("#CityForm").validate({
        rules: {
            CountryName: { required: true }
        },
        highlight: function (element) {
            $(element).closest('.form-group').addClass('has-error');
        },
        unhighlight: function (element) {
            $(element).closest('.form-group').removeClass('has-error');
        },
        errorPlacement: function (error, element) {
            if (element.parent('.input-group').length) {
                error.insertAfter(element.parent());
            } else {
                error.insertAfter(element);
            }
        }
    });
}