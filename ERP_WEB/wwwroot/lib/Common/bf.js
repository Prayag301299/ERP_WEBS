
function Deletebf(Id) {
    debugger
    $.ajax({
        url: "/BF/Delete?Id=" + Id,
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
	AddGetModal("/BF/Edit?Id=" + Id, "Add new Bf", "lg", function () { });
}



$(document).ready(function () {
	/*$('#tblBf').DataTable();*/



    $("body").on("click", "#btnAddbf", function () {
		AddGetModal("/BF/Add", "Add new Bf", "lg", function () { });
	});


    $("body").on("click", "#btnCancel", function () {
        $("#modal-common").modal('hide');
    });
});