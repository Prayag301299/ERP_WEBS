
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


function AddOrEditbf(Id) {
    debugger
    AddGetModal("/Country/Edit?Id=" + Id, "Add new Bf", "lg", function () { });
}



$(document).ready(function () {
    $('#tblcountry').DataTable();



    $("body").on("click", "#btnAddbf", function () {
        AddGetModal("/Country/Add", "Add new Country", "lg", function () { });
    });


    $("body").on("click", "#btnCancel", function () {
        $("#modal-common").modal('hide');
    });
});