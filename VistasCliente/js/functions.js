var APP = window.APP || {};

APP.functions = (function() {

    var API_KEYS = {
        root: 'http://localhost:44364/API/',
        getAll: 'GetAll',
        getById: 'GetById/',
        create: 'Create',
        update: 'Update',
        delete: 'Delete'
    }

    var makeAPICall = function(apiName, apiCall, method, params, onSuccess, onError) {
        $.ajax({
            type: method,
            url: API_KEYS.root+apiName+'/'+API_KEYS[apiCall],
            data: params,
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
    } 

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

    var getAPIKey = function(key) {
        return API_KEYS[key];
    }

    var init = function() {
        bindButtons();
    };

    return {
        init: init,
        makeAPICall: makeAPICall
    }
}());

window.onload = function() {
    APP.functions.init();
}