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