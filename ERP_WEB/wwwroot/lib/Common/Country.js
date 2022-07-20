
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