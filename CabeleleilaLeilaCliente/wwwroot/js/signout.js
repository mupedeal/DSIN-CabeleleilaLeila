var updateMask = function(event) {
    var $element = $('#' + this.id);
    $(this).off('blur');
    $element.unmask();
    if (this.value.replace(/\D/g, '').length > 10) {
        $element.mask("(00) 00000-0000");
    } else {
        $element.mask("(00) 0000-00009");
    }
    $(this).on('blur', updateMask);
}

$(function () {
    $('.fone').each(function (i, el) {
        $('#' + el.id).mask("(00) 00000-0000");
    });
    $('.cpf').mask('000.000.000-00');
    $('.codigo-uso-unico').mask('000000');

    $('.fone').on('blur', updateMask);

    $.extend(jQuery.validator.messages, {
        required: "Este campo é obrigatório.",
        remote: "Please fix this field.",
        email: "Por favor informe um e-mail válido.",
        url: "Please enter a valid URL.",
        date: "Please enter a valid date.",
        dateISO: "Please enter a valid date (ISO).",
        number: "Por favor digite apenas números.",
        digits: "Please enter only digits.",
        creditcard: "Please enter a valid credit card number.",
        equalTo: "Please enter the same value again.",
        accept: "Please enter a value with a valid extension.",
        maxlength: jQuery.validator.format("Por favor não digite mais que {0} caracteres."),
        minlength: jQuery.validator.format("Por favor digite ao menos {0} caracteres."),
        rangelength: jQuery.validator.format("Please enter a value between {0} and {1} characters long."),
        range: jQuery.validator.format("Please enter a value between {0} and {1}."),
        max: jQuery.validator.format("Please enter a value less than or equal to {0}."),
        min: jQuery.validator.format("Please enter a value greater than or equal to {0}.")
    });

    $.validator.addMethod("cpf", function (value, element) {
        value = jQuery.trim(value);

        value = value.replace('.', '');
        value = value.replace('.', '');
        cpf = value.replace('-', '');
        while (cpf.length < 11) cpf = "0" + cpf;
        var expReg = /^0+$|^1+$|^2+$|^3+$|^4+$|^5+$|^6+$|^7+$|^8+$|^9+$/;
        var a = [];
        var b = new Number;
        var c = 11;
        for (i = 0; i < 11; i++) {
            a[i] = cpf.charAt(i);
            if (i < 9) b += (a[i] * --c);
        }
        if ((x = b % 11) < 2) { a[9] = 0 } else { a[9] = 11 - x }
        b = 0;
        c = 11;
        for (y = 0; y < 10; y++) b += (a[y] * c--);
        if ((x = b % 11) < 2) { a[10] = 0; } else { a[10] = 11 - x; }

        var retorno = true;
        if ((cpf.charAt(9) != a[9]) || (cpf.charAt(10) != a[10]) || cpf.match(expReg)) retorno = false;

        return this.optional(element) || retorno;

    }, "Informe um CPF válido");
});