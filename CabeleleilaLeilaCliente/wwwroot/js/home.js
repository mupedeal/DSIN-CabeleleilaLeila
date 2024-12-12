var showAgendamentoStep01 = function () {
    $('#btnAgendar').hide();
    $('#btnEntrar').prop('disabled', true);
    $('.loader-agendar').show();

    $.ajax({
        url: "/HomeAPI/GetServicos"
    }).done(function (data) {
        if (data == null) {
            alert('Nenhum serviço disponível no momento. Por favor tente novamente mais tarde!');
        } else {
            $.each(data, function (i, e) {
                let checkbox = `
                    <div class="form-check">
                      <input class="form-check-input" name="servicos" type="checkbox" value="${e.id}" id="servico${i}">
                      <label class="form-check-label" for="servico${i}">
                        ${e.nome}
                      </label>
                    </div>
                `;
                $('#listaServicos').append(checkbox);
            });

            $('.home-actions').hide();
            $('.agendamento-step-01').show();
        }
    }).fail(function (error) {
        alert(error.responseText);
    }).always(function () {
        $('.loader-agendar').hide();
        $('#btnAgendar').show();
        $('#btnEntrar').prop('disabled', false);        
    });
}

var showLoginStep01 = function () {
    $('.home-actions').hide();
    $('.login-step-01').show();
}

var enviarCodigo = function () {
    if ($('#clienteCpf').valid()) {
        $('#clienteCpf').prop('readonly', true);
        $('#btnEnviarCodigo').hide();
        $('.loader-enviar-codigo').show();

        $('.login-step-01').hide();
        $('.login-step-02').show();
    }
}

var entrarCodigo = function () {
    if ($('#clienteCodigoUsoUnico').valid()) {
        $('#clienteCodigoUsoUnico').prop('readonly', true);
        $('#btnEntrarCodigo').hide();
        $('.loader-entrar-codigo').show();
        setTimeout(() => {
            alert('Esta funcionalidade ainda não está disponível. Volte em breve!');
            $('#clienteCodigoUsoUnico').prop('readonly', false);
            $('.loader-entrar-codigo').hide();
            $('#btnEntrarCodigo').show();            
        }, 3000);
    }
}

var voltarParaHome = function () {
    window.location.reload();
}

var confirmarServicos = function () {
    if ($(`[name="servicos"]:checked`).length == 0) {
        alert('Selecione ao menos um serviço para continuar.');
    } else {
        $('.agendamento-step-01').hide();
        $('.agendamento-step-02').show();
    }
}

var voltarServicos = function () {
    $('.agendamento-step-02').hide();
    $('.agendamento-step-01').show();
}

var confirmarDataHora = function () {
    if ($('#dataHoraAgendamento').val() == '') {
        alert('Selecione uma data e hora válidas para continuar.');
    } else {
        $('.agendamento-step-02').hide();
        $('.agendamento-step-03').show();
    }
}

var voltarDataHora = function () {
    $('#agendamento-step-03, #agendamento-step-03-compl').hide();
    $('#clienteCpfAgendamento, #clienteNomeAgendamento, #clienteCelularAgendamento, #clienteEmailAgendamento').val('');
}

var confirmarCadastro = function () {
    if ($('.agendamento-step-03-compl').is(':visible')) {
        $('#clienteCpfAgendamento, #clienteNomeAgendamento, #clienteCelularAgendamento, #clienteEmailAgendamento').prop('disabled', true);
        $('#btnVoltarDataHora').prop('disabled', true);
        $('#btnConfirmarCadastro').hide();
        $('.loader-confirmar-cadastro').show();
        setTimeout(() => {
            alert('Esta funcionalidade ainda não está disponível. Volte em breve!');

            $('.loader-confirmar-cadastro').hide();
            $('#btnConfirmarCadastro').show();
            $('#btnVoltarDataHora').prop('disable', false);
            $('#clienteCpfAgendamento, #clienteNomeAgendamento, #clienteCelularAgendamento, #clienteEmailAgendamento').prop('disabled', false);
        }, 3000);
    } else {
        if ($('#clienteCpfAgendamento').valid()) {
            $('#clienteCpfAgendamento').prop('disabled', true);
            $('#btnVoltarDataHora').prop('disabled', true);
            $('#btnConfirmarCadastro').hide();
            $('.loader-confirmar-cadastro').show();

            setTimeout(() => {
                $('.agendamento-step-03-compl').show();

                $('.loader-confirmar-cadastro').hide();
                $('#btnConfirmarCadastro').show();
                $('#btnVoltarDataHora').prop('disable', false);
                $('#clienteCpfAgendamento').prop('disabled', false);
            }, 3000);
        }
    }
}

$(function () {
    $('#btnAgendar').on('click', showAgendamentoStep01);
    $('#btnEntrar').on('click', showLoginStep01);
    $('#btnEnviarCodigo').on('click', enviarCodigo);
    $('.login-btn-voltar').on('click', voltarParaHome);
    $('#btnEntrarCodigo').on('click', entrarCodigo);
    $('#btnConfirmarServicos').on('click', confirmarServicos);
    $('#btnVoltarServicos').on('click', voltarServicos);
    $('#btnConfirmarDataHora').on('click', confirmarDataHora);
    $('#btnVoltarDataHora').on('click', voltarDataHora);
    $('#btnConfirmarCadastro').on('click', confirmarCadastro);
});