var APP = window.APP || {};

APP.reservacion = (function() {

    var $api_reservation = 'Reservation/';
    var $api_room = 'Room/';
    var $reservation_form_selector = '#reservation-form';
    var $available_rooms = null;
    var $tipo_habitacion_selector = '#tipo_habitacion_search';
    var $available_rooms_selector = '#available-rooms';
    var $id_cliente_selector = '#iD_CLIENTE';
    var $dateFormat = 'mm/dd/yy';
    var $from = null;
    var $to = null;
    var $cantidad_adultos_selector = '#cantidad_adultos';
    var $cantidad_ninos_selector = '#cantidad_ninos';
    var $cantidad_adultos;
    var $cantidad_ninos;
    var $rooms_selected;
    var $rooms_needed;
    var $errors;

    var bindButtons = function() {        
        $('.check-availability').on('click', function(e) {
            e.preventDefault();
            APP.functions.makeAPICall($api_room+'GetAvailable', 'GET', null, alertAvailable, callFailed);
        });

        $from.on('change', function () {
            $to.datepicker('option', 'minDate', getDate($from));
        });

        $to.on('change', function () {
            $from.datepicker('option', 'maxDate', getDate($to));
        });

        $($cantidad_adultos_selector).on('change', setAdultos);
        $($cantidad_ninos_selector).on('change', setNinos);

        $($reservation_form_selector).on('submit', function(e) {
            e.preventDefault();
            validateReservationForm();
        });
    };
 
    var getDate = function( element ) {
      var date;
      try {
        date = $.datepicker.parseDate( $dateFormat, element.val() );
      } catch( error ) {
        date = null;
      }
      return date;
    };

    var callFailed = function(response) {
        console.log(response);
    };

    var alertAvailable = function(response) {
        if (response.result && response.result.length > 0) {
            var $tipo_habitacion = $($tipo_habitacion_selector).children("option:selected").val();
            $available_rooms = response.result.filter(function(room) {
                return room.tipO_HABITACION == parseInt($tipo_habitacion);
            });
        }
        // console.log($available_rooms);
        createAvailableRoomsForm();
    };

    var createAvailableRoomsForm = function() {
        var $htmlContent = '';
        
        if ($available_rooms && $available_rooms.length > 0) {
            $htmlContent += '<div class="table-wrapper-scroll-y my-custom-scrollbar">'
            $htmlContent += '<table class="table">';
            $htmlContent += '<thead>';
            $htmlContent += '<tr>';
            $htmlContent += '<th scope="col">Reservar</th>';
            $htmlContent += '<th scope="col">#</th>';
            $htmlContent += '<th scope="col">Nombre</th>';
            $htmlContent += '</tr>';
            $htmlContent += '</thead>';
            $htmlContent += '<tbody id="available-rooms-content">';

            $available_rooms.forEach(function(room) {
                $htmlContent += '<tr>';
                $htmlContent += '<td><input type="checkbox" name="'+room.iD_HABITACION+'" value="'+room.iD_HABITACION+'" id="'+room.iD_HABITACION+'"/></td>';
                $htmlContent += '<td><label for="'+room.iD_HABITACION+'">'+room.numero+'<label></td>';
                $htmlContent += '<td>'+room.nombre+'</td>';
                $htmlContent += '</tr>';
            });

            $htmlContent += '</tbody>';
            $htmlContent += '</table>';
            $htmlContent += '</div>';
        }
        else {
            $htmlContent += '<h5>No hay habitaciones disponibles con los parámetros requeridos</h5>';
        }

        $($available_rooms_selector).html($htmlContent);
        bindAvailableRooms();
    };

    var bindAvailableRooms = function() {
        $rooms_selected = 0;
        $($available_rooms_selector).find('input[type="checkbox"]').each(function () {
            var $this = $(this);
            $this.on('click', function() {
                toggleRoom(this.name, this.checked);
            });
        });
    };

    var toggleRoom = function(id, isChecked) {
        // console.log('id: '+id+', checked: '+isChecked);
        $available_rooms.forEach(function(room) {
            if (room.iD_HABITACION == id) {
                room.disponible = !isChecked;
            }
        });
        if (isChecked) {
            $rooms_selected += 1;
        }
        else {
            $rooms_selected -= 1;
        }
    }

    var setAdultos = function() {
        $cantidad_adultos = parseInt($($cantidad_adultos_selector).val()) || 0;
    };

    var setNinos = function() {
        $cantidad_ninos = parseInt($($cantidad_ninos_selector).val()) || 0;
    };

    var validateReservationForm = function() {
        var $valid = APP.functions.validateForm($($reservation_form_selector));
        if ($valid) {
            var $total_huespedes = $cantidad_adultos + $cantidad_ninos;
            $rooms_needed = Math.ceil($total_huespedes / 4.0);
            // console.log('rooms needed: '+$rooms_needed+', rooms selected: '+$rooms_selected);
            $valid = validateRoomsSelected();
            // console.log($errors);
            if (!$valid) {
                // console.log($errors);
                APP.functions.customAlert('Por favor revise los siguientes errores: <br/><ul>'+$errors.join('<br/>')+'</ul>', 'Error');
            }
            else {
                createReservacion();
            }
        }
    };

    var createReservacion = function() {
        APP.functions.makeAPICall($api_reservation+'Create', 'POST', $($reservation_form_selector).serialize(), reservationCreated, callFailed);
    };

    var reservationCreated = function(response) {
        var $reservation = response.result;
        if ($reservation) {
            console.log($reservation);
        }
        else {
            APP.functions.customAlert('Se ha producido un error al crear la reservación. Favor inténtelo de nuevo.', 'Error');
        }
    }

    var validateRoomsSelected = function() {
        $errors.length = 0;
        if ($rooms_selected < $rooms_needed) {
            $errors.push('<li>Necesita seleccionar al menos '+$rooms_needed+' habitaci'+($rooms_needed > 1 ? 'ones' : 'ón')+'.</li>');
        }
        if ($rooms_selected > $cantidad_adultos) {
            $errors.push('<li>Se le permite seleccionar máximo una habitación por cada adulto que ingrese.</li>');
        }
        return $errors.length === 0;
    };
    
    var init = function() {
        $cantidad_adultos = 0;
        $cantidad_ninos = 0;
        $rooms_selected = 0;
        $rooms_needed = 0;
        $errors = [];
        $from = $('#fecha_ingreso').datepicker({
            minDate: 0,
            changeMonth: true,
        });
        $to = $('#fecha_salida').datepicker({
            minDate: 1,
            changeMonth: true,
        });
        var $sessionUser = APP.functions.getSessionUser();
        if ($sessionUser) {
            $($id_cliente_selector).val($sessionUser.id);
        }
        bindButtons();
    };

    return {
        init: init
    };
}());

$(window).on('load', function() {
    APP.reservacion.init();
});