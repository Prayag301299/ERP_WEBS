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