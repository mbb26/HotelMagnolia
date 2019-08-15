var APP = window.APP || {};

APP.newUser = (function() {

    var $api_user = 'User';

    var bindButtons = function() {
        $('.create-user').on('click', function(e) {
            e.preventDefault();
            $('input[name="id_usuario"]').val(''+Math.floor(Math.random() * 100000)+10);
            APP.functions.makeAPICall($api_user, 'create', 'POST', $('#create-user-form').serialize(),userCreated,userFailed);
        });
    };

    var userCreated = function(response) {
        console.log(response);
    }

    var userFailed = function(response) {
        console.log(response);
    }

    var init = function() {
        bindButtons();
    };

    return {
        init: init
    }
}());

window.onload = function() {
    APP.newUser.init();
}