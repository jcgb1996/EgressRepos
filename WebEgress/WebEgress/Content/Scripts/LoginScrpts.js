var Login = {



	ValidarTexto: function () {
		var User = $("#UserLogin").val();
		if (User != "") {
			$("#BtnOk").removeClass("btnDisable");
			$("#BtnOk").addClass("btnVisible");
			$("#btnFail").addClass("btnDisable");
			$("#btnFail").removeClass("btnVisible");
		} else {
			$("#BtnOk").addClass("btnDisable");
			$("#BtnOk").removeClass("btnVisible");
			$("#btnFail").removeClass("btnDisable");
			$("#btnFail").addClass("btnVisible");
		}
	},

	validarUsuario: function () {
		$('.modal').modal('show');
		var Url = '../../Acceso/Acceso/ValidaUsuario';
		var User = $("#UserLogin").val();
		var ajaxData = JSON.stringify({ Usuario: User });
		$.ajax({
			url: Url,
			data: ajaxData,
			type: "POST",
			contentType: "application/json; charset=utf-8",
			dataType: "html",
			success: function (data) {

				$('.modal').modal('hide');
				$("div#ContentLogin").empty().html(data);

			},
			error: function (xhr, status, error) {
				var errorr = error
			}
		});
	},


	ValidarPassword: function () {
		$('.modal').modal('show');
		var Url = '../../Acceso/Acceso/ValidaPassword';
		var TxtPasswordLog = $("#TxtPasswordLog").val();
		var ajaxData = JSON.stringify({ Password: TxtPasswordLog });
		$.ajax({
			url: Url,
			data: ajaxData,
			type: "POST",
			contentType: "application/json; charset=utf-8",
			dataType: "html",
			success: function (data) {
				$('.modal').modal('hide');
				document.getElementById("FrmSiguiente").submit();
				//$("div#ContentBody").empty().html(data);
			},
			error: function (xhr, status, error) {
				var errorr = error
			}
		});
	},

	ViewLoginRegistro: function() {
		var Url = '../../Acceso/Acceso/ViewLoginRegistro';
		$.ajax({
			url: Url,
			type: "POST",
			contentType: "application/json; charset=utf-8",
			dataType: "html",
			success: function (data) {
				$("div#ContentLogin").empty().html(data);
				
			},
			error: function (xhr, status, error) {
				var errorr = error
			}
		});
	}

};