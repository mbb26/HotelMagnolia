var Functions = (function() {
    var bindButtons = function() {
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
        $('form').on('submit', function (e, options) {
            options = options || {};
            if (!options.validated) {
                e.preventDefault();
                validateForm(this, e);
            }
        });
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

    var validateForm = function (form, e) {
        var $form = $(form);
        var $valid = true;
        $form.find('[data-function="noBlank"]').each(function () {
            $valid = validateNoBlank(this) && $valid;
        });
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
    }
    
    var resetEnabled = function(checkbox) {
        var $target = $(checkbox).attr('data-target');
        var $action = $(checkbox).attr('data-function');
        if ($action === 'toggleEnable') {
            $($target).each(function() {
                $(this).attr('disabled', !checkbox.checked);
                validateNoBlank(this);
            });
        }
    }

    var init = function() {
        bindButtons();
    };

    return {
        init: init
    }
}());

window.onload = function() {
    Functions.init();
}