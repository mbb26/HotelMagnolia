var Functions = (function() {
    var bindButtons = function() {
        $('input:checkbox').each(function() {
            var $action = $(this).attr('data-action');
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
    
    var resetEnabled = function(checkbox) {
        var $target = $(checkbox).attr('data-target');
        var $action = $(checkbox).attr('data-action');
        if ($action === 'toggleEnable') {
            $($target).each(function() {
                $(this).attr('disabled', !checkbox.checked);
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