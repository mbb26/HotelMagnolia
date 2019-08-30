var APP = window.APP || {};

APP.functions = (function() {

    var API_KEYS = {
        root: 'http://localhost:44364/API/'
    };
    var $user_in_session = 'userInSession';
    var $reservations_cookie = 'reservationsCookie';

    var makeAPICall = function(apiRequest, method, params, onSuccess, onError) {
        $.ajax({
            type: method,
            url: API_KEYS.root+apiRequest,
            data: params,
            crossDomain: true,
            success: function (response) {
                if (typeof(onSuccess) === 'function') {
                    onSuccess(response);
                }
            },
            error: function (error) {
                if (typeof(onError) === 'function') {
                    onError(error);
                }
            }
        });
    };

    var getSessionUser = function() {
        return JSON.parse($.cookie($user_in_session) || null);
    };

    var setSessionUser = function(user) {
        $.cookie($user_in_session, JSON.stringify(user));
        loadMenu();
    };

    var removeSessionUser = function() {
        $.removeCookie($user_in_session);
        loadMenu();
    };

    var getReservations = function() {
        return JSON.parse($.cookie($reservations_cookie) || null);
    };

    var setReservations = function(reservations) {
        $.cookie($reservations_cookie, JSON.stringify(reservations));
    };

    var removeReservations = function() {
        $.removeCookie($reservations_cookie);
    };

    var getCookie = function(name) {
        return JSON.parse($.cookie(name) || null);
    };

    var setCookie = function(name, value) {
        $.cookie(name, JSON.stringify(value));
    };

    var removeCookie = function(name) {
        $.removeCookie(name);
    };

    var customAlert = function (message, title, redirectURL) {
        if ( !title )
            title = 'Alert';
    
        if ( !message )
            message = 'No Message to Display.';
    
        $('<div></div>').html( message ).dialog({
            title: title,
            resizable: false,
            modal: true,
            buttons: {
                'Ok': function()  {
                    $( this ).dialog( 'close' );
                    if (redirectURL) {
                        $(location).attr('href', redirectURL);
                    }
                }
            }
        });
    };

    var bindButtons = function() {
        getSessionUser();
        $('input:checkbox').each(function() {
            var $action = $(this).attr('data-function');
            if ($action === 'toggleEnable') {
                $(this).on('click', function() {
                    resetEnabled(this);
                });
            }
        });
		$('.reset-form').on('click', function(e) {
			e.preventDefault();
			resetForm(this);
        });
        $('form[data-function="initialize"]').each(function() {
            initializeForm(this);
        })
        $('form[data-validation="validate"]').on('submit', function (e, options) {
            options = options || {};
            if (!options.validated) {
                e.preventDefault();
                validateFormAndSubmit(this, e);
            }
        });
    };

    var bindLogout = function() {        
        $('.logout-user').on('click', function(e) {
            e.preventDefault();
            APP.functions.removeSessionUser();
            APP.functions.customAlert('Ha cerrado su sesión', 'Usuario', './index.html');
            loadMenu();
        });
    };

    var loadMenu = function() {
        var $navContent = $('#navbarSupportedContent');
        var $htmlContent = '';
        var $sessionUser = getSessionUser();
        
        if (getSessionUser() != null) {
            $htmlContent += '<ul class="navbar-nav mr-auto">';
            $htmlContent += '<li class="nav-item dropdown">';
            $htmlContent += '<a class="nav-link dropdown-toggle" href="#" id="menuUsuario" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">'+$sessionUser.name+'</a>';
            $htmlContent += '<div class="dropdown-menu" aria-labelledby="menuUsuario">';
            $htmlContent += '<a class="dropdown-item" href="cambiar_password.html">Cambio de Contraseña</a>';
            $htmlContent += '<a class="dropdown-item logout-user" href="#">Logout</a>';
            $htmlContent += '</div>';
            $htmlContent += '</li>';
            $htmlContent += '<li class="nav-item dropdown">';
            $htmlContent += '<a class="nav-link dropdown-toggle" href="#" id="menuAdministracion" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Servicios</a>';
            $htmlContent += '<div class="dropdown-menu" aria-labelledby="menuAdministracion">';
            $htmlContent += '<a class="dropdown-item" href="resevaciones.html">Reservacion</a>';
            $htmlContent += '</div>';
            $htmlContent += '</li>';
            $htmlContent += '</ul>';
            $htmlContent += '<ul id="carrito" class="nav navbar-nav navbar-right">';
            $htmlContent += '<li class="nav-item"><a href="carrito.html" class="nav-link"><span class="glyphicon glyphicon-user"></span>Carrito</a></li>';
            $htmlContent += '</ul>';
        }        
        else {
            $htmlContent += '<ul class="navbar-nav mr-auto">';
            $htmlContent += '<li class="nav-item dropdown">';
            $htmlContent += '<a class="nav-link dropdown-toggle" href="#" id="menuUsuario" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Usuario</a>';
            $htmlContent += '<div class="dropdown-menu" aria-labelledby="menuUsuario">';
            $htmlContent += '<a class="dropdown-item" href="login.html">Login</a>';
            $htmlContent += '</div>';
            $htmlContent += '</li>';
            $htmlContent += '<li class="nav-item dropdown">';
            $htmlContent += '<a class="nav-link dropdown-toggle" href="#" id="menuAdministracion" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Servicios</a>';
            $htmlContent += '<div class="dropdown-menu" aria-labelledby="menuAdministracion">';
            $htmlContent += '<a class="dropdown-item" href="resevaciones.html">Reservacion</a>';
            $htmlContent += '</div>';
            $htmlContent += '</li>';
            $htmlContent += '</ul>';
            $htmlContent += '<ul id="carrito" class="nav navbar-nav navbar-right">';
            $htmlContent += '<li><a href="carrito.html"><span class="glyphicon glyphicon-user"></span>Carrito</a></li>';
            $htmlContent += '</ul>';
        }
        $navContent.html($htmlContent);
        bindLogout();
    };

	var resetForm = function(button) {
        var $form = $(button).closest('form')[0];
        if ($form) {
            $form.reset();
            $($form).find('input:checkbox').each(function() {
                resetEnabled(this);
            });
        }
    };

    var initializeForm = function (form) {
        var $form = $(form);
        $form.find('input:checkbox').each(function () {
            resetEnabled(this);
        });
        $form.find('[data-function="noBlank"]').each(function() {
            var $label = $($(this).closest('.form-group').find('.control-label')[0]);
            if ($label) {
                $label.html($label.html() + ' <span class="text-danger">*</span>');
            }
        });
        $form.find('[data-function="noBlank"]').each(function () {
            $(this).on('blur', function () {
                validateNoBlank(this);
            });
        });
    };

    var validateForm = function (form) {
        var $form = $(form);
        var $valid = true;
        $form.find('[data-function="noBlank"]').each(function () {
            $valid = validateNoBlank(this) && $valid;
        });
        return $valid;
    };

    var resetFormAlerts = function (form) {
        var $form = $(form);
        $form.find('[data-function="noBlank"]').each(function () {
            resetAlerts(this);
        });
    };

    var resetAlerts = function(field) {
        var $field = $(field);
        var $message = $($field.siblings('.text-danger')[0]);
        $message.html('');
    };

    var validateFormAndSubmit = function (form, e) {
        var $valid = validateForm(form);
        if ($valid) {
            $(e.currentTarget).trigger(e.type, { 'validated': true });
        }
    };

    var validateNoBlank = function(field) {
        var $field = $(field);
        var $valid = true;
        var $message = $($field.siblings('.text-danger')[0]);
        $message.html('');

        if (!$field.attr('disabled')) {
            if (!($field.val() || $field.val().trim())) {
                $message.html('Este campo es requerido');
                $valid = false;
            }
        }
        else {
            $field.val('');
        }
        return $valid;
    };
    
    var resetEnabled = function(checkbox) {
        var $target = $(checkbox).attr('data-target');
        var $action = $(checkbox).attr('data-function');
        if ($action === 'toggleEnable') {
            $($target).each(function() {
                $(this).attr('disabled', !checkbox.checked);
                validateNoBlank(this);
            });
        }
    };

    var init = function() {
        bindButtons();
        loadMenu();
    };

    return {
        init: init,
        makeAPICall: makeAPICall,
        validateForm: validateForm,
        getSessionUser: getSessionUser,
        setSessionUser: setSessionUser,
        removeSessionUser: removeSessionUser,
        getReservations: getReservations,
        setReservations: setReservations,
        removeReservations: removeReservations,
        getCookie: getCookie,
        setCookie: setCookie,
        removeCookie: removeCookie,
        customAlert: customAlert,
        resetFormAlerts: resetFormAlerts
    };
}());

$(window).on('load', function() {
    APP.functions.init();
});