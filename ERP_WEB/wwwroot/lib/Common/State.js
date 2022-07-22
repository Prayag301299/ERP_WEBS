
function DeleteState(Id) {
    debugger
    $.ajax({
        url: "/State/Delete?Id=" + Id,
        success: function (result) {
            if (result.isSuccess) {
                alert("Deleted Successfully")
                location.reload();
            }
            else {
                alert(result.msg)
            }
        }
    });
}


function AddOrEditState(Id) {
    debugger
    AddGetModal("/State/Edit?Id=" + Id, "Edit State", "lg", function () { });
}

$(document).ready(function () {
    /*$('#tblBf').DataTable();*/



    $("body").on("click", "#btnAddState", function () {
        AddGetModal("/State/Add", "Add new State", "lg", function () { });
    });


    $("body").on("click", "#btnCancel", function () {
        $("#modal-common").modal('hide');
    });
});