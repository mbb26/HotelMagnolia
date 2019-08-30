var APP = window.APP || {};

APP.payment = (function() {

    var $api_favorite_cards = 'PaymentMethod/';
    var $api_reservation = 'Reservation/';
    var $cart_reservations_selector = '#cart-reservations';
    var $payment_method_form_selector = '#payment-method-form';
    var $reservation_payment_form_Selector = "#reservation-payment-form";
    var $view_favorite_cards_selector = "#view-favorite-cards";
    var $favorite_cards_selector = '#favorite-cards';
    var $favorite_cards;
    var $valid_cards = 'visa,mastercard';
    var $valid_cards_names = 'Visa, MasterCard';
    var $credit_card_name;
    var $valid_length;
    var $errors;

    var bindButtons = function() {

        $($view_favorite_cards_selector).on('click', function(e) {
            e.preventDefault();
            loadFavoriteCards();
        });

        $('#CardNumber').validateCreditCard(function(result) {
            var cards = $valid_cards.split(',');
            cards.forEach(function(card) {
                $('#CardNumber').removeClass(card);
            })
            $valid_length = result.length_valid;

            if (result.card_type && $valid_cards.indexOf(result.card_type.name) > -1) {                
                $('#CardNumber').addClass(result.card_type.name);
                $credit_card_name = result.card_type.name;
            }
            else {
                $credit_card_name = null;
            }
        });

        $($payment_method_form_selector).on('submit', function(e) {
            e.preventDefault();
            validatePaymentForm();
        });
    };

    var validatePaymentForm = function() {
        if ($('#use-favorite-new').prop('checked')) {
            var $valid = APP.functions.validateForm($($payment_method_form_selector));
            if ($valid) {
                $errors.length = 0;
                if (!$credit_card_name) {
                    $errors.push('<li>Solamente se permite utilizar tarjetas de los siguientes tipos: '+$valid_cards_names+'</li>');
                }
                if (!$valid_length) {
                    $errors.push('<li>La longitud del número de tarjeta no es válida para el tipo de tarjeta.</li>');
                }
                if (!validExpirationDate($('#ExpiredDate').val())) {
                    $errors.push('<li>Por favor ingrese la fecha de expiración en formato MM/AA.</li>');
                }
                if ($errors.length > 0) {
                    APP.functions.customAlert('Por favor revise los siguientes errores: <br/><ul>'+$errors.join('<br/>')+'</ul>', 'Error');
                }
                else {
                    if ($('#AgregarAFavoritas').prop('checked')) {
                        saveCard();
                    }
                    payAllReservations();
                }
            }
        }
        else {
            payAllReservations();
        }
    };

    var payAllReservations = function() {
        var $reservations = APP.functions.getReservations() || [];
        var $reservations_paid = [];
        $reservations.forEach(function(reservation) {
            console.log(reservation);
            reservation.estadO_RESERVACION = 1;
            payReservation(reservation);
            $reservations_paid.push('<li>'+reservation.iD_RESERVACION+'</li>');
        });
        if ($reservations_paid.length > 0) {
            APP.functions.customAlert('Las siguiente reservaciones se han pagado con éxito: <ul>'+$reservations_paid.join()+'</ul>', 'Reservación', 'carrito.html');
            APP.functions.removeReservations();
        }
    }

    var payReservation = function(reservation) {
        $('#estadO_RESERVACION').val(reservation.estadO_RESERVACION);
        $('#fechA_ENTRADA').val(reservation.fechA_ENTRADA);
        $('#fechA_SALIDA').val(reservation.fechA_SALIDA);
        $('#iD_CLIENTE').val(reservation.iD_CLIENTE);
        $('#iD_RESERVACION').val(reservation.iD_RESERVACION);
        $('#tipO_HABITACION').val(reservation.tipO_HABITACION);
        APP.functions.makeAPICall($api_reservation+'Update', 'POST', $($reservation_payment_form_Selector).serialize(), reservationPaid, callFailed);
    }

    var reservationPaid = function(response) {
        var $reservation = response.result;
        if ($reservation) {
            console.log('Reservation paid: ');
            console.log($reservation);
        };
    };

    var saveCard = function() {
        var $id = (Math.floor(Math.random()*1000000)+1);
        $('#id-payment-method').val($id);
        var $email = APP.functions.getSessionUser().email;
        $('#Email').val($email);
        APP.functions.makeAPICall($api_favorite_cards+'Create', 'POST', $($payment_method_form_selector).serialize(), cardSaved, callFailed);
    }

    var loadFavoriteCards = function() {
        APP.functions.makeAPICall($api_favorite_cards+'GetAll', 'GET', null, cardsRetrieved, callFailed);
    }

    var callFailed = function(response) {
        console.log('Ugly error:');
        console.log(response);
    };

    var cardsRetrieved = function(response) {
        var $cards = response.result;
        if ($cards && $cards.length > 0) {
            var $email = APP.functions.getSessionUser().email;
            $cards = $cards.filter(function(card) {
                return card.email == $email;
            });
        };
        $favorite_cards = $cards;
        createFavoriteCards();
    };

    var cardSaved = function(response) {
        var $card = response.result;
        if ($card) {
            console.log('Card saved: ');
            console.log($card);
        };
    };

    var createFavoriteCards = function() {
        var $htmlContent = '';

        $htmlContent += '<table align="justify-content-end,align-items-center">';
        $htmlContent += '<thead>';
        $htmlContent += '<tr>';
        $htmlContent += '<th>Numero de Tarjeta</th>';
        $htmlContent += '<th>Fecha de Vencimiento</th>';
        $htmlContent += '<th>CVV</th>';
        $htmlContent += '<th>Usar</th>';
        $htmlContent += '</tr>';
        $htmlContent += '</thead>';
        $htmlContent += '<tbody>';
        $htmlContent += '';
        
        if ($favorite_cards && $favorite_cards.length > 0) {

            $favorite_cards.forEach(function(card) {
                console.log(card);
                $htmlContent += '<tr>';
                $htmlContent += '<td>XXXX XXXX XXXX '+card.cardNumber.substr(-4)+'</td>';
                $htmlContent += '<td>'+card.expiredDate+'</td>';
                $htmlContent += '<td>XXX</td>';
                $htmlContent += '<td><input type="radio" name="useFavorite" id="use-favorite-'+card.id+'" value="'+card.id+'"></td>';
                $htmlContent += '</tr>';
            });
        }
        else {
            $htmlContent += '<tr>';
            $htmlContent += '<td colspan="4">No tiene tarjetas favoritas.</td>';
            $htmlContent += '</tr>';
        }

        $htmlContent += '</tbody>';
        $htmlContent += '</table>';

        $($favorite_cards_selector).html($htmlContent);
        bindFavoriteRadioButtons();
    }

    var bindFavoriteRadioButtons = function() {
        $('input[name="useFavorite"]').each(function() {
            $(this).on('click', function(e) {
                if ($(this).prop('checked')) {
                    $(this).prop('checked', true);
                    APP.functions.resetFormAlerts($($payment_method_form_selector));
                }
            });
        });
    };

    var validExpirationDate = function(d) {
        d = new String(d)
        var re1 = new RegExp("[0|1][0-9]\/[0-9]{2}")
        var re2 = new RegExp("^[1[3-9]]")
        var re3 = new RegExp("^00")
        return re1.test(d)&&(!re2.test(d))&&(!re3.test(d))                
   };
    
    var init = function() {
        $errors = [];
        $favorite_cards = [];
        bindButtons();
    };

    return {
        init: init
    };
}());

$(window).on('load', function() {
    APP.payment.init();
});