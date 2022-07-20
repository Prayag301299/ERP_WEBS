function GetMediaTypeList() {
	var listVM;
	$(function () {
		listVM = {
			dt: null,
			init: function () {
				dt = $('#categoryList').DataTable({
					"order": [],
					"serverSide": true,
					"processing": true,
					"autoWidth": false,
					"ajax": {
						"url": "/Category/GetCategories",
						"type": "Get"
					},
					"columns": [
						{ "title": "id", "data": "id", "searchable": false, "visible": false },
						{ "title": "Category Name", "data": "categoryName", "searchable": true, "Sortable": true },
						{
							"title": "Action", "data": "id", "width": "10%", "searchable": false, "orderable": false, "Sortable": true, render: function (data, type, row) {
								var html = "<div class='btn-group dropleft'>";
								html += "<a class='dropdown-item edt-rcd' href='javascript:void(0);' data-uri='/Category/Edit?id=" + row.id + "'><i class='bx bx-edit-alt me - 1'></i> Edit</a>";
								html += "<a class='dropdown-item edt-dlt' href='javascript:void(0);' data-uri='/Category/Delete?id=" + row.id + "' ><i class='bx bx-trash me-1'></i>Delete</a>";
								html += "</div>";
								return html;
							}
						}
					],
					"lengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100]],
				});
			}
		}
		listVM.init();
	});
}








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
    $.ajax({
        url: "/BF/GetDataByid?Id=" + Id,
        success: function (result) {
            if (result != null) {
                $("#modalCenter").addClass("show")
            }
        }
    });
}



$(document).ready(function () {
    $("body").on("click", "#btnAddbf", function () {
		AddGetModal("/BF/Add", "Add new Bf", "lg", function () { });
    });

    $("body").on("click", "#btnCancel", function () {
        $("#modal-common").modal('hide');
    });
});