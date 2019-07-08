function Save() {

    var PriceValues = new Object();
 
        PriceValues.id_consecutivo = "1";
        PriceValues.tipo = $("#ComboBoxTipo").val();
        PriceValues.precio = $("#InputPrecio").val();


        $.ajax({
            type: "post",
            data: JSON.stringify(PriceValues),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: "/Admin/SavePrice",
            success: function (data) {
                alert("OK");
            }
    });

  
}

function Update() {

    var PriceValues = new Object();

    PriceValues.id_consecutivo = $("#InputConsecutive").val();;
    PriceValues.tipo = $("#ComboBoxType").val();
    PriceValues.precio = $("#InputPrice").val();


    $.ajax({
        type: "post",
        data: JSON.stringify(PriceValues),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        url: "/Admin/UpdatePrice",
        success: function (data) {
            alert("OK");
        }
    });


}


