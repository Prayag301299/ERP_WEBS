function AddGetModal(uri, header, modelsize, callback) {
	debugger;
	$.ajax({
		url: uri,
		type: "Get",
		dataType: "html",
		async: true,
		traditional: true,
		success: function (data, Status, xhr) {
			debugger;
			if (data != undefined && data != null) {
				$("#modal-common .modal-body").html(data);
				$("#modal-common .modal-title").html(header);
				//$("#mymodal").modal('show');
				$("#modal-common").modal({keyboard: false });
				$("#modal-common").focus();
				callback();
			} else {

				alert("Sorry");
			}
		},
		error: function (error) {

			alert("Sorry");
		}
	});
}