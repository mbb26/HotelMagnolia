var APP = window.APP || {};

APP.reservacion = (function() {

    var $api_reservation = 'Reservation/';
    var $api_room = 'Room/';
    var $reservation_form_selector = '#reservation-form';
    var $available_rooms = null;
    var $tipo_habitacion_selector = '#tipo_habitacion_search';
    var $available_rooms_selector = '#available-rooms';
    var $dateFormat = 'mm/dd/yy';
    var $from = null;
    var $to = null;
    var $cantidad_adultos_selector = '#cantidad_adultos';
    var $cantidad_ninos_selector = '#cantidad_ninos';
    var $cantidad_adultos;
    var $cantidad_ninos;
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
        console.log($available_rooms);
        createAvailableRoomsForm();
    };

    var createAvailableRoomsForm = function() {
        var $htmlContent = '';
        
        if ($available_rooms && $available_rooms.length > 0) {
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
        }
        else {
            $htmlContent += '<h5>No hay habitaciones disponibles con los parámetros requeridos</h5>';
        }

        $($available_rooms_selector).html($htmlContent);
        bindAvailableRooms();
    };

    var bindAvailableRooms = function() {
        $($available_rooms_selector).find('input[type="checkbox"]').each(function () {
            var $this = $(this);
        });
    };

    var setAdultos = function() {
        $cantidad_adultos = parseInt($($cantidad_adultos_selector).val()) || 0;
        console.log($cantidad_adultos);
    };

    var setNinos = function() {
        $cantidad_ninos = parseInt($($cantidad_ninos_selector).val()) || 0;
        console.log($cantidad_ninos);
    };

    var validateReservationForm = function() {
        
    };
    
    var init = function() {
        $cantidad_adultos = 0;
        $cantidad_ninos = 0;
        $errors = [];
        $from = $('#fecha_ingreso').datepicker({
            minDate: 0,
            changeMonth: true,
        });
        $to = $('#fecha_salida').datepicker({
            minDate: 1,
            changeMonth: true,
        });
        bindButtons();
    };

    return {
        init: init
    };
}());

$(window).on('load', function() {
    APP.reservacion.init();
});