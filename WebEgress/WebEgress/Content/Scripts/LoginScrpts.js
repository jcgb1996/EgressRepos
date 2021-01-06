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
		var Url = '@HttpContext.Current.Request.RequestContext.RouteData.Values["Login"].ToString()/ValidaUsuario';
		var lala = window.location.pathname;
		var User = $("#UserLogin").val();
		var ajaxData = JSON.stringify({ Usuario: User });
		$.ajax({
			cache: false,
			dataType: 'html',
			url: Url,
			data: { Usuario: User },
			type: "POST",
			contentType: "application/json; charset=utf-8",
			success: function (data, status, xhr) {

				var result = data.d;


			},
			error: function (xhr, status, error) {
				var errorr = error
			}
		});
	}

};