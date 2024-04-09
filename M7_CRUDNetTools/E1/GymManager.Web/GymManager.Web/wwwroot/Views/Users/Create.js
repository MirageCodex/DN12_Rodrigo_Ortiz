jQuery(function () {
    jQuery.validator.addMethod('confirmpassword', function (value, element, params) {
        return value == jQuery("#Password").val();
    });
    jQuery.validator.unobtrusive.adapters.add('confirmpassword', function (options) {
        var element = jQuery(options.form).find('#confirm_password')[0];

        options.rules['confirmpassword'] = [element];
        options.messages['confirmpassword'] = options.message;
    });
});
