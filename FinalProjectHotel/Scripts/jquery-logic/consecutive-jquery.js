$(document).ready(function () {


});

function Save() {

    var ValoresConsecutivo = new Object();
    if ($("#InputPrefijo").val() == "" || $("#InputRangoInicial").val() == "" || $("#InputRangoFinal").val() == "") {
        ValoresConsecutivo.id_consecutivo = $("#InputConsecutivo").val();
        ValoresConsecutivo.descripcion = $("#ComboBoxDescripcion").val();
        ValoresConsecutivo.prefijo = " ";
        ValoresConsecutivo.rango_inicial = "0";
        ValoresConsecutivo.rango_final = "0";
    } else {
        ValoresConsecutivo.id_consecutivo = $("#InputConsecutivo").val();
        ValoresConsecutivo.descripcion = $("#ComboBoxDescripcion").val();
        ValoresConsecutivo.prefijo = $("#InputPrefijo").val();
        ValoresConsecutivo.rango_inicial = $("#InputRangoInicial").val();
        ValoresConsecutivo.rango_final = $("#InputRangoFinal").val();
    } 

        $.ajax({
            type: "post",
            data: JSON.stringify(ValoresConsecutivo),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: "/Admin/SaveConsecutive",
            success: function () {
                alert("OK");
            }
    });
}

function Update() {

    var ValoresConsecutivo = new Object();
    if ($("#InputPrefijo").val() == "" || $("#InputRangoInicial").val() == "" || $("#InputRangoFinal").val() == "") {

        ValoresConsecutivo.codigo = $("#InputCode").val(); 
        ValoresConsecutivo.id_consecutivo = $("#InputConsecutivo").val(); 
        ValoresConsecutivo.descripcion = $("#ComboBoxDescripcion").val();
        ValoresConsecutivo.prefijo = " ";
        ValoresConsecutivo.rango_inicial = "0";
        ValoresConsecutivo.rango_final = "0";
    } else {

        ValoresConsecutivo.codigo = $("#InputCode").val(); 
        ValoresConsecutivo.id_consecutivo = $("#InputConsecutivo").val();
        ValoresConsecutivo.descripcion = $("#ComboBoxDescripcion").val();
        ValoresConsecutivo.prefijo = $("#InputPrefijo").val();
        ValoresConsecutivo.rango_inicial = $("#InputRangoInicial").val();
        ValoresConsecutivo.rango_final = $("#InputRangoFinal").val();
    }


    $.ajax({
        type: "post",
        data: JSON.stringify(ValoresConsecutivo),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        url: "/Admin/UpdateConsecutive",
        success: function () {
            alert("OK");
        }
    });


}

function getval(combobox) {
    if ($("#HavePrefix").is(':checked')) {
        if (combobox.value == "Habitaciones") {
            $("#InputPrefijo").val("HAB");
        }
        if (combobox.value == "Actividades") {
            $("#InputPrefijo").val("ACV");
        }
        if (combobox.value == "Precios") {
            $("#InputPrefijo").val("PRE");
        }
        if (combobox.value == "Activos") {
            $("#InputPrefijo").val("ACT");
        }
        if (combobox.value == "Reservaciones") {
            $("#InputPrefijo").val("RES");
        }
        if (combobox.value == "Clientes") {
            $("#InputPrefijo").val("CLI");
        }
        if (combobox.value == "Bitácora") {
            $("#InputPrefijo").val("BIT");
        }
    } else {
        $("#InputPrefijo").val("");
    }
  
}


$('#HavePrefix').change(function () {
    if ($("#HavePrefix").is(':checked')) {
        $("#InputPrefijo").prop('disabled', false);

    } else {
        $("#InputPrefijo").val("");
        $("#InputPrefijo").prop('disabled', true);
    }
});

$('#HaveRange').change(function () {
    if ($("#HaveRange").is(':checked')) {
        $("#InputRangoInicial").prop('disabled', false);
        $("#InputRangoFinal").prop('disabled', false);
    } else {
        $("#InputRangoInicial").prop('disabled', true);
        $("#InputRangoFinal").prop('disabled', true);
    }
});


