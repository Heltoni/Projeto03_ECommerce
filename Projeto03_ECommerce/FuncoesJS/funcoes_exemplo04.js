$(document).ready(function () {//ESTE COMANDO AGUARDA TODO O DOCUMENTO SER CARREGADO
    //definir uma lista de cursos
    var cursos = ["Asp.Net", "Culinária", "Paraquedismo", "C#"]; //variavel do tipo array
    //var cursos = {}; //variavel que recebera um objeto javascript

    //percorrendo o array: forma 01    
    //for (var i = 0; i < cursos.length; i++) {
    //    $("#lista")
    //        .append("<option value=" + i + ">" + cursos[i] + "</option>");
    //}

    //percorrendo o array: forma 02    
    $.each(cursos, function (indice, elemento) {
        //AQUI CRIAMOS UM ELEMENTO OPTION COM PROPRIEDADES VALUE E TEXT
        //debugger;
        $("#lista").append($("<option>", {            
            value: indice,
            text: elemento
        }));
    });

    $("#btnEnviar").click(function () {
        //obtendo os valores dos campos de entrada com o jquery
        var nome = $("#nome").val();
        var idade = $("#idade").val();

        var resultado;

        //removendo as classes "ok" e "erro"
        if ($("#resposta").hasClass("erro")) {
            $("#resposta").removeClass("erro");
        }
        if ($("#resposta").hasClass("ok")) {
            $("#resposta").removeClass("ok");
        }

        if (idade == "") {
            resultado = "Idade inválida";
            $("#resposta").addClass("erro");
        }
        else {
            if (idade < 18) {
                resultado = nome + " é menor de idade!";                
            }
            else {
                resultado = nome + " é maior de idade!";                
            }
            $("#resposta").addClass("ok");
        }

        $("#resposta").hide();
        $("#resposta").html(resultado);
        $("#resposta").fadeIn(3000);
        $("#resposta").delay(2000);
        $("#resposta").fadeOut(3000);

    });

});

//Este simbolo $ é utilizado para executar as funções do JQuery
//Exemplo:
//JQuery("#btnEnviar").click(function () {
//    alert("Mensagem");
//});
//$("#btnEnviar").click(function () {
//    alert("Mensagem");
//});