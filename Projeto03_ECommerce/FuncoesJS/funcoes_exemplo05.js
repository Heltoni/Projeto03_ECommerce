$(document).ready(function () {
    //Array de Estados (Com objetos)
    var estados = [
        { "id": 1, "estado": "SP" },
        { "id": 2, "estado": "RJ" },
        { "id": 3, "estado": "MG" },
        { "id": 4, "estado": "BA" }
    ];

    //Array de Cidades (Com objetos)
    var cidades = [
        { id: 1, idestado: 1, cidade: "Campinas" },
        { id: 2, idestado: 1, cidade: "Sorocaba" },
        { id: 3, idestado: 2, cidade: "Niteroi" },
        { id: 4, idestado: 2, cidade: "Cabo Frio" },
        { id: 5, idestado: 2, cidade: "Angra" },
        { id: 6, idestado: 3, cidade: "Belo Horizonte" },
        { id: 7, idestado: 3, cidade: "Betim" },
        { id: 8, idestado: 4, cidade: "Extrema" },
        { id: 9, idestado: 4, cidade: "Salvador" },
        { id: 10, idestado: 4, cidade: "Porto Seguro" }
    ];

    //listando os estados na tela
    $.each(estados, function (indice, item) {
        $("#estado").append($("<option>", {
            value: item.id,
            text: item.estado
        }));
    });

    //listando as cidades
    $("#estado").change(function () {
        var idestado = $(this).val();

        //função grep já retorna a coleção filtradas
        var cidadesFiltradas = $.grep(cidades, function (elemento) {
            return elemento.id == idestado;
        });

        $("#cidade").html("<option>Selecione a Cidade</option>");
        $.each(cidadesFiltradas, function (indice, item) {
            $("#cidade").append($("<option>", {
                value: item.id,
                text: item.cidade
            }));
        });

    });
})