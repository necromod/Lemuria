//Jquery
$(document).ready(function(){

    //buscar planos na API mockada
    $.ajax({
        url: 'https://lemuria.azurewebsites.net/api/plano',
        //url: 'https://636ef023bb9cf402c80c28c8.mockapi.io/plano',
        type: 'get',
        contentType: 'application/json',
        success: function (dados) {

            var planos = $('.plans-container');

            //forEach percorre cada item da lista
            dados.forEach(function(item) {
                
                if (item.recomendado == true) {
                    var destaque = 'recommended';
                }else{
                    var destaque = '';
                }

                var plano = '';
                plano += ' <div class="plan-card">';
                plano += '      <ul>';
                plano += '          <li class="plan-price '+ destaque + '">US$ ' + item.preco + '</li>';
                plano += '          <li class="plan-name">' + item.nome + '</li>';
                plano += '          <li>' + item.armazenamento + ' GB of space in disk</li>';
                plano += '          <li>' + item.subdominios + ' Sub-domains</li>';
                plano += '          <li>' + item.emails + ' Email accounts</li>';
                plano += '          <li>C-panel</li>';
                plano += '          <li><a class="default-btn" href="assinatura.html?idPlano=' + item.id + '" >Select</a></li>';
                plano += '      </ul>';
                plano += ' </div>';

                planos.append(plano)

            });

        },
        error: function(erro){
            console.log(erro);
        }
    });


    // Envio do email
    $('#btnEnviar').click(function(){

        var nome = $('#name').val();
        var email = $('#email').val();
        var mensagem = $('#message').val();

        if (nome == '' || email == '' || mensagem == ''){
            alert('Todos os campos são obrigatórios!!');
            return;
        }
        else{
            var msg = new Object();
            msg.Nome = nome;
            msg.Email = email;
            msg.Mensagem = mensagem;
        }
        //Envio para API (Método POST)
        $.ajax ({
            url: 'https://lemuria.azurewebsites.net/api/email',
            type: 'post',
            contentType: 'application/json',
            //dataType: 'json',
            data: JSON.stringify(msg),
            success: function (dados) {
                alert('Email enviado com sucesso!');
                $('#name').val('');
                $('#email').val('');
                $('#message').val('');
            
            },
            error: function(erro){
                alert('erro ao enviar e-mail!');
            }
        })

    })
});

