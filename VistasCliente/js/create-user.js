var APP = window.APP || {};

APP.createUser = (function() {

    var $api_user = 'User';
    var $form_selector = '#create-user-form';
    var $form = null;

    var bindButtons = function() {
        $('.create-user').on('click', function(e) {
            e.preventDefault();
            if (APP.functions.validateForm($form)) {
                $('input[name="id_usuario"]').val(''+(Math.floor(Math.random() * 1000000)+9000000));
                APP.functions.makeAPICall($api_user, 'create', 'POST', $form.serialize(), userCreated, callFailed);
            }
        });
        
        $('.create-user-cancel').on('click', function(e) {
            e.preventDefault();
            APP.functions.makeAPICall($api_user, 'login', 'POST', $form.serialize(), userLogged, callFailed);
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
        alert('El usuario '+response.result.username+' se ha creado con éxito');

        if ($form.length > 0) {
            $form[0].reset();
        }
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
            alert('El usuario '+sessionUser.username+' se ha logueado');
        }
        else {
            alert('Usuario o contraseña incorrectos');
        }
    };

    var alertAvailable = function(response) {
        console.log(response);
        var $available = response.result;
        alert('El nombre de usuario '+($available?' ':'NO ')+'se encuentra disponible');
    };

    var loginFailed = function(response) {
        console.log(response);
    };
    var init = function() {
        $form = $($form_selector);
        bindButtons();
    };

    return {
        init: init
    };
}());

$(window).on('load', function() {
    APP.createUser.init();
});