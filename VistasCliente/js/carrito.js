var APP = window.APP || {};

APP.carrito = (function() {

    $cart_reservations_selector = '#cart-reservations';

    var bindButtons = function() {
    };

    var createReservationsTable = function() {
        var $htmlContent = '';

        var $reservations = APP.functions.getReservations() || [];
        
        if ($reservations && $reservations.length > 0) {

            $reservations.forEach(function(reservation) {
                console.log(reservation);
                $htmlContent += '<tr>';
                $htmlContent += '<td>'+reservation.iD_RESERVACION+'</td>';
                $htmlContent += '<td>'+reservation.tipO_HABITACION+'</td>';
                $htmlContent += '<td>'+reservation.fechA_ENTRADA+'</td>';
                $htmlContent += '<td>'+reservation.fechA_SALIDA+'</td>';
                $htmlContent += '</tr>';
            });
        }
        else {
            $htmlContent += '<tr>';
            $htmlContent += '<td colspan="4">No tiene reservaciones disponibles</td>';
            $htmlContent += '</tr>';
        }

        $($cart_reservations_selector).html($htmlContent);
    };
    
    var init = function() {
        createReservationsTable();
        bindButtons();
    };

    return {
        init: init
    };
}());

$(window).on('load', function() {
    APP.carrito.init();
});