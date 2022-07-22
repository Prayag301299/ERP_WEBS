function DeleteShade(Id) {
    debugger
    $.ajax({
        url: "/Shade_Item/Delete?Id=" + Id,
        success: function (result) {
            if (result.isSuccess) {
                alert("Deleted Successfully")
                location.reload();
            }
        }
    });
}

function AddOrEditShade(Id) {
    debugger
    AddGetModal("/Shade_Item/Edit?Id=" + Id, "Edit Shade/Item", "lg", function () { });
}

$(document).ready(function () {
    /*$('#tblBf').DataTable();*/



    $("body").on("click", "#btnAddShade", function () {
        AddGetModal("/Shade_Item/Add", "Add Shade/Item", "lg", function () { });
    });


    $("body").on("click", "#btnCancel", function () {
        $("#modal-common").modal('hide');
    });
});