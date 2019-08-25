var APP = window.APP || {};

APP.userFunctions = (function() {

    var $api_user = 'User';
    var $create_user_form_selector = '#create-user-form';
    var $create_user_form = null;
    var $login_form_selector = '#login-form';
    var $login_form = null;

    var bindButtons = function() {
        $('.create-user').on('click', function(e) {
            e.preventDefault();
            if (APP.functions.validateForm($create_user_form)) {
                $('input[name="id_usuario"]').val(''+(Math.floor(Math.random() * 1000000)+9000000));
                APP.functions.makeAPICall($api_user, 'create', 'POST', $create_user_form.serialize(), userCreated, callFailed);
            }
        });
        
        $('#login-form').on('submit', function(e) {
            e.preventDefault();
            if (APP.functions.validateForm(this)) {
                APP.functions.makeAPICall($api_user, 'login', 'POST', $login_form.serialize(), userLogged, callFailed);
            }
        });
        
        $('.check-availability').on('click', function(e) {
            e.preventDefault();
            APP.functions.makeAPICall($api_user, 'availability', 'GET', $('#user_name').serialize(), alertAvailable, callFailed);
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
        console.log(response);
        var $available = response.result;
        APP.functions.customAlert('El nombre de usuario '+($available?' ':'NO ')+'se encuentra disponible');
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
    APP.userFunctions.init();
});