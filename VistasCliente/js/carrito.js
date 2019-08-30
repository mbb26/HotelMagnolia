var APP = window.APP || {};

APP.carrito = (function() {

    var $api_reservations = 'Reservation/'
    var $api_reservations = 'Reservation/'
    var $cart_reservations_selector = '#cart-reservations';
    var $user_reservations;
    var $tipos_habitacion = ['Not_selected', 'Normal', 'Deluxe', 'Condominio'];

    var bindButtons = function() {
        $('#cart-button-pay').on('click', function() {
            $(location).attr('href', 'pantalla_pago.html');
        });
    };

    var loadReservations = function() {
        APP.functions.makeAPICall($api_reservations+'GetAll', 'GET', null, reservationsRetrieved, callFailed);
    }

    var callFailed = function(response) {
        console.log('Ugly error:');
        console.log(response);
    };

    var reservationsRetrieved = function(response) {
        var $reservations = response.result;
        if ($reservations && $reservations.length > 0) {
            var $id = APP.functions.getSessionUser().id;
            $reservations = $reservations.filter(function(reservation) {
                return reservation.iD_CLIENTE == $id && reservation.estadO_RESERVACION == 2;
            });
        };
        $user_reservations = $reservations;
        createReservationsTable();
    };

    var createReservationsTable = function() {
        var $htmlContent = '';
        
        if ($user_reservations && $user_reservations.length > 0) {
            console.log($user_reservations);
            $user_reservations.forEach(function(reservation) {
                console.log(reservation);
                $htmlContent += '<tr>';
                $htmlContent += '<td>'+reservation.iD_RESERVACION+'</td>';
                $htmlContent += '<td>'+$tipos_habitacion[reservation.tipO_HABITACION]+'</td>';
                $htmlContent += '<td>'+reservation.fechA_ENTRADA+'</td>';
                $htmlContent += '<td>'+reservation.fechA_SALIDA+'</td>';
                $htmlContent += '<td><input type="checkbox" name="pay-reservation-'+reservation.iD_RESERVACION+'" id="pay-reservation-'+reservation.iD_RESERVACION+'" /></td>';
                $htmlContent += '</tr>';
            });
        }
        else {
            $htmlContent += '<tr>';
            $htmlContent += '<td colspan="5">No tiene reservaciones pendientes de pago.</td>';
            $htmlContent += '</tr>';
            $('#cart-button-pay').attr('disabled', true);
        }

        $($cart_reservations_selector).html($htmlContent);
    };
    
    var init = function() {
        $user_reservations = [];
        loadReservations();
        bindButtons();
    };

    return {
        init: init
    };
}());

$(window).on('load', function() {
    APP.carrito.init();
});