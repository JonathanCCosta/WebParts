$(document).ready(function () {
    $(".propriedadesTipo select").change(TrocaPropriedades);

    $("#ddlSPE").change(function () {
        var iselectedspe = $(this).val();
        FiltraDropDown(iselectedspe, "ddlEmpreendimento");
    });


    $("#ddlEmpreendimento").change(function () {
        var iselectedspe = $(this).val();
        FiltraDropDown(iselectedspe, "ddlPN");
        FiltraDropDown(iselectedspe, "ddlObra");
    });

    $("#btnUpload").click(function () {
        var retorno = ValidaPropriedades();
        if (!retorno)
            alert("As propriedades necessárias para o tipo de modelo selecionado não foram preenchidas corretamente.");
        else
            if (confirm("Deseja continuar o carregamento do modelo selecionado?"))
                return true;
            else
                return false;
    });
});

function FiltraDropDown(idddl, iddropdown) {
    if (idddl == 0)
        $(document.getElementById(iddropdown).options).each(function (index, option) {
            $(option).attr("style", "");
        });
    else
        $(document.getElementById(iddropdown).options).each(function (index, option) {
            if (option.attributes["lookup"] != undefined && option.attributes["lookup"].value != "0" && option.attributes["lookup"].value != idddl) {
                $(option).hide();
            }
            else
                $(option).attr("style", "")
        });

    document.getElementById(iddropdown).options[0].selected = true;
}

function TrocaPropriedades() {
    var tipo = $(".propriedadesTipo select").val();
    switch (tipo) {
        case '1': ConfiguraCamposAvancoFisico();
            break;
        case '2': ConfiguraCamposAvancoFinanceiro();
            break;
        case '3': ConfiguraCamposDRE();
            break;
        case '4': ConfiguraCamposBP();
            break;
        case "5": ConfiguraCamposFluxoCaixa();
            break;
        default: ConfiguraCamposDefault();
            break;

    }
}
function ConfiguraCamposDefault() {

    $(".propriedadesDados select").show();
    /*$("#ddlSPE").toggle(1000);
	$("#ddlEmpreendimento").toggle(1000);
	$("#ddlPN").toggle(1000);
	$("#ddlObra").toggle(1000);
	$("#ddlTipo").toggle(1000);
	$("#ddlPrevistoRevistoRealizado").toggle(1000);*/
}

function ConfiguraCamposAvancoFisico() {
    $(".propriedadesDados select").show();
    $("#ddlPN").toggle(1000);
    $("#ddlTipo").toggle(1000);
    $("#ddlPrevistoRevistoRealizado").toggle(1000);
}

function ConfiguraCamposAvancoFinanceiro() {
    $(".propriedadesDados select").show();
    $("#ddlPN").toggle(1000);
    $("#ddlObra").toggle(1000);
    $("#ddlTipo").toggle(1000);
    $("#ddlPrevistoRevistoRealizado").toggle(1000);
}

function ConfiguraCamposDRE() {
    $(".propriedadesDados select").show();
    $("#ddlObra").toggle(1000);
}

function ConfiguraCamposBP() {
    $(".propriedadesDados select").show();
    $("#ddlObra").toggle(1000);
}

function ConfiguraCamposFluxoCaixa() {
    $(".propriedadesDados select").show();
    $("#ddlObra").toggle(1000);
}

function ValidaPropriedades() {
    var tipo = $(".propriedadesTipo select").val();
    if (tipo == 0)
        return false;

    switch (tipo) {
        case '1': return ValidaCamposAvancoFisico();
        case '2': return ValidaCamposAvancoFinanceiro();
        case '3': return ValidaCamposDRE();
        case '4': return ValidaCamposBP();
        case "5": return ValidaCamposFluxoCaixa();
        default: return ValidaCamposDefault();
    }
}

function ValidaCamposAvancoFisico() {
    return ($("#ddlPN").val() != 0 && $("#ddlTipo").val() != 0 && $("#ddlPrevistoRevistoRealizado").val() != 0)
}
function ValidaCamposAvancoFinanceiro() {
    return ($("#ddlObra").val() != 0 && $("#ddlPN").val() != 0 && $("#ddlTipo").val() != 0 && $("#ddlPrevistoRevistoRealizado").val() != 0)
}
function ValidaCamposDRE() {
    return ($("#ddlPN").val() != 0 && $("#ddlTipo").val() != 0 && $("#ddlPrevistoRevistoRealizado").val() != 0)
}
function ValidaCamposBP() {
    return ($("#ddlPN").val() != 0 && $("#ddlTipo").val() != 0 && $("#ddlPrevistoRevistoRealizado").val() != 0)
}
function ValidaCamposFluxoCaixa() {
    return ($("#ddlPN").val() != 0 && $("#ddlTipo").val() != 0 && $("#ddlPrevistoRevistoRealizado").val() != 0)
}
function ValidaCamposDefault() {
    return ($("#ddlSPE").val() != 0 && $("#ddlEmpreendimento").val() != 0 && $("#ddlObra").val() != 0 && $("#ddlPN").val() != 0 && $("#ddlTipo").val() != 0 && $("#ddlPrevistoRevistoRealizado").val() != 0)
}