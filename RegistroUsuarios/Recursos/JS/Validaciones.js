$(document).ready(function () {

    //Validaciones para cada texbox

    $('#txtCorreo').focusout(function () {
        var validEmail = /^\w+([.-_+]?\w+)*@\w+([.-]?\w+)*(\.\w{2,10})+$/;
        if (!validEmail.test($(this).val())) {
            //Si no es un emial valido se muestra los datos para un email invalido 
            alert("El email no es valido, ingresar un correo valido");
            $(this).focus();
        }
    });

    $('#txtUsuario').focusout(function () {
        var usr = $(this).val();
        if (usr.length < 7) {
            alert("El usuario debe tener al menos 10 caracteres.");
            $(this).focus();
        }
    });


    $('#txtPswd').focusout(function () {

        var password = $(this).val();

        // Validar longitud mínima de 10 caracteres
        if (password.length < 10) {
            alert("La contraseña debe tener al menos 10 caracteres.");
        }

        // Validar al menos una mayúscula
        if (!/[A-Z]/.test(password)) {
            alert("La contraseña debe contener al menos una letra mayúscula.");
        }

        // Validar al menos una minúscula
        if (!/[a-z]/.test(password)) {
            alert("La contraseña debe contener al menos una letra minúscula.");
        }

        // Validar al menos un símbolo
        if (!/[!@#$%^&*()]/.test(password)) {
            alert("La contraseña debe contener al menos un símbolo.");
        }

        // Validar al menos un número
        if (!/[0-9]/.test(password)) {
            alert("La contraseña debe contener al menos un número.");
        }
        $(this).focus();
    });



});