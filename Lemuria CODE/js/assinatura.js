//Jquery
$(document).ready(function(){

    //Busca para metros na query string 
    var urlParams = new URLSearchParams(window.location.search);
    var idSelecionado = urlParams.get('idPlano');
    console.log(idSelecionado   )


    //Carregando o Select (Dropdown) de planos

    //buscar planos na API mockada
    $.ajax({
        url: "https://lemuria.azurewebsites.net/api/plano",
        //url: 'https://636ef023bb9cf402c80c28c8.mockapi.io/plano',
        type: 'get',
        contentType: 'application/json',
        success: function (dados) {

            var selectPlanos = $('#plano');

            //forEach percorre cada item da lista
            dados.forEach(function(item) {
                selectPlanos.append('<option value="' + item.id + '">' + item.nome + '</option>');
            });

            //Seleciona no dropdown o plano passado pelo parametro
            selectPlanos.val(idSelecionado);
            selectPlanos.trigger("change");
            

        },
        error: function(erro){
            console.log(erro);
        }
    });

    //Envio de assinatura
    $('#btnAssinar').click(function(){

        var cliente = $('#cliente').val();
        var cpf = $('#cpf').val();
        var telefone = $('#telefone').val();
        var email = $('#email').val();
        var preco = $('#preco').val();
        var idPlano = $('#plano').val();

        if (cliente == '' || cpf == '' || telefone == '' || email == '' || preco == '' || idPlano == 0){
            alert('Todos os Campos são obrigatórios!!!')
            return;
        }
        else{
            var assinatura = new Object();
            assinatura.cliente = cliente;
            assinatura.cpf = cpf;
            assinatura.telefone = telefone;
            assinatura.email = email;
            assinatura.preco = parseFloat(preco);
            assinatura.idPlano = parseInt(idPlano);
        }
        //Envio para API (Metodo POST)
        $.ajax({    
            url: "https://lemuria.azurewebsites.net/api/Assinatura",
            type: 'post',
            contentType: 'application/json',
            data: JSON.stringify(assinatura),
            success: function(dados) {
                alert('Assinatura realizada com sucesso!');
                console.log('Deu certo!z');
                //se quiser, limpar os campos
            },
            error: function(erro){
                alert('Ocorreu um erro!');
            }
        });
        
    });

    //Ao mudar o plano
    $('#plano').change(function(){
        $.ajax({
            url: "https://lemuria.azurewebsites.net/api/plano/" + $('#plano').val(),
            //url: 'https://636ef023bb9cf402c80c28c8.mockapi.io/plano',
            type: 'get',
            contentType: 'application/json',
            success: function (dados) {
                $('#preco').val(dados.preco);
            },
            error: function(erro){
                console.log(erro);
            }
        });




    });


});