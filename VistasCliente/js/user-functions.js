var APP = window.APP || {};
var auxFunction;
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
        
        $('.login-user').on('click', function(e) {
            e.preventDefault();
            APP.functions.makeAPICall($api_user, 'login', 'POST', $login_form.serialize(), userLogged, callFailed);
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
        alert('El usuario '+response.result.useR_NAME+' se ha creado con éxito');

        if ($create_user_form.length > 0) {
            $create_user_form[0].reset();
        }
    };

    var userLogged = auxFunction=function(response) {
        console.log(response);
        var $createdUser = response.result;
        console.log($createdUser);
        if ($createdUser != null) {
            var $user = {
                id: $createdUser.iD_USUARIO,
                username: $createdUser.useR_NAME,
                name: $createdUser.nombre
            };
            APP.functions.setSessionUser($user);
            var sessionUser = APP.functions.getSessionUser();
            alert('El usuario '+sessionUser.username+' se ha logueado correctamente.');
            $(location).attr('href','./index.html');
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

    
window.fbAsyncInit = function() {
    FB.init({
      appId      : '657287368113471',
      cookie     : true,
      xfbml      : true,
      version    : 'v4.0'
    });
    FB.AppEvents.logPageView();   
  };

  (function(d, s, id){
     var js, fjs = d.getElementsByTagName(s)[0];
     if (d.getElementById(id)) {return;}
     js = d.createElement(s); js.id = id;
     js.src = "https://connect.facebook.net/en_US/sdk.js";
     fjs.parentNode.insertBefore(js, fjs);
   }(document, 'script', 'facebook-jssdk'));

   function checkLoginState() {
    FB.getLoginStatus(function(response) {
        console.log(response);
        testAPI();
    });
  }

function testAPI() {
    FB.api('/me?fields=id,name,email', function(response) {
        APP.functions.makeAPICall('User/'+'GetUserByEmail?email='+encodeURI(response.email), 'GET',null, auxFunction, function(response){
            console.log(response);
        });
    });
}
function onSignIn(googleUser) {
    var profile = googleUser.getBasicProfile();
    APP.functions.makeAPICall('User/'+'GetUserByEmail?email='+encodeURI(profile.getEmail()), 'GET',null, auxFunction, function(response){
        console.log(response);
    });  
}

function recaptchaOkay(){
    $("#btnCrear").removeClass("hidden");
}