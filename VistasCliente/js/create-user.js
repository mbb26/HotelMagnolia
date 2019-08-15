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
                APP.functions.makeAPICall($api_user, 'create', 'POST', $form.serialize(), userCreated, userFailed);
            }
        });
    };

    var userCreated = function(response) {
        console.log(response);
        if ($form.length > 0) {
            $form[0].reset();
        }
    };

    var userFailed = function(response) {
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