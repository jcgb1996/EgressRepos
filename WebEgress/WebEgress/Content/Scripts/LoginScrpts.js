var Login = {



	ValidarTexto: function (Op) {

		switch (Op) {

			case "Va": {
				var User = $("#UserLogin").val();
				if (User != "") {
					/*Se oculta el btn de registro*/
					$("#BtnRegistro").addClass("btnDisable");
					$("#BtnRegistro").removeClass("btnVisible");

					$("#BtnOk").removeClass("btnDisable");
					$("#BtnOk").addClass("btnVisible");
					$("#btnFail").addClass("btnDisable");
					$("#btnFail").removeClass("btnVisible");

					/*Se limpian los controles de registro */
					$("#TxtNombres").val("");
					$("#TxtApellidos").val("");
					$("#TxtCorreo").val("");
					$("#TxtUsuario").val("");
					$("#TxtContraseña").val("");

				} else {
					$("#BtnOk").addClass("btnDisable");
					$("#BtnOk").removeClass("btnVisible");
					$("#btnFail").removeClass("btnDisable");
					$("#btnFail").addClass("btnVisible");
				}
			} break;

			case "Re": {
				/*Boton para validar Usario*/
				var User = $("#UserLogin").val();
				if (User != "") {
					$("#UserLogin").val("");
					$("#BtnOk").addClass("btnDisable");
					$("#BtnOk").removeClass("btnVisible");

				}

				/*ir al registro*/
				var TxtNombres = $("#TxtNombres").val();
				var TxtApellidos = $("#TxtApellidos").val();
				var TxtCorreo = $("#TxtCorreo").val();
				var TxtUsuario = $("#TxtUsuario").val();
				var TxtContraseña = $("#TxtContraseña").val();
				if (TxtNombres != ""
					&& TxtApellidos != ""
					&& TxtCorreo != ""
					&& TxtUsuario != ""
					&& TxtContraseña != ""
				) {
					$("#BtnRegistro").removeClass("btnDisable");
					$("#BtnRegistro").addClass("btnVisible");
					$("#btnFail").addClass("btnDisable");
					$("#btnFail").removeClass("btnVisible");
				} else {
					$("#BtnRegistro").addClass("btnDisable");
					$("#BtnRegistro").removeClass("btnVisible");
					$("#btnFail").removeClass("btnDisable");
					$("#btnFail").addClass("btnVisible");
				}




			} break;
		}

	},

	validarUsuario: function () {
		$('.modal').modal('show');
		var Url = '../../Acceso/Acceso/ValidaUsuario';
		var UrlNextView = '../../Acceso/Acceso/CargarViewPassword';
		var User = $("#UserLogin").val();
		var dto = {
			Usuario: User,
		};

		$.post(Url, dto).done(function (data) {
			if (data.ExisteUsuario) {

				$.ajax({
					url: UrlNextView,
					type: "GET",
					data: dto,
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

			} else {

				$('.modal').modal('hide');
				alert(data.Response.Mensaje);
			}
		});
	},

	ValidarPassword: function () {
		$('.modal').modal('show');
		var Url = '../../Acceso/Acceso/ValidaPassword';
		var TxtPasswordLog = $("#TxtPasswordLog").val();
		var User = $("#LblUserLogin").text();

		var dto = {
			Usuario: User,
			Password: TxtPasswordLog,
		};

		$.post(Url, { Usuario: User, Password: TxtPasswordLog }).done(function (data) {

			if (data.Exito) {
				$("#TxtUserFrm").val(User);
				document.getElementById("FrmSiguiente").submit();
			} else {
				alert(data.Mensaje);
			}

			$('.modal').modal('hide');

		});
	},

	RegistroUsuario: function () {

		$('.modal').modal('show');
		var Url = '../../Acceso/Acceso/RegistrarUsuario';


		var TxtNombres = $("#TxtNombres").val();
		var TxtApellidos = $("#TxtApellidos").val();
		var TxtCorreo = $("#TxtCorreo").val();
		var TxtUsuario = $("#TxtUsuario").val();
		var TxtContraseña = $("#TxtContraseña").val();

		_Usuario = {
			Usuario: TxtUsuario,
			Password: TxtContraseña,
			Nombres: TxtNombres,
			Apellidos: TxtApellidos,
			Correo: TxtCorreo,
		};

		var dto = {
			Usuario: _Usuario,
		};

		$.post(Url, dto).done(function (data) {

			alert(data.Mensaje);
		});


	},


	ViewLoginRegistro: function () {
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
				document.getElementById("FrmSiguiente").submit();
				var errorr = error
			}
		});
	}


};