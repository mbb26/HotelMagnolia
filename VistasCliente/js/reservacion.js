var APP = window.APP || {};

APP.reservacion = (function() {

    var $api_reservation = 'Reservation/';
    var $api_room = 'Room/';
    var $create_user_form_selector = '#create-user-form';
    var $create_user_form = null;
    var $login_form_selector = '#login-form';
    var $login_form = null;
    var $available_rooms = null;
    var $tipo_habitacion_selector = "#TIPO_HABITACION";

    var bindButtons = function() {        
        $('.check-availability').on('click', function(e) {
            e.preventDefault();
            APP.functions.makeAPICall($api_room+'GetAvailable', 'GET', null, alertAvailable, callFailed);
        });
    };

    var callFailed = function(response) {
        console.log(response);
    };

    var userCreated = function(response) {
        console.log(response);

        if ($create_user_form.length > 0) {
            $create_user_form[0].reset();
        }

        APP.functions.customAlert('El usuario '+response.result.useR_NAME+' se ha creado con éxito', 'Usuario', './index.html');
    };

    var userLogged = function(response) {
        console.log(response);
        var $createdUser = response.result;
        console.log($createdUser);
        if ($createdUser != null) {
            var $user = {
                username: $createdUser.useR_NAME,
                name: $createdUser.nombre
            };
            APP.functions.setSessionUser($user);
            var sessionUser = APP.functions.getSessionUser();
            APP.functions.customAlert('El usuario '+sessionUser.username+' se ha logueado correctamente.', 'Login', './index.html');
        }
        else {
            APP.functions.customAlert('Usuario o contraseña incorrectos');
        }
    };

    var alertAvailable = function(response) {
        if (response.result && response.result.length > 0) {
            var $tipo_habitacion = $($tipo_habitacion_selector).children("option:selected").val();
            $available_rooms = response.result.filter(function(room) {
                return room.tipO_HABITACION == parseInt($tipo_habitacion);
            });
        }
        console.log($available_rooms);
    };
    
    var init = function() {
        $create_user_form = $($create_user_form_selector);
        $login_form = $($login_form_selector);
        bindButtons();
    };

    return {
        init: init
    };
}());

$(window).on('load', function() {
    APP.reservacion.init();
});