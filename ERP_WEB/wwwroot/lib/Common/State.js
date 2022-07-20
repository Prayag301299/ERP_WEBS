
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