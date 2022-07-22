
function DeleteCity(Id) {
    debugger
    $.ajax({
        url: "/City/Delete?Id=" + Id,
        success: function (result) {
            if (result.isSuccess) {
                alert("Deleted Successfully")
                location.reload();
            }
        }
    });
}

function AddOrEditCity(Id) {
    debugger
    AddGetModal("/City/Edit?Id=" + Id, "Edit City", "lg", function () { });
}

$(document).ready(function () {
    /*$('#tblBf').DataTable();*/



    $("body").on("click", "#btnAddCity", function () {
        AddGetModal("/City/Add", "Add new City", "lg", function () { });
    });


    $("body").on("click", "#btnCancel", function () {
        $("#modal-common").modal('hide');
    });
});