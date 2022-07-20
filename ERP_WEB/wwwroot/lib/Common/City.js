
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