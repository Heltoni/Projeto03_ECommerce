﻿function exibirValores() {
    //obtendo os valores dos campos de entrada
    var vCodigo = document.getElementById("codigo").value;
    var vDescricao = document.getElementById("descricao").value;
    var vPreco = document.getElementById("preco").value;

    //convertendo vPreco para double
    vPreco = parseFloat(vPreco);

    var erro1 = "", erro2 = "", erro3 = "";
    if (vPreco == "0") {
        erro1 = "Comparando texto: não pode ser zero";
    }
    if (vPreco == 0) {
        erro2 = "Comparando número: não pode ser zero";
    }
    //3 vezes o igual (=) é validação de tipos
    if (vPreco === 0) {
        erro3 = "Comparando tipo: não pode ser zero";
    }
    //gerando uma resposta
    //var resposta = "Código: " + vCodigo +
    //    "\nDescrição: " + vDescricao +
    //    "\nPreço: " + vPreco;

    //exibindo a resposta em uma caixa de mensagens
    //alert(resposta);


    var resposta = "Código: " + vCodigo +
        "<br/>Descrição: " + vDescricao +
        "<br/>Preço: " + vPreco +
        "<br/>Erro1: " + erro1 +
        "<br/>Erro2: " + erro2 +
        "<br/>Erro3: " + erro3 ;

    //exibindo a resposta na div
    //o html não entende o \n, porém isso tivemos que alterar a msg
    var vResultado = document.getElementById("resultado");
    vResultado.innerHTML = resposta;
}

var botao = document.getElementById("btnExibir");
botao.addEventListener("click", exibirValores);