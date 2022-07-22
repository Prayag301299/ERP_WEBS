function Deletegsm(Id) {
    debugger
    $.ajax({
        url: "/GSM/Delete?Id=" + Id,
        success: function (result) {
            if (result.isSuccess) {
                alert("Deleted Successfully")
                location.reload();
            }
        }
    });
}

function AddOrEditgsm(Id) {
    debugger
    AddGetModal("/GSM/Edit?Id=" + Id, "Add new Bf", "lg", function () { });
}

$(document).ready(function () {
    /*$('#tblBf').DataTable();*/



    $("body").on("click", "#AddGsm", function () {
        AddGetModal("/GSM/Add", "Add new GSM", "lg", function () { });
    });


    $("body").on("click", "#btnCancel", function () {
        $("#modal-common").modal('hide');
    });
});