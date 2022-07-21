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
				$("#modal-common").modal('show');
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



//const Toast = Swal.mixin({
//	toast: true,
//	position: 'top-end',
//	showConfirmButton: false,
//	timer: 3000
//});

//function NotifyMsg(Desc, msgType) {
//	Toast.fire({
//		icon: msgType,
//		title: " " + Desc
//	})
//}